using Dryva.Enrollment.DTOs.Customer;
using MediatR;
using System;

namespace Dryva.Enrollment.Application.Handlers
{
    public class UpdateCustomerGenericTypeDataCommand<IN,OUT> : IRequest<OUT>
    {
        public IN Customer { get; }
        public Guid Id { get; }
        public string TypeName { get; }

        public UpdateCustomerGenericTypeDataCommand(IN model, Guid id, string typeName)
        {
            Customer = model;
            Id = id;
            this.TypeName = typeName;
        }
    }
}
