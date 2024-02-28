using CustomerApp.DTOs.Customer;
using CustomerApp.DTOs.Device;
using CustomerApp.DTOs.Driver;
using CustomerApp.DTOs.Financial;
using CustomerApp.DTOs.MapsDTO;
using CustomerApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Services
{
    public interface ICustomerService
    {
        Task<EnvelopeData<RegistrationDTO>> GetRegistrationByPhoneNumberAsync(string phoneNumber);
        Task<EnvelopeData<IEnumerable<CustomerDetailDTO>>> GetCustomersAsync();
        Task<EnvelopeData<CustomerDataDTO>> GetCustomerByIdAsync(Guid id);
        Task<EnvelopeData<CustomerDataDTO>> GetCustomerByPhoneNumberAsync(string phoneNumber);
        Task<EnvelopeData<RegistrationDTO>> SaveRegistrationAsync(RegistrationDTO item);
        Task<EnvelopeData<PersonalDataDTO>> UpdateCustomerAsync(PersonalDataDTO item);
        Task<EnvelopeData<ContactDataDTO>> UpdateCustomerAsync(ContactDataDTO item);
        Task<EnvelopeData<BioDataDTO>> UpdateCustomerAsync(BioDataDTO item);
        Task<EnvelopeData<CSNDTO>> UpdateCustomerAsync(CSNDTO item);


        Task<int> SaveCustomerDetail_Local(CustomerInfo item);
        CustomerInfo GetCustomerDetail_Local();
    }
}
