using MediatR;
using System.Threading;
using System.Threading.Tasks;
using ThucTap.Models;
using ThucTap.Queries;
using ThucTap.Repositories;
using System.Collections.Generic;

namespace ThucTap.Handlers
{
    public class GetListHandlers
    {
        public class GetProductListHandler : IRequestHandler<GetListQuery.GetProductListQuery, List<ProductDetails>>
        {
            private readonly IEntityRepository _productRepository;

            public GetProductListHandler(IEntityRepository productRepository)
            {
                _productRepository = productRepository;
            }

            public async Task<List<ProductDetails>> Handle(GetListQuery.GetProductListQuery query, CancellationToken cancellationToken)
            {
                return await _productRepository.GetProductListAsync();
            }
        }

        public class GetOrderListHandler : IRequestHandler<GetListQuery.GetOrderListQuery, List<OrderDetails>>
        {
            private readonly IEntityRepository _orderRepository;

            public GetOrderListHandler(IEntityRepository orderRepository)
            {
                _orderRepository = orderRepository;
            }

            public async Task<List<OrderDetails>> Handle(GetListQuery.GetOrderListQuery query, CancellationToken cancellationToken)
            {
                return await _orderRepository.GetOrderListAsync();
            }
        }

        public class GetCustomerListHandler : IRequestHandler<GetListQuery.GetCustomerListQuery, List<CustomerDetails>>
        {
            private readonly IEntityRepository _customerRepository;

            public GetCustomerListHandler(IEntityRepository customerRepository)
            {
                _customerRepository = customerRepository;
            }

            public async Task<List<CustomerDetails>> Handle(GetListQuery.GetCustomerListQuery query, CancellationToken cancellationToken)
            {
                return await _customerRepository.GetCustomerListAsync();
            }
        }
    }

}
