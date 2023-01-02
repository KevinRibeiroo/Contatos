using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContatoController : ControllerBase
    {
        database.ContatoDatabase cttDB = new database.ContatoDatabase();
        Business.ContatoBusiness cttBS = new Business.ContatoBusiness();

        [HttpGet]
        public List<Models.TbContato> GetAll()
        {
            List<Models.TbContato> contatos = cttDB.ListarTodos();
            return contatos;
        }

        [HttpPost]
        public ActionResult<Models.TbContato> PostContato(Models.TbContato contato)
        {
            try
            {
                cttBS.InserirContato(contato);
                return contato;   
            }
            catch (System.Exception ex)
            {
                return new BadRequestObjectResult(
                    new Models.response.ErrorResponse(ex, 400)
                );
            }
        }

        [HttpPut]
        public void PutContato(Models.TbContato contato)
        {
         cttDB.AlterarContato(contato);
        }

        [HttpDelete("{contato}")]
        public void DeleteContato(int contato)
        {
           cttDB.DeletarContato(contato);
        }
    }
}