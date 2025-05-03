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
        public string conta;
        public int idade;
        public int saldo;
        public int ordem;
        public int pri;

        public void adicionarCliente(int chegada)
        {
            Console.WriteLine("Digite o nome do cliente:");
            nome = Console.ReadLine();
            Console.WriteLine("Digite o CPF do cliente:");
            cpf = Console.ReadLine();
            Console.WriteLine("Digite o email do cliente:");
            email = Console.ReadLine();
            Console.WriteLine("Digite o telefone do cliente:");
            telefone = Console.ReadLine();
            Console.WriteLine("Digite a idade do cliente:");
            idade = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite o número da conta do cliente:");
            conta = Console.ReadLine();
            Console.WriteLine("Digite o saldo da conta do cliente:");
            saldo = int.Parse(Console.ReadLine());
            Console.WriteLine("Digite 1 para cliente prioritario \nDigite 0 para clienfe NÃO prioritario:");
            pri = int.Parse(Console.ReadLine());
            ordem = chegada;

        }




    }
}
