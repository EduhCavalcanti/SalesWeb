using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SalesWeb.Data;
using SalesWeb.Models;
using Microsoft.EntityFrameworkCore;
using SalesWeb.Services.Exception;

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
            return _context.Seller.ToList();//E vai converter para uma lista => ToList()
        }

        //Método que vai inserir um novo vendedor no banco de dados
        public void Insert (Seller obj)
        {
            //Vai inserir esse obj no banco de dados
            //obj.Department = _context.Department.First();//(Provisório) Vai pegar o primeiro departamento para incluir no DepartmentId
            _context.Add(obj);
            _context.SaveChanges();//Para confirmar a criação no banco de dados
        }

        //Método que vai procurar por id
        public Seller FindById(int id)
        {
            // Se tiver um id válido vai retornar o Id do Seller
            //Para incluir o departamento junto tem que colocar o include >Válido para a página de detalhes
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id == id);
        }

        //Método para remover o vendendor 
        public void Remove(int id)//Vai receber um id para remover o seller correto
        {
            //Vai pegar o obj(Seller) de acordo com com parametro 
            var obj = _context.Seller.Find(id);
            //Com obj na mão,vamos remover o seller pelo id que foi informado no parâmetro acima
            _context.Seller.Remove(obj);
            //Para confirmar a remoção no banco de dados
            _context.SaveChanges();
        }

        //Método para atualizar o seller no banco de dados
        public void Update(Seller obj)
        {
            //vai verificar se o id passado já existe no banco
            if (!_context.Seller.Any(x => x.Id == obj.Id) )//Any() Verifica se existe no banco de dados, foi passado id no parâmetro
            {
                //Vai lançar uma excessão
                throw new NotFoundException("Id não foi encontrado");
            }
            try { 
            //Se passar pela condição, vai atualizar o seller
            _context.Update(obj);
            _context.SaveChanges();
            }//Se acontecer alguma excessão (error) iremos tratar 
            catch (DbUpdateConcurrencyException e)
            {
                //Vai relançar uma outra excessão
                throw new DbConcurrencyException(e.Message);

            }
        }
    }
}
