using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelLivro
{
    public class FileManagement
    {
        private static string path_folder = @"C:\Users\55169\Desktop\Projeto\Files";
        private static void InicializarArquivo(string file_name)
        {
            if (!Directory.Exists(path_folder))
            {
                Directory.CreateDirectory(path_folder);
            }

            if (!File.Exists($@"{path_folder}\{file_name}"))
            {
                using (File.Create($@"{path_folder}\{file_name}"))
                {
                    Console.WriteLine($"Arquivo {file_name} Criado com sucesso!");
                }
            }

        }
        public static void WriteFileCSV(List<Cliente> lista)
        {
            string file_name = "CLIENTE.csv";

            InicializarArquivo(file_name);

            try
            {
                StreamWriter arq = File.CreateText($"{path_folder}\\{file_name}");

                foreach (Cliente c in lista)
                {
                    arq.WriteLine(c.ToString());
                }
                arq.Close();
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                Console.WriteLine("ERRO:" + ex.Message);

            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine("ERRO:" + ex.Message);

            }
        }
        public static void WriteFileCSV(List<Livro> lista)
        {
            string file_name = "LIVRO.csv";

            InicializarArquivo(file_name);
            try
            {
                StreamWriter arq = File.CreateText($"{path_folder}\\{file_name}");

                foreach (Livro l in lista)
                {
                    arq.WriteLine(l.ToString());
                }
                arq.Close();
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                Console.WriteLine("ERRO:" + ex.Message);

            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine("ERRO:" + ex.Message);

            }
        }
        public static void WriteFileCSV(List<EmprestimoLivro> lista)
        {
            string file_name = "EMPRESTIMO.csv";

            InicializarArquivo(file_name);

            try
            {
                StreamWriter arq = File.CreateText($"{path_folder}\\{file_name}");

                foreach (EmprestimoLivro el in lista)
                {
                    arq.WriteLine(el.ToString());
                }
                arq.Close();
            }
            catch (System.IO.DirectoryNotFoundException ex)
            {
                Console.WriteLine("ERRO:" + ex.Message);

            }
            catch (System.IO.IOException ex)
            {
                Console.WriteLine("ERRO:" + ex.Message);

            }
        }

        public static List<Cliente> ConvertFileCSVToListCliente()
        {
            CultureInfo CultureBr = new CultureInfo(name: "pt-BR");

            List<Cliente> lista = new List<Cliente>();
            
            string file_name = "CLIENTE.csv";
            
            string linha = "";
            
            string[] linhaseparada;

            StreamReader reader = null;
            try
            {
                reader = new StreamReader($"{path_folder}\\{file_name}", Encoding.UTF8, true);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Arquivo não encontrado!!!\n");
            }

            while (true)
            {
                linha = reader.ReadLine();
                if (linha == null) break;
                linhaseparada = linha.Split(',');
                string data_string = linhaseparada[3].ToString();
                lista.Add(new Cliente
                {
                    IdCliente = int.Parse(linhaseparada[0]),
                    CPF = linhaseparada[1],
                    Nome = linhaseparada[2],
                    DataNascimento = DateTime.ParseExact($"{data_string}", "d", CultureBr),
                    Telefone = linhaseparada[4],
                    Endereco = new Endereco
                    {
                        Logradouro = linhaseparada[5],
                        Bairro = linhaseparada[6],
                        Cidade = linhaseparada[7],
                        Estado = linhaseparada[8],
                        CEP = linhaseparada[9]
                    }
                });
            }
            return lista;
        }

        public static List<Livro> ConvertFileCSVToListLivro()
        {
            CultureInfo CultureBr = new CultureInfo(name: "pt-BR");

            List<Livro> lista = new List<Livro>();

            string file_name = "LIVRO.csv";

            string linha = "";

            string[] linhaseparada;

            StreamReader reader = null;
            try
            {
                reader = new StreamReader($"{path_folder}\\{file_name}", Encoding.UTF8, true);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Arquivo não encontrado!!!\n");
            }

            while (true)
            {
                linha = reader.ReadLine();
                if (linha == null) break;
                linhaseparada = linha.Split(',');

                lista.Add(new Livro
                {
                    NumeroTombo = int.Parse(linhaseparada[0]),
                    Titulo = linhaseparada[1],
                    ISBN = linhaseparada[2],
                    //DataPublicacao = DateTime.ParseExact(linhaseparada[3].ToString(), "d", CultureBr),
                    Genero = linhaseparada[4],
                    Autor = linhaseparada[5]
                });
            }
            return lista;
        }
        public static List<EmprestimoLivro> ConvertFileCSVToListEmprestimo()
        {
            CultureInfo CultureBr = new CultureInfo(name: "pt-BR");

            List<EmprestimoLivro> lista = new List<EmprestimoLivro>();

            string file_name = "EMPRESTIMO.csv";

            string linha = "";

            string[] linhaseparada;

            StreamReader reader = null;
            try
            {
                reader = new StreamReader($"{path_folder}\\{file_name}", Encoding.UTF8, true);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Arquivo não encontrado!!!\n");
            }

            while (true)
            {
                linha = reader.ReadLine();
                if (linha == null) break;
                linhaseparada = linha.Split(',');

                lista.Add(new EmprestimoLivro
                {
                    IdCliente = int.Parse(linhaseparada[0]),
                    NumeroTombo = int.Parse(linhaseparada[1]),
                    DataEmprestimo = DateTime.ParseExact("15/03/2021", "d", CultureBr),
                    DataDevolucao = DateTime.ParseExact("25/03/2021", "d", CultureBr),
                    StatusEmprestimo = int.Parse(linhaseparada[4])
                });
            }
            return lista;
        }
    }
}
