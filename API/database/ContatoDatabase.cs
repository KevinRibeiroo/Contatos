using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace API.database
{
    public class ContatoDatabase
    {
        Models.ContatoContext ctt = new Models.ContatoContext();
        public List<Models.TbContato> ListarTodos()
        {
            List<Models.TbContato> contatos = ctt.TbContatos.ToList();
            return contatos;
        }

        public bool ContatoExistente(Models.TbContato contato)
        {
            bool cttRepetido = ctt.TbContatos.Any(x => x.DsNome == contato.DsNome 
                                                    && x.NrTelefone == contato.NrTelefone);
            return cttRepetido;
        }

        public Models.TbContato InserirContato(Models.TbContato contato)
        {
            ctt.TbContatos.Add(contato);
            ctt.SaveChanges();

            return contato;
        }

        public void AlterarContato(Models.TbContato contato)
        {
            Models.TbContato cttAlterar = ctt.TbContatos.First(x => x.PkId == contato.PkId);

            cttAlterar.DsNome = contato.DsNome;
            cttAlterar.DsEmail = contato.DsEmail;
            cttAlterar.NrTelefone = contato.NrTelefone;

            ctt.SaveChanges();
        }

        public void DeletarContato(int contato)
        {
            Models.TbContato cttDeletar = ctt.TbContatos.First(x => x.PkId == contato);
            
            ctt.Remove(cttDeletar);
            ctt.SaveChanges();
        }
    }
}