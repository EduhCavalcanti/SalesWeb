using System;
namespace SalesWeb.Services.Exception
{
    //Classe para tratamento de erro 
    public class IntegrityException : ApplicationException
    {
        //contrutor básico, passando a message para classe base
        public IntegrityException (string message) : base(message)
        {
        }
    }
}