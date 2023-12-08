using ThucTap.Models;
using MediatR;

namespace ThucTap.Commands
{
    public class CreateCommands
    {
        public class CreateProductCommand : IRequest<ProductDetails>
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Price { get; set; }
            public string Category { get; set; }

            public CreateProductCommand(string name, string description, decimal price, string category)
            {
                Name = name;
                Description = description;
                Price = price;
                Category = category;
            }
        }

        public class CreateOrderCommand : IRequest<OrderDetails>
        {
            public CustomerDetails Customer { get; set; }
            public List<ProductDetails> Products { get; set; }
            public DateTime OrderDate { get; set; }
            public decimal TotalAmount { get; set; }

            public CreateOrderCommand(CustomerDetails customer, List<ProductDetails> products, DateTime orderDate, decimal totalAmount)
            {
                Customer = customer;
                Products = products;
                OrderDate = orderDate;
                TotalAmount = totalAmount;
            }
        }


        public class CreateCustomerCommand : IRequest<CustomerDetails>
        {
            public string Name { get; set; }
            public string Email { get; set; }
            public string Address { get; set; }
            public int Age { get; set; }

            public CreateCustomerCommand(string name, string email, string address, int age)
            {
                Name = name;
                Email = email;
                Address = address;
                Age = age;
            }
        }

        public class CreateUserCommand : IRequest<User>
        {
            public string UserName { get; set; }
            public string Password { get; set; }
            public string HoTen { get; set; }
            public string Email { get; set; }

            public CreateUserCommand(string userName, string password, string hoTen, string email)
            {
                UserName = userName;
                Password = password;
                HoTen = hoTen;
                Email = email;
            }
        }
    }

}
