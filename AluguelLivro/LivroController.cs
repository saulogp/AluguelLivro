using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelLivro
{
    public class LivroController
    {
        public static bool VerificaISBN(List<Livro> lista, string isbn)
        {
            foreach (Livro l in lista)
            {
                if (l.ISBN.Equals(isbn))
                {
                    return true;
                }
            }
            return false;
        }
        public static Livro ReadCliente(List<Livro> lista)
        {
            CultureInfo CultureBr = new CultureInfo(name: "pt-BR");
            Livro livro;
            string isbn, titulo, genero,autor;
            Console.WriteLine("Cadastro do livro\n");

            Console.Write("Informe o ISBN: ");
            isbn = Console.ReadLine();
            if (VerificaISBN(lista, isbn))//caso o isbn exista cai fora
            {
                Console.WriteLine("Livro já cadastrado");
                return null;
            }
            int numTombo = lista.Count() + 1;
            Console.Write("Informe o Título: ");
            titulo = Console.ReadLine();
            Console.Write("Informe o Genero: ");
            genero = Console.ReadLine();
            DateTime datapubli;
            do { 
                Console.Write("Informe o Data de Publicação: ");
                datapubli = DateTime.ParseExact(Console.ReadLine(), "d", CultureBr);
                if (datapubli > DateTime.Now) Console.WriteLine("A data de publicação não pode ser maior que a data atual!");
            } while (datapubli > DateTime.Now);
            Console.Write("Informe o Autor: ");
            autor = Console.ReadLine();
            
            livro = new Livro
            {
                NumeroTombo = numTombo,
                ISBN = isbn,
                Titulo = titulo,
                Genero = genero,
                DataPublicacao = datapubli,
                Autor = autor
            };
            return livro;
        }
    }
}
