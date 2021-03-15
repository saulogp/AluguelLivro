using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelLivro
{
    class DevolucaoController
    {
        public static void Devolucao(List<EmprestimoLivro> listaEmprestimo)
        {
            CultureInfo CultureBr = new CultureInfo(name: "pt-BR");
            //Livro livro;
            EmprestimoLivro emprestimoLivro = null;
            
            double valorMulta =0;
            Console.WriteLine("Devolução do Livro\n");

            Console.WriteLine("Informe o Número do Tombo:");
            long numTombo = long.Parse(Console.ReadLine());
            if (EmprestimoLivroController.VerificaNTomboDisponivel(listaEmprestimo, numTombo))//caso entre significa que o livro esta como devolvido ou que nunca foi encontrado
            {

                emprestimoLivro = EmprestimoLivroController.RetornaEmprestimo(listaEmprestimo, numTombo);
                Console.WriteLine(emprestimoLivro.ToString());
                emprestimoLivro.StatusEmprestimo = 2; //update da status para devolvido
                Console.WriteLine(emprestimoLivro.ToString());
                
                string dataAtual = DateTime.Now.ToString("d");
                DateTime dataAtualConvertida = DateTime.ParseExact(dataAtual, "d", CultureBr);
                if(dataAtualConvertida > emprestimoLivro.DataDevolucao)
                {
                    valorMulta = CalculaMulta(emprestimoLivro.DataDevolucao, dataAtualConvertida);
                    Console.WriteLine("O valor da multa é: R$" + valorMulta);
                }
                FileManagement.WriteFileCSV(listaEmprestimo);
            }
            else { 
                Console.WriteLine("Livro não encontrado para devolução");
                return;
            }
        }

        private static double CalculaMulta(DateTime dataDevolucao, DateTime dataAtual)
        {
            const double multaValorDiario = 0.10;
            TimeSpan date = dataDevolucao - dataAtual;
            int totalDias = date.Days;
            Console.WriteLine("Total de dias: " + totalDias);

            if(totalDias < 0)
            {
                totalDias = totalDias * -1;
                return totalDias * multaValorDiario;
            }
            return 0.0;
        }


    }
}
