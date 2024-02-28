using CustomerApp.DTOs.Customer;
using CustomerApp.Models;
using CustomerApp.Services.ServiceUtils;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CustomerApp.Services
{
    internal class CustomerService : ICustomerService
    {
        private string ControllerName = "Customers";


        public async Task<EnvelopeData<RegistrationDTO>> GetRegistrationByPhoneNumberAsync(string phoneNumber)
        {
            return await APIHelper.GetData<RegistrationDTO>(ControllerName, $"RegistrationByPhoneNumber/{phoneNumber}");
        }
        public async Task<EnvelopeData<IEnumerable<CustomerDetailDTO>>> GetCustomersAsync()
        {
            return await APIHelper.GetData<IEnumerable<CustomerDetailDTO>>(ControllerName);
        }
        public async Task<EnvelopeData<CustomerDataDTO>> GetCustomerByIdAsync(Guid id)
        {
            return await APIHelper.GetData<CustomerDataDTO>(ControllerName, $"{id}");
        }
        public async Task<EnvelopeData<CustomerDataDTO>> GetCustomerByPhoneNumberAsync(string phoneNumber)
        {
            return await APIHelper.GetData<CustomerDataDTO>(ControllerName, $"CustomerByPhoneNumber/{phoneNumber}");
        }

        public async Task<EnvelopeData<RegistrationDTO>> SaveRegistrationAsync(RegistrationDTO item)
        {
            if (item == null)
                return new Envelope<RegistrationDTO>().ReportError("Object can not be null");
            //Envelope.ReportError("Object can not be null");

            var model = await this.GetRegistrationByPhoneNumberAsync(item.PhoneNumber);
            if (model.Data != null)
            {
                return await APIHelper.UpdateField<RegistrationDTO>(item, this.ControllerName, $"Registration/{ model.Data.Id}");
            }
            else
            {
                return await APIHelper.InsertData<RegistrationDTO>(item, ControllerName);
            }
        }
        public async Task<EnvelopeData<PersonalDataDTO>> UpdateCustomerAsync(PersonalDataDTO item)
        {
            return await APIHelper.UpdateField<PersonalDataDTO>(item, this.ControllerName, $"Personal/{item.Id}");
        }
        public async Task<EnvelopeData<BioDataDTO>> UpdateCustomerAsync(BioDataDTO item)
        {
            return await APIHelper.UpdateField<BioDataDTO>(item, this.ControllerName, $"BioData/{item.Id}");
        }
        public async Task<EnvelopeData<ContactDataDTO>> UpdateCustomerAsync(ContactDataDTO item)
        {
            return await APIHelper.UpdateField<ContactDataDTO>(item, this.ControllerName, $"Contact/{item.Id}");
        }
        public async Task<EnvelopeData<CSNDTO>> UpdateCustomerAsync(CSNDTO item)
        {
            return await APIHelper.UpdateField<CSNDTO>(item, this.ControllerName, $"CSN/{item.Id}");
        }


        public async Task<int> SaveCustomerDetail_Local(CustomerInfo item)
        {
            if (item == null)
                return -1;

            App.Current.Properties["Login"] = item;
            if (item.Id != Guid.Empty)
            {
                return await App.Services.LocalDb.UpdateAsync(item);
            }
            else
            {
                item.Id = Guid.NewGuid();
                return await App.Services.LocalDb.InsertAsync(item);
            }
        }

        public CustomerInfo GetCustomerDetail_Local()
        {
            if (App.Current.Properties.ContainsKey("Login"))
                return App.Current.Properties["Login"] as CustomerInfo;

            var model = Task.Run(async () => await App.Services.LocalDb.Table<CustomerInfo>().FirstOrDefaultAsync()).Result;
           
            if (model != null)
                App.Current.Properties["Login"] = model;

            return model;
        }


    }
}
