using Dryva.VendorSubscription.API.Application.Commands;
using Dryva.VendorSubscription.API.Persistence.CustomerRecharge;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Dryva.VendorSubscription.API.Application.Handlers
{
    public class DeleteCustomerSubscriptionHandler : IRequestHandler<DeleteCustomerSubscriptionCommand, int>
    {
        private readonly ICustomerRechargeCommandRepository commandRepository;

        public DeleteCustomerSubscriptionHandler(ICustomerRechargeCommandRepository commandRepository)
        {
            this.commandRepository = commandRepository;
        }

        public async Task<int> Handle(DeleteCustomerSubscriptionCommand request, CancellationToken cancellationToken)
        {
            return await commandRepository.DeleteCustomerRechargeAsync(request.RechargeId);
        }
    }
}
