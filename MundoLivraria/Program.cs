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
            
            ///////////////////////
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
                            RealizarTarefasCaixa(caixaLogado, livro);
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
        static void ExibirListaLivros(List<Livros> livros, bool emStock)
        {
            Console.Clear();

            if (emStock)
            {
                Console.WriteLine("========== Livros em Stock ==========");
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("{0,-60} {1,-20} {2,-10} {3,-10} {4,-15} {5,-15}", "Título", "Autor", "Preço", "Quantidade", "ISBN", "Gênero");
                Console.WriteLine(new string('-', 130));

                foreach (var livro in livros.Where(l => l.quantidadeStock > 0))
                {
                    Console.WriteLine("{0,-60} {1,-20} {2,-10:C2} {3,-10} {4,-15} {5,-15}", livro.Titulo, livro.Autor, livro.Preco, livro.quantidadeStock, livro.ISBN, livro.Genero);
                 
                }
            }
            else
            {
                Console.WriteLine("========== Livros Fora de Stock ==========");
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine("{0,-60} {1,-20} {2,-10} {3,-15} {4,-15}", "Título", "Autor", "Preço", "ISBN", "Gênero");
                Console.WriteLine(new string('-', 130));

                foreach (var livro in livros.Where(l => l.quantidadeStock == 0))
                {
                    Console.WriteLine("{0,-60} {1,-20} {2,-10:C2} {3,-15} {4,-15}", livro.Titulo, livro.Autor, livro.Preco, livro.ISBN, livro.Genero);
                }
            }

            Console.WriteLine(new string('=', 144));

            if (emStock || !emStock)
            {
                Console.WriteLine("\nPressione qualquer tecla para continuar...");
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void ConsultarLivroPorISBN(List<Livros> livros)
        {
            Console.Write("Insira o ISBN do livro: ");
            string isbn = Console.ReadLine();

            Livros livroEncontrado = livros.FirstOrDefault(l => l.ISBN == isbn);

            if (livroEncontrado != null)
            {
                Console.WriteLine("\nInformações do Livro:");
                Console.WriteLine($"Título: {livroEncontrado.Titulo}");
                Console.WriteLine($"Autor: {livroEncontrado.Autor}");
                Console.OutputEncoding = System.Text.Encoding.UTF8;
                Console.WriteLine($"Preço: {livroEncontrado.Preco:C2}");
                Console.WriteLine($"Quantidade em Stock: {livroEncontrado.quantidadeStock}");
                Console.WriteLine($"Gênero: {livroEncontrado.Genero}");
                Console.WriteLine($"ISBN: {livroEncontrado.ISBN}");
            }
            else
            {
                Console.WriteLine("Livro não encontrado...");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }

        static void ConsultarTotalLivrosVendidosEReceita(List<Livros> livros)
        {
            int totalLivrosVendidos = 0;
            double receitaTotal = 0.0;

            foreach (var livro in livros)
            {
                int livrosVendidos = livro.quantidadeStockInicial - livro.quantidadeStock;
                double receitaLivro = livrosVendidos * livro.Preco;

                livrosVendidos = Math.Max(0, livrosVendidos);

                totalLivrosVendidos += livrosVendidos;
                receitaTotal += livrosVendidos * livro.Preco;
            }

            Console.WriteLine($"Total de livros vendidos: {totalLivrosVendidos}");
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($"Receita total: {receitaTotal:C2}");

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }




        //CAIXA
        static void RealizarTarefasCaixa(Caixa caixa, List<Livros> livros)
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
                            ExibirListaLivros(livros, true);
                        }
                        else if (subOpcao == "2")
                        {
                            ExibirListaLivros(livros, false);
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
                                if (totalVenda > 50)
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
                        ConsultarLivroPorISBN(livros);
                        break;
                    case "4":
                        ListarLivrosPorAutor(livros);
                        break;
                    case "5":
                        ConsultarTotalLivrosVendidosEReceita(livros);
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
                            ExibirListaLivros(livros, true);
                        }
                        else if (subOpcao == "2")
                        {
                            ExibirListaLivros(livros, false);
                        }
                        break;
                    case "2":
                        Console.WriteLine("==== Lista de Funcionários ====");
                        ExibirListaFuncionarios(funcionarios);
                        break;
                    case "3":
                        CriarPerfil(funcionarios);
                        break;
                    case "4":
                        EliminarPerfil(funcionarios);
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
                        ConsultarTotalLivrosVendidosEReceita(livros);
                        break;

                    case "7":
                        ConsultarLivroPorISBN(livros);
                        break;

                    case "8":
                        AtualizarLivro(livros);
                        break;

                    case "9":
                        ListarLivrosPorAutor(livros);
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

        static void ExibirListaFuncionarios(List<IFuncionario> funcionarios)
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

        static void CriarPerfil(List<IFuncionario> funcionarios)
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

        static void EliminarPerfil(List<IFuncionario> funcionarios)
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

        static void AtualizarLivro(List<Livros> livros)
        {
            Console.WriteLine("===== Atualizar Livro =====");
            Console.Write("Insira ISBN: ");
            string isbn = Console.ReadLine();
            Livros livroParaAtualizar = livros.FirstOrDefault(l => l.ISBN == isbn);
            Console.Clear();

            if (livroParaAtualizar != null)
            {
                Console.WriteLine("Escolha o que deseja modificar: ");
                Console.WriteLine("1. Título");
                Console.WriteLine("2. Autor");
                Console.WriteLine("3. Preço");
                Console.WriteLine("4. Quantidade em Stock");
                Console.WriteLine("5. ISBN ");
                Console.Write("Escolha uma opção (1-5): ");
                string opcaoAtualizacao = Console.ReadLine();
                Console.Clear();

                switch (opcaoAtualizacao)
                {
                    case "1":
                        Console.Write("Novo Título: ");
                        livroParaAtualizar.Titulo = Console.ReadLine();
                        break;
                    case "2":
                        Console.Write("Novo Autor: ");
                        livroParaAtualizar.Autor = Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("Novo Preço: ");
                        if (double.TryParse(Console.ReadLine(), out double novoPreco))
                        {
                            livroParaAtualizar.Preco = novoPreco;
                        }
                        else
                        {
                            Console.WriteLine("Preço inválido...");
                            return;
                        }
                        break;
                    case "4":
                        Console.Write("Nova Quantidade em Stock: ");
                        if (int.TryParse(Console.ReadLine(), out int novaQuantidade))
                        {
                            livroParaAtualizar.quantidadeStock = novaQuantidade;
                        }
                        else
                        {
                            Console.WriteLine("Quantidade inválida...");
                            return;
                        }
                        break;
                    case "5":
                        Console.Write("Novo ISBN: ");
                        livroParaAtualizar.ISBN = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Opção inválida...");
                        return;
                }

                Console.WriteLine("Livro atualizado com sucesso");
            }
            else
            {
                Console.WriteLine("Livro não encontrado...");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }

        static void ListarLivrosPorAutor(List<Livros> livros)
        {
            Console.WriteLine("===== Listar Livros por Autor =====");
            Console.Write("Nome do autor: ");
            string autorEscolhido = Console.ReadLine();

            List<Livros> livrosDoAutor = livros.Where(l => l.Autor.Equals(autorEscolhido, StringComparison.OrdinalIgnoreCase)).ToList();

            if (livrosDoAutor.Any())
            {
                Console.WriteLine($"\nLivros do autor '{autorEscolhido}':");
                ExibirListaLivros(livrosDoAutor, true);
            }
            else
            {
                Console.WriteLine($"Não foram encontrados livros do autor '{autorEscolhido}'.");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
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
                            ExibirListaLivros(livros, true);

                        }
                        else if (subOpcao == "2")
                        {
                            ExibirListaLivros(livros, false);

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
                                Livros novoLivro = CriarNovoLivro();
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

        static Livros CriarNovoLivro()
        {
            Console.Clear();
            Console.WriteLine("===== Criar Novo Livro =====");
            Console.Write("Inserir o título do livro: ");
            string titulo = Console.ReadLine();
            Console.Write("Inserir o autor do livro: ");
            string autor = Console.ReadLine();
            Console.Write("Inserir o preço do livro: ");
            double preco = 0;


            while (!double.TryParse(Console.ReadLine(), out preco) || preco <= 0)
            {
                Console.WriteLine("Preço inválido...");
                Console.Write("Inserir o preço do livro: ");
            }

            Console.Write("Inserir a quantidade stock: ");
            int quantidadeStock;

            while (!int.TryParse(Console.ReadLine(), out quantidadeStock) || quantidadeStock < 0)
            {
                Console.WriteLine("Quantidade inválida...");
                Console.Write("Inserir a quantidade stock: ");
            }

            Console.Write("Inserir o género do livro: ");
            string genero = Console.ReadLine();
            Console.Write("Inserir o ISBN do livro: ");
            string isbn = Console.ReadLine();

            Livros novoLivro = new Livros(titulo, autor, preco, quantidadeStock, genero, isbn);
            Console.WriteLine("\n\nNovo livro adicionado com sucesso!");
            Console.WriteLine("\nPressione qualquer tecla para continuar...");
            Console.ReadKey();
            Console.Clear();

            return novoLivro;
        }
        //////////
        /////////////
        ///////////
        //////////
        /////////
        

        // introduzir credenciais e verificar
        static bool RealizarLogin(List<IFuncionario> funcionarios, string cargo, List<Livros> livros)
        {
            for (int tentativa = 0; tentativa < 3; tentativa++)
            {
                Console.Clear();
                Console.Write($" ======== {cargo} ========");
                Console.Write($"\n Insira o seu ID: ");
                string utilizador = Console.ReadLine();

                Console.Write($" Insira a sua palavra-chave: ");
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
