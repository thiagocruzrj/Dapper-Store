using DapperStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using DapperStore.Domain.StoreContext.Handlers;
using DapperStore.Tests.Mocks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperStore.Tests.Handlers
{
    [TestClass]
    public class CustomerHandlerTests
    {
        [TestMethod]
        public void ShouldRegisterWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Thiago";
            command.LastName = "Cruz";
            command.Document = "14220929762";
            command.Email = "thagocruz@gmail.com";
            command.Phone = "21969716652";

            var handler = new CustomerHandler(new FakeCustomerRepository(), new FakeEmailService());
            var result = handler.Handle(command);

            Assert.AreNotEqual(null, result);
            Assert.AreEqual(true, handler.IsValid);
        }
    }
}