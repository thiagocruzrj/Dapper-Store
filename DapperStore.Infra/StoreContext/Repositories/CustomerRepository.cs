using System.Data;
using System.Linq;
using Dapper;
using DapperStore.Domain.StoreContext.Entities;
using DapperStore.Domain.StoreContext.Repositories;
using DapperStore.Infra.StoreContext.DataConnection;

namespace DapperStore.Infra.StoreContext.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly OracleDataConnection _context;

        public CustomerRepository(OracleDataConnection context)
        {
            _context = context;
        }
        public bool CheckDocument(string document)
        {
            return 
                _context
                .Connection
                .Query<bool>(
                    "spCheckDocument",
                    new { Document = document},
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public bool CheckEmail(string email)
        {
            return 
                _context
                .Connection
                .Query<bool>(
                    "spCheckEmail",
                    new { Email = email},
                    commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        public void Save(Customer customer)
        {
            _context.Connection.Execute("spCreateCustomer",
            new{
                Id = customer.Id,
                FirstName = customer.Name.FirstName,
                LastName = customer.Name.LastName,
                Document = customer.Document.Number,
                Email = customer.Email.Address,
                Phone = customer.Phone
            }, commandType: CommandType.StoredProcedure);

            foreach (var address in customer.Addresses)
            {
                _context.Connection.Execute("spCreateAddress",
                new{
                    Id = address.Id,
                    CustomerId = customer.Id,
                    Number = address.Number,
                    Complement = address.Complement,
                    District = address.District,
                    City = address.City,
                    State = address.State,
                    Country = address.Country,
                    ZipCode = address.ZipCode,
                    Type = address.Type
                }, commandType: CommandType.StoredProcedure);
            }
        }
    }
}