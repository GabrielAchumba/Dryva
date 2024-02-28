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
    public class GetRTPSByIdHandler : IRequestHandler<GetRTPSByIdQuery, InvestorDTO>
    {
        private readonly IRTPSQueryRepository _repository;
        private readonly ILogger<GetRTPSByIdHandler> _logger;
      
        public GetRTPSByIdHandler(IRTPSQueryRepository repository, ILogger<GetRTPSByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<InvestorDTO> Handle(GetRTPSByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetRTPSById handler");
            return await _repository.GetRTPSById(request.Id);
        }
    }
}
