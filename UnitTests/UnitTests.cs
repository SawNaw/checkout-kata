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
        public void ScanTwoItems()
        {
            checkoutMachine.Scan("C40");

            checkoutMachine.Scan("T34");

            checkoutMachine.Done();

            Assert.AreEqual(checkoutMachine.TotalPrice, 159);
        }

        public void ScanFourApples()
        {
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");

            checkoutMachine.Done();

            Assert.AreEqual(checkoutMachine.TotalPrice, 180);
        }

        [Test]
        public void ScanThreeBiscuits()
        {
            checkoutMachine.Scan("B15");
            checkoutMachine.Scan("B15");
            checkoutMachine.Scan("B15");

            checkoutMachine.Done();

            Assert.AreEqual(checkoutMachine.TotalPrice, 75);
        }

        [Test]
        public void ScanFourApplesAndThreeBiscuits()
        {
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");

            checkoutMachine.Scan("B15");
            checkoutMachine.Scan("B15");
            checkoutMachine.Scan("B15");


            checkoutMachine.Done();

            Assert.AreEqual(checkoutMachine.TotalPrice, 255);
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