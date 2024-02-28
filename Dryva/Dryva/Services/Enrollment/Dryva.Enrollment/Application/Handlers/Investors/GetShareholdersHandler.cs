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
    public class GetShareholdersHandler : IRequestHandler<GetShareholdersQuery, IEnumerable<InvestorDTO>>
    {
        private readonly IShareholderQueryRepository _repository;
        private readonly ILogger<GetShareholdersHandler> _logger;

        public GetShareholdersHandler(IShareholderQueryRepository repository, ILogger<GetShareholdersHandler> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<IEnumerable<InvestorDTO>> Handle(GetShareholdersQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called into GetShareholders handler");
            return await _repository.GetShareHolders();
        }
    }
}
