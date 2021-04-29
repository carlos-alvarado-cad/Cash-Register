using System;

namespace CashRegister5
{
    class Program
    {
        static void Main(string[] args)
        {
            double purchaseAmt = amtRequest("Please enter purchase amount: ");
            double paymentAmt = amtRequest("Please enter payment amount: ");
            ChangeDue(purchaseAmt, paymentAmt);
        }

        static double amtRequest(string prompt)
        {
            double amt = 0;
            do
            {
                try
                {
                    Console.Write(prompt);
                    amt = double.Parse(Console.ReadLine());
                    if (amt <= 0)
                    {
                        Console.WriteLine("Please enter an amount greater than 0.\n");
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message + "\n");
                }
                
            } while (amt <= 0);

            return amt;
        }

        static double Convert(double change, double denomination, string currency)
        {
            if ((change / denomination) >= 1)
            {
                Console.WriteLine($"{currency} owed: {(int)(change / denomination)}");
            }
            change = change % denomination;
            return Math.Round(change, 2);
        }

        static void ChangeDue(double purchase, double payment)
        {

            if (payment == purchase)
            {
                Console.WriteLine("Thank you for paying an exact amount! Have a nice day!");
            }
            else
            {
                while (payment - purchase < 0)
                {
                    Console.WriteLine("Sorry, thats not enough money to pay for this transaction.\n");
                    purchase = amtRequest("Please enter purchase amount: ");
                    payment = amtRequest("Please enter payment amount: ");
                }
                double change = payment - purchase;
                Console.WriteLine($"Change due: {Math.Round(change, 2)}");
                change = Convert(change, 20, "Twenties");
                change = Convert(change, 10, "Tens");
                change = Convert(change, 5, "Fives");
                change = Convert(change, 1, "Ones");
                change = Convert(change, .25, "Quarters");
                change = Convert(change, .10, "Dimes");
                change = Convert(change, .05, "Nickles");
                change = Convert(change, .01, "Pennies");
            }
        }
    }
}
