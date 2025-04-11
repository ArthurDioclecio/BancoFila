using System;

namespace Banco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int selecionarmenu = 0;
            int contagemfila = 0;
            int selecaofila = 0;
            int contagemcliente = 0;
            int selecaocliente = 0;

            Cliente temp = new Cliente();
     

            Cliente[] fila = new Cliente[10];
            Cliente[] cliente = new Cliente[10];

            for (int i = 0; i < 10; i++)
            {
                fila[i] = new Cliente();
                cliente[i] = new Cliente();
            }

            void criarCliente()
            {
                if (contagemcliente < 10)
                {
                    cliente[contagemcliente].adicionarCliente();
                    contagemcliente++;
                }else
                {
                    Console.WriteLine("\nLimite de clientes atingido, mova algum cliente para a fila ou delete um existente\n");
                }
            }

            void adicionarNaFila()
            {

                if (contagemfila < 10 && contagemcliente > 0)
                {
                    listarCliente();
                    Console.WriteLine("\nSelecione o cliente que deseja adicionar na fila:\n");
                    selecaocliente = int.Parse(Console.ReadLine());
                    fila[contagemfila] = cliente[selecaocliente];

                    for (int i = selecaocliente; i < contagemcliente - 1; i++)
                    {
                        cliente[i] = cliente[i + 1];
                    }

                    cliente[contagemcliente - 1] = new Cliente();
                    contagemcliente--;
                    contagemfila++;
                }
                else
                {
                    Console.WriteLine("\nFila cheia, atenda um cliente para adicionar\nOu nao tem clientes cadastrados\n");
                }
            }

            void removerCliente()
            {
                if (contagemcliente == 0)
                {
                    Console.WriteLine("\nNão há clientes cadastrados\n");
                    return;
                }
                else
                {
                    
                    Console.WriteLine("\nSelecione o cliente que deseja remover:\n");
                    selecaocliente = int.Parse(Console.ReadLine());

                    for (int i = selecaocliente; i < contagemcliente - 1; i++)
                    {
                        cliente[i] = cliente[i + 1];
                    }

                    cliente[contagemcliente - 1] = new Cliente();
                    contagemcliente--;
                }
            }

            void atenderCliente()
            {
                if (contagemfila == 0)
                {
                    Console.WriteLine("\nFila vazia, adicione um cliente na fila\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\nSelecione o a posicao cliente da fila que deseja atender:\n");
                    selecaofila = int.Parse(Console.ReadLine());

                    for (int i = selecaofila; i < contagemfila - 1; i++)
                    {
                        fila[i] = fila[i + 1];
                    }

                    fila[contagemfila - 1] = new Cliente();
                    contagemfila--;
                }
            }


            void listarFila()
            {
                if (contagemfila == 0)
                {
                    Console.WriteLine("\nNão há clientes na fila\n");
                    return;
                }
                else
                {
                    for (int i = 0; i < contagemfila; i++)
                    {
                        Console.WriteLine("posição: {0} - Nome {1}", i, fila[i].nome);
                    }
                }
            }

            void listarCliente()
            {
                if (contagemcliente == 0)
                {
                    Console.WriteLine("\nNão há clientes cadastrados\n");
                    return;
                }
                else
                {
                    for (int i = 0; i < contagemcliente; i++)
                    {
                        Console.WriteLine("Cliente: {0} - Nome {1} ", i, cliente[i].nome);
                    }
                }
            }

            void mostrarCliente()
            {
                if (contagemcliente == 0)
                {
                    Console.WriteLine("\nNão há clientes cadastrados\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\nSelecione o cliente que deseja ver:\n");
                    selecaocliente = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nome do cliente: {0}", cliente[selecaocliente].nome);
                    Console.WriteLine("CPF do cliente: {0}", cliente[selecaocliente].cpf);
                    Console.WriteLine("Email do cliente: {0}", cliente[selecaocliente].email);
                    Console.WriteLine("Telefone do cliente: {0}", cliente[selecaocliente].telefone);
                    Console.WriteLine("Idade do cliente: {0}", cliente[selecaocliente].idade);
                    Console.WriteLine("Conta do cliente: {0}", cliente[selecaocliente].conta);
                    Console.WriteLine("Saldo do cliente: {0}", cliente[selecaocliente].saldo);
                }
            }

            void mostrarClienteFila()
            {
                if (contagemfila == 0)
                {
                    Console.WriteLine("\nNão há clientes na fila\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\nSelecione o cliente que deseja ver:\n");
                    selecaofila = int.Parse(Console.ReadLine());
                    Console.WriteLine("Nome do cliente: {0}", fila[selecaofila].nome);
                    Console.WriteLine("CPF do cliente: {0}", fila[selecaofila].cpf);
                    Console.WriteLine("Email do cliente: {0}", fila[selecaofila].email);
                    Console.WriteLine("Telefone do cliente: {0}", fila[selecaofila].telefone);
                    Console.WriteLine("Idade do cliente: {0}", fila[selecaofila].idade);
                    Console.WriteLine("Conta do cliente: {0}", fila[selecaofila].conta);
                    Console.WriteLine("Saldo do cliente: {0}", fila[selecaofila].saldo);
                }
            }

            void prioridadeFila()
            {
                if (contagemfila == 0)
                {
                    Console.WriteLine("\nNão há clientes na fila\n");
                    return;
                }
                else
                {
                    listarFila();
                    Console.WriteLine("\nSelecione o cliente que deseja colocar como prioritario:\n");
                    selecaofila = int.Parse(Console.ReadLine());


                    temp = fila[selecaofila];

                    for (int i = selecaofila; i > 0; i--)
                    {
                        fila[i] = fila[i - 1];
                    }

                    fila[0] = temp;
                }



            }
            // acho q dava pra deixar a selecao de cliente e fila na msm variavel mas to com preguiça de arrumar

            while (true)
            {
                Console.WriteLine("\nSelecione uma opção:\n");
                Console.WriteLine("1 - Adicionar cliente na fila");
                Console.WriteLine("2 - Criar cliente");
                Console.WriteLine("3 - Atender cliente");
                Console.WriteLine("4 - Listar clientes fora da fila");
                Console.WriteLine("5 - Listar clientes na fila");
                Console.WriteLine("6 - Mostrar cliente na fila");
                Console.WriteLine("7 - Mostrar cliente fora da fila");
                Console.WriteLine("8 - Colocar cliente como prioritario");
                Console.WriteLine("9 - Remover cliente fora da fila");
                Console.WriteLine("q - Sair");

                string input = Console.ReadLine();
                if (input == "q") break;

                selecionarmenu = int.Parse(input);
                switch (selecionarmenu)
                {
                    case 1:
                        adicionarNaFila();
                        break;
                    case 2:
                        criarCliente();
                        break;
                    case 3:
                        listarFila();
                        atenderCliente();
                        break;
                    case 4:
                        
                        listarCliente();
                        break;
                    case 5:
                        listarFila();
                        break;
                    case 6:
                        listarFila();
                        mostrarClienteFila();
                        break;
                    case 7:
                        listarCliente();
                        mostrarCliente();
                        break;
                    case 8:
                        prioridadeFila();
                        break;
                    case 9:
                        listarCliente();
                        
                        removerCliente();
                        break;
                    default:
                        Console.WriteLine("\nOpção inválida.\n");
                        break;
                }
            }
        }
    }
}

    
