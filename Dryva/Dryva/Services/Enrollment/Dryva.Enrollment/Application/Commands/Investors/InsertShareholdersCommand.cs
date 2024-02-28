using Dryva.Enrollment.DTOs.Investor;
using MediatR;

namespace Dryva.Enrollment.Application.Commands
{
    public class InsertShareholdersCommand : IRequest<InvestorDTO>
    {
        public NewInvestorDTO Investor { get; }

        public InsertShareholdersCommand(NewInvestorDTO model)
        {
            Investor = model;
        }
    }
}
