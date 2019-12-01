using System;
using System.Collections.Generic;
using DapperStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace DapperStore.Domain.StoreContext.Commands.OrderCommands.Input
{
    public class PlaceOrderCommand : Notifiable, ICommand
    {
        public PlaceOrderCommand()
        {
            OrderItems = new List<OrderItemCommand>();
        }

        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }

        public bool Valid()
        {
            AddNotifications(new ValidationContract()
                .HasLen(Customer.ToString(), 36, "Customer", "Client identificador invalid")
                .IsGreaterThan(OrderItems.Count, 0, "Items", "None of items order found")
            );
            return Valid();
        }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}