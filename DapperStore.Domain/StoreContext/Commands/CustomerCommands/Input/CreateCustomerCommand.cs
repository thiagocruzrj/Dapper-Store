using DapperStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace DapperStore.Domain.StoreContext.Commands.CustomerCommands.Input
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        // Fail fast validation
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasMinLen(FirstName, 3, "FirstName", "Name must be have 3 characters at minimum.")
                .HasMaxLen(FirstName, 40, "FirstName", "Name must be have 40 characters at maximum.")
                .HasMaxLen(LastName, 3, "LastName", "Surname must be have 3 characters at minimum.")
                .HasMinLen(LastName, 40, "LastName", "Surname must be have 40 characters at minimum.")
                .IsEmail(Email, "Email","Email is invalid")
                .HasLen(Document, 11, "Document", "Invalid CPF"));
            
            return Valid();
        }

        // User exist on DB (Email)
        // User exist on DB (CPF)
    }
}