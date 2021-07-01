using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
//Usando para estanciar a classe Departaments de Model
using SalesWeb.Models;
namespace SalesWeb.Controllers {
    //Criando classe Controller de Departaments 
    public class DepartmentsController : Controller { //Controler herdando da classe MVC


        //Método Action
        public IActionResult Index() {
            //Criando lista da classe Departaments em Models
            List<Department> list = new List<Department>();

            return View();
        }
    }
}