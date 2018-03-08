using ModernStore.Domain.Enums;
using ModernStore.Shared.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using FluentValidator;

namespace ModernStore.Domain.Entities
{
    public class Order : Entity
    {
        protected Order()
        {

        }

        private readonly IList<OrderItem> _items;

        public Order(Customer customer,  decimal deliveryFree, decimal discount)
        {
            Customer = customer;
            CreateData = DateTime.Now;
            Number = Guid.NewGuid().ToString().Substring(0,8).ToUpper();
            Status = EOrderStatus.Created;
            DeliveryFree = deliveryFree;
            Discount = discount;

            _items = new List<OrderItem>();

            new ValidationContract<Order>(this)
                .IsGreaterThan(x=>x.DeliveryFree, 0)
                .IsGreaterThan(x=>x.Discount,-1);

        }

        public Customer Customer { get; private set; }

        public DateTime CreateData { get; private set; }

        public string Number { get; private set; }

        public EOrderStatus Status { get; private set; }

        public ICollection<OrderItem> Items => _items.ToArray(); 

        public decimal DeliveryFree { get; private set; }

        public decimal Discount { get; private set; }

        public decimal SubTotal() => Items.Sum(x => x.Total());

        public decimal Total() => SubTotal() + DeliveryFree - Discount;



        public void AddItem(OrderItem item)
        {
            AddNotifications(item.Notifications);
            if (item.IsValid())
                _items.Add(item);
        }

   

    }
}
