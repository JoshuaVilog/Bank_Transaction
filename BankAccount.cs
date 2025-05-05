using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BankAccount
{
    class BankData
    {
        public int rid { get; set; }
        public int accountId { get; set; }
        public int password { get; set; }
        public double balance { get; set; }

        public BankData(int Rid, int AccountId, int Password, double Balance)
        {
            rid = Rid;
            accountId = AccountId;
            password = Password;
            balance = Balance;
        }
    }
    class BankAccount
    {
        private List<BankData> list = new List<BankData>(){
            new BankData(1, 123456789, 123456, 1000.00),
            new BankData(2, 123654789, 000000, 1000.00),
        };

        public bool checkAccount(int accountId, int password)
        {
            bool isLogin = false;

            if(accountId.ToString() != "" && password.ToString() != "")
            {
                bool isExist = false;
                int selectedPassword = 0;

                for(int index = 0; index < list.Count; index++)
                {
                    if(accountId == list[index].accountId)
                    {
                        isExist = true;
                        selectedPassword = list[index].password;
                        break;
                    }
                }

                if(isExist == true)
                {
                    if(selectedPassword == password)
                    {
                        isLogin = true;
                    }
                }
            }

            return isLogin;
        }

        public double GetBalance(int accountID)
        {
            double balance = 0;

            for(int index = 0; index < list.Count; index++)
            {
                if(accountID == list[index].accountId)
                {
                    balance = list[index].balance;
                    break;
                }
            }

            return balance;
        }

        public void Deposit(int accountID, double amount)
        {
            if(amount == 0 || amount.ToString() == "")
            {
                Console.WriteLine("Please input an amount.");
            } else
            {
                double balance = 0;
                int selected = 0;

                for (int index = 0; index < list.Count; index++)
                {
                    if (accountID == list[index].accountId)
                    {
                        balance = list[index].balance;
                        selected = index;
                        break;
                    }
                }

                balance += amount;

                list[selected].balance = balance;

                Console.WriteLine("Deposit Successfully.");
                Console.WriteLine("Current Balance: " + balance);
            }
        }

        public void Withdraw(int accountID, double amount)
        {
            if (amount == 0 || amount.ToString() == "")
            {
                Console.WriteLine("Please input an amount.");
            } else
            {
                double balance = 0;
                int selected = 0;

                for(int index = 0; index < list.Count; index++)
                {
                    if(accountID == list[index].accountId)
                    {
                        balance = list[index].balance;
                        selected = index;
                        break;
                    }
                }

                if(balance < amount)
                {
                    Console.WriteLine("Your amount is too exceed to your balance.");
                } else
                {
                    balance = balance - amount;
                    list[selected].balance = balance; 

                    Console.WriteLine("Withdraw Successful.");
                    Console.WriteLine("Current Balance: " + balance);
                }
            }
        }
    }
    
}
