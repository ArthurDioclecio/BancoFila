using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Banco;

namespace Banco
{
    public class Menu : FilaBanco
    {
        public void exibir()
        {
            string confirmar;
            int selecao = 0;
            while (true)
            {
                Console.WriteLine("\nSelecione uma opção:\n");
                Console.WriteLine("1 - Criar cliente");
                Console.WriteLine("2 - Atender cliente");
                Console.WriteLine("3 - Listar clientes na fila");
                Console.WriteLine("4 - Ver dados do cliente");
                Console.WriteLine("5 - Alterar dados");
                Console.WriteLine("q - Sair");

                confirmar = Console.ReadLine();
                if (confirmar == "q" || confirmar == "Q") { break; }
                if (int.TryParse(confirmar, out selecao))
                {
                    switch (selecao)
                    {

                        case 1:
                            Console.Clear();
                            criarCliente();
                            break;
                        case 2:
                            Console.Clear();
                            atenderCliente();
                            break;

                        case 3:
                            Console.Clear();
                            listarFila();
                            break;
                        case 4:
                            Console.Clear();
                            mostrarClienteFila();
                            break;

                        case 5:
                            Console.Clear();
                            alterarDados();
                            break;
                        default:
                            Console.Clear();
                            Console.WriteLine("\nOpção inválida.\n");
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("\nOpção inválida.\n");
                }
            }


        }

    }
}

