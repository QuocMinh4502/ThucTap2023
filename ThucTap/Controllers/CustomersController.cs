using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ThucTap.Commands;
using ThucTap.Models;
using ThucTap.Queries;
using static ThucTap.Commands.CreateCommands;
using static ThucTap.Commands.DeleteCommands;
using static ThucTap.Commands.UpdateCommands;
using static ThucTap.Queries.GetByIdQuery;
using static ThucTap.Queries.GetListQuery;

namespace ThucTap.Controllers
{
    // CustomersController
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator mediator;

        public CustomersController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        
        public async Task<List<CustomerDetails>> GetCustomerListAsync()
        {
            var customerDetails = await mediator.Send(new GetCustomerListQuery());
            return customerDetails;
        }

        [HttpGet("{customerId}")]
        public async Task<CustomerDetails> GetCustomerByIdAsync(int customerId)
        {
            var customerDetails = await mediator.Send(new GetCustomerByIdQuery() { Id = customerId });
            return customerDetails;
        }

        [HttpPost]
        public async Task<CustomerDetails> AddCustomerAsync(CustomerDetails customerDetails)
        {
            var customerDetail = await mediator.Send(new CreateCustomerCommand(
                customerDetails.Name,
                customerDetails.Email,
                customerDetails.Address,
                customerDetails.Age));
            return customerDetail;
        }

        [HttpPut]
        public async Task<int> UpdateCustomerAsync(CustomerDetails customerDetails)
        {
            var isCustomerDetailUpdated = await mediator.Send(new UpdateCustomerCommand(
               customerDetails.Id,
               customerDetails.Name,
               customerDetails.Email,
               customerDetails.Address,
               customerDetails.Age));
            return isCustomerDetailUpdated;
        }

        [HttpDelete("{customerId}")]
        public async Task<int> DeleteCustomerAsync(int customerId)
        {
            return await mediator.Send(new DeleteCustomerCommand() { Id = customerId });
        }
    }

}