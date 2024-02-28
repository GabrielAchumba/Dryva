using Dryva.Enrollment.DTOs.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Queries
{
    public class GetCustomerByPhoneNumberQuery : IRequest<CustomerDataDTO>
    {
        public string PhoneNumber { get;  }
        public GetCustomerByPhoneNumberQuery(string phoneNumber)
        {
            PhoneNumber = phoneNumber;
        }
    }
}
