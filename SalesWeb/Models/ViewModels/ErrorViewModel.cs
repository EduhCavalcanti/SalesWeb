using System;

namespace SalesWeb.Models.ViewModels {
    //Classe reponsável pelos erros personalizados do serviço
    public class ErrorViewModel {
        //Id interno criado pelo MVC
        public string RequestId { get; set; }
        //Para acrescentar uma mensagem customizada messe objeto
        public string Message { get; set; }

        //função para retornar se ele existe 
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}