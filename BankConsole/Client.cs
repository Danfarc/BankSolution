using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole
{
    public class Client : User, IPerson
    {
        //Propiedad
        public char TaxRegime { get; set; }

        public Client(){}

        // base referencia al constructor de padre
        public Client(int ID, string Name, string Email, decimal Balance, char taxRegime) : base(ID, Name, Email, Balance)
        {
            this.TaxRegime = taxRegime;
            SetBalance(Balance);
        }

        //Override es para sobre escribir el metodo padre
        public override void SetBalance(decimal amount)
        {
            base.SetBalance(amount);
            
            if(this.TaxRegime.Equals('M')) 
            {
                Balance += (amount * 0.02m);
            }
        }

        public override string ShowData()
        {
            return base.ShowData()+ $", Regimen Fiscal: {this.TaxRegime}";
        }

        public string GetName()
        {
            return this.Name;
        }
        public string GetCountry()
        {
            return "Mexico";
        }

    }
}
