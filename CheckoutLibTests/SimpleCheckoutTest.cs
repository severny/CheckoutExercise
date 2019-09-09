using CheckoutLib;
using NUnit.Framework;

namespace Tests
{
    public class SimpleCheckoutTest
    {
        [Test]
        public void Given_Checkout__When_Calling_Total__Then_Zero_Expected()
        {
            var checkout = new Checkout();
            Assert.That(decimal.Zero, Is.EqualTo(checkout.Total()), "Total should be zero when Checkout initialized");
        }
    }
}