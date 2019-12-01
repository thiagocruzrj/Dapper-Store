using DapperStore.Domain.StoreContext.Entities;
using DapperStore.Domain.StoreContext.Repositories;

namespace DapperStore.Tests.Mocks
{
    public class FakeCustomerRepository : ICustomerRepository
    {
        public bool CheckDocument(string document)
        {
            return false;
        }

        public bool CheckEmail(string email)
        {
            return false;
        }

        public void Save(Customer customer)
        {
            
        }
    }
}