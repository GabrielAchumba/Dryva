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
    public class GetShareholdersByIdHandler : IRequestHandler<GetShareholdersByIdQuery, InvestorDTO>
    {
        private readonly IShareholderQueryRepository _repository;
        private readonly ILogger<GetShareholdersByIdHandler> _logger;
      
        public GetShareholdersByIdHandler(IShareholderQueryRepository repository, ILogger<GetShareholdersByIdHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<InvestorDTO> Handle(GetShareholdersByIdQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetShareholdersById handler");
            return await _repository.GetShareHolderById(request.Id);
        }
    }
}
