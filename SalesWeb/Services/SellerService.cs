using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWeb.Data;
using SalesWeb.Models;

namespace SalesWeb.Services
{
    public class SellerService
    {
        //Dependencia para MVC context -- DbContext banco de dados
        private readonly SalesWebContext _context;

        //Construtor para injeção de dependência
        public SellerService(SalesWebContext context)
        {
            this._context = context;
        }

        //Método para retornar a lista com todos o vendedores
        public List<Seller> FindAll()
        {
            //Vai acessar a fonte de dados relacionado a tabela de vendedores
            return _context.Seller.ToList();//E vai converter para uma lista => ToString
        }

        //Método que vai inserir um novo vendedor no banco de dados
        public void Insert (Seller obj)
        {
            //Vai inserir esse obj no banco de dados
            _context.Add(obj);
            _context.SaveChanges();//Para confirmar a criação no banco de dados
        }
    }
}
