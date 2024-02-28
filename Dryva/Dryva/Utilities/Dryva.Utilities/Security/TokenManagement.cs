using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dryva.Utilities.Security
{
	/// <summary>
	/// Represents a TokenManagement class.
	/// </summary>
	public static class TokenManagement
	{
		private static string key = "Dryva.Security.TokenManagement";

		public static string Issuer => "https://dryva.microservices.com";
		public static SecurityKey SigningKey => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

		/// <summary>
		/// Creates the token for vendor terminal and bus validator.
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <param name="name">The device name.</param>
		/// <param name="serialNumber">The device serial number.</param>
		/// <param name="terminalNumber">The device terminal number.</param>
		/// <param name="companyName">The name of the company that owns the device.</param>
		/// <returns>System.String.</returns>
		public static string CreateToken(Guid userId, string name, string serialNumber, int terminalNumber, string companyName)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.SerialNumber, serialNumber),
				new Claim(ClaimTypes.NameIdentifier, terminalNumber.ToString()),
				new Claim(ClaimTypes.GivenName, name),
				new Claim(ClaimTypes.Name, companyName),
				new Claim(ClaimTypes.PrimarySid, userId.ToString())
			};
			return GenerateToken(claims);
		}
		/// <summary>
		/// Creates the token for platform users.
		/// </summary>
		/// <param name="userId">The user identifier.</param>
		/// <param name="firstName">The first name.</param>
		/// <param name="lastName">The last name.</param>
		/// <param name="emailAddress">The email address.</param>
		/// <param name="companyName">The name of the company.</param>
		/// <returns>System.String.</returns>
		public static string CreateToken(Guid userId, string firstName, string lastName, string emailAddress, string companyName)
		{
			List<Claim> claims = new List<Claim>
			{
				new Claim(ClaimTypes.Email, emailAddress),
				new Claim(ClaimTypes.NameIdentifier, lastName),
				new Claim(ClaimTypes.GivenName, firstName),
				new Claim(ClaimTypes.Name, companyName),
				new Claim(ClaimTypes.PrimarySid, userId.ToString())
			};
			return GenerateToken(claims);
		}
		/// <summary>Gets the principal from the specified token.</summary>
		/// <param name="token">The token.</param>
		/// <returns>ClaimsPrincipal.</returns>
		public static ClaimsPrincipal GetPrincipal(string token)
		{
			try
			{
				JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
				JwtSecurityToken jwtToken = (JwtSecurityToken)tokenHandler.ReadToken(token);

				if (jwtToken == null)
					return null;

				TokenValidationParameters parameters = new TokenValidationParameters()
				{
					ValidateIssuer = false,
					ValidateAudience = false,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					RequireExpirationTime = true,
					ValidIssuer = Issuer,
					ValidAudience = Issuer,
					IssuerSigningKey = SigningKey
				};

				SecurityToken securityToken;
				ClaimsPrincipal principal = tokenHandler.ValidateToken(token, parameters, out securityToken);
				return principal;
			}
			catch
			{
				return null;
			}
		}
		/// <summary>
		/// Generates the token.
		/// </summary>
		/// <param name="claims">The claims.</param>
		/// <returns>System.String.</returns>
		private static string GenerateToken(List<Claim> claims)
		{
			var signInCredentials = new SigningCredentials(SigningKey, SecurityAlgorithms.HmacSha512Signature);
			var tokenDescription = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(claims),
				NotBefore = DateTime.Now,
				Expires = DateTime.Now.AddMinutes(15),
				SigningCredentials = signInCredentials
			};

			var tokenHandler = new JwtSecurityTokenHandler();
			var token = tokenHandler.CreateToken(tokenDescription);
			string tokenString = tokenHandler.WriteToken(token);

			return tokenString;
		}
	}
}
