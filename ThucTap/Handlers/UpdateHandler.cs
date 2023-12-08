using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThucTap.Commands;
using ThucTap.Repositories;

namespace ThucTap.Handlers
{
    public class UpdateHandlers
    {
        public class UpdateProductHandler : IRequestHandler<UpdateCommands.UpdateProductCommand, int>
        {
            private readonly IEntityRepository _productRepository;

            public UpdateProductHandler(IEntityRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<int> Handle(UpdateCommands.UpdateProductCommand command, CancellationToken cancellationToken)
            {
                var productDetails = await _productRepository.GetProductByIdAsync(command.Id);
                if (productDetails == null)
                    return default;

                productDetails.Name = command.Name;
                productDetails.Description = command.Description;
                productDetails.Price = command.Price;
                productDetails.Category = command.Category;

                return await _productRepository.UpdateProductAsync(productDetails);
            }
        }

        public class UpdateOrderHandler : IRequestHandler<UpdateCommands.UpdateOrderCommand, int>
        {
            private readonly IEntityRepository _orderRepository;

            public UpdateOrderHandler(IEntityRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<int> Handle(UpdateCommands.UpdateOrderCommand command, CancellationToken cancellationToken)
            {
                var orderDetails = await _orderRepository.GetOrderByIdAsync(command.OrderId);
                if (orderDetails == null)
                    return default;

                // Cập nhật các thuộc tính của OrderDetails theo command

                return await _orderRepository.UpdateOrderAsync(orderDetails);
            }
        }

        public class UpdateCustomerHandler : IRequestHandler<UpdateCommands.UpdateCustomerCommand, int>
        {
            private readonly IEntityRepository _customerRepository;

            public UpdateCustomerHandler(IEntityRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<int> Handle(UpdateCommands.UpdateCustomerCommand command, CancellationToken cancellationToken)
            {
                var customerDetails = await _customerRepository.GetCustomerByIdAsync(command.Id);
                if (customerDetails == null)
                    return default;

                // Cập nhật các thuộc tính của CustomerDetails theo command
                customerDetails.Name = command.Name;
                customerDetails.Email = command.Email;
                customerDetails.Address = command.Address;
                customerDetails.Age = command.Age;
                // Thêm các thuộc tính khác của khách hàng cần được cập nhật

                return await _customerRepository.UpdateCustomerAsync(customerDetails);
            }
        }

    }
}
