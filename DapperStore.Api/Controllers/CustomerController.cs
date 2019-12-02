using System;
using System.Collections.Generic;
using DapperStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using DapperStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using DapperStore.Domain.StoreContext.Entities;
using DapperStore.Domain.StoreContext.Handlers;
using DapperStore.Domain.StoreContext.Queries;
using DapperStore.Domain.StoreContext.Repositories;
using DapperStore.Domain.StoreContext.ValueObjects;
using DapperStore.Shared.Commands;
using Microsoft.AspNetCore.Mvc;

namespace DapperStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ICustomerRepository _repository;
        private readonly CustomerHandler _handler;
        public CustomerController(ICustomerRepository repository, CustomerHandler handler)
        {
            _repository = repository;
            _handler = handler;
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
        public object Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            if(_handler.Invalid)
                return BadRequest(_handler.Notifications);

            return result;
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