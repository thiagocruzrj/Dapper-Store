using System;
using System.Collections.Generic;
using DapperStore.Domain.StoreContext.Entities;
using DapperStore.Domain.StoreContext.Queries;

namespace DapperStore.Domain.StoreContext.Repositories
{
    public interface ICustomerRepository
    {
         bool CheckDocument(string document);
         bool CheckEmail(string email);
         void Save(Customer customer);
         CustomerOrdersCountResult GetCustomerOrdersCount(string document);
         IEnumerable<ListCustomerQueryResult> GetList();
         GetCustomerQueryResult GetById(Guid id);
         IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id);
    }
}