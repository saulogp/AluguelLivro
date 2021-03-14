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
            Console.Write("Informe o Data de Publicação: ");
            DateTime datapubli = DateTime.ParseExact(Console.ReadLine(), "d", CultureBr);
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
