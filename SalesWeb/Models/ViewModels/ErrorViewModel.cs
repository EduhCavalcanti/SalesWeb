using System;

namespace SalesWeb.Models.ViewModels {
    //Classe repons�vel pelos erros personalizados do servi�o
    public class ErrorViewModel {
        //Id interno criado pelo MVC
        public string RequestId { get; set; }
        //Para acrescentar uma mensagem customizada messe objeto
        public string Message { get; set; }

        //fun��o para retornar se ele existe 
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}