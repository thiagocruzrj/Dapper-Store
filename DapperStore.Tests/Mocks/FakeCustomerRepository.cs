using System;
using System.Collections.Generic;
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

        public GetCustomerQueryResult GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public CustomerOrdersCountResult GetCustomerOrdersCount(string document)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Customer customer)
        {
            
        }

        IEnumerable<ListCustomerQueryResult> ICustomerRepository.GetList()
        {
            throw new System.NotImplementedException();
        }
    }
}