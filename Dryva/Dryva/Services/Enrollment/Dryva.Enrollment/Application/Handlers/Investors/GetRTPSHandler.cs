using AutoMapper;
using Dryva.Enrollment.Application.Queries;
using Dryva.Enrollment.DTOs.Investor;
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
    public class GetRTPSHandler : IRequestHandler<GetRTPSQuery, IEnumerable<InvestorDTO>>
    {
        private readonly IRTPSQueryRepository _repository;
        private readonly ILogger<GetRTPSHandler> _logger;

        public GetRTPSHandler(IRTPSQueryRepository repository, ILogger<GetRTPSHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<InvestorDTO>> Handle(GetRTPSQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetRTPS handler");
            return await _repository.GetRTPs();
        }
    }
}
