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
        //public static string path_folder = "";
        
        public static void WriteFileCSV(List<Cliente> lista)
        {
            string file_name = "CLIENTE.csv";
            
            using (StreamWriter streamWriter = File.CreateText($"{file_name}"))
            {
                foreach (var linha in lista)
                {
                    streamWriter.WriteLine(linha.ToString());
                }
                streamWriter.Close();
            }

        }
        public static void WriteFileCSV(List<Livro> lista)
        {
            string file_name = "LIVRO.csv";
            
            using (StreamWriter streamWriter = File.CreateText($"{file_name}"))
            {
                foreach (var linha in lista)
                {
                    streamWriter.WriteLine(linha.ToString());
                }
                streamWriter.Close();
            }
        }
        public static void WriteFileCSV(List<EmprestimoLivro> lista)
        {
            string file_name = "EMPRESTIMO.csv";
            
            using (StreamWriter streamWriter = File.CreateText($"{file_name}"))
            {
                foreach (var linha in lista)
                {
                    streamWriter.WriteLine(linha.ToString());
                }
                streamWriter.Close();
            }
        }
        public static List<Cliente> ConvertFileCSVToListCliente()
        {
            List<Cliente> lista = new List<Cliente>();
            
            if (File.Exists("CLIENTE.csv"))
            {

                CultureInfo CultureBr = new CultureInfo(name: "pt-BR");


                string file_name = "CLIENTE.csv"; 

                string linha = "";

                string[] linhaseparada;

                StreamReader reader = null;
                try
                {
                    reader = new StreamReader($"{file_name}", Encoding.UTF8, true);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Arquivo não encontrado!!!\n");
                }

                while (true)
                {
                    linha = reader.ReadLine();
                    if (linha == null) break;
                    linhaseparada = linha.Split(';');
                    lista.Add(new Cliente
                    {
                        IdCliente = int.Parse(linhaseparada[0]),
                        CPF = linhaseparada[1],
                        Nome = linhaseparada[2],
                        DataNascimento = Convert.ToDateTime(linhaseparada[3]),
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
                reader.Close();
            }
            return lista;
        }
        public static List<Livro> ConvertFileCSVToListLivro()
        {
            List<Livro> lista = new List<Livro>();
            if (File.Exists("LIVRO.csv"))
            {

                CultureInfo CultureBr = new CultureInfo(name: "pt-BR");


                string file_name = "LIVRO.csv";
                string linha = "";

                string[] linhaseparada;

                StreamReader reader = null;
                try
                {
                    reader = new StreamReader($"{file_name}", Encoding.UTF8, true);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Arquivo não encontrado!!!\n");
                }

                while (true)
                {
                    linha = reader.ReadLine();
                    if (linha == null) break;
                    linhaseparada = linha.Split(';');

                    lista.Add(new Livro
                    {
                        NumeroTombo = int.Parse(linhaseparada[0]),
                        ISBN = linhaseparada[1],
                        Titulo = linhaseparada[2],
                        Genero = linhaseparada[3],
                        DataPublicacao = Convert.ToDateTime(linhaseparada[4]),
                        Autor = linhaseparada[5]
                    });
                }
                reader.Close();
            }
            return lista;
        }
        public static List<EmprestimoLivro> ConvertFileCSVToListEmprestimo()
        {
            List<EmprestimoLivro> lista = new List<EmprestimoLivro>();
            if (File.Exists("EMPRESTIMO.csv"))
            {

                CultureInfo CultureBr = new CultureInfo(name: "pt-BR");


                string file_name = "EMPRESTIMO.csv";

                string linha = "";

                string[] linhaseparada;

                StreamReader reader = null;
                try
                {
                    reader = new StreamReader($"{file_name}", Encoding.UTF8, true);
                }
                catch (FileNotFoundException)
                {
                    Console.WriteLine("Arquivo não encontrado!!!\n");
                }

                while (true)
                {
                    linha = reader.ReadLine();
                    if (linha == null) break;
                    linhaseparada = linha.Split(';');

                    foreach (string l in linhaseparada)
                    {
                        Console.WriteLine(l);
                    }

                    lista.Add(new EmprestimoLivro
                    {
                        IdCliente = long.Parse(linhaseparada[0]),
                        NumeroTombo = long.Parse(linhaseparada[1]),
                        DataEmprestimo = Convert.ToDateTime(linhaseparada[2]),
                        DataDevolucao = Convert.ToDateTime(linhaseparada[3]),
                        StatusEmprestimo = int.Parse(linhaseparada[4])
                    });
                }
                reader.Close();
            }
            return lista;
        }
    }
}
