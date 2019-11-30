using DapperStore.Domain.Entities.StoreContext;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var c = new Customer("Thiago",
              "Cruz",
              "12345678910",
              "thagocruz@gmail.com",
              "21969716652",
              "rua 1, 23");
        }
    }
}
