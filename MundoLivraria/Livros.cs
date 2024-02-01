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
            this.Titulo = titulo;
            this.Autor = autor;
            this.Preco = preco;
            this.quantidadeStock = quantidadeStock;
            this.quantidadeStockInicial = quantidadeStock; 
            this.Genero = genero;
            this.ISBN = isbn;
        }
        //Lista dos livros em stock
        public virtual void ExibirLivrosInStock()
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

        }

        //para vender livros caixa + gerente
        public double Vender(int quantidade)
        {
            //vai ver se a quantidade a ser vendido é maior que 0 e menor ou igual à quantidade em stock
            if (quantidade > 0 && quantidade <= this.quantidadeStock)
            {
                /*Caso a quantidade seja - verdadeira - maior que 0 e dentro dos limites do stock. 
                (quantidade refere - se à quantidade que vai ser vendida dentro dos limites do stock.)*/

                this.quantidadeStock -= quantidade;   //qntdStock = qntdStock - quantidade; 
                this.TotalVendidos += quantidade;   //TotalVendidos = TotalVendidos + quantidade;

                double valorVenda = this.Preco * quantidade;

                this.ReceitaTotal += valorVenda;
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
                this.quantidadeStock += quantidade;
                Console.WriteLine($"{quantidade} livro(s) adicionado(s) ao stock com sucesso!");
            }
            else
            {
                Console.WriteLine("Quantidade inválida para adicionar ao stock....");
            }
        }

    }
}
