using DapperStore.Domain.StoreContext.Commands.CustomerCommands.Input;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperStore.Tests.Commands
{
    [TestClass]
    public class CreateCustomerCommandTests
    {
        [TestMethod]
        public void ShouldValidadeWhenCommandIsValid()
        {
            var command = new CreateCustomerCommand();
            command.FirstName = "Thiago";
            command.LastName = "Cruz";
            command.Document = "14220929762";
            command.Email = "thagocruz@gmail.com";
            command.Phone = "21969716652";

            Assert.AreEqual(true, command.Valid());
        }
    }
}