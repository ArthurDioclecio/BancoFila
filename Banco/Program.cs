using System;

namespace Banco
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int contagemfila = 0;
            int selecaofila = 0;
            string confirmar;
            int opcao = 0;

            int chegada = 1;

            Cliente temp = new Cliente();


            Cliente[] fila = new Cliente[10];


            for (int i = 0; i < 10; i++)
            {
                fila[i] = new Cliente();

            }

            void criarCliente()
            {
                if (contagemfila < 10)
                {

                    Console.WriteLine("\nCriar Cliente\n");

                    Console.WriteLine("\nDigite C continuar\nDigite B para voltar\n");
                    confirmar = Console.ReadLine();

                    if (confirmar == "C" || confirmar == "c")
                    {


                        fila[contagemfila].adicionarCliente(chegada);
                        if (fila[contagemfila].pri == 1)
                        {
                            prioridadeFila();
                        }
                        else { }
                        contagemfila++;
                        chegada++;


                    }
                    else if (confirmar == "B" || confirmar == "b")
                    {

                        return;

                    }
                    else
                    {
                        Console.WriteLine("\nOpção invalida\n");
                        criarCliente();
                    }

                }
                else
                {
                    Console.WriteLine("\nLimite de clientes atingido\n");
                }

            }

            void atenderCliente()
            {
                if (contagemfila == 0)
                {
                    Console.WriteLine("\nNão há clientes na fila\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\nAtender cliente {0}\n", fila[0].nome);
                    Console.WriteLine("\nDigite C continuar\nDigite B para voltar\n");
                    confirmar = Console.ReadLine();

                    if (confirmar == "C" || confirmar == "c")
                    {
                        Console.WriteLine("\nCliente {0} atendido\n", fila[0].nome);

                        int i = 0;

                        for (i = 0; i < contagemfila - 1 && i < 9; i++)
                        {
                            fila[i] = fila[i + 1];
                        }

                        fila[i] = new Cliente();

                        contagemfila--;
                    }
                    else if (confirmar == "B" || confirmar == "b")
                    {

                        return;

                    }
                    else
                    {
                        Console.WriteLine("\nOpção invalida\n");
                        atenderCliente();
                    }

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
                    for (int i = 0; i < contagemfila && i < 10; i++)
                    {
                        Console.WriteLine("posição: {0} - Nome {1} - Ordem Chegada {2}", i, fila[i].nome, fila[i].ordem);
                    }
                }
            }

            void mostrarClienteFila()
            {
                if (contagemfila == 0)
                {
                    Console.Clear();

                    Console.WriteLine("\nNão há clientes na fila\n");
                    return;
                }
                else
                {
                    Console.WriteLine("\nVer Dados\n");
                    Console.WriteLine("\nDigite C continuar\nDigite B para voltar\n");
                    confirmar = Console.ReadLine();

                    if (confirmar == "C" || confirmar == "c")
                    {

                        listarFila();
                        Console.WriteLine("\nSelecione a posição do cliente que deseja ver:\n");
                        selecaofila = int.Parse(Console.ReadLine());
                        if (selecaofila > contagemfila - 1 || selecaofila < 0)
                        {
                            Console.WriteLine("\nCliente não existe\n");
                        }
                        else
                        {
                            mostrarClienteNaFila();
                        }
                    }
                    else if (confirmar == "B" || confirmar == "b")
                    {

                        return;

                    }
                    else
                    {
                        Console.WriteLine("\nOpção invalida\n");
                        mostrarClienteFila();
                    }
                }
            }
            void mostrarClienteNaFila()
            {

                Console.WriteLine("Nome do cliente: {0}", fila[selecaofila].nome);
                Console.WriteLine("CPF do cliente: {0}", fila[selecaofila].cpf);
                Console.WriteLine("Email do cliente: {0}", fila[selecaofila].email);
                Console.WriteLine("Telefone do cliente: {0}", fila[selecaofila].telefone);
                Console.WriteLine("Idade do cliente: {0}", fila[selecaofila].idade);
                Console.WriteLine("Conta do cliente: {0}", fila[selecaofila].conta);
                Console.WriteLine("Saldo do cliente: {0}", fila[selecaofila].saldo);
                Console.WriteLine("Prioritario: {0}\n", fila[selecaofila].pri);

            }

            void prioridadeFila()
            {

                selecaofila = contagemfila;

                temp = fila[selecaofila];
                int i = 0;

                for (i = selecaofila; i > 0 && fila[i - 1].pri == 0; i--)
                {
                    fila[i] = fila[i - 1];
                }

                fila[i] = temp;

            }

            void alterarDados()
            {
                int opcao = 0;
                listarFila();
                if (contagemfila == 0)
                {
                    return;
                }
                Console.WriteLine("\nAlterar Dados\n");
                Console.WriteLine("\nDigite C continuar\nDigite B para voltar\n");
                confirmar = Console.ReadLine();

                if (confirmar == "C" || confirmar == "c")
                {
                    Console.WriteLine("\nSelecione a posição do cliente que deseja alterar os dados\n");
                    selecaofila = int.Parse(Console.ReadLine());
                    if (selecaofila > contagemfila - 1 || selecaofila < 0)
                    {
                        Console.WriteLine("\nCliente não existe\n");
                    }
                    else
                    {
                        mostrarClienteNaFila();
                        Console.WriteLine("Qual informacão deseja alterar?");
                        Console.WriteLine("1 - Nome: ");
                        Console.WriteLine("2 - CPF: ");
                        Console.WriteLine("3 - E-mail: ");
                        Console.WriteLine("4 - Telefone: ");
                        Console.WriteLine("5 - Idade: ");
                        Console.WriteLine("6 - Número da conta");
                        Console.WriteLine("7 - Saldo: ");
                        Console.WriteLine("8 - Prioritario: ");
                        confirmar = Console.ReadLine();
                        if (confirmar == "1" || confirmar == "2" || confirmar == "3" || confirmar == "4" || confirmar == "5" || confirmar == "6" || confirmar == "7" || confirmar == "8")

                        {

                            opcao = int.Parse(confirmar);
                            Console.Clear();
                            switch (opcao)
                            {
                                case 1:
                                    Console.WriteLine("Digite o novo nome");
                                    fila[selecaofila].nome = Console.ReadLine();
                                    break;
                                case 2:
                                    Console.WriteLine("Digite o novo CPF");
                                    fila[selecaofila].cpf = Console.ReadLine();
                                    break;
                                case 3:
                                    Console.WriteLine("Digite o novo email");
                                    fila[selecaofila].email = Console.ReadLine();
                                    break;
                                case 4:
                                    Console.WriteLine("Digite o novo telefone");
                                    fila[selecaofila].telefone = Console.ReadLine();
                                    break;
                                case 5:
                                    Console.WriteLine("Digite a nova idade");
                                    fila[selecaofila].idade = int.Parse(Console.ReadLine());
                                    break;
                                case 6:
                                    Console.WriteLine("Digite o novo número de conta");
                                    fila[selecaofila].conta = int.Parse(Console.ReadLine());
                                    break;
                                case 7:
                                    Console.WriteLine("Digite o novo saldo");
                                    fila[selecaofila].saldo = double.Parse(Console.ReadLine());
                                    break;
                                case 8:
                                    Console.WriteLine("Digite a nova prioridade");
                                    fila[selecaofila].pri = int.Parse(Console.ReadLine());


                                    if (fila[selecaofila].pri == 1)
                                    {

                                        temp = fila[selecaofila];
                                        int i = 0;

                                        for (i = selecaofila; i > 0 && fila[i - 1].pri == 0 || i > 0 && fila[i - 1].ordem > temp.ordem; i--)
                                        {
                                            fila[i] = fila[i - 1];
                                        }

                                        fila[i] = temp;
                                    }
                                    else
                                    {
                                        temp = fila[selecaofila];
                                        int i = 0;

                                        for (i = selecaofila; i < 9 && fila[i + 1].pri == 1 || i < 9 && fila[i + 1].ordem < temp.ordem; i++)
                                        {
                                            fila[i] = fila[i + 1];
                                        }

                                        fila[i] = temp;

                                    }

                                    break;

                                default:
                                    break;
                            }
                        }
                        else
                        {
                            Console.WriteLine("\nOpção inválida.\n");
                        }
                    }



                }
                else if (confirmar == "B" || confirmar == "b")
                {

                    return;

                }
                else
                {
                    Console.WriteLine("\nOpção invalida\n");
                    alterarDados();
                }
            }




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
                if (confirmar == "1" || confirmar == "2" || confirmar == "3" || confirmar == "4" || confirmar == "5")
                {

                    selecaofila = int.Parse(confirmar);
                    switch (selecaofila)
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


