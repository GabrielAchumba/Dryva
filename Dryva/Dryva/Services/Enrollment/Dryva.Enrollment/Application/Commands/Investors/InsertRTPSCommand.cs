using Dryva.Enrollment.DTOs.Investor;
using MediatR;

namespace Dryva.Enrollment.Application.Commands
{
    public class InsertRTPSCommand : IRequest<InvestorDTO>
    {
        public NewInvestorDTO Investor { get; }

        public InsertRTPSCommand(NewInvestorDTO model)
        {
            Investor = model;
        }
    }
}
