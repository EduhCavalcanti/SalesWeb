
using Microsoft.EntityFrameworkCore;
using SalesWeb.Data;
using SalesWeb.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalesWeb.Services{
    public class  DepartmentService
    {
        private readonly SalesWebContext _context;

        public DepartmentService (SalesWebContext context)
        {
            this._context = context;
        }
        //Quando método for assíncrono tem que usar o Taks
        public async Task<List<Department>>  FindAll()
        {
            //Fazendo uma consulta no banco de dados via context e utilizando o model, e vai retornar ordenado por nome
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}