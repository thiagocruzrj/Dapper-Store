using System;
using DapperStore.Domain.StoreContext.Entities.Enums;

namespace DapperStore.Domain.Entities.StoreContext
{
    public class Delivery
    {
        public Delivery(DateTime estimatedDeliveryDate)
        {
            CreateDate = DateTime.Now;
            EstimatedDeliveryDate = estimatedDeliveryDate;
            Status = EDeliveryStatus.Waiting;
        }

        public DateTime CreateDate { get; private set; }
        public DateTime EstimatedDeliveryDate { get; private set; }
        public EDeliveryStatus Status { get; private set; }

        public void Ship()
        {
            // If estimated date is in the past, doesnt ship
            Status = EDeliveryStatus.Shipped;
        }

        public void Cancel()
        {
            // If Status = delivery, we cant cancel
            Status = EDeliveryStatus.Canceled;
        }
    }
}