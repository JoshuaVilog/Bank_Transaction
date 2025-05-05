using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAccount
{

    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount();

            bool isExitToProgram = false;
            do
            {
                Console.WriteLine("Choose an option:");
                Console.WriteLine("[A] Login Account.");
                Console.WriteLine("[E] Exit to program.");
                string str = Console.ReadLine();
                
                if(str == "E" || str == "e"){
                    isExitToProgram = true;
                } else if(str == "A" || str == "a")
                {
                    bool isLogin = false;
                    int loginAccountId = 0;

                    do
                    {
                        Console.WriteLine("Enter your account ID:");
                        int accountId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter Password:");
                        int password = Convert.ToInt32(Console.ReadLine());

                        bool check = account.checkAccount(accountId, password);

                        if(check == true)
                        {
                            isLogin = true;
                            loginAccountId = accountId;
                            Console.WriteLine("Login Successfully");
                        } else if(check == false)
                        {
                            Console.WriteLine("Please check your account ID and password.");
                        }

                    } while (isLogin != true);

                    bool isLogout = false;
                    do
                    {
                        Console.WriteLine("=======================================");
                        Console.WriteLine("Choose an option:");
                        Console.WriteLine("[A] Deposit.");
                        Console.WriteLine("[B] Withdraw.");
                        Console.WriteLine("[C] Balance Inquiry");
                        Console.WriteLine("[D] Logout.");
                        string choose = Console.ReadLine();

                        switch (choose)
                        {
                            case "A": case "a":
                                Console.WriteLine("Enter amount to deposit:");
                                double amountToDeposit = Convert.ToDouble(Console.ReadLine());

                                account.Deposit(loginAccountId, amountToDeposit);
                                break;
                            case "B": case "b":

                                Console.WriteLine("Enter amount to withdraw:");
                                double amountToWithdraw = Convert.ToDouble(Console.ReadLine());

                                account.Withdraw(loginAccountId, amountToWithdraw);
                                break;
                            case "C": case "c":
                                Console.WriteLine("Your balance is " + account.GetBalance(loginAccountId));
                                break;
                            case "D": case "d":

                                isLogout = true;
                                break;
                            default:
                                Console.WriteLine("Invalid input");
                                break;

                        }

                    } while (isLogout != true);
                }

            } while (isExitToProgram != true);
            Console.WriteLine("Tap to exit again.");

            Console.ReadKey();
        }
    }
}
