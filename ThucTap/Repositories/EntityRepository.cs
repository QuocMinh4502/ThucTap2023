using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using ThucTap.Data;
using ThucTap.Models;

namespace ThucTap.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private readonly DbContextClass _dbContext;

        public EntityRepository(DbContextClass dbContext)
        {
            _dbContext = dbContext;
        }

   

        // Phần liên quan đến ProductDetails
        public async Task<List<ProductDetails>> GetProductListAsync()
        {
            return await _dbContext.Products.ToListAsync();
        }

        public async Task<ProductDetails> GetProductByIdAsync(int Id)
        {
            return await _dbContext.Products.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<ProductDetails> AddProductAsync(ProductDetails productDetails)
        {
            var result = _dbContext.Products.Add(productDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> UpdateProductAsync(ProductDetails productDetails)
        {
            _dbContext.Products.Update(productDetails);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteProductAsync(int Id)
        {
            var filteredData = _dbContext.Products.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Products.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        // Phần liên quan đến OrderDetails
        public async Task<List<OrderDetails>> GetOrderListAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }

        public async Task<OrderDetails> GetOrderByIdAsync(int Id)
        {
            return await _dbContext.Orders.Where(x => x.OrderId == Id).FirstOrDefaultAsync();
        }

        public async Task<OrderDetails> AddOrderAsync(OrderDetails orderDetails)
        {
            var result = _dbContext.Orders.Add(orderDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> UpdateOrderAsync(OrderDetails orderDetails)
        {
            _dbContext.Orders.Update(orderDetails);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteOrderAsync(int Id)
        {
            var filteredData = _dbContext.Orders.Where(x => x.OrderId == Id).FirstOrDefault();
            _dbContext.Orders.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        // Phần liên quan đến CustomerDetails
        public async Task<List<CustomerDetails>> GetCustomerListAsync()
        {
            return await _dbContext.Customers.ToListAsync();
        }

        public async Task<CustomerDetails> GetCustomerByIdAsync(int Id)
        {
            return await _dbContext.Customers.Where(x => x.Id == Id).FirstOrDefaultAsync();
        }

        public async Task<CustomerDetails> AddCustomerAsync(CustomerDetails customerDetails)
        {
            var result = _dbContext.Customers.Add(customerDetails);
            await _dbContext.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<int> UpdateCustomerAsync(CustomerDetails customerDetails)
        {
            _dbContext.Customers.Update(customerDetails);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> DeleteCustomerAsync(int Id)
        {
            var filteredData = _dbContext.Customers.Where(x => x.Id == Id).FirstOrDefault();
            _dbContext.Customers.Remove(filteredData);
            return await _dbContext.SaveChangesAsync();
        }

        public Task<OrderDetails> GetOrderByIdAsync(object id)
        {
            throw new NotImplementedException();
        }
    }
}
