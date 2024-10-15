using Shop.Domain.Commands.Requests;
using Shop.Domain.Commands.Responses;

namespace Shop.Domain.Handlers
{
    public class CreateCustomerHandler : ICreateCustomerHandler
    {
        public CreateCustomerResponse Handle(CreateCustomerRequest request)
        {
            return new CreateCustomerResponse
            {
                Id = Guid.NewGuid(),
                Name = "Diego Lins",
                Email = "diegolins@ibm.com",
                Date = DateTime.Now
            };
        }
    }
}
