using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using System;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Domain.Tests
{
    [TestClass]
    internal class OrderTests
    {
        private  static readonly User User = new User("Felipe", "123456", "123456");
        private readonly Customer _customer = new Customer(
            new Name("fe", "soares"),
            new Email("felipe_msaores@yahoo.com.br"),
            new Document("36129943873"), User);

        [TestMethod]
        [TestCategory("Order - new Order")]
        public void GivenAnOutOfStockProductItShouldReturnError()
        {
            var mouse = new Product("Mouse", 50, "mouse.jpg", 0);

            Console.WriteLine($"Mouses: {mouse.QuantityOnHand}");

            var order = new Order(_customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 10));

            Assert.IsFalse(order.IsValid());

           
        }

        [TestMethod]
        [TestCategory("Order - new Order")]
        public void GivenAnOutOfStockProductItShouldUpdateQuantityOnHand()
        {
            var mouse = new Product("Mouse", 20, "mouse.jpg", 20);

            Console.WriteLine($"Mouses: {mouse.QuantityOnHand}");

            var order = new Order(_customer, 8, 10);
            order.AddItem(new OrderItem(mouse, 2));

            Assert.IsTrue(mouse.QuantityOnHand == 18);
        }

        [TestMethod]
        [TestCategory("Order - new Order")]
        public void GivenAValidOrderTheTotalItShouldBe310()
        {
            var mouse = new Product("Mouse", 300, "mouse.jpg", 20);

            Console.WriteLine($"Mouses: {mouse.QuantityOnHand}");

            var order = new Order(_customer, 10, 2);
            order.AddItem(new OrderItem(mouse, 1));

            Assert.IsTrue(order.Total() == 310);
        }
    }
}
