using System;

namespace SalesWeb.Models.Enums
{
    //Vai ser um tipo enumerado
    public enum SaleStatus : int 
    {
        Pending = 0, //Pendente
        Billed = 1, //Faturado
        Canceled = 2, //Cancelado
    }
}