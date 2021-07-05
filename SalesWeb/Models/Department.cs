using System;
using System.Linq;
using System.Collections.Generic;

namespace SalesWeb.Models {
    //Classe Departamento
    public class Department {
        //Atributos da classe
        public int Id { get; set; }
        public string Name { get; set; }
        //Fazendo associação com outra classe, de 1 pra muitos > 1 depatamento(Department pode ter vários vendedores(Seller)
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>(); //Instanciando lista com coleção de vendedores
    

        //Criando construtor vázio (Necessário, pois vai criar um construtor com argumentos)
        public Department(){ }

        //Criando construtor com argumentos
        public Department(int id, string name) {
            this.Id = id;
            this.Name = name;
        }

        //Método para adicionar um vendedor
        public void AddSeller(Seller seller)
        {
            Sellers.Add(seller);
        }

        //Método para retornar total de vendas do Departamento em um período de tempo
        public double TotalSales(DateTime initial, DateTime final)
        {
            //Reaproveitando método da classe Seller para somar todos os vendedores no periodo de tempo da classe departamento
            return Sellers.Sum(seller => seller.TotalSales(initial, final)); //TotalSales é um método para somar em periodo de tempo
        }
    
    }
}