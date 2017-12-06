using System;
using System.Collections.Generic;

namespace ExemploCRUD
{
    class Program
    {
        static void Main(string[] args)
        {
            BancoDados bd = new BancoDados();
            Categoria cat = new Categoria();
            string cs;
            int escolha;

            Console.WriteLine("_______MENU BANCO DE DADOS____");
            System.Console.WriteLine("1_ CADASTRAR");
            System.Console.WriteLine("2_ ATUALIZAR");
            System.Console.WriteLine("3_ APAGAR");
            System.Console.WriteLine("4_ SELECIONAR");
            System.Console.WriteLine("9_ SAIR");
            string resposta = Console.ReadLine();
            int opcao = Int16.Parse(resposta);

            while (opcao != 9)
            {
                switch (opcao)
                {
                    case 1:
                        System.Console.WriteLine("Adicionar dados em qual BD:");
                        System.Console.WriteLine("Categoria, Clientes, Funcionarios, Pedidos, Produtos");
                        cs = Console.ReadLine().ToLower();

                        switch (cs)
                        {
                            case "categoria":
                                System.Console.WriteLine("Digite o título: ");
                                cat.Titulo = Console.ReadLine();
                                bd.Adicionar(cat);
                                break;
                            default:
                                System.Console.WriteLine("Opção inválida");
                                break;

                        }

                        break;

                    case 2:
                        System.Console.WriteLine("Atualizar dados em qual BD:");
                        System.Console.WriteLine("Categoria, Clientes, Funcionarios, Pedidos, Produtos");
                        cs = Console.ReadLine().ToLower();

                        switch (cs)
                        {
                            case "categoria":
                                System.Console.WriteLine("UPDATE do titulo: ");
                                cat.Titulo = Console.ReadLine();
                                System.Console.WriteLine("Where id = ");
                                cat.IdCategoria = Convert.ToInt16(Console.ReadLine());
                                bd.Atualizar(cat);
                                break;
                            default:
                                System.Console.WriteLine("Opção inválida");
                                break;
                        }
                        opcao = 9;
                        break;

                    case 3:
                        System.Console.WriteLine("Deletar dados em qual BD:");
                        System.Console.WriteLine("Categoria, Clientes, Funcionarios, Pedidos, Produtos");
                        cs = Console.ReadLine().ToLower();

                        switch (cs)
                        {
                            case "categoria":
                                System.Console.WriteLine("DELETE id =");
                                cat.IdCategoria = Convert.ToInt16(Console.ReadLine());
                                bd.Deletar(cat);
                                break;
                            default:
                                System.Console.WriteLine("Opção inválida");
                                break;
                        }
                        break;

                    case 4:
                        System.Console.WriteLine("Selecionar dados em qual BD:");
                        System.Console.WriteLine("Categoria, Clientes, Funcionarios, Pedidos, Produtos");
                        cs = Console.ReadLine().ToLower();

                        switch (cs)
                        {
                            case "categoria":
                                System.Console.WriteLine("Selecionar por:");
                                System.Console.WriteLine("1_ Título");
                                System.Console.WriteLine("2_ ID");
                                System.Console.WriteLine("Digite a opção desejada: 1 ou 2");
                                escolha = Convert.ToInt16(Console.ReadLine());

                                if (escolha == 1)
                                {
                                    System.Console.WriteLine("Digite o título");
                                    cat.Titulo = Console.ReadLine();
                                    List<Categoria> listSelectCategoria = bd.ListarCategorias(cat.Titulo);
                                }
                                else if (escolha == 2)
                                {
                                    System.Console.WriteLine("Digite o id");
                                    cat.IdCategoria = Convert.ToInt16(Console.ReadLine());
                                    List<Categoria> listSelectCategoria = bd.ListarCategorias(cat.IdCategoria);
                                }
                                break;
                            default:
                                System.Console.WriteLine("Opção inválida");
                                break;
                        }
                        break;

                }
            }

            bd.Adicionar(cat);









        }
    }
}
