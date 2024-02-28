using Dryva.Enrollment.DTOs.Investor;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Queries
{
    public interface IRTPSQueryRepository
    {
        Task<IEnumerable<InvestorDTO>> GetRTPs(int pageIndex = 1, int pageSize = 100);
        Task<InvestorDTO> GetRTPSById(Guid id);
    }
}