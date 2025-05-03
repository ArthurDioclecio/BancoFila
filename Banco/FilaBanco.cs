using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco
{
    public class FilaBanco
    {

        int contagemfila = 0;
        int selecaofila = 0;
        static int tamfila = 10;
        int iniciar = 0;

        string confirmar;

        int chegada = 1;

        Cliente temp = new Cliente();


        static Cliente[] fila = new Cliente[tamfila];



        protected void criarCliente()
        {
            if (contagemfila < tamfila)
            {
                if (iniciar == 0)
                {
                    for (int i = 0; i < tamfila; i++)
                    {
                        fila[i] = new Cliente();

                    }
                }

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

        protected void atenderCliente()
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

                    for (i = 0; i < contagemfila - 1 && i < tamfila - 1; i++)
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

        protected void listarFila()
        {
            if (contagemfila == 0)
            {
                Console.WriteLine("\nNão há clientes na fila\n");
                return;
            }
            else
            {
                for (int i = 0; i < contagemfila && i < tamfila; i++)
                {
                    Console.WriteLine("posição: {0} - Nome {1} - Ordem Chegada {2}", i, fila[i].nome, fila[i].ordem);
                }
            }
        }

        protected void mostrarClienteFila()
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

        protected void alterarDados()
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
                    if (int.TryParse(Console.ReadLine(), out opcao))

                    {
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
                                fila[selecaofila].conta = Console.ReadLine();
                                break;
                            case 7:
                                Console.WriteLine("Digite o novo saldo");
                                fila[selecaofila].saldo = int.Parse(Console.ReadLine());
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

                                    for (i = selecaofila; i < tamfila - 1 && fila[i + 1].pri == 1 || i < tamfila - 1 && fila[i + 1].ordem < temp.ordem; i++)
                                    {
                                        fila[i] = fila[i + 1];
                                    }

                                    fila[i] = temp;

                                }

                                break;

                            default:
                                Console.WriteLine("\nOpção invalida\n");
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

    }
}