using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Ex14_SimpleAccount
{
    public class BankAccount
    {

        
        public string Name { get; set; }

        private double _balance;
        public double Balance { get { return _balance; } }

        private bool _locked;

        // Constructors
        public BankAccount(double balance)
        {
            this._balance = balance;      
        }

        public BankAccount(string name, double balance)
        {
            this.Name = name;
            this._balance = balance;         
        }

        public BankAccount(string name, double balance, bool locked)
        {
            this.Name = name;
            this._balance = balance;
            this._locked = locked;
        }

        // Må ikke være i stand til at indsætte på en låst konto
        public void Deposit(double amount)
        {     
            if (_locked)
            {
                Console.Write("Din konto er låst - du kan ikke indsætte penge");
                return;
            }
            this._balance += amount;     
        }

        // Må ikke trække flere penge, end der er på bankkontoen
        // Må ikke trække fra en låst bankkonto
        public void Withdraw(double amount)
        {
            if (_balance < amount)
            {
                Console.WriteLine("Du har desværre ikke penge nok til denne handling");
                return;
            }
            if (_locked)
            {
                Console.WriteLine("Din konto er låst - du kan ikke trække penge");
                return;
            }
            this._balance -= amount;
        }

        public void ChangeLockState()
        {
            if (_locked == true) 
            { _locked = false; }

            else if (_locked == false)
            { _locked = true; }
        }

        public override string ToString()
        {
            string title = $"Name: {Name}, Balance: {Balance}";
            return title;
        }



    }
}
