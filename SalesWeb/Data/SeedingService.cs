using System;
using System.Linq;
using SalesWeb.Models;
using SalesWeb.Models.Enums;

//Classe para popular o banco de dados
namespace SalesWeb.Data
{
    public class SeedingService
    {
        //Registrando uma dependência com DbContext
        private SalesWebContext _context;

        //Iniciando o construtor para injeção de dependência
        public SeedingService (SalesWebContext context)
        {
            this._context = context;
        }

        //Método responsável por popular a banco de dados
        public void Seed()
        {
            //Condição para verificar se existe algum dado no banco de dados
            if (_context.Department.Any() || //Any() verifica se existe algo.
                _context.Seller.Any() ||
                _context.SalesRecord.Any())
            {
                return; //O banco de dados já foi populado! (Se existir algum dado ele não vai retornar nada)
            }
            //Se não houver dados, iremos popular o banco de dados
            else
            {
                Department d1 = new Department(1, "computers");
                Department d2 = new Department(2, "Fashion");
                Department d3 = new Department(3, "Eletronics");
                Department d4 = new Department(4, "Books");

                Seller s1 = new Seller(1, "Junior Romero", "junior@junio.com", new DateTime(1998,4,28), 1045, d1);
                Seller s2 = new Seller(2, "Bob Romero", "bob@junio.com", new DateTime(1998, 4, 28), 1045, d2);
                Seller s3 = new Seller(3, "Garcia Romero", "garcia@junio.com", new DateTime(1998, 4, 28), 1045, d3);
                Seller s4 = new Seller(4, "Lucca Romero", "lucca@junio.com", new DateTime(1998, 4, 28), 1045, d4);
                Seller s5 = new Seller(5, "Lorena Romero", "lorena@junio.com", new DateTime(1998, 4, 28), 1045, d1);

                SalesRecord a1 = new SalesRecord(1, new DateTime(2021,7,06), 11.000, SaleStatus.Billed, s1);
                SalesRecord a2 = new SalesRecord(2, new DateTime(2012, 3, 06), 5.000, SaleStatus.Billed, s2);
                SalesRecord a3 = new SalesRecord(3, new DateTime(2018, 1, 06), 2.000, SaleStatus.Pending, s4);
                SalesRecord a4 = new SalesRecord(4, new DateTime(2020, 10, 02), 4.000, SaleStatus.Billed, s4);
                SalesRecord a5 = new SalesRecord(5, new DateTime(2020, 7, 29), 4.000, SaleStatus.Canceled, s3);
                SalesRecord a6 = new SalesRecord(6, new DateTime(2020, 12, 15), 4.000, SaleStatus.Pending, s5);
                SalesRecord a7 = new SalesRecord(7, new DateTime(2020, 8, 21), 4.000, SaleStatus.Canceled, s1);

                //Realizando a inclusão no banco de dados
                _context.Department.AddRange(d1,d2,d3,d4); //Método utilizado para incluir varios dados de uma vez no banco
                _context.Seller.AddRange(s1, s2, s3, s4, s5);
                _context.SalesRecord.AddRange(a1, a2, a3, a4, a5, a6, a7);

                //Para salvar as operações acima no banco de dados
                //Vai salvar e confirmar as alterações no banco de dados
                _context.SaveChanges(); 
            }
        }
    }
}