using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AluguelLivro
{
    public class ClienteController
    {
        public static bool VerificaCPF(List<Cliente> lista, string cpf)
        {
            foreach(Cliente c in lista)
            {
                if(c.CPF.Equals(cpf))
                {
                    return true;
                }
            }
            return false;
        }

        public static Cliente ReadCliente(List<Cliente> lista)
        {
            CultureInfo CultureBr = new CultureInfo(name: "pt-BR");
            Cliente cliente; ;
            string cpf, nome, telefone, logradouro, bairro, cidade, estado, cep;
            Console.WriteLine("Cadastro do cliente\n");

            Console.Write("Informe o CPF: ");
            cpf = Console.ReadLine();
            if (VerificaCPF(lista, cpf))//caso o cpf exista cai fora
            {
                Console.WriteLine("Cliente já cadastrado");
                return null;
            }
            int id = lista.Count() + 1;
            Console.Write("Informe o Nome: ");
            nome = Console.ReadLine();
            Console.Write("Informe o Telefone: ");
            telefone = Console.ReadLine();
            Console.Write("Informe o Data Nascimento: ");
            DateTime datanasc = DateTime.ParseExact(Console.ReadLine(), "d", CultureBr);
            Console.Write("Informe o Logradouro: ");
            logradouro = Console.ReadLine();
            Console.Write("Informe o Bairro: ");
            bairro = Console.ReadLine();
            Console.Write("Informe o Cidade: ");
            cidade = Console.ReadLine();
            Console.Write("Informe o Estado: ");
            estado = Console.ReadLine();
            Console.Write("Informe o CEP: ");
            cep = Console.ReadLine();

            cliente = new Cliente
            {
                IdCliente = id,
                CPF = cpf,
                Nome = nome,
                DataNascimento = datanasc,
                Telefone = telefone,
                Endereco = new Endereco
                {
                    Logradouro = logradouro,
                    Bairro = bairro,
                    Cidade = cidade,
                    Estado = estado,
                    CEP = cep
                }
            };
            return cliente;
        }
    }
}
