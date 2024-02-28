using Dryva.Enrollment.DTOs.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Queries
{
    public class GetCustomerRegistrationByPhoneNumberQuery : IRequest<CustomerRegistrationDTO>
    {
        public string PhoneNumber { get;  }
        public GetCustomerRegistrationByPhoneNumberQuery(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
