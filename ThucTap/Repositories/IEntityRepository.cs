using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThucTap.Data;
using ThucTap.Models;

namespace ThucTap.Repositories
{
    
   public interface IEntityRepository
    {
        Task<List<ProductDetails>> GetProductListAsync();
        Task<ProductDetails> GetProductByIdAsync(int Id);
        Task<ProductDetails> AddProductAsync(ProductDetails productDetails);
        Task<int> UpdateProductAsync(ProductDetails productDetails);
        Task<int> DeleteProductAsync(int Id);

        Task<List<OrderDetails>> GetOrderListAsync();
        Task<OrderDetails> GetOrderByIdAsync(int Id);
        Task<OrderDetails> AddOrderAsync(OrderDetails orderDetails);
        Task<int> UpdateOrderAsync(OrderDetails orderDetails);
        Task<int> DeleteOrderAsync(int Id);

        Task<List<CustomerDetails>> GetCustomerListAsync();
        Task<CustomerDetails> GetCustomerByIdAsync(int Id);
        Task<CustomerDetails> AddCustomerAsync(CustomerDetails customerDetails);
        Task<int> UpdateCustomerAsync(CustomerDetails customerDetails);
        Task<int> DeleteCustomerAsync(int Id);
        Task<OrderDetails> GetOrderByIdAsync(object id);
    }

 
}


