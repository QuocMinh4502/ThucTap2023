using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThucTap.Models;
using ThucTap.Queries;
using ThucTap.Repositories;

namespace ThucTap.Handlers
{
    public class GetByIdHandlers
    {
        public class GetProductByIdHandler : IRequestHandler<GetByIdQuery.GetProductByIdQuery, ProductDetails>
        {
            private readonly IEntityRepository _productRepository;

            public GetProductByIdHandler(IEntityRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<ProductDetails> Handle(GetByIdQuery.GetProductByIdQuery query, CancellationToken cancellationToken)
            {
                return await _productRepository.GetProductByIdAsync(query.Id);
            }
        }

        public class GetOrderByIdHandler : IRequestHandler<GetByIdQuery.GetOrderByIdQuery, OrderDetails>
        {
            private readonly IEntityRepository _orderRepository;

            public GetOrderByIdHandler(IEntityRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<OrderDetails> Handle(GetByIdQuery.GetOrderByIdQuery query, CancellationToken cancellationToken)
            {
                return await _orderRepository.GetOrderByIdAsync(query.Id);
            }
        }

        public class GetCustomerByIdHandler : IRequestHandler<GetByIdQuery.GetCustomerByIdQuery, CustomerDetails>
        {
            private readonly IEntityRepository _customerRepository;

            public GetCustomerByIdHandler(IEntityRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<CustomerDetails> Handle(GetByIdQuery.GetCustomerByIdQuery query, CancellationToken cancellationToken)
            {
                return await _customerRepository.GetCustomerByIdAsync(query.Id);
            }
        }
    }
}
