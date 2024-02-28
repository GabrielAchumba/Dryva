using Dryva.Enrollment.DTOs.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Queries
{
    public class GetCustomerByIdQuery : IRequest<CustomerDataDTO>
    {
        public Guid CustomerId { get;  }
        public GetCustomerByIdQuery(Guid customerId)
        {
            CustomerId = customerId;
        }
    }
}
