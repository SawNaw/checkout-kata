using checkout_kata.Core;
using NUnit.Framework;
using System;

namespace UnitTests
{
    public class SingleDiscountTests
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

        [Test]
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
        public void ScanSixApples()
        {
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");

            checkoutMachine.Done();

            Assert.AreEqual(checkoutMachine.TotalPrice, 260);
        }
       
        [Test]
        public void ScanFourApplesPlus1B()
        {
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("B15");

            checkoutMachine.Done();

            Assert.AreEqual(checkoutMachine.TotalPrice, 210);
        }
        [Test]
        public void ScanFourApplesPlus2B()
        {
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("B15");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("B15");

            checkoutMachine.Done();

            Assert.AreEqual(checkoutMachine.TotalPrice, 225);
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
            
            checkoutMachine.Scan("B15");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("B15");
            checkoutMachine.Scan("A99");
            checkoutMachine.Scan("B15");


            checkoutMachine.Done();

            Assert.AreEqual(checkoutMachine.TotalPrice, 255);
        }

        [Test]
        public void ScanInvalidItem_ThrowsException()
        {
            Assert.Throws<InvalidBarcodeException>(()=> checkoutMachine.Scan("INVALID SKU"));
        }
    }
}