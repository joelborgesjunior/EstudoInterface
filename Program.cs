using System.Globalization;
using System;
using Entities;
using Services;

namespace Ex19
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter contract data");
            Console.Write("Number: ");
            int number = int.Parse(Console.ReadLine());
            Console.Write("Data (dd/MM/yyyy): ");
            DateTime date = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
            Console.Write("Contract value: ");
            double value = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
            Console.Write("Enter number os installments: ");
            int installments = int.Parse(Console.ReadLine());

            Contract contract = new Contract(number, date, value);

            ContractService contractServices = new ContractService(contract, installments, new PayPalService());

            contractServices.calculateQuota();

            Console.WriteLine("Installments: ");
            foreach (var c in contractServices.Contract.Installment) 
            {
                Console.WriteLine(c);

            }
        }
    }
}
