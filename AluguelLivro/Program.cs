using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelLivro
{
    public class Program
    {
        static void Main(string[] args)
        {
            CultureInfo CultureBr = new CultureInfo(name: "pt-BR");
            
            List<Cliente> listaCliente = new List<Cliente>();
            Cliente cliente;

            List<Livro> listaLivro = new List<Livro>();
            Livro livro;

            List<EmprestimoLivro> listaEmprestimoLivros = new List<EmprestimoLivro>();
            EmprestimoLivro emprestimoLivro;
            
            listaCliente = FileManagement.ConvertFileCSVToListCliente();
            listaLivro = FileManagement.ConvertFileCSVToListLivro();
            listaEmprestimoLivros = FileManagement.ConvertFileCSVToListEmprestimo();

            int op;
            do
            {

                do
                {
                    op = MenuPrincipal();
                }
                while (op > 5 || op < 0);

                switch (op)
                {
                    case 1:
                        //Cadastro cliente
                        cliente = ClienteController.ReadCliente(listaCliente);
                        if (cliente != null)
                        {
                            listaCliente.Add(cliente);
                            FileManagement.WriteFileCSV(listaCliente);
                            Console.WriteLine("Cliente cadastrado!");
                        }
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadKey();
                        break;
                    case 2:
                        //Cadastro Livro
                        livro = LivroController.ReadCliente(listaLivro);
                        if (livro != null)
                        {
                            listaLivro.Add(livro);
                            FileManagement.WriteFileCSV(listaLivro);
                            Console.WriteLine("Livro cadastrado!");
                            Console.WriteLine("O Número do Tombo é: " + livro.NumeroTombo);
                        }
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadKey();
                        break;
                    case 3:
                        //Empréstimo de Livro 
                        do {
                            emprestimoLivro = EmprestimoLivroController.ReadEmprestimo(listaEmprestimoLivros, listaLivro, listaCliente);
                            if (emprestimoLivro != null)
                            {
                                listaEmprestimoLivros.Add(emprestimoLivro);                                
                                FileManagement.WriteFileCSV(listaEmprestimoLivros);
                                Console.WriteLine("Empréstimo realizado com sucesso!");
                            }
                            else {
                                Console.WriteLine("Deseja tentar novamente(s/n):");
                                string continuar = Console.ReadLine();
                                if (continuar.ToUpper() == "N") break;                   
                            }
                        } while (emprestimoLivro == null);
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadKey();
                        break;
                    case 4:
                        DevolucaoController.Devolucao(listaEmprestimoLivros);
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadKey();
                        break;
                    case 5:
                        EmprestimoLivroController.Relatorio(listaEmprestimoLivros, listaLivro, listaCliente);
                        Console.WriteLine("Pressione ENTER para continuar...");
                        Console.ReadKey();
                        break;

                }
            } while (op != 0);
        }

        public static int MenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("Menu Principal\n1- Cadastro de Cliente\n2- Cadastro de Livro\n3- Empréstimo de Livro\n4- Devolução de Livro\n5- Relatório de Empréstimo de Devoluções\n0- Sair\n>>>");
            int value = int.Parse(Console.ReadLine());
            return value;
        }
    }
}
