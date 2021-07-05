using System;
using SalesWeb.Models.Enums;

//Classe referente a data da venda
namespace SalesWeb.Models
{
    public class SalesRecord
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Amount { get; set; }
        public SaleStatus Status { get; set; } // Tipo enumerado conforme foi criado 

        //Fazendo associação de vendas(SalesRecord) possui 1 vendendor(Seller)
        public Seller Seller { get; set; }


        //Criando construtor vázio (Necessário, pois vai criar um construtor com argumentos)
        public SalesRecord()
        {
        }

        //Criando construtor com argumentos
        public SalesRecord(int id, DateTime date, double amount, SaleStatus status, Seller seller)
        {
            this.Id = id;
            this.Date = date;
            this.Amount = amount;
            this.Status = status;
            this.Seller = seller;
        }
    }
}