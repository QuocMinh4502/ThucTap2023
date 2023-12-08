using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThucTap.Commands;
using ThucTap.Repositories;

namespace ThucTap.Handlers
{
    public class DeleteHandlers
    {
        public class DeleteProductHandler : IRequestHandler<DeleteCommands.DeleteProductCommand, int>
        {
            private readonly IEntityRepository _productRepository;

            public DeleteProductHandler(IEntityRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<int> Handle(DeleteCommands.DeleteProductCommand command, CancellationToken cancellationToken)
            {
                var productDetails = await _productRepository.GetProductByIdAsync(command.Id);
                if (productDetails == null)
                    return default;

                return await _productRepository.DeleteProductAsync(productDetails.Id);
            }
        }

        public class DeleteOrderHandler : IRequestHandler<DeleteCommands.DeleteOrderCommand, int>
        {
            private readonly IEntityRepository _orderRepository;

            public DeleteOrderHandler(IEntityRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<int> Handle(DeleteCommands.DeleteOrderCommand command, CancellationToken cancellationToken)
            {
                var orderDetails = await _orderRepository.GetOrderByIdAsync(command.Id);
                if (orderDetails == null)
                    return default;

                // Xử lý xóa OrderDetails tương ứng

                return await _orderRepository.DeleteOrderAsync(orderDetails.OrderId);
            }
        }

        public class DeleteCustomerHandler : IRequestHandler<DeleteCommands.DeleteCustomerCommand, int>
        {
            private readonly IEntityRepository _customerRepository;

            public DeleteCustomerHandler(IEntityRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<int> Handle(DeleteCommands.DeleteCustomerCommand command, CancellationToken cancellationToken)
            {
                var customerDetails = await _customerRepository.GetCustomerByIdAsync(command.Id);
                if (customerDetails == null)
                    return default;

                // Xử lý xóa CustomerDetails tương ứng

                return await _customerRepository.DeleteCustomerAsync(customerDetails.Id);
            }
        }
    }
}
