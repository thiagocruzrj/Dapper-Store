using DapperStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using DapperStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using DapperStore.Domain.StoreContext.Entities;
using DapperStore.Domain.StoreContext.Repositories;
using DapperStore.Domain.StoreContext.Services;
using DapperStore.Domain.StoreContext.ValueObjects;
using DapperStore.Shared.Commands;
using FluentValidator;

namespace DapperStore.Domain.StoreContext.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _repository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository repository, IEmailService emailService)
        {
            _repository = repository;
            _emailService = emailService;
        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            // Verify if CPF exist on DB
            if(_repository.CheckDocumnet(command.Document))
            AddNotification("Document", "This CPF is already in use");

            // Verify if Email exist on DB
            if(_repository.CheckEmail(command.Email))
            AddNotification("Email", "This Email is already in use");

            // Create VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            // Create Entities
            var customer = new Customer(name, document, email, command.Phone);

            // Validating Entities and VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if(Invalid) return null;
            // Persist the customer on DB
            _repository.Save(customer);

            // Send welcome email
            _emailService.Send(email.Address, "thagocruz@gmail.com", "Welcome", "Test email");

            // Return result to screen
            return new CreateCustomerCommandResult(customer.Id, name.ToString(), email.Address);
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new System.NotImplementedException();
        }
    }
}