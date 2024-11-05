using Common.Domain;
using Common.Domain.Exceptions;

namespace Book.Domain.OrderAgg
{
    public class OrderItem : BaseEntity
    {
        public OrderItem(int inventoryId, int count, int price)
        {
            CountGuard(count);
            PriceGuard(price);

            InventoryId = inventoryId;
            Count = count;
            Price = price;
        }

        public long OrderId { get; private set; }
        public int InventoryId { get; private set; }
        public int Count { get; private set; }
        public int Price { get; private set; }
        public int TotalPrice => Price * Count;

        public void ChangeCount(int newCount)
        {
            CountGuard(newCount);
            Count = newCount;
        }

        public void SetPrice(int newPrice)
        {
            PriceGuard(newPrice);
            Price = newPrice;
        }

        public void CountGuard(int count)
        {
            if (count < 1)
                throw new InvalidDomainDataException();
        }

        public void PriceGuard(int Price)
        {
            if (Price < 1)
                throw new InvalidDomainDataException("مبلغ وارد شده نامعتبر است");
        }
    }

}