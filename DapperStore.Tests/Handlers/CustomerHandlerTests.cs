using DapperStore.Domain.StoreContext.Commands.CustomerCommands.Input;
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

            Assert.AreEqual(true, command.Valid());

            var handler = new customerHandler(new FakeCustomerRepository(), new FakeEmailService());
        }
    }
}