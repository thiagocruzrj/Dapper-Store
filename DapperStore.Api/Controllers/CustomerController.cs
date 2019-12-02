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
        [Route("v1/customers")]
        // Caching on client [ResponseCache(Location = ResponseCacheLocation.Client, Duration = 60)]
        [ResponseCache(Duration = 60)]
        // Cache-Control: public, max-age=64
        public IEnumerable<ListCustomerQueryResult> Get()
        {
            return _repository.GetList();
        }

        [HttpGet]
        [Route("v2/customers/{document}")]
        public GetCustomerQueryResult GetById(Guid document)
        {
            return _repository.GetById(document);
        }

        [HttpGet]
        [Route("v1/customers/{id}")]
        public GetCustomerQueryResult GetByDocument(Guid id)
        {
            return _repository.GetById(id);
        }

        [HttpGet]
        [Route("v1/customers/{id}/orders")]
        public IEnumerable<ListCustomerOrderQueryResult> GetOrders(Guid id)
        {
            return _repository.GetOrders(id);
        }

        [HttpPost]
        [Route("v1/customers")]
        public object Post([FromBody]CreateCustomerCommand command)
        {
            var result = (CreateCustomerCommandResult)_handler.Handle(command);
            if(_handler.Invalid)
                return BadRequest(_handler.Notifications);

            return result;
        }

        [HttpPut]
        [Route("v1/customers/{id}")]
        public Customer Put([FromBody]CreateCustomerCommand command)
        {
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);
            var customer = new Customer(name, document, email, command.Phone);
            return customer;
        }

        [HttpDelete]
        [Route("v1/customers/{id}")]
        public object Delete()
        {
            return new { message = "Customer removed with sucess!"};
        }
    }
}