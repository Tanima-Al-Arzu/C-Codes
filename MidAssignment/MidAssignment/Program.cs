using System;

namespace MidAssignment
{
    class Address
    {
        private int houseNo, roadNo;
        private string city;
        public string country;
        public Address(int houseNo, int roadNo, string city, string country)
        {
            this.houseNo = houseNo;
            this.roadNo = roadNo;
            this.city = city;
            this.country = country;
        }
        public int HouseNo
        {
            set { this.houseNo = value; }
            get { return this.houseNo; }
        }
        public int RoadNo
        {
            set { this.roadNo = value; }
            get { return this.roadNo; }
        }
        public string City
        {
            set { this.city = value; }
            get { return this.city; }
        }
        public string Country
        {
            set { this.country = value; }
            get { return this.country; }
        }
        public void GetAddress()
        {

            Console.WriteLine("Address:House No-{0}\nRoad No-{1}\nCity-{2}\nCountry-{3}\n", this.houseNo, this.roadNo, this.city, this.country);

        }
    }

    class Bank
    {
        private Account[] myBank;
        private string bankName;
        public Bank(string name, int size)
        {
            this.bankName = name;
            this.myBank = new Account[size];
            //  Console.WriteLine("Bank Name:" + name + "  Size:" + size);
        }
        public string Name
        {
            set { this.bankName = value; }
            get { return this.bankName; }
        }
        public Account[] Accounts
        {
            get { return this.myBank; }
        }
        public void AddAccount(Account account)
        {
            for (int i = 0; i < myBank.Length; i++)
            {
                if (myBank[i] == null)
                {
                    myBank[i] = account;
                    break;
                }
            }
        }
        public void DeletAccount(int accountNumber)
        {
            for (int i = 0; i < myBank.Length; i++)
            {
                if (myBank[i] == null)
                {
                    continue;
                }
                else if (myBank[i].AccountNumber == accountNumber)
                {
                    myBank[i] = null;
                    Console.WriteLine("Account Deleted\n");
                    for (int j = i; j < myBank.Length - 1; j++)
                    {
                        myBank[j] = myBank[j + 1];
                    }
                    break;
                }
            }

        }
        /*
                public void PrintAllAccount()
                {
                    for (int i = 0; i < myBank.Length; i++)
                    {
                        if (myBank[i] == null)
                        {
                            continue;
                        }
                        myBank[i].ShowAccountInformation();
                    }
                }
        */

        public void Transaction(int transactionType, int amount)
        {
            Console.WriteLine();
        }
        public void PrintAccountDetails()
        {
            Console.WriteLine("Bank Name: " + bankName);


        }

    }

    class Account
    {
        private int accountNumber;
        private string accountName;
        private double balance;
        private Address address;
        public Account(int accountNumber, string accountName, double balance, Address address)
        {
            this.accountNumber = accountNumber;
            this.accountName = accountName;
            this.balance = balance;
            this.address = address;
        }
        public int AccountNumber
        {
            set { this.accountNumber = value; }
            get { return this.accountNumber; }
        }
        public string AccountName
        {
            set { this.accountName = value; }
            get { return this.accountName; }
        }
        public double Balance
        {
            set { this.balance = value; }
            get { return this.balance; }
        }
        public Address Address
        {
            set { this.address = value; }
            get { return this.address; }
        }

        public void Deposit(double x)
        {
            Balance = x + Balance;
            Console.WriteLine(x + " Taka deposited successfully.");
            Console.WriteLine("Balance After deposit:" + Balance);
        }
        public Boolean Withdraw(double y)
        {
            if (Balance >= y)
            {
                Balance = (Balance - y);
                Console.WriteLine(y + " Taka withdrawn successfully.");
                Console.WriteLine("Balance AfterWithdraw:" + Balance);
                return true;
            }
            else
            {
                Console.WriteLine("Withdrawl of money can not possible.");
                return false;
            }
        }
        public void Transfer(double amount, Account receiver)
        {
            if (this.Withdraw(amount)) ;
            {
                receiver.Deposit(amount);
            }
            Balance = (Balance - amount);
            Console.WriteLine(amount + " Taka Transferred Successfully.");
            Console.WriteLine("Transfer:" + Balance);
        }


        public void ShowAccountInformation()
        {
            //Console.WriteLine("Account No:"+this.accountNumber+"\nAccount Name:"+this.accountName+"\nBalance:"+this.balance);
            Console.WriteLine("Account No:{0}\nAccount Name:{1}\nBalance:{2}", this.accountNumber, this.accountName, this.balance);
            this.address.GetAddress();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            //1-1 Relation
            //Address address1 = new Address(20,10,"Dhaka");
            //Account account1 = new Account(1001,"Shakib",2000,address1);
            //account1.PrintAccount();
            //Account account2 = new Account(2002, "Tamim", 3000, new Address(40, 30, "Chittagong"));
            //account2.PrintAccount();
            //Console.WriteLine(account2.Address.City);
            //1-* Relation
            Bank ourBank = new Bank("Developers Bank", 5);

            // ourBank.AddAccount(new Account(1001, "Shakib", 2000, new Address(20, 10, "Dhaka")));
            //     ourBank.AddAccount(new Account(2002, "Tamim", 3000, new Address(40, 30, "Chittagong")));
            //        ourBank.AddAccount(new Account(3003, "Mushfiq", 4000, new Address(40, 30, "Chittagong")));
            //ourBank.PrintAllAccount();
            //       ourBank.SearchAccount(2002);
            Account a = new Account(2, "Bank", 500, new Address(20, 10, "Dhaka", "Bangladesh"));
            a.ShowAccountInformation();
            a.Deposit(500);
            a.Withdraw(100);
            ourBank.PrintAccountDetails();


            Console.ReadKey();
        }
    }
}
