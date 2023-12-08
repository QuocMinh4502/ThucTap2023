using MediatR;
using ThucTap.Models;

namespace ThucTap.Commands
{
    public class UpdateCommands
    {
        public class UpdateProductCommand : IRequest<int>
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }

            public UpdateProductCommand(int id, string name, string description, decimal price, string category)
            {
                Id = id;
                Name = name;
                Description = description;
                Price = price;
                Category = category;
            }
        }

        public class UpdateOrderCommand : IRequest<int>
        {
            public int OrderId { get; set; }
            public CustomerDetails Customer { get; set; }
            public List<ProductDetails> Products { get; set; }
            public DateTime OrderDate { get; set; }
            public decimal TotalAmount { get; set; }


            public UpdateOrderCommand(int orderId, CustomerDetails customer, List<ProductDetails> products, DateTime orderDate, decimal totalAmount)
            {
                OrderId = orderId;
                Customer = customer;
                Products = products;
                OrderDate = orderDate;
                TotalAmount = totalAmount;
            }
        }

        public class UpdateCustomerCommand : IRequest<int>
        {
            public int Id { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public int Age { get; set; }
            public string Name { get; internal set; }


            public UpdateCustomerCommand(int id, string name, string email, string address, int age)
            {
                Id = id;
                Name = name;
                Email = email;
                Address = address;
                Age = age;
            }
        }

        public class UpdateUserCommand : IRequest<int>
        {
            public int Id { get; set; }
            public string UserName { get; set; }
            public string Password { get; set; }
            public string HoTen { get; set; }
            public string Email { get; set; }

            public UpdateUserCommand(int id, string userName, string password, string hoTen, string email)
            {
                Id = id;
                UserName = userName;
                Password = password;
                HoTen = hoTen;
                Email = email;
            }
        }
    }
}
