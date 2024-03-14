using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace MundoLivraria
{
    class Livros
    {
        public string Titulo;
        public string Autor;
        public double Preco;
        public int quantidadeStock;
        public string Genero;
        public string ISBN;
      

        public int quantidadeStockInicial;
        public int TotalVendidos { get; private set; }
        public double ReceitaTotal { get; private set; }
        //adicionar mais propriedades

        //construtor da classe livros
        public Livros(string titulo, string autor, double preco, int quantidadeStock, string genero, string isbn)
        {
            Titulo = titulo;        
            Autor = autor;
            Preco = preco;
            this.quantidadeStock = quantidadeStock;
            quantidadeStockInicial = quantidadeStock; 
            Genero = genero;
            ISBN = isbn;
            

        }
        //Lista dos livros em stock
        /* public virtual void ExibirLivrosInStock()
         {

             Console.WriteLine($"\nTítulo: {Titulo}");
             Console.WriteLine($"Autor: {Autor}");
             Console.WriteLine($"Género: {Genero}");
             Console.WriteLine($"ISBN: {ISBN}");
             Console.OutputEncoding = System.Text.Encoding.UTF8;
             Console.WriteLine($"Preco: {Preco}€");
             Console.WriteLine($"Stock: {quantidadeStock} livro(s) em stock!");

         }
         //lista dos livros sem stock
         public virtual void ExibirLivrosOutOfStock()
         {

             Console.WriteLine($"\nTítulo: {Titulo}");
             Console.WriteLine($"Autor: {Autor}");
             Console.OutputEncoding = System.Text.Encoding.UTF8;
             Console.WriteLine($"Preco: {Preco}€");
             Console.WriteLine($"Stock: {quantidadeStock} livro(s) em stock!");


             if (quantidadeStock == 0)
             {
                 Console.WriteLine($"Fora de Stock");
             }
             else
             {
                 Console.WriteLine($"Stock: {quantidadeStock} livro(s) em stock!");
             }

         }*/

        //para vender livros caixa + gerente

        public static void ExibirListaLivros(List<Livros> livros, bool emStock)
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

        public static void AtualizarLivro(List<Livros> livros)
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

        public static void LivrosPorAutor(List<Livros> livros)
        {
            Console.WriteLine("===== Listar Livros por Autor =====");
            Console.Write("Nome do autor: ");
            string autorEscolhido = Console.ReadLine();

            List<Livros> livrosDoAutor = livros.Where(l => l.Autor.Equals(autorEscolhido, StringComparison.OrdinalIgnoreCase)).ToList();

            if (livrosDoAutor.Any())
            {
                Console.WriteLine($"\nLivros do autor '{autorEscolhido}':");
                Livros.ExibirListaLivros(livrosDoAutor, true);
            }
            else
            {
                Console.WriteLine($"Não foram encontrados livros do autor '{autorEscolhido}'.");
            }

            Console.WriteLine("\nPressione qualquer tecla para voltar ao menu...");
            Console.ReadKey();
            Console.Clear();
        }

        public static void ConsultarLivroPorISBN(List<Livros> livros)
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

        public static Livros CriarNovoLivro()
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
        public double Vender(int quantidade)
        {
            //vai ver se a quantidade a ser vendido é maior que 0 e menor ou igual à quantidade em stock
            if (quantidade > 0 && quantidade <= quantidadeStock)
            {
                /*Caso a quantidade seja - verdadeira - maior que 0 e dentro dos limites do stock. 
                (quantidade refere - se à quantidade que vai ser vendida dentro dos limites do stock.)*/

                quantidadeStock -= quantidade;   //qntdStock = qntdStock - quantidade; 
                TotalVendidos += quantidade;   //TotalVendidos = TotalVendidos + quantidade;

                double valorVenda = Preco * quantidade;

                ReceitaTotal += valorVenda;
                return valorVenda;
            }
                //Caso a qntd seja - falso - vai imprimir mensagem de erro e retorna valor a 0 que significa que a venda foi cancelada.
            else
            {
                Console.WriteLine("Quantidade inválida para vender. Operação cancelada...");
                return 0;
            }
        }

        //total livros vendidos
        public void ConsultarTotalVendidosEReceita()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine($"\nTotal de livros vendidos: {TotalVendidos}");
            Console.WriteLine($"Receita total: {ReceitaTotal:C2}");
        }


        //função do Repositor em adicionar stock já registado no sistema
        public void AdicionarStock(int quantidade)
        {
            if (quantidade > 0)
            {
                quantidadeStock += quantidade;
                Console.WriteLine($"{quantidade} livro(s) adicionado(s) ao stock com sucesso!");
            }
            else
            {
                Console.WriteLine("Quantidade inválida para adicionar ao stock....");
            }
        }

        public static void ConsultarTotalLivrosVendidosEReceita(List<Livros> livros)
        {
            int totalLivrosVendidos = 0;
            double receitaTotal = 0.0;

            foreach (var livro in livros)
            {
                int livrosVendidos = livro.quantidadeStockInicial - livro.quantidadeStock;
                double receitaLivro = livrosVendidos * livro.Preco;

                //garante q nº lvro n seja neg
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

    }
}
