using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using Newtonsoft.Json;

namespace BankConsole
{
    public class User //: //IPerson //APerson, 
    {

        // Propiedades
        /*
        public int ID {get; set;}
        public string Name { get; set; }
        public string Email { get; set; }
        public decimal Balance { get; set; }
        public DateTime RegisterDate { get; set; }
        */
        /*Encapsulado*/
        // Decorador o Anotacion
        /*
        [JsonProperty]
        private int ID {get; set;}
        [JsonProperty]
        private string Name { get; set; }
        [JsonProperty]
        private string Email { get; set; }
        [JsonProperty]
        private decimal Balance { get; set; }
        [JsonProperty]
        private DateTime RegisterDate { get; set; }
        */
        // Protected para que pueda ser heredado
        [JsonProperty]
        protected int ID { get; set; }
        [JsonProperty]
        protected string Name { get; set; }
        [JsonProperty]
        protected string Email { get; set; }
        [JsonProperty]
        protected decimal Balance { get; set; }
        [JsonProperty]
        protected DateTime RegisterDate { get; set; }



        //Constructor
        public User() { }
        public User(int ID, string Name, string Email, decimal Balance)
        {
            this.ID = ID;
            this.Name = Name;
            this.Email = Email;
            //this.Balance = Balance;
            //SetBalance(Balance);
            this.RegisterDate = DateTime.Now;
        }

        public DateTime GetRegisterDate()
        {
            return this.RegisterDate;
        }
        //Metodos
        // Virtual se utiliza para que los hijos puedan hacer sobrecarga a este metodo
        public virtual string ShowData()
        {
            //return "Nombre: " + this.Name + ", Email: " + this.Email + ", Saldo: " + this.Balance + ", Fecha de registro: " + this.RegisterDate ;
            //Simbolo de interpolacion $
            return $"ID: {this.ID}, Nombre: {this.Name} , Email: {this.Email}, Saldo: {this.Balance} , Fecha de registro: {this.RegisterDate.ToShortDateString()}";

        }
        //Sobrecarga
        public string ShowData(string initialMessage)
        {

            return $"{initialMessage} -> Nombre: {this.Name} , Email: {this.Email}, Saldo: {this.Balance} , Fecha de registro: {this.RegisterDate.ToShortDateString()}";

        }

        public virtual void SetBalance(decimal amount)
        {
            //Declaro variables
            decimal quantity = 0;

            if (amount < 0)
                quantity = 0;
            else
                quantity = amount;

            this.Balance += quantity;
        }

        public int GetID()
        {
            return this.ID;
        }

        // Clase Abstracta Implementa solo los metosos abstractos
        /*
        public  string GetName()
        {
            return this.Name;
        }
        public string GetCountry()
        {
            return "Mexico";
        }
        */
    }
}