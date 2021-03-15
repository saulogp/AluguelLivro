using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelLivro
{
    public class Cliente
    {
        public long IdCliente { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Telefone { get; set; }
        public Endereco Endereco { get; set; }

        public override string ToString()
        {
            return $"{IdCliente};{CPF};{Nome};{DataNascimento.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)};{Telefone};{Endereco.Logradouro};{Endereco.Bairro};{Endereco.Cidade};{Endereco.Estado};{Endereco.CEP}";
        }
    }
}
