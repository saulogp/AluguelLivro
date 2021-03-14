using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelLivro
{
    public class EmprestimoLivroController
    {
        public static bool VerificaNTomboCadastrado(List<Livro> lista, int numTombo)
        {
            foreach (Livro l in lista)
            {
                if (l.NumeroTombo.Equals(numTombo)) // verifica se esta cadastrado
                {
                    return true;
                }
            }
            return false;
        }
        public static bool VerificaNTomboDisponivel(List<EmprestimoLivro> lista, int numTombo)
        {
            foreach (EmprestimoLivro el in lista)
            {
                if ((el.NumeroTombo.Equals(numTombo) ) && (el.StatusEmprestimo.Equals(1))) //verifica se esta emprestado ou não
                {
                    return true;
                }
            }
            return false;
        }
        public static long VerificaCPF(List<Cliente> lista, string cpf)
        {
            foreach (Cliente c in lista)
            {
                if (c.CPF.Equals(cpf))
                {
                    return c.IdCliente;
                }
            }
            return 0;
        }

        public static EmprestimoLivro ReadEmprestimo(List<EmprestimoLivro> listaEmprestimoLivro, List<Livro> listaLivro, List<Cliente> listaCliente)
        {
            CultureInfo CultureBr = new CultureInfo(name: "pt-BR");
            EmprestimoLivro emprestimoLivro;
            string cpf;
            int numTombo;
            long idCliente;
            Console.WriteLine("Empréstimo do livro\n");

            Console.Write("Informe o Número do Tombo: ");
            numTombo = int.Parse(Console.ReadLine());
            if (VerificaNTomboCadastrado(listaLivro, numTombo))//caso o numTombo exista verifica se esta disponivel
            {
                if(VerificaNTomboDisponivel(listaEmprestimoLivro, numTombo))
                {
                    Console.WriteLine("Livro indisponível para empréstimo");
                    return null;
                }
            }
            else
            {
                Console.WriteLine("Esse Número de tombo não esta cadastrado!");
                return null;
            }
            Console.Write("Informe o CPF: ");
            cpf = Console.ReadLine();
            idCliente = VerificaCPF(listaCliente, cpf);
            if (idCliente == 0)
            {
                Console.WriteLine("Cliente não cadastrado");
                return null;

            }
            
            Console.Write("Informe o Data de Devolução: ");
            DateTime dataDevolucao = DateTime.ParseExact(Console.ReadLine(), "d", CultureBr);
            string dataAtual = DateTime.Now.ToString("d");
            DateTime dataEmprestimo = DateTime.ParseExact(dataAtual, "d", CultureBr);

            emprestimoLivro = new EmprestimoLivro
            {
                NumeroTombo = numTombo,
                IdCliente = idCliente,
                DataEmprestimo = dataEmprestimo,
                DataDevolucao = dataDevolucao,
                StatusEmprestimo = 1
            };
            return emprestimoLivro;
        }
    }
}
