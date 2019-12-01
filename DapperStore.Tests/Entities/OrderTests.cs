using DapperStore.Domain.Entities.StoreContext;
using DapperStore.Domain.StoreContext.Entities;
using DapperStore.Domain.StoreContext.Entities.Enums;
using DapperStore.Domain.StoreContext.ValueObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DapperStore.Tests.Entities
{
    [TestClass]
    public class OrderTests
    {
        private Product _mouse;
        private Product _keybord;
        private Product _chair;
        private Product _monitor;
        private Customer _customer;
        private Order _order;
        public OrderTests()
        {
            var name = new Name("Thiago", "Cruz");
            var document = new Document("14220929762");
            var email = new Email("thagocruz@gmail.com");
            _customer = new Customer(name, document, email, "5521969716652");
            _order = new Order(_customer);

            _mouse = new Product("Mouse gamer", "Mouse Gamer", "mouse.jpg", 99M, 10);
            _keybord = new Product("Keybord", "Keybord", "Keybord.jpg", 120M, 10);
            _chair = new Product("Chair gamer", "Chair Gamer", "chair.jpg", 999M, 10);
            _monitor = new Product("Monitor gamer", "Monitor Gamer", "monitor.jpg", 600M, 10);
        }
        // I can create a new order
        [TestMethod]
        public void ShouldCreateOrderWhenValid()
        {
            Assert.AreEqual(true, _order.IsValid);
        }

        // Creating an order, status should be created
        [TestMethod]
        public void StatusShouldBeCreateWhenOrderCreated()
        {
            Assert.AreEqual(EOrderStatus.Created, _order.Status);
        }

        // When add a new item, the quantity must change
        [TestMethod]
        public void ShouldReturnTwoWhenAddedTwoValidItems()
        {
            _order.AddItem(_monitor, 5);
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(2, _order.Items.Count);
        }

        // When add a new item, should decrease the product quantity
        [TestMethod]
        public void ShouldReturnFiveWhenPurshesedFiveItem()
        {
            _order.AddItem(_mouse, 5);
            Assert.AreEqual(_mouse.QuantityOnHand, 5);
        }

        // When acknowledge an order, should generate a number
        [TestMethod]
        public void ShouldReturnANumberWhenOrderPlaced()
        {
            _order.Place();
            Assert.AreNotEqual("", _order.Number);
        }

        // When pay an order, status must be paid
        [TestMethod]
        public void ShouldReturnPaidWehnOrderPaid()
        {
            _order.Pay();
            Assert.AreEqual(EOrderStatus.Paid, _order.Status);
        }

        // Just 5 produts by order
        [TestMethod]
        public void ShouldTwoWhenPurshesedTenProducts()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();
            Assert.AreEqual(2, _order.Deliveries.Count);
        }

        // When cancel an order, status must be canceled
        [TestMethod]
        public void StatusShouldBeCanceledWhenOrderCanceled()
        {
            _order.Cancel();
            Assert.AreEqual(EOrderStatus.Canceled, _order.Status);
        }

        // When cancel an order, must be cancel the delivery
        [TestMethod]
        public void ShouldCancelDeliveriesWhenOrderCanceled()
        {
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.AddItem(_mouse, 1);
            _order.Ship();

            _order.Cancel();
            foreach (var x in _order.Deliveries)
            {
                Assert.AreEqual(EOrderStatus.Canceled, x.Status);
            }
        }
        
        public void CreateCustomer()
        {
            // Verify if email exist
            // Verify if CPF exist
            // Create VOs
            // Create Entities
            // Validate entities and VOs
            // Insert the costumer on DB
            // Send Slack invite
            // Send welcome email
        }
    }
}