using System;
using System.Collections.Generic;

namespace DapperStore.Domain.StoreContext.Commands.OrderCommands.Input
{
    public class PlaceOrderCommand
    {
        public Guid Customer { get; set; }
        public IList<OrderItemCommand> OrderItems { get; set; }
    }

    public class OrderItemCommand
    {
        public Guid Product { get; set; }
        public decimal Quantity { get; set; }
    }
}