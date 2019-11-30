using DapperStore.Domain.Entities.StoreContext;
using DapperStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperStore.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // var c = new Customer("Thiago Cruz",
            //   "12345678910",
            //   "thagocruz@gmail.com",
            //   "21969716652",
            //   "rua 1, 23");

            // var order = new Order(c);

            var name = new Name("Thiago", "Cruz");
            var document = new Document("12345678911");
            var email = new Email("teste@gmail.com");
            var c = new Customer(name, document, email, "21986532215");

            var mouse = new Product("Mouse", "Logitec", "image.png", 59.90M, 10);
            var Teclado = new Product("Teclado", "Logitec", "image.png", 59.90M, 610);
            var Impressora = new Product("Impressora", "hp", "image.png", 159.90M, 10);
            var monitor = new Product("monitor", "lg", "image.png", 259.90M, 10);
            var cadeira = new Product("cadeira", "lg", "image.png", 359.90M, 10);
            var pc = new Product("pc", "lg", "image.png", 459.90M, 10);

            var order = new Order(c);
            order.AddItem(new OrderItem(mouse, 5));
            order.AddItem(new OrderItem(Teclado, 5));
            order.AddItem(new OrderItem(cadeira, 5));
            order.AddItem(new OrderItem(pc, 5));
            order.AddItem(new OrderItem(Impressora, 5));

            // Making the order
            order.Place();

            // Simulating an order
            order.Pay();

            // Simulatring a deleviry
            order.Ship();

            // Simulating a cancel
            order.Cancel();
        }
    }
}
