using CSharpRefactorings.DiscountManager.Refactored;
using NUnit.Framework;

namespace CSharpRefactoringTests.DiscountManager.Refactored
{
    public class DiscountManagerTest
    {
        [TestCase(100, Customer.NotRegistered, 0, 100)]
        [TestCase(100, Customer.NotRegistered, 1, 99)]
        [TestCase(100, Customer.NotRegistered, 2, 98)]
        [TestCase(100, Customer.NotRegistered, 3, 97)]
        [TestCase(100, Customer.NotRegistered, 4, 96)]
        [TestCase(100, Customer.NotRegistered, 5, 95)]
        [TestCase(100, Customer.NotRegistered, 6, 95)]
        [TestCase(100, Customer.SimpleCustomer, 0, 90)]
        [TestCase(100, Customer.ValuableCustomer, 0, 70)]
        [TestCase(100, Customer.MostValuableCustomer, 0, 50)]
        [TestCase(100, Customer.SimpleCustomer, 1, 89.1)]
        [TestCase(100, Customer.MostValuableCustomer, 5, 47.5)]

        public void ApplyDiscount(decimal price, Customer customer, int loyalty, decimal expected)
        {
            // arrange
            var discountManager = new CSharpRefactorings.DiscountManager.Refactored.DiscountManager();

            // act
            var actual = discountManager.ApplyDiscount(price, customer, loyalty);

            // assert
            Assert.AreEqual(expected, actual);
        }
    }
}
