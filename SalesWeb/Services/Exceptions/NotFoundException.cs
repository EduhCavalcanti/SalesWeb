using System;


namespace SalesWeb.Services.Exception
{
    //Classe usada para repassar uma excessão personalizada >>Usada para tratrar exclusivamente essa excessão
    public class NotFoundException : ApplicationException
    {
        //contrutor básico, passando a message para classe base
        public NotFoundException(string message ) : base(message)
        {

        }

    }
}