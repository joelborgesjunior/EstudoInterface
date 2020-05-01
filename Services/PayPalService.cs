using Interfaces;
using Entities;

namespace Services
{
    class PayPalService : IOnlinePayment
    {
       public double paymentFee(double amount){
           return (amount / 100.00) * 2.00;
       } 

       public double interest(double amount){
           return (amount / 100.00) * 1.00;
       }
    }
}