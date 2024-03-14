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

        public static void ExibirListaFuncionarios(List<IFuncionario> funcionarios)
        {
            foreach (var funcionario in funcionarios)
            {
                Console.WriteLine($"\n {funcionario.Cargo}: {funcionario.Nome}");
            }
            Console.WriteLine("================================");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void CriarPerfil(List<IFuncionario> funcionarios)
        {
            Console.WriteLine("========== Criar Perfil ==========");
            Console.Write("Inserir nome do novo funcionário: ");
            string nome = Console.ReadLine();
            Console.Write("Username: ");
            string utilizador = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();
            Console.Write("Selecione o cargo (Caixa, Gerente, Repositor): ");
            string cargo = Console.ReadLine();

            IFuncionario novoFuncionario = null;

            switch (cargo.ToLower())
            {
                case "caixa":
                    novoFuncionario = new Caixa(nome, utilizador, password);
                    break;
                case "gerente":
                    novoFuncionario = new Gerente(nome, utilizador, password);
                    break;
                case "repositor":
                    novoFuncionario = new Repositor(nome, utilizador, password);
                    break;
                default:
                    Console.WriteLine("Cargo não encontrado. Perfil não criado...");
                    return;
            }

            funcionarios.Add(novoFuncionario);

            Console.WriteLine($"\nPerfil de {novoFuncionario.Cargo} '{novoFuncionario.Nome}' criado com sucesso!");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void EliminarPerfil(List<IFuncionario> funcionarios)
        {
            Console.WriteLine("========== Eliminar Perfil ==========");
            Console.Write("Inserir o username do funcionário a eliminar: ");
            string utilizador = Console.ReadLine();

            IFuncionario funcionarioParaEliminar = funcionarios.FirstOrDefault(f => f.Utilizador == utilizador);

            if (funcionarioParaEliminar != null)
            {
                funcionarios.Remove(funcionarioParaEliminar);
                Console.WriteLine($"Perfil de {funcionarioParaEliminar.Cargo} '{funcionarioParaEliminar.Nome}' eliminado com sucesso!");
            }
            else
            {
                Console.WriteLine("Funcionário não encontrado. Nenhum perfil eliminado.");
            }

            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
