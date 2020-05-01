using System.Collections.Generic;
using System;
using Entities;
using Interfaces;

namespace Services
{
    class ContractService
    {
        public Contract Contract { get; set; }
        public int Months { get; set; }
        IOnlinePayment _onlinePayment;

        public ContractService(Contract contract, int months, IOnlinePayment onlinePayment)
        {
            Contract = contract;
            Months = months;
            _onlinePayment = onlinePayment;
        }

        public void calculateQuota()
        {
            Contract.Installment = new List<Installment>();

            for (int i = 1; i <= Months; i++)
            {
                double number = Contract.TotalValue / Months;
                double Interest = i * (_onlinePayment.interest(number));
                number += Interest;
                double PaymentFee = _onlinePayment.paymentFee(number);
                number += PaymentFee;
                DateTime DueDate = Contract.Date.AddMonths(i);
                Installment Ins = new Installment(DueDate, number);
                Contract.Installment.Add(Ins);
            }
        }
    }
}