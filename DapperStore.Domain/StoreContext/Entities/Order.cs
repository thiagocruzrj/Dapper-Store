using System;
using System.Collections.Generic;
using DapperStore.Domain.StoreContext.Entities.Enums;

namespace DapperStore.Domain.Entities.StoreContext
{
    public class Order
    {
        public Order(Customer customer)
        {
            Customer = customer;
            // Creating a random guid, converting to string, removing -, maximum 8 characteres and put the guid in uppercase
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,8).ToUpper();
            CreateDate = DateTime.Now;
            Status = EOrderStatus.Created;
            Items = new List<OrderItem>();
            Deliveries = new List<Delivery>();
        }

        public Customer Customer { get; private set; }
        public string Number { get; private set; }
        public DateTime CreateDate { get; private set; }
        public EOrderStatus Status { get; private set; }
        public IReadOnlyCollection<OrderItem> Items { get; private set; }
        public IReadOnlyCollection<Delivery> Deliveries { get; private set; }

        public void AddItem(OrderItem order)
        {
            // Validating item
            // Add order
        }

        // To place an order
        public void Place(){ }
    }
}