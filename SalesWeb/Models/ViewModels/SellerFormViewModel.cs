
using System.Collections.Generic;

namespace SalesWeb.Models.ViewModels
{
    //Classe que vai conter os dados para o formulário
    public class SellerFormViewModel
    {
        //Vai ter que ter o vendedor no formulário
        public Seller Seller { get; set; }
        //Vai ter que ter o departameto para fazer a lista de departamentos
        public ICollection<Department> Departments { get; set; }
    }
}