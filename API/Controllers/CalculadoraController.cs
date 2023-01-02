using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace API.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    public class CalculadoraController : ControllerBase
    {
        [HttpGet("{a}/{b}")]
        public int Somar(int a, int b)
        {
            return a + b;
        }

        [HttpGet("multiplicar/{a}/{b}")]
        public int Multiplicar(int a, int b)
        {
            return a * b;
        }

        [HttpPost]
        public CalcRes Dividir(CalcModel m)
        {
            CalcRes Resp = new CalcRes{};
            Resp.R = m.A / m.B;
            return Resp;
        }
    }
}