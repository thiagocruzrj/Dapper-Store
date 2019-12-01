using FluentValidator;

namespace DapperStore.Domain.Entities.StoreContext
{
    public class OrderItem : Notifiable
    {
        public OrderItem(Product product, decimal quantity)
        {
            Product = product;
            Quantity = quantity;
            Price = product.Price;

            // Without extension
            //if(product.QuantityOnHand < quantity) Notification.Add("Quantity", "Product out of stock");
            if(product.QuantityOnHand < quantity) AddNotification("Quantity", "Product out of stock");

            product.DecreaseQuantity(quantity);
        }
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
        //public IDictionary<string, string> Notifications { get; set; }
    }
}