using System;
using System.Collections.Generic;
using System.Linq;
using DapperStore.Domain.StoreContext.Entities;
using DapperStore.Domain.StoreContext.Entities.Enums;
using DapperStore.Shared.Entities;

namespace DapperStore.Domain.Entities.StoreContext
{
    public class Order : Entity
    {
        private readonly IList<OrderItem> _items;
        private readonly IList<Delivery> _deliveries;
        public Order(Customer customer)
        {
            Customer = customer;
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

        public void AddItem(Product product, decimal quantity)
        {
            if(quantity > product.QuantityOnHand)
                AddNotification("OrderItem", $"Product {product.Title} doesnt have {quantity} items on stock.");
            
            var item = new OrderItem(product, quantity);
            _items.Add(item);
        }
        public void Place()
        {
            // Generating an order number
            Number = Guid.NewGuid().ToString().Replace("-","").Substring(0,8).ToUpper();
            // Validating a order
            if(_items.Count == 0)
                AddNotification("Order", "This order doesnt have items!");
        }

        // Pay an order
        public void Pay()
        {
            Status = EOrderStatus.Paid;
        }

        // Send an order
        public void Ship()
        {
            // business rule, just 5 products by delivery
            var deliveries = new List<Delivery>();
            //deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
            var count = 1;

            // Breaking the deliveries in five products
            foreach (var item in _items)
            {
                if(count == 5)
                {
                    count = 1;
                    deliveries.Add(new Delivery(DateTime.Now.AddDays(5)));
                }
                count++;
            }
            // roam all deliveries that ive made and send all deliveries to order
            deliveries.ForEach(x => x.Ship());
            deliveries.ForEach(x => _deliveries.Add(x));
        }

        // Cancel an order
        public void Cancel()
        {
            Status = EOrderStatus.Canceled;
            _deliveries.ToList().ForEach(x => x.Cancel());
        }
    }
}