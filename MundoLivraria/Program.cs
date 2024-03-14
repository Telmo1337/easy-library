using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MundoLivraria
{
    class Program
    {
        static void Main(string[] args)
        {
            //Intro
            Console.WriteLine("\n\n\n           Bem-Vindo MundoLivraria\n");
            Console.WriteLine("      __...--~~~~~-._   _.-~~~~~--...__\r\n    //               `V'               \\\\ \r\n   //                 |                 \\\\ \r\n  //__...--~~~~~~-._  |  _.-~~~~~~--...__\\\\ \r\n //__.....----~~~~._\\ | /_.~~~~----.....__\\\\\r\n====================\\\\|//====================\r\n                    `---`");
            Console.WriteLine("\n            Por favor, aguarde...");
            Thread.Sleep(2000);
            Console.Clear();

            /////////////////////////c+objg
            //LISTA DE FUNCIONARIOS
            List<IFuncionario> funcionarios = new List<IFuncionario>();
            //caixa:
            Caixa caixa1 = new Caixa("João Silva", "joao1", "123");
            Caixa caixa2 = new Caixa("Pedro Fernandes", "pedro1", "234");
            Caixa caixa3 = new Caixa("Inês Costa", "ines1", "567");
            Caixa caixa4 = new Caixa("Rui Pedro Morais", "rui1", "890");

            funcionarios.Add(caixa1);
            funcionarios.Add(caixa2);
            funcionarios.Add(caixa3);
            funcionarios.Add(caixa4);

            //gerente:
            Gerente gerente1 = new Gerente("Maria Castro", "maria1", "123");
            Gerente gerente2 = new Gerente("José Abruzzi", "abruzzi1", "345");

            funcionarios.Add(gerente1);
            funcionarios.Add(gerente2);

            //repositor:
            Repositor repositor1 = new Repositor("Carlos Lopes", "carlos1", "123");
            Repositor repositor2 = new Repositor("Ana Costa", "ana2", "496");
            Repositor repositor3 = new Repositor("Telmo Marques", "telmo1", "234");


            funcionarios.Add(repositor1);
            funcionarios.Add(repositor2);
            funcionarios.Add(repositor3);

            //========================================================================//
            //LISTA DE LIVROS

            List<Livros> livro = new List<Livros>();
            //criação dos livros
            //instock
            Livros livro00 = new Livros("A Cidade das Estrelas", "Valentina Nebula", 14.99, 10, "Fantasia, Drama", "978-3-16-148410-0");
            Livros livro01 = new Livros("O Portal Intergalático", "Zephyr Stellaris", 21.99, 14, "Terror", "978-0-13-149505-0");
            Livros livro02 = new Livros("Máquinas da Eternidade", "Engenius Infinitus", 12.00, 6, "Mistério, Suspense", "978-1-84628-855-9");
            Livros livro03 = new Livros("Cérebro Quântico", "Quantumia A.I.", 9.99, 23, "Ciência", "978-0-9921990-5-7");
            Livros livro04 = new Livros("O Enigma das Esferas Alienígenas", "Xenos Sphere", 16.99, 12, "Ficção Científica", "978-1-93435-785-2");

            //outofstock
            Livros livro30 = new Livros("Algoritmo das Estrelas", "Stellar Code", 18.50, 0, "Aventura", "978-1-90339-952-3");
            Livros livro31 = new Livros("A Órbita do Tempo", "Tempus Chronos", 15.75, 0, "Romance", "978-0-306-40615-7");
            Livros livro32 = new Livros("O Universo dos Bits", "Byte Explorer", 11.25, 0, "Filosofia", "978-0-596-52068-7");
            Livros livro33 = new Livros("Nébula Digital", "Cyber Nebula", 24.99, 0, "Autobiografia", "978-1-56619-909-4");
            Livros livro34 = new Livros("A Conexão Quântica", "Quantum Link", 20.00, 0, "Livros Infantis", "978-0-385-35139-0");
            

            //imprimirlivros IN STOCK
            livro.Add(livro00);
            livro.Add(livro01);
            livro.Add(livro02);
            livro.Add(livro03);
            livro.Add(livro04);

            /*===============================================================*/
            //imprimirlivros OUT OF STOCK
            
            livro.Add(livro30);
            livro.Add(livro31);
            livro.Add(livro32); 
            livro.Add(livro33);
            livro.Add(livro34);

            ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            //////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///
            //menu principal - logins dos funcionários
            while (true)
            {
                Console.WriteLine("========== Menu Principal ==========");
                Console.WriteLine("1. Login como Caixa");
                Console.WriteLine("2. Login como Gerente");
                Console.WriteLine("3. Login como Repositor");
                Console.WriteLine("0. Sair");
                Console.WriteLine("====================================");
                Console.WriteLine("========== MundoLivraria ===========");

                Console.Write("Escolha uma opção (0-3): ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        if (RealizarLogin(funcionarios, "Caixa", livro))
                        {
                            Caixa caixaLogado = (Caixa)funcionarios.Find(f => f.Cargo == "Caixa" && f.Logado);
                            RealizarTarefasCaixa(caixaLogado, funcionarios, livro);
                        }
                        else
                            Console.WriteLine("Login inválido. Tente novamente.");
                        break;
                    case "2":
                        if (RealizarLogin(funcionarios, "Gerente", livro))
                        {
                            Gerente gerenteLogado = (Gerente)funcionarios.Find(f => f.Cargo == "Gerente" && f.Logado);
                            RealizarTarefasGerente(gerenteLogado, funcionarios, livro);
                        }      
                        else
                            Console.WriteLine("Login inválido. Tente novamente.");
                        break;
                    case "3":
                        if (RealizarLogin(funcionarios, "Repositor", livro))
                        {
                            Repositor repositorLogado = (Repositor)funcionarios.Find(f => f.Cargo == "Repositor" && f.Logado);
                            RealizarTarefasRepositor(repositorLogado, livro);
                        }
                            
                        else
                            Console.WriteLine("Login inválido. Tente novamente.");
                        break;
                    case "0":
                        Console.WriteLine("A sair do programa... Até logo!");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }


        //CAIXA
        static void RealizarTarefasCaixa(Caixa caixa, List<IFuncionario> funcionarios, List<Livros> livros)
        {
            while (true)
            {
                Console.WriteLine("========== Menu Caixa ==========");
                Console.WriteLine("1. Exibir Lista de Livros");
                Console.WriteLine("2. Realizar Venda");
                Console.WriteLine("3. Consultar livro por ISBN");
                Console.WriteLine("4. Consultar livro por autor");
                Console.WriteLine("5. Receita");
                Console.WriteLine("0. Sair");
                Console.WriteLine("================================");

                Console.Write("Escolha uma opção (0-5): ");
                string opcao = Console.ReadLine();
                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("1. Livros em Stock");
                        Console.WriteLine("2. Livros Fora de Stock");
                        Console.Write("Escolha uma opção (1-2): ");
                        string subOpcao = Console.ReadLine();
                        if (subOpcao == "1")
                        {
                            Livros.ExibirListaLivros(livros, true);
                        }
                        else if (subOpcao == "2")
                        {
                            Livros.ExibirListaLivros(livros, false);
                        }
                        break;
                    case "2":
                        Console.WriteLine("===== Realizar Venda =====");
                        Console.Write("Insira o ISBN do livro: ");
                        string isbn = Console.ReadLine();
                        Livros livroParaVenda = livros.FirstOrDefault(l => l.ISBN == isbn);

                        if (livroParaVenda != null)
                        {
                            Console.Write("Insira a quantidade a ser vendida: ");

                            if (int.TryParse(Console.ReadLine(), out int quantidade))
                            {
                                Console.Clear();
                                double totalVenda = livroParaVenda.Vender(quantidade);

                                // desconto
                                if (totalVenda >= 50)
                                {
                                    
                                    double totalIvaVenda = totalVenda * 1.23;

                                    double Desconto = totalIvaVenda * 0.10;

                                    double valorFinal = totalIvaVenda - Desconto ;

                                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                                    Console.WriteLine($"Desconto: {Desconto:C2}");
                                    Console.WriteLine($"Valor final: {valorFinal:C2}\n\n");
                                }

                                //infos
                                double totalIvaVenda1 = totalVenda * 1.23;


                                Console.OutputEncoding = System.Text.Encoding.UTF8;
                                Console.WriteLine($"Preço sem IVA: {totalVenda:C2}");
                                Console.WriteLine($"Preço com IVA (23%): {totalIvaVenda1:C2}");




                                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Quantidade inválida...");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado.");
                        }
                        break;
                    case "3":
                        Livros.ConsultarLivroPorISBN(livros);
                        break;
                    case "4":
                        Livros.LivrosPorAutor(livros);
                        break;
                    case "5":
                        Livros.ConsultarTotalLivrosVendidosEReceita(livros);
                        break;
                    case "0":
                        Console.WriteLine("A sair do menu de Caixa...");
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        //GERENTE
        static void RealizarTarefasGerente(Gerente gerente, List<IFuncionario> funcionarios, List<Livros> livros)   
        {
            while (true)
            {
                Console.WriteLine("========== Menu Gerente ==========");
                Console.WriteLine("1. Exibir Lista de Livros");
                Console.WriteLine("2. Exibir Lista de Funcionários");
                Console.WriteLine("3. Criar Perfil");
                Console.WriteLine("4. Eliminar Perfil");
                Console.WriteLine("5. Realizar Venda");
                Console.WriteLine("6. Receita");
                Console.WriteLine("7. Consultar livros ISBN");
                Console.WriteLine("8. Alterar informações de um livro");
                Console.WriteLine("9. Consultar livros por autor");
                Console.WriteLine("0. Sair");
                Console.WriteLine("================================");

                Console.Write("Escolha uma opção (0-9): ");
                string opcao = Console.ReadLine();
                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("1. Livros em Stock");
                        Console.WriteLine("2. Livros Fora de Stock");
                        Console.Write("Escolha uma opção (1-2): ");
                        string subOpcao = Console.ReadLine();
                        if (subOpcao == "1")
                        {
                            Livros.ExibirListaLivros(livros, true);
                        }
                        else if (subOpcao == "2")
                        {
                            Livros.ExibirListaLivros(livros, false);
                        }
                        break;
                    case "2":
                        Console.WriteLine("==== Lista de Funcionários ====");
                        Gerente.ExibirListaFuncionarios(funcionarios);
                        break;
                    case "3":
                        Gerente.CriarPerfil(funcionarios);
                        break;
                    case "4":
                        Gerente.EliminarPerfil(funcionarios);
                        break;
                    case "5":
                        Console.WriteLine("===== Realizar Venda =====");
                        Console.Write("Inserir ISBN do livro: ");
                        string isbn = Console.ReadLine();
                        Livros livroParaVenda = livros.FirstOrDefault(l => l.ISBN == isbn);

                        if (livroParaVenda != null)
                        {
                            Console.Write("Quantidade para a venda: ");

                            if (int.TryParse(Console.ReadLine(), out int quantidade))
                            {
                                Console.Clear();
                                double totalVenda = livroParaVenda.Vender(quantidade);

                                // desconto
                                if (totalVenda > 50)
                                {

                                    double totalIvaVenda = totalVenda * 1.23;

                                    double Desconto = totalIvaVenda * 0.10;

                                    double valorFinal = totalIvaVenda - Desconto;

                                    Console.OutputEncoding = System.Text.Encoding.UTF8;
                                    Console.WriteLine($"Desconto: {Desconto:C2}");
                                    Console.WriteLine($"Valor final: {valorFinal:C2}\n\n");
                                }

                                //infos
                                double totalIvaVenda1 = totalVenda * 1.23;


                                Console.OutputEncoding = System.Text.Encoding.UTF8;
                                Console.WriteLine($"Preço sem IVA: {totalVenda:C2}");
                                Console.WriteLine($"Preço com IVA (23%): {totalIvaVenda1:C2}");

                                Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
                                Console.ReadKey();
                                Console.Clear();
                            }
                            else
                            {
                                Console.WriteLine("Quantidade inválida...");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Livro não encontrado...");
                        }
                        break;
                    case "6":
                        Livros.ConsultarTotalLivrosVendidosEReceita(livros);
                        break;

                    case "7":
                        Livros.ConsultarLivroPorISBN(livros);
                        break;

                    case "8":
                        Livros.AtualizarLivro(livros);
                        break;

                    case "9":
                        Livros.LivrosPorAutor(livros);
                        break;

                    case "0":
                        Console.WriteLine("A sair do menu de Gerente...");
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        //REPOSITOR
        static void RealizarTarefasRepositor(Repositor repositor, List<Livros> livros)
        {
            while (true)
            {
                Console.WriteLine("========== Menu Repositor ==========");
                Console.WriteLine("1. Exibir Lista de Livros");
                Console.WriteLine("2. Stock");
                Console.WriteLine("0. Sair");
                Console.WriteLine("================================");

                Console.Write("Escolha uma opção (0-2): ");
                string opcao = Console.ReadLine();
                Console.Clear();

                switch (opcao)
                {
                    case "1":
                        Console.WriteLine("1. Livros em Stock");
                        Console.WriteLine("2. Livros Fora de Stock");
                        Console.Write("Escolha uma opção (1-2): ");
                        string subOpcao = Console.ReadLine();
                        if (subOpcao == "1")
                        {
                            Livros.ExibirListaLivros(livros, true);

                        }
                        else if (subOpcao == "2")
                        {
                            Livros.ExibirListaLivros(livros, false);

                        }
                        break;
                    case "2":
                        Console.WriteLine("===== Adicionar Stock ou Novo Livro =====");
                        Console.WriteLine("1. Adicionar Stock");
                        Console.WriteLine("2. Adicionar Novo Livro");
                        Console.Write("Escolha uma opção (1-2): ");
                        string subOpcaoAdicionar = Console.ReadLine();

                        switch (subOpcaoAdicionar)
                        {
                            case "1":
                                Console.Clear();
                                Console.Write("Insira o ISBN do livro: ");
                                string isbnAdicionar = Console.ReadLine();
                                Livros livroParaAdicionarStock = livros.FirstOrDefault(l => l.ISBN == isbnAdicionar);

                                if (livroParaAdicionarStock != null)
                                {
                                    Console.Write("Inserir a quantidade a ser adicionada ao stock: ");

                                    if (int.TryParse(Console.ReadLine(), out int quantidadeAdicionar))
                                    {
                                        Console.Clear();
                                        livroParaAdicionarStock.AdicionarStock(quantidadeAdicionar);
                                    }
                                    else
                                    {
                                        Console.WriteLine("Quantidade inválida...");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Livro não encontrado...");
                                }
                                break;
                            case "2":
                                Livros novoLivro = Livros.CriarNovoLivro();
                                livros.Add(novoLivro);
                                break;
                            default:
                                Console.WriteLine("Opção inválida. Tente novamente.");
                                break;
                        }
                        break;
                    case "0":
                        Console.WriteLine("A sair do menu repositor...");
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Opção inválida...");
                        break;
                }
            }
        }


        // introduzir credenciais e verificar
        static bool RealizarLogin(List<IFuncionario> funcionarios, string cargo, List<Livros> livros)
        {
            for (int tentativa = 0; tentativa < 3; tentativa++)
            {
                Console.Clear();
                Console.Write($" ======== {cargo} ========");
                Console.Write($"\n Insira o seu id: ");
                string utilizador = Console.ReadLine();

                Console.Write($" Insira a sua pass: ");
                string password = Console.ReadLine();

                Console.Clear();

                foreach (var funcionario in funcionarios)
                {
                    if (funcionario.Cargo == cargo && funcionario.ValidarLogin(utilizador, password))
                    {
                        Console.WriteLine("\n ==== A dar início ao programa... Aguarde um pouco... ====");
                        Thread.Sleep(2000);
                        Console.Clear();
                        Console.WriteLine($"\n ==== Login bem-sucedido!! {cargo} - {funcionario.Nome} ====");
                        Thread.Sleep(1200);


                        Console.Clear();
                        return true;
                    }
                }

                Console.WriteLine($"\n {3 - (tentativa + 1)} tentativa(s). Tente novamente...");
                Thread.Sleep(1500);
            }

            Console.Clear();
            Console.WriteLine("\n Número de tentativas excedido. Encerrar o programa...");
            Thread.Sleep(2000);
            Environment.Exit(0);
            return false;





        }
    }
}
