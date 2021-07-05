using System.Collections.Generic;

namespace SalesWeb.Models {
    //Classe Departamento
    public class Department {
        //Atributos da classe
        public int Id { get; set; }
        public string Name { get; set; }
        //Fazendo associa��o com outra classe, de 1 pra muitos > 1 depatamento(Department pode ter v�rios vendedores(Seller)
        public ICollection<Seller> Sellers { get; set; } = new List<Seller>(); //Instanciando lista com cole��o de vendedores
    

        //Criando construtor v�zio (Necess�rio, pois vai criar um construtor com argumentos)
        public Department(){ }

        //Criando construtor com argumentos
        public Department(int id, string name) {
            this.Id = id;
            this.Name = name;
        }
    
    }
}