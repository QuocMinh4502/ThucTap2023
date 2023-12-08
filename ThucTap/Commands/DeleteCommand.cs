using MediatR;

namespace ThucTap.Commands
{
    public class DeleteCommands
    {
        public class DeleteProductCommand : IRequest<int>
        {
            public int Id { get; set; }

            public DeleteProductCommand(int id)
            {
                Id = id;
            }

            public DeleteProductCommand()
            {
            }
        }

        public class DeleteOrderCommand : IRequest<int>
        {
            public int Id { get; set; }

            public DeleteOrderCommand(int id)
            {
                Id = id;
            }

            public DeleteOrderCommand()
            {
            }
        }

        public class DeleteCustomerCommand : IRequest<int>
        {
            public int Id { get; set; }

            public DeleteCustomerCommand(int id)
            {
                Id = id;
            }

            public DeleteCustomerCommand()
            {
            }
        }

        public class DeleteUserCommand : IRequest<int>
        {
            public int Id { get; set; }

            public DeleteUserCommand(int id)
            {
                Id = id;
            }

            public DeleteUserCommand()
            {
            }
        }
    }
}
