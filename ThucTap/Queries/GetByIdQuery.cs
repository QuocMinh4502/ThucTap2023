using MediatR;
using ThucTap.Models;

namespace ThucTap.Queries
{
    public class GetByIdQuery
    {
        public int Id { get; internal set; }

        public class GetProductByIdQuery : IRequest<ProductDetails>
        {
            public int Id { get; set; }
        }

        public class GetOrderByIdQuery : IRequest<OrderDetails>
        {
            public int Id { get; set; }
        }

        public class GetCustomerByIdQuery : IRequest<CustomerDetails>
        {
            public int Id { get; set; }
        }
    }
}
