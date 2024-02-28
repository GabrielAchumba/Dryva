using Dryva.Enrollment.DTOs.Customer;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dryva.Enrollment.Application.Queries
{
    public class GetCustomerDetailQuery : IRequest<IEnumerable<CustomerDetailDTO>>
    {
       
    }
}
