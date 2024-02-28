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
    public class InsertRTPSHandler : IRequestHandler<InsertRTPSCommand, InvestorDTO>
    {
        private readonly EnrollmentDbContext _context;
        private readonly ILogger<InsertRTPSHandler> _logger;
        private IMapper _mapper;

        public InsertRTPSHandler(
            EnrollmentDbContext context,
            ILogger<InsertRTPSHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<InvestorDTO> Handle(InsertRTPSCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into InsertRTPS handler");
            var model = this._mapper.Map<RTPS>(request.Investor);

            await _context.RTPs.AddAsync(model);
            await _context.SaveChangesAsync(cancellationToken);

            return this._mapper.Map<InvestorDTO>(model);
        }
    }
}
