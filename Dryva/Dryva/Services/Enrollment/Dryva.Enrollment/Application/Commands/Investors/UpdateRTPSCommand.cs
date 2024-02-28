using Dryva.Enrollment.DTOs.Investor;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Commands
{
    public class UpdateRTPSCommand : IRequest<InvestorDTO>
    {
        public NewInvestorDTO Investor { get; }
        public Guid Id { get; }

        public UpdateRTPSCommand(NewInvestorDTO model, Guid id)
        {
            Investor = model;
            Id = id;
        }
    }
}
