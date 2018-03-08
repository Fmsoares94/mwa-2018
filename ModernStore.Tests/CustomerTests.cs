using Microsoft.VisualStudio.TestTools.UnitTesting;
using ModernStore.Domain.Entities;
using ModernStore.Domain.ValueObjects;

namespace ModernStore.Tests
{
    [TestClass]
    public class CustomerTests
    {
        private readonly User _user = new User("Felipe", "Soares","Soares");

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidFirstNameShouldReturnANotification()
        {
           
            var customer = new Customer( new Name("fe", "soares"), new Email("felipe_msaores@yahoo.com.br"), new Document("36129943873") , _user);
            Assert.IsFalse(customer.IsValid());
            
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidLastNameShouldReturnANotification()
        {
           
            var customer = new Customer(new Name("fe", "soares"), new Email("@yahoo.com.br"), new Document("36129943873"), _user);
            Assert.IsFalse(customer.IsValid());
        }

        [TestMethod]
        [TestCategory("Customer - New Customer")]
        public void GivenAnInvalidEmailNameShouldReturnANotification()
        {
            
            var customer = new Customer(new Name("fe", "soares"), new Email("felipe_msaores@yahoo.com.br"), new Document("36129943823"), _user);
            Assert.IsFalse(customer.IsValid());
          
        }
    }
}
