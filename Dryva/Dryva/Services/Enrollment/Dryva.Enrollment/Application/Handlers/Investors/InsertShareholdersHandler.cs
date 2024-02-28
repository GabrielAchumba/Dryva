using AutoMapper;
using Dryva.Enrollment.Application.Commands;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.Investor;
using Dryva.Enrollment.Models;
using Dryva.Enrollment.Repositories.Commands;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Handlers
{
    public class InsertShareholdersHandler : IRequestHandler<InsertShareholdersCommand, InvestorDTO>
    {
        private readonly EnrollmentDbContext _context;
        private readonly ILogger<InsertShareholdersHandler> _logger;
        private IMapper _mapper;

        public InsertShareholdersHandler(
            EnrollmentDbContext context,
            ILogger<InsertShareholdersHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<InvestorDTO> Handle(InsertShareholdersCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into InsertShareholders handler");
            var model = this._mapper.Map<Shareholder>(request.Investor);

            await _context.Shareholders.AddAsync(model);
            await _context.SaveChangesAsync(cancellationToken);

            return this._mapper.Map<InvestorDTO>(model);
        }
    }
}
