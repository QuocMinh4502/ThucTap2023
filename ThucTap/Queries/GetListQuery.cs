using ThucTap.Models;
using MediatR;

namespace ThucTap.Queries
{
    public class GetListQuery
    {
        public class GetProductListQuery : IRequest<List<ProductDetails>>
        {
        }

        public class GetOrderListQuery : IRequest<List<OrderDetails>>
        {
        }

        public class GetCustomerListQuery : IRequest<List<CustomerDetails>>
        {
        }
    }
}
