using System;
using System.Collections.Generic;
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
            if (!Directory.Exists(path_folder))//CRIA PASTA
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
    }
}
