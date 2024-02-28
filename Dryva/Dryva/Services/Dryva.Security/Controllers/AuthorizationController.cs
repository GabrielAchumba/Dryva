using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Dryva.Security.DTOs;
using Dryva.Security.Models;
using Dryva.Security.Repositories.Queries;
using Dryva.Utilities.Security;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Dryva.Security.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorizationController : ControllerBase
    {
        private readonly IDeviceQueryRepository queryRepository;
        private readonly IMapper mapper;
        private readonly UserManager<AppUser> userManager;
        private readonly RoleManager<AppRole> roleManager;

        public AuthorizationController(IDeviceQueryRepository queryRepository, IMapper mapper,
            UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            this.queryRepository = queryRepository;
            this.mapper = mapper;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        [HttpPost]
        [Route("LoginDevice")]
        public async Task<IActionResult> Login([FromBody] DeviceAccountDTO accountDTO)
        {
            var device = await queryRepository.GetDevice(accountDTO.Terminal);
            var loginDTO = new LoginDTO<DeviceAccountDTO>();

            if (device != null && device.SerialNumber == accountDTO.SerialNumber)
            {
                accountDTO.Id = device.Id;
                loginDTO.Authenticated = true;
                loginDTO.Instance = accountDTO;
                loginDTO.Token = TokenManagement.CreateToken(device.Id, accountDTO.Name,
                    accountDTO.SerialNumber, accountDTO.Terminal, accountDTO.CompanyName);

                return Ok(loginDTO);
            }

            loginDTO.Successful = false;
            return BadRequest(loginDTO);
        }

        [HttpPost]
        [Route("LoginUser")]
        public async Task<IActionResult> Login([FromBody] CredentialDTO credentialDTO)
        {
            var user = await userManager.FindByNameAsync(credentialDTO.Email);
            var loginDTO = new LoginDTO<UserAccountDTO>();

            if (user != null)
            {
                var isValid = await userManager.CheckPasswordAsync(user, credentialDTO.Password);

                if (isValid)
                {
                    var userId = Guid.Parse(user.Id);
                    var companyName = user.CompanyName ?? "";
                    loginDTO = new LoginDTO<UserAccountDTO>
                    {
                        Authenticated = true,
                        Instance = new UserAccountDTO
                        {
                            Id = userId,
                            CompanyName = user.CompanyName,
                            Email = user.Email,
                            FirstName = user.FirstName,
                            LastName = user.LastName
                        },
                        Successful = true,
                        Token = TokenManagement.CreateToken(userId, user.FirstName, user.LastName, user.Email, companyName)
                    };
                }
            }

            return BadRequest(loginDTO);
        }

        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO userDTO)
        {
            if (userDTO.Id == Guid.Empty)
                userDTO.Id = Guid.NewGuid();

            var user = mapper.Map<AppUser>(userDTO);
            user.UserName = user.Email;

            var result = await userManager.CreateAsync(user, userDTO.Password);

            if (!result.Succeeded)
                return BadRequest(userDTO);

            result = await userManager.AddToRoleAsync(user, "Guest");

            if (!result.Succeeded)
                return BadRequest(userDTO);

            return Ok(userDTO);
        }
    }
}
