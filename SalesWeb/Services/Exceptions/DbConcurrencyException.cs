using System;

namespace SalesWeb.Services.Exception
{
    //Classe usada para repassar uma excessão personalizada >>Usada para tratrar exclusivamente essa excessão
    public class DbConcurrencyException : ApplicationException
    {
        //contrutor básico, passando a message para classe base
        public DbConcurrencyException(string message) : base(message)
        {

        }
        
    }
}