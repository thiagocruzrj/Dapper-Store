using DapperStore.Domain.StoreContext.Entities;

namespace DapperStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
         bool CheckDocument(string document);
         bool CheckEmail(string email);
         void Save(Customer customer);
    }
}