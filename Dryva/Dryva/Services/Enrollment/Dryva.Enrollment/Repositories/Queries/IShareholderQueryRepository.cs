using Dryva.Enrollment.DTOs.Investor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Queries
{
    public interface IShareholderQueryRepository
    {
        Task<InvestorDTO> GetShareHolderById(Guid id);
        Task<IEnumerable<InvestorDTO>> GetShareHolders(int pageIndex = 1, int pageSize = 100);
    }
}