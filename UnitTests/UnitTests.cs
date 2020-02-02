using checkout_kata.Core;
using NUnit.Framework;

namespace UnitTests
{
    public class Tests
    {
        CheckoutMachine checkoutMachine = new CheckoutMachine();

        [SetUp]
        public void Setup()
        {
            checkoutMachine = new CheckoutMachine();
        }

        [Test]
        public void ScanSingleItem()
        {
            checkoutMachine.Scan("C40");

            checkoutMachine.Done();

            Assert.AreEqual(checkoutMachine.TotalPrice, 60);
        }

        [Test]
        public void ScanInvalidItem_TestFails()
        {
            checkoutMachine.Scan("INVALID SKU");

            checkoutMachine.Done();

            // This should FAIL!
            Assert.AreEqual(checkoutMachine.TotalPrice, 255);
        }
    }
}