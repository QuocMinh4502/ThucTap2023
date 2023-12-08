using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThucTap.Commands;
using ThucTap.Models;
using ThucTap.Repositories;

namespace ThucTap.Handlers
{
    public class CreateHandlers
    {
        public class CreateProductHandler : IRequestHandler<CreateCommands.CreateProductCommand, ProductDetails>
        {
            private readonly IEntityRepository _productRepository;

            public CreateProductHandler(IEntityRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<ProductDetails> Handle(CreateCommands.CreateProductCommand command, CancellationToken cancellationToken)
            {
                var productDetails = new ProductDetails()
                {
                    Name = command.Name,
                    Description = command.Description,
                    Price = command.Price,
                    Category = command.Category
                };

                return await _productRepository.AddProductAsync(productDetails);
            }
        }

        public class CreateOrderHandler : IRequestHandler<CreateCommands.CreateOrderCommand, OrderDetails>
        {
            private readonly IEntityRepository _orderRepository;

            public CreateOrderHandler(IEntityRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<OrderDetails> Handle(CreateCommands.CreateOrderCommand command, CancellationToken cancellationToken)
            {
                var orderDetails = new OrderDetails()
                {
                    Customer = command.Customer,
                    Products = command.Products,
                    OrderDate = command.OrderDate,
                    TotalAmount = command.TotalAmount

                    // Thêm các thuộc tính cần thiết cho OrderDetails
                };
                return await _orderRepository.AddOrderAsync(orderDetails);
            }
        }

        public class CreateCustomerHandler : IRequestHandler<CreateCommands.CreateCustomerCommand, CustomerDetails>
        {
            private readonly IEntityRepository _customerRepository;

            public CreateCustomerHandler(IEntityRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<CustomerDetails> Handle(CreateCommands.CreateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customerDetails = new CustomerDetails()
                {
                    Name = command.Name,
                    Email = command.Email,
                    Address = command.Address,
                    Age = command.Age
                    // Thêm các thuộc tính cần thiết cho CustomerDetails
                };

                return await _customerRepository.AddCustomerAsync(customerDetails);
            }
        }
    }
}
