#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

#endregion

using System.EnterpriseServices;

namespace ESDemo
{
    [Transaction(TransactionOption.Required)]
    public class CustomerService
    {        
        public void IncreaseCreditLimit(
                                int customerNum, 
                                double increaseAmount)
        {
            try
            {
                Customer cust = new Customer(customerNum);
                double max = cust.MaxAllowableCredit;
                double current = cust.CreditLimit;

                if (max < current + increaseAmount)
                {
                    ContextUtil.MyTransactionVote = TransactionVote.Abort;
                }
                else
                {
                    cust.CreditLimit += increaseAmount;
                    cust.Save();
                    ContextUtil.MyTransactionVote = TransactionVote.Commit;
                }
            }
            catch (Exception ex)
            {
                ContextUtil.MyTransactionVote = TransactionVote.Abort;
            }
        }       
    }

    public class Customer
    {
        public Customer(int customerNum) { }
        public double MaxAllowableCredit 
        {
            get { return 100000; }
        }

        public double CreditLimit
        {
            get { return 50000; }
            set { double c = value; }
        }
        public void Save() { }
    }
}
