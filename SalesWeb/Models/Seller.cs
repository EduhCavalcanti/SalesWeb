using System;
using System.Collections.Generic;

//Classe vendedor 
namespace SalesWeb.Models
{
    public class Seller
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public double BaseSalary { get; set; }
        //Fazendo associação de vendedores(Saller) possui 1 Departament(Departments)
        public Department Department { get; set; }
        //Fazendo associação de 1 vendedor(Seller) para varias vendas(SalesRecord)
        public ICollection<SalesRecord> Sales { get; set; } = new List<SalesRecord>(); //Instanciando lista com coleção de vendas


        //Criando construtor vázio (Necessário, pois vai criar um construtor com argumentos)
        public Seller()
        {
        }

        //Criando construtor com argumentos
        public Seller(int id, string name, string email, DateTime birthDate, double baseSalary, Department department)
        {
            this.Id = id;
            this.Name = name;
            this.Email = email;
            this.BirthDate = birthDate;
            this.BaseSalary = baseSalary;
            this.Department = department;
        }




    }
}