using FluentValidator;
using FluentValidator.Validation;

namespace DapperStore.Domain.StoreContext.ValueObjects
{
    public class Email : Notifiable
    {
        public Email(string address)
        {
            Address = address;

            AddNotifications(new ValidationContract()
                            .Requires()
                            .IsEmail(Address, "Email","Email is invalid"));
        }
        public string Address { get; set; }

        public override string ToString()
        {
            return Address;
        }
    }
}