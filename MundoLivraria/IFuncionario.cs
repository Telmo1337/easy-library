using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MundoLivraria
{
    interface IFuncionario
    {
        string Nome { get; }
        string Utilizador { get; }
        string Password { get; }
        string Cargo { get; }

        bool Logado { get; set; }
        bool ValidarLogin(string utilizador, string password);
    }
}
