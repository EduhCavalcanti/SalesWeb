
using System;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace SalesWeb.Controllers
{
    public class SalesRecordsController : Controller
    {
        public  IActionResult Index()
        {
            return View();
        }

        //Método para busca simples 
        public IActionResult SimpleSearch()
        {
            return View();

        }

        //Método para busca em grupo 
        public IActionResult GroupingSearch()
        {
            return View();

        }





    }
}