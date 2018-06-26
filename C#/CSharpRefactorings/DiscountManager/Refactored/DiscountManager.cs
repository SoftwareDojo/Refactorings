using System.Collections.Generic;

namespace CSharpRefactorings.DiscountManager.Refactored
{
    public enum Customer
    {
        NotRegistered = 1,
        SimpleCustomer = 2,
        ValuableCustomer = 3,
        MostValuableCustomer = 4
    }

    public class DiscountManager
    {
        private readonly int m_MaxLoyaltyDiscount;
        private readonly IDictionary<Customer, decimal> m_CustomerDiscounts;

        public DiscountManager() : this(
            new Dictionary<Customer, decimal>
            {
                {Customer.NotRegistered, 0},
                {Customer.SimpleCustomer, 0.1m},
                {Customer.ValuableCustomer, 0.3m},
                {Customer.MostValuableCustomer, 0.5m}
            }, 5)
        {
        }

        public DiscountManager(IDictionary<Customer, decimal> customerDiscounts, int maxLoyaltyDiscount)
        {
            m_CustomerDiscounts = customerDiscounts;
            m_MaxLoyaltyDiscount = maxLoyaltyDiscount;
        }

        public decimal ApplyDiscount(decimal price, Customer customer, int loyaltyInYears)
        {
            decimal priceAfterDiscount = ApplyCustomerDiscount(price, customer);
            return ApplyLoyaltyDiscount(priceAfterDiscount, loyaltyInYears);
        }

        private decimal ApplyCustomerDiscount(decimal price, Customer customer)
        {
            if (!m_CustomerDiscounts.ContainsKey(customer)) return price;
            return price - m_CustomerDiscounts[customer] * price;
        }

        private decimal ApplyLoyaltyDiscount(decimal price, int loyalty)
        {
            decimal discount = loyalty > m_MaxLoyaltyDiscount ? (decimal)m_MaxLoyaltyDiscount / 100 : (decimal)loyalty / 100;
            return price - discount * price;
        }
    }
}
