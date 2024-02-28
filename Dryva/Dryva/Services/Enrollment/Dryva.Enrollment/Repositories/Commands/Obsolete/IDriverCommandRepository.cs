using Dryva.Enrollment.DTOs.Driver;
using System;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Repositories.Commands
{
    public interface IDriverCommandRepository
    {
        Task<int> Delete(Guid id);
        Task<int> Insert(DriverRegistrationDTO dtoModel);
        Task<int> Update(DriverBioDataDTO dtoModel);
        Task<int> Update(DriverContactDTO dtoModel);
        Task<int> Update(DriverOwnerNOKDTO dtoModel);
        Task<int> Update(DriverPersonalDataDTO dtoModel);
        Task<int> Update(DriverRegistrationDTO dtoModel);
        Task<int> Update(DriverVehicleDTO dtoModel);
    }
}