using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Models.response
{
    public class ErrorResponse
    {
        public ErrorResponse(Exception ex,int codigo)
        {
            Erro = ex.Message;
        }
        public int Codigo {get; set;}
        public string Erro {get; set;}
    }
}