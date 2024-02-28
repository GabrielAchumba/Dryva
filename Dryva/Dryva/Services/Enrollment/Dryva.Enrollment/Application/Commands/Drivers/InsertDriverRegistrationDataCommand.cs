using Dryva.Enrollment.DTOs.Driver;
using MediatR;

namespace Dryva.Enrollment.Application.Handlers
{
    public class InsertDriverRegistrationDataCommand : IRequest<DriverRegistrationDTO>
    {
        public NewDriverRegistrationDTO Driver { get; }

        public InsertDriverRegistrationDataCommand(NewDriverRegistrationDTO model)
        {
            Driver = model;
        }
    }
}
