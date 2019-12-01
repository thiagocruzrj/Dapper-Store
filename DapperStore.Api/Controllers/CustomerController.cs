using System;
using System.Collections.Generic;
using DapperStore.Domain.Entities.StoreContext;
using DapperStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using DapperStore.Domain.StoreContext.Entities;
using DapperStore.Domain.StoreContext.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace DapperStore.Api.Controllers
{
    public class CustomerController : Controller
    {
        
        [HttpGet]
        [Route("customers")]
        public List<Customer> Get()
        {
            var name = new Name("Thiago", "Cruz");
            var document = new Document("14220929762");
            var email = new Email("thagocruz@gmail.com");
            var customer = new Customer(name, document, email, "5521969716652");
            var customers = new List<Customer>();
            customers.Add(customer);
            return customers;
        }

        [HttpGet]
        [Route("customers/{id}")]
        public Customer GetById(Guid id)
        {
            var name = new Name("Thiago", "Cruz");
            var document = new Document("14220929762");
            var email = new Email("thagocruz@gmail.com");
            var customer = new Customer(name, document, email, "5521969716652");
            return customer;
        }

        [HttpGet]
        [Route("customers/{id}/orders")]
        public List<Order> GetOrders(Guid id)
        {
            var name = new Name("Thiago", "Cruz");
            var document = new Document("14220929762");
            var email = new Email("thagocruz@gmail.com");
            var customer = new Customer(name, document, email, "5521969716652");
            var order = new Order(customer);

            var mouse = new Product("Mouse gamer", "Mouse Gamer", "mouse.jpg", 99M, 10);
            var keybord = new Product("Keybord", "Keybord", "Keybord.jpg", 120M, 10);
            order.AddItem(keybord, 5);
            order.AddItem(mouse, 5);
            var orders = new List<Order>();
            orders.Add(order);
            return orders;
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