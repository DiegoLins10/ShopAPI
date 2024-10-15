using Shop.Domain.Commands.Requests;
using Shop.Domain.Commands.Responses;

namespace Shop.Domain.Handlers
{
    public interface ICreateCustomerHandler
    {
        public CreateCustomerResponse Handle(CreateCustomerRequest request);
    }
}
