namespace Interfaces
{
    interface IOnlinePayment
    {
       public double paymentFee(double amount); 
       public double interest(double amount);
    }
}