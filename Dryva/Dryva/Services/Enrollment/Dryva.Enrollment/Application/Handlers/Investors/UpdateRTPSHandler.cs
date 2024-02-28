using AutoMapper;
using Dryva.Enrollment.Application.Commands;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.Investor;
using Dryva.Enrollment.Models;
using Dryva.Enrollment.Repositories.Commands;
using Dryva.Enrollment.Repositories.Queries;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Handlers
{
    public class UpdateRTPSHandler : IRequestHandler<UpdateRTPSCommand, InvestorDTO>
    {
        private readonly EnrollmentDbContext _context;
        private readonly ILogger<UpdateRTPSHandler> _logger;
        private IMapper _mapper;

        public UpdateRTPSHandler(
            EnrollmentDbContext context,
            ILogger<UpdateRTPSHandler> logger,
            IMapper mapper)
        {
            _context = context;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<InvestorDTO> Handle(UpdateRTPSCommand request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into UpdateRTPS handler");

            var model = _context.RTPs.SingleOrDefault(x => x.Id == request.Id);
            if (model == null)
                throw new KeyNotFoundException("Id not found!");

            _mapper.Map(request.Investor, model);
            _context.RTPs.Update(model);
            await _context.SaveChangesAsync(cancellationToken);

            return _mapper.Map<InvestorDTO>(model);
        }
    }
}
