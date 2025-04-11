using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class Cliente
    {
        public string nome;
        public string cpf;
        public string email;
        public string telefone;
        public int conta;
        public int idade;
        public double saldo;

        public void adicionarCliente()
        {
            Console.WriteLine("Digite o nome do cliente:");
            nome = Console.ReadLine();
            /*Console.WriteLine("Digite o CPF do cliente:");
            cpf = Console.ReadLine();
            Console.WriteLine("Digite o email do cliente:");
            email = Console.ReadLine();
            Console.WriteLine("Digite o telefone do cliente:");
            telefone = Console.ReadLine();
            Console.WriteLine("Digite a idade do cliente:");
            idade = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o número da conta do cliente:");
            conta = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o saldo da conta do cliente:");
            saldo = double.Parse(Console.ReadLine());

            */


        }




    }
}
