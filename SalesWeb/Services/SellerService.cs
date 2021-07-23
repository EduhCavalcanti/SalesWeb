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
        public async Task<List<Seller>> FindAll()
        {
            //Vai acessar a fonte de dados relacionado a tabela de vendedores
            return await _context.Seller.ToListAsync();//E vai converter para uma lista => ToList()
        }

        //Método que vai inserir um novo vendedor no banco de dados
        public async Task Insert (Seller obj)
        {
            //Vai inserir esse obj no banco de dados
            //obj.Department = _context.Department.First();//(Provisório) Vai pegar o primeiro departamento para incluir no DepartmentId
            _context.Add(obj);
            await _context.SaveChangesAsync();//Para confirmar a criação no banco de dados
        }

        //Método que vai procurar por id
        public async Task<Seller> FindById(int id)
        {
            // Se tiver um id válido vai retornar o Id do Seller
            //Para incluir o departamento junto tem que colocar o include >Válido para a página de detalhes
            return await _context.Seller.Include(obj => obj.Department).FirstOrDefaultAsync(obj => obj.Id == id);
        }

        //Método para remover o vendendor 
        public async Task Remove(int id)//Vai receber um id para remover o seller correto
        {
            try 
            { 
            //Vai pegar o obj(Seller) de acordo com com parametro 
            var obj = await _context.Seller.FindAsync(id);
            //Com obj na mão,vamos remover o seller pelo id que foi informado no parâmetro acima
            _context.Seller.Remove(obj);
            //Para confirmar a remoção no banco de dados
            await _context.SaveChangesAsync();
            }
            //Se não conseguir excluir 
            catch(DbUpdateException e)
            {
                //Vai lançar a excessão em nivel de serviço
                throw new IntegrityException("Não é possível excluir vendedor(a)");
            }
        }

        //Método para atualizar o seller no banco de dados
        public async Task Update(Seller obj)
        {
            //vai verificar se o id passado já existe no banco
            bool hasAny = await _context.Seller.AnyAsync(x => x.Id == obj.Id);
            if (!hasAny)// Verifica se existe no banco de dados, foi passado id no parâmetro
            {
                //Vai lançar uma excessão
                throw new NotFoundException("Id não foi encontrado");
            }
            try { 
            //Se passar pela condição, vai atualizar o seller
            _context.Update(obj);
            await _context.SaveChangesAsync();
            }//Se acontecer alguma excessão (error) iremos tratar 
            catch (DbUpdateConcurrencyException e)
            {
                //Vai relançar uma outra excessão
                throw new DbConcurrencyException(e.Message);

            }
        }
    }
}
