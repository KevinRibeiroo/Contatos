using System.Text.RegularExpressions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace API.Business
{
    public class ContatoBusiness
    {
        database.ContatoDatabase  cttDB = new database.ContatoDatabase();

        public Models.TbContato InserirContato(Models.TbContato contato)
        {
            if (cttDB.ContatoExistente(contato))
                throw new ArgumentException("Este registro já foi inserido");

            if (string.IsNullOrEmpty(contato.DsNome))
                throw new ArgumentException("O campo de nome é obrigatório");
            else 
            {
                string[] SobreNome = contato.DsNome.Trim().Split();
                if (SobreNome.Length < 2)
                {
                    throw new ArgumentException("É necessário inserir um sobrenome");
                }
            }

            if (string.IsNullOrEmpty(contato.NrTelefone))
                throw new ArgumentException("O campo de telefone é obrigatório");

            if (! DateTime.TryParse(contato.DtNascimento.ToString(), out DateTime Data))
                throw new ArgumentException("Data nascimento inválida");

            if (! string.IsNullOrEmpty(contato.DsEmail))
            {
                string RegexEmail = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$";
                bool emailValid = Regex.IsMatch(contato.DsEmail,RegexEmail);

                if (emailValid)
                    throw new ArgumentException("E-mail inválido");
            }    
            
            Models.TbContato ctt = cttDB.InserirContato(contato);
            return ctt;
        }

        public void AlterarContato(Models.TbContato contato)
        {
             if (string.IsNullOrEmpty(contato.DsNome))
                throw new ArgumentException("O campo de nome é obrigatório");
            else 
            {
                string[] SobreNome = contato.DsNome.Trim().Split();
                if (SobreNome.Length < 2)
                {
                    throw new ArgumentException("É necessário inserir um sobrenome");
                }
            }

            if (string.IsNullOrEmpty(contato.NrTelefone))
                throw new ArgumentException("O campo de telefone é obrigatório");
            
            if (! DateTime.TryParse(contato.DtNascimento.ToString(), out DateTime Data))
                throw new ArgumentException("Data nascimento inválida");
            
            cttDB.AlterarContato(contato);
        }
    }
}