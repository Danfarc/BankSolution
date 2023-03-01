using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsole
{
    public class Employee : User, IPerson
    {
        //Propiedades
        public string Department { get; set; }

        public Employee(){}
        public Employee(int ID, string Name, string Email, decimal Balance, string Department) : base(ID, Name, Email, Balance)
        {
            this.Department = Department;
            SetBalance(Balance);
        }

        public override void SetBalance(decimal amount)
        {
            base.SetBalance(amount);

            //if (!string.IsNullOrEmpty(this.Department))
            //{
                if (this.Department.Equals("IT"))
                    this.Balance += (amount * 0.05m);
            //}


        }
        public override string ShowData()
        {
            return base.ShowData() + $", Departamento: {this.Department}";
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
