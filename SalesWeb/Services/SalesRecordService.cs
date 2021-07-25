using Microsoft.AspNetCore.Mvc;
using SalesWeb.Data;
using System.Collections.Generic;
using SalesWeb.Models;
using System;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace SalesWeb.Services
{
    public class SalesRecordService
    {
        private readonly SalesWebContext _context;

        public SalesRecordService(SalesWebContext context)
        {
            this._context = context;
        }

        //Método para retorno das vendas no período passado no parâmetro
        public async Task<List<SalesRecord>> FindByDate(DateTime? minDate, DateTime? maxDate)
        {
            //Vai construir um objeto para fazer consulta pelo DdContex
            var result = from obj in _context.SalesRecord select obj;

            //Se tiver uma data vai fazer consulta passando a logica da data
            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value);
            }
            //Vai retornar a consultado com os Joins necessários
            return await result
                .Include(x => x.Seller)//Vai incluir os Sellers
                .Include(x => x.Seller.Department)//Vai incluir os Departaments
                .OrderByDescending(x => x.Date)// Vai retornar em ordem descrescente
                .ToListAsync(); //Retornar como lista
        }
    }
}