using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundoLivraria
{
    class Repositor : IFuncionario
    {
        /* public string Nome { get; }
         public string Utilizador { get; }
         public string Password { get; }
         public string Cargo => "Repositor";
         public bool Logado { get; set; }
        */

        public string Nome { get; }
        public string Utilizador { get; } 
        private string Password { get; } 

        public string Cargo => "Repositor";
        public bool Logado { get; set; }

        string IFuncionario.Password => Password;

        //construtor da classe repositor
        public Repositor(string nome, string utilizador, string password)
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
