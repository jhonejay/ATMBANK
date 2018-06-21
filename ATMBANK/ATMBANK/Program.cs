using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ATMBANK
{
    class Program
    {
        double amount = 0;
        double balance = 0;
        double withdraw = 0;
        double currentAmount = 0;
        int pin = 0;
        public void Menu()
     {
            try {
                int option;
                do {

                    Console.WriteLine("****MENU****");
                    Console.WriteLine("[1].Deposit");
                    Console.WriteLine("[2].Withdraw");
                    Console.WriteLine("[3].Check Balance");
                    Console.WriteLine("[4]. EXIT");


                    option = Convert.ToInt32(Console.ReadLine());


                    switch (option)
                    {
                        case 1:
                            Console.Clear();
                            Deposit();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 2:
                            Console.Clear();
                            Withdraw();
                            Console.ReadLine();
                            Console.Clear();
                            break;

                        case 3:
                            Console.Clear();
                            Balance();
                            Console.ReadLine();
                            Console.Clear();
                            break;
                        case 4:
                            Environment.Exit(0);
                            break;


                    }
                } while (option <= 4);
            }catch(Exception e)
            {
                Console.WriteLine("Processing....");
                Thread.Sleep(1500);
                Console.Clear();
                Menu();
            }
            Console.ReadKey();
     }

        public void Deposit()
        {
            if (balance == 0) {
                Console.WriteLine("Enter amount you want to deposit : ");
                amount = Convert.ToInt32(Console.ReadLine());
                balance = amount;
            } else
            {
                newBalance();
            }

        }
        public void Balance()
        {
            Console.WriteLine("Your current balance is {0}", balance );
        
        }
        public void newBalance() {
            
            Console.WriteLine("Enter amount do you want to add");
            int  amount = Convert.ToInt32(Console.ReadLine());
            currentAmount = balance + amount;
      
            Console.WriteLine("Your new Balance is {0}", currentAmount);
            balance = currentAmount;
        }

        public void Withdraw()
        {
            Console.WriteLine("Enter amount you want to widthdraw: ");
            double am = Convert.ToDouble(Console.ReadLine());
            if (am > balance)
            {
                Console.WriteLine("You can't widthdraw greater than your balance");
                return;
            } else if(am<0)
             {
                Console.WriteLine("You can't widthdraw! boang naka!?");
                return;
            }
            else
            {
                balance = balance - am;
                Console.WriteLine("You've successfully widthdraw");
                Console.WriteLine("Processing....");
                Thread.Sleep(1500);
                Console.WriteLine("Your new Balance is {0}", balance);
            }
        }

        public void AccessPin()
        {
            int count = 0;
                bool boo = false;
            do {
                Console.WriteLine("Enter Bank Pin: ");
                int pin = Convert.ToInt32(Console.ReadLine());

                if (pin.ToString().Length > 0 && pin.ToString().Length < 5)
                {
                    if (pin.ToString().Equals("2555"))
                    {
                        boo = true;
                        Console.Clear();
                        Menu();

                    }
                    else
                    {
                        Console.WriteLine("Wrong Pin");
                        boo = false;
                        count++;
                        Console.Clear();
                        if (count == 5)
                        {
                            Console.WriteLine("You have attempted 5 times. Security Breach");
                            Console.WriteLine("Terminating......");
                            Thread.Sleep(1500);
                            Environment.Exit(0);
                        }
                       


                    }
                }
            } while (boo == false);
       
        }
        static void Main(string[] args)
        {
            Program p1 = new Program();
            p1.AccessPin();
            Console.ReadKey();

        }
    }
}
