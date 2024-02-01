using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundoLivraria
{
    class Gerente : IFuncionario
    {
        public string Nome { get; }
        public string Utilizador { get; }
        public string Password { get; }
        public string Cargo => "Gerente";

        public bool Logado { get; set; }

        //construtor classe gerente
        public Gerente(string nome, string utilizador, string password)
        {
            Nome = nome;
            Utilizador = utilizador;
            Password = password;
        }

        public bool ValidarLogin(string utilizador, string password)
        {
            return Utilizador == utilizador && Password == password;
        }


    }
}
