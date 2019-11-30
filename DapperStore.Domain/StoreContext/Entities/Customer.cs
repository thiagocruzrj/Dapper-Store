namespace DapperStore.Domain.Entities.StoreContext
{
    public class Customer
    {
        public Customer(string fistnaName,
                        string lastName,
                        string document,
                        string email,
                        string phone,
                        string address)
        {
            FirstName = fistnaName;
            LastName = lastName;
            Document = document;
            Email = email;
            Phone = phone;
            Address = address;
        }
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string Document { get; private set; }
        public string Email { get; private set; }
        public string Phone { get; private set; }
        public string Address { get; private set; }
    }
}