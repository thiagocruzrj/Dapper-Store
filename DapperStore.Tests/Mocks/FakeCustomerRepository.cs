using DapperStore.Domain.StoreContext.Entities;
using DapperStore.Domain.StoreContext.Queries;
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

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            throw new System.NotImplementedException();
        }

        public void Save(Customer customer)
        {
            
        }
    }
}