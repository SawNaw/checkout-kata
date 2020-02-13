using checkout_kata.Core;
using NUnit.Framework;
using System;

namespace UnitTests
{
    public class MultipleDiscountTests
    {
        CheckoutMachine checkoutMachine = new CheckoutMachine();

        [SetUp]
        public void Setup()
        {
            checkoutMachine = new CheckoutMachine();
        }

        [Test]
        public void ScanItemWithTwoDiscounts()
        {
            checkoutMachine.Scan("C40");
            checkoutMachine.Scan("C40");
            checkoutMachine.Scan("C40");
            checkoutMachine.Scan("C40");
            checkoutMachine.Scan("C40");
            checkoutMachine.Scan("C40");
            checkoutMachine.Scan("C40");
            checkoutMachine.Scan("C40");
            checkoutMachine.Scan("C40");
            checkoutMachine.Scan("C40");
            checkoutMachine.Scan("C40");
            checkoutMachine.Scan("C40");

            checkoutMachine.Done();

            Assert.AreEqual(checkoutMachine.TotalPrice, 60);
        }
    }
}