using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
//Usando para estanciar a classe Departaments de Model
using SalesWeb.Models;

namespace SalesWeb.Controllers {
    //Criando classe Controller de Departaments 
    public class DepartmentsController : Controller { //Controler herdando da classe MVC


        //Método Action (Método que vai listar os departamentos)
        public IActionResult Index() {

            //Criando lista da classe Departaments em Models
            List<Department> list = new List<Department>();

            //Adicionando novos departamentos 
            list.Add(new Department() { Id = 1, Name = "Eletronicos" });
            list.Add(new Department() { Id = 2, Name = "Fashion" });

            //Retornando a lista(dados) do controller para view
            return View(list);
        }
    }
}