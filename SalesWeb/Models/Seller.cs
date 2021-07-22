using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq; //para usar where

//Classe vendedor 
namespace SalesWeb.Models
{
    public class Seller
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Necessário Nome para prosseguir")]
        [StringLength(60, MinimumLength =5, ErrorMessage ="Tamanho do nome tem que ter de 5 a 60 caracteres")]
        public string Name { get; set; }
        //para validação, utilizar no front asp-validation
        [Required(ErrorMessage ="Necessário Email para prosseguir")]
        [EmailAddress(ErrorMessage ="Necessário email válido")]
        [DataType(DataType.EmailAddress)] //Vai colocar como tipo Email
        public string Email { get; set; }

        [Display(Name = "Birth Date")]//Vai aparece no front da aplicaçãom com o espaço
        [DataType(DataType.Date)]//Vai ficar apenas com a data, tirando as horas que estavam antes
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Base Salary")]
        [DisplayFormat(DataFormatString = "{0:F2}")] //Vai aparecer com duas casas decimais 
        [DataType(DataType.Currency)] //Vai colocar como tipo moeda
        public double BaseSalary { get; set; }

        //Fazendo associação de vendedores(Saller) possui 1 Departament(Departments)
        public Department Department { get; set; }
        //Criando propriedade id do departamento || // Não pode ser null, entity framework não permite ficar null
        public int DepartmentId { get; set; } 
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

        //Método para adicionar uma venda a lista de vendas (Sales<SalesRecord>)
        public void AddSales(SalesRecord sr)
        {
            Sales.Add(sr);
        }

        //Método para remover uma venda a lista de vendas
        public void RemoveSales(SalesRecord sr)
        {
            Sales.Remove(sr);
        }

        //Método para retornar o total de venda em um período de tempo
        public double TotalSales(DateTime initial, DateTime final)
        {
            //Filtrando lista de venda pelo tempo e somando com o montante (amount)| sr = SaleRecord
            return Sales.Where(sr => sr.Date >= initial && sr.Date <= final).Sum(sr => sr.Amount); //Somando com o montante 
        }
    }
}