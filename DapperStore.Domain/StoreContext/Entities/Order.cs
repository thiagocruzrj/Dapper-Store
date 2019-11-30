using System;
using System.Collections.Generic;
using System.Linq;
using DapperStore.Domain.StoreContext.Entities.Enums;

namespace DapperStore.Domain.Entities.StoreContext
{
    public class Order
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = customer;
            // Creating a random guid, converting to string, removing -, maximum 8 characteres and put the guid in uppercase
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,8).ToUpper();
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            _items = new List<OrderItem>();
            _deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items => _items.ToArray();
        public IReadOnlyCollection<Delivery> Deliveries => _deliveries.ToArray();

        public void AddItem(OrderItem order)
        {
            // Validating item
            // Add order
            _items.Add(order);
        }

        public void Delivery(Delivery delivery)
        {
            // Validating delivery
            // Add delivery
            _deliveries.Add(delivery);
        }

        // To place an order
        public void Place(){ }
    }
}