using FluentValidator;

namespace DapperStore.Domain.Entities.StoreContext
{
    public class OrderItem : Notifiable
    {
        public OrderItem(Product product, decimal quatity)
        {
            Product = product;
            Quantity = quatity;
            Price = product.Price;

            // Without extension
            //if(product.QuantityOnHand < quantity) Notification.Add("Quantity", "Product out of stock");
            if(product.QuantityOnHand < quatity) AddNotification("Quantity", "Product out of stock");
        }
        public Product Product { get; private set; }
        public decimal Quantity { get; private set; }
        public decimal Price { get; private set; }
        //public IDictionary<string, string> Notifications { get; set; }
    }
}