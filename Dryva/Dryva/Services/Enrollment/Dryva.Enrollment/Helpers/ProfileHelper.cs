using AutoMapper;
using Dryva.Enrollment.DTOs.Customer;
using Dryva.Enrollment.DTOs.Investor;
using Dryva.Enrollment.DTOs.Lga;
using Dryva.Enrollment.DTOs.State;
using Dryva.Enrollment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Dr = Dryva.Enrollment.DTOs.Driver;
namespace Dryva.Enrollment.Helpers
{
    public class ProfileHelper : Profile
    {
        public ProfileHelper()
        {
            CreateMap<CustomerRegistrationDTO, Customer>().ReverseMap();
            CreateMap<NewCustomerRegistrationDTO, Customer>().ReverseMap();

            CreateMap<CustomerCSNDTO, Customer>().ReverseMap();
            CreateMap<NewCustomerCSNDTO, Customer>().ReverseMap();

            CreateMap<CustomerPersonalDataDTO, Customer>().ReverseMap();
            CreateMap<NewCustomerPersonalDataDTO, Customer>().ReverseMap();

            CreateMap<CustomerBioDataDTO, Customer>().ReverseMap();
            CreateMap<NewCustomerBioDataDTO, Customer>().ReverseMap();

            CreateMap<CustomerContactDTO, Customer>().ReverseMap();
            CreateMap<NewCustomerContactDTO, Customer>().ReverseMap();

            CreateMap<CustomerDetailDTO, Customer>().ReverseMap();

            CreateMap<CustomerDataDTO, Customer>().ReverseMap();

            CreateMap<Dr.DriverRegistrationDTO, Driver>().ReverseMap();
            CreateMap<Dr.NewDriverRegistrationDTO, Driver>().ReverseMap();

            CreateMap<Dr.DriverPersonalDataDTO, Driver>().ReverseMap();
            CreateMap<Dr.NewDriverPersonalDataDTO, Driver>().ReverseMap();

            CreateMap<Dr.DriverBioDataDTO, Driver>().ReverseMap();
            CreateMap<Dr.NewDriverBioDataDTO, Driver>().ReverseMap();

            CreateMap<Dr.DriverContactDTO, Driver>().ReverseMap();
            CreateMap<Dr.NewDriverContactDTO, Driver>().ReverseMap();

            CreateMap<Dr.DriverOwnerNOKDTO, Driver>().ReverseMap();
            CreateMap<Dr.NewDriverOwnerNOKDTO, Driver>().ReverseMap();

            CreateMap<Dr.DriverVehicleDTO, Driver>().ReverseMap();
            CreateMap<Dr.NewDriverVehicleDTO, Driver>().ReverseMap();

            CreateMap<Dr.DriverDetailDTO, Driver>().ReverseMap();

            CreateMap<Dr.DriverDataDTO, Driver>().ReverseMap();

            CreateMap<InvestorDTO, RTPS>().ReverseMap();
            CreateMap<NewInvestorDTO, RTPS>().ReverseMap();

            CreateMap<InvestorDTO, Shareholder>().ReverseMap();
            CreateMap<NewInvestorDTO, Shareholder>().ReverseMap();

            CreateMap<State, StateDTO>().ReverseMap();
            CreateMap<Lga, LGADTO>().ReverseMap();
        }
    }
}
