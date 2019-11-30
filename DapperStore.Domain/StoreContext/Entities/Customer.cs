using System.Collections.Generic;
using System.Linq;
using DapperStore.Domain.StoreContext.Entities;
using DapperStore.Domain.StoreContext.ValueObjects;
using FluentValidator;

namespace DapperStore.Domain.Entities.StoreContext
{
    public class Customer : Notifiable
    {
        private readonly IList<Address> _addresses;
        public Customer(Name name,
                        Document document,
                        Email email,
                        string phone)
        {
            Name = name;
            Document = document;
            Email = email;
            Phone = phone;
            _addresses = new List<Address>();
        }
        public Name Name { get; set; }
        public Document Document { get; private set; }
        public Email Email { get; private set; }
        public string Phone { get; private set; }
        // bodiless function, when the fuction has only one line
        // doesnt work with ORMs
        public IReadOnlyCollection<Address> Addresses => _addresses.ToArray();

        public void AddAddress(Address address)
        {
            // Address validating
            // Add address (added in a new private list, new list address instance, after that added on address property list)
            _addresses.Add(address);
        }

        public override string ToString()
        {
            return Name.ToString();
        }
    }
}