
using SalesWeb.Data;
using SalesWeb.Models;
using System.Collections.Generic;
using System.Linq;

namespace SalesWeb.Services{
    public class  DepartmentService
    {
        private readonly SalesWebContext _context;

        public DepartmentService (SalesWebContext context)
        {
            this._context = context;
        }

        public List<Department>  FindAll()
        {
            //Fazendo uma consulta no banco de dados via context e utilizando o model, e vai retornar ordenado por nome
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}