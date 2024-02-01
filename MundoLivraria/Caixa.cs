using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MundoLivraria
{
    class Caixa : IFuncionario
    {
        public string Nome { get; }
        public string Utilizador { get; }
        public string Password { get; }
        public string Cargo => "Caixa";

        public bool Logado { get; set; }


        //construtor caixa 
        public Caixa(string nome, string utilizador, string password)
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