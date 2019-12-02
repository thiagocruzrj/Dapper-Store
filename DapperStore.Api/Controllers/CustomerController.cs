using System;
using System.Collections.Generic;
using DapperStore.Domain.Entities.StoreContext;
using DapperStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using DapperStore.Domain.StoreContext.Entities;
using DapperStore.Domain.StoreContext.Queries;
using DapperStore.Domain.StoreContext.Repositories;
using DapperStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace DapperStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        public CustomerController(ICustomerRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        [Route("customers")]
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.GetList();
        }

        [HttpGet]
        [Route("customers/{id}")]
        public GetCustomerQueryResult GetById(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("customers")]
        public Customer Post([FromBody]CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);
            return customer;
        }

        [HttpPut]
        [Route("customers/{id}")]
        public Customer Put([FromBody]CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);
            return customer;
        }

        [HttpDelete]
        [Route("customers/{id}")]
        public object Delete()
        {
            return new { message = "Customer removed with sucess!"};
        }
    }
}