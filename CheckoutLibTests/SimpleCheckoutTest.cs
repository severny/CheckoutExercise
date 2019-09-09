using CheckoutLib;
using NUnit.Framework;

namespace Tests
{
    public class SimpleCheckoutTest
    {
        [Test]
        public void Given_A_Checkout__When_Calling_Total__Then_Zero_Expected()
        {
            var checkout = new Checkout();
            Assert.That(decimal.Zero, Is.EqualTo(checkout.Total()), "Total should be zero when Checkout initialized");
        }

        /*
         The simplest way to prove item has been scanned is to return bool on success/false, and check wheter collection/storage has been modified.
         Other way could be to have internal storage eg IInternalItemStorage and mock method as necessary, interface could be useful to extend functionality, 
         eg persist scanned items etc.
        */
        [Test]
        public void Given_A_Null__When_Scanned__Then_False_Expected()
        {
            var checkout = new Checkout();
            Assert.That(false, Is.EqualTo(checkout.Scan(null)), "The scan should return true at success");
            Assert.That(0, Is.EqualTo(checkout.ScannedItemsCount()), "Number of scanned items should be zero");
        }


        [Test]
        public void Given_An_Item__When_Scan__Then_True_Expected()
        {
            var checkout = new Checkout();
            var item = new Item("Tst", 1.2m);

            Assert.That(true, Is.EqualTo(checkout.Scan(item)), "The scan should return true at success");
            Assert.That(1, Is.EqualTo(checkout.ScannedItemsCount()), "Number of scanned items should be one");
        }


        [Test]
        public void Given_An_Item__When_Item_Scanned_Twice__Then_Only_Once_Should_Be_Recorded()
        {
            var checkout = new Checkout();
            var item = new Item("Tst", 1.2m);
            checkout.Scan(item);
            Assert.That(true, Is.EqualTo(checkout.Scan(item)), "The scan should return true when item scanned second time, scan shall be idempotent operation");
            Assert.That(1, Is.EqualTo(checkout.ScannedItemsCount()), "Number of scanned items should remain one");
        }

        [Test]
        public void Given_An_Item__When_Sanned__Then_Correct_Amount_Is_Returned()
        {
            var checkout = new Checkout();
            var item = new Item("Tst", 1.2m);
            checkout.Scan(item);
            Assert.That(1.2m, Is.EqualTo(checkout.Total()), "Total price for one item should be 1.2");
            
        }


        [Test]
        public void Given_A_Collection_Of_Items__When_Scanned__Then_Correct_Amount_Is_Returned()
        {
            var checkout = new Checkout();

            for (int i = 0; i < 10; i++)
            {
                var item = new Item(@"Tst_{i}", 0.1m * i);
                checkout.Scan(item);
            }
            Assert.That(4.5m, Is.EqualTo(checkout.Total()), "Total price for one item should be 1.2");
        }
    }
}