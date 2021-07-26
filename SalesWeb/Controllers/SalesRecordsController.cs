
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using SalesWeb.Services;
using System.Linq;

namespace SalesWeb.Controllers
{
    public class SalesRecordsController : Controller
    {
        private readonly SalesRecordService _salesRecordService;

        public SalesRecordsController(SalesRecordService salesRecordService)
        {
            _salesRecordService = salesRecordService;
        }

        public  IActionResult Index()
        {
            return View();
        }

        //Método para busca simples 
        public async Task<IActionResult> SimpleSearch(DateTime? minDate, DateTime? maxDate)
        {
            //Se o usuário não colocar a data minima, o sistema vai pegar a data do começo do ano 
            if (!minDate.HasValue) 
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            //Se o usuário não passar nenhuma data maxima, o sistema vai colocar data atual
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            //Vai retornar para view
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            //Vai consultar no findByDate passando os parâmetros que foram passado no view
            var result = await _salesRecordService.FindByDate(minDate, maxDate);
            return View(result);

        }

        //Método para busca em grupo 
        public async Task<IActionResult> GroupingSearch(DateTime? minDate, DateTime? maxDate)
        {
            //Se o usuário não colocar a data minima, o sistema vai pegar a data do começo do ano 
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }
            //Se o usuário não passar nenhuma data maxima, o sistema vai colocar data atual
            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }
            //Vai retornar para view
            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            //Vai consultar no findByDate passando os parâmetros que foram passado no view
            var result = await _salesRecordService.FindByDateGrouping(minDate, maxDate);
            return View(result);
        }





    }
}