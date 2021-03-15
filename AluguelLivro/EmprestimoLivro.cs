using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelLivro
{
    public class EmprestimoLivro
    {
        public long IdCliente { get; set; }
        public long NumeroTombo { get; set; }

        public DateTime DataEmprestimo { get; set; }
        public DateTime DataDevolucao { get; set; }
        public int StatusEmprestimo { get; set; }

        public override string ToString()
        {
            return $"{IdCliente};{NumeroTombo};{DataEmprestimo.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)};{DataDevolucao.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)};{StatusEmprestimo}";
        }
    }
}
