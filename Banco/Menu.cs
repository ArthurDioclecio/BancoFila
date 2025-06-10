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





CREATE DATABASE DB_CDs;

USE DB_CDs;

CREATE TABLE Artista (
    Cod_Art INT NOT NULL PRIMARY KEY,
    Nome_Art VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Gravadora (
    Cod_Grav INT NOT NULL PRIMARY KEY,
    Nome_Grav VARCHAR(50) NOT NULL UNIQUE
);

CREATE TABLE Categoria (
    Cod_Cat INT NOT NULL PRIMARY KEY,
    Nome_Cat VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Estado (
    Sigla_Est CHAR(2) NOT NULL PRIMARY KEY,
    Nome_Est VARCHAR(100) NOT NULL UNIQUE
);

CREATE TABLE Cidade (
    Cod_cidade INT NOT NULL PRIMARY KEY,
    Sigla_est CHAR(2) NOT NULL,
    Nome_cid VARCHAR(100) NOT NULL,
    FOREIGN KEY (Sigla_est) REFERENCES Estado(Sigla_Est)
);

CREATE TABLE Cliente (
    Cod_cli INT NOT NULL PRIMARY KEY,
    Cod_cid INT NOT NULL,
    Nome_Cli VARCHAR(100) NOT NULL,
    Endereço_cli VARCHAR(200) NOT NULL,
    Renda_cli DECIMAL(10,2) NOT NULL CHECK (Renda_cli >= 0),
    Sexo_cli CHAR(1) NOT NULL CHECK (Sexo_cli IN ('F', 'M')),
    FOREIGN KEY (Cod_cid) REFERENCES Cidade(Cod_cidade)
);

CREATE TABLE Conjuge (
    Cod_cli INT NOT NULL PRIMARY KEY,
    Nome_conj VARCHAR(100) NOT NULL,
    Renda_conj DECIMAL(10,2) NOT NULL CHECK (Renda_conj >= 0),
    Sexo_conj CHAR(1) NOT NULL CHECK (Sexo_conj IN ('F', 'M')),
    FOREIGN KEY (Cod_cli) REFERENCES Cliente(Cod_cli)
);

CREATE TABLE Funcionario (
    Cod_Func INT NOT NULL PRIMARY KEY,
    Nome_Func VARCHAR(100) NOT NULL,
    End_func VARCHAR(200) NOT NULL,
    Sal_func DECIMAL(10,2) NOT NULL CHECK (Sal_func >= 0),
    Sexo_func CHAR(1) NOT NULL CHECK (Sexo_func IN ('F', 'M'))
);
CREATE TABLE Dependente (
    Cod_Dep INT NOT NULL PRIMARY KEY,
    Cod_func INT NOT NULL,
    Nome_dep VARCHAR(100) NOT NULL,
    Sexo_dep CHAR(1) NOT NULL CHECK (Sexo_dep IN ('F', 'M')),
    FOREIGN KEY (Cod_func) REFERENCES Funcionario(Cod_Func)
);

CREATE TABLE Titulo (
    Cod_tit INT NOT NULL PRIMARY KEY,
    Cod_Cat INT NOT NULL,
    Cod_Grav INT NOT NULL,
    Nome_cd VARCHAR(100) NOT NULL UNIQUE,
    Val_cd DECIMAL(10,2) NOT NULL CHECK (Val_cd > 0),
    Qtd_Estq INT NOT NULL CHECK (Qtd_Estq >= 0),
    FOREIGN KEY (Cod_Cat) REFERENCES Categoria(Cod_Cat),
    FOREIGN KEY (Cod_Grav) REFERENCES Gravadora(Cod_Grav)
);

CREATE TABLE Pedido (
    Cod_ped INT NOT NULL PRIMARY KEY,
    Cod_cli INT NOT NULL,
    Cod_fun INT NOT NULL,
    Data_Ped datetime NOT NULL,
    Val_ped DECIMAL(10,2) NOT NULL CHECK (Val_ped > 0),
    FOREIGN KEY (Cod_cli) REFERENCES Cliente(Cod_cli),
    FOREIGN KEY (Cod_fun) REFERENCES Funcionario(Cod_Func)
);

CREATE TABLE Titulo_Pedido (
    Num_ped INT NOT NULL,
    Cod_tit INT NOT NULL,
    Qtd_cd INT NOT NULL CHECK (Qtd_cd >= 1),
    Val_cd DECIMAL(10,2) NOT NULL CHECK (Val_cd > 0),
    PRIMARY KEY (Num_ped, Cod_tit),
    FOREIGN KEY (Num_ped) REFERENCES Pedido(Cod_ped),
    FOREIGN KEY (Cod_tit) REFERENCES Titulo(Cod_tit)
);

CREATE TABLE Titulo_Artista (
    Cod_tit INT NOT NULL,
    Cod_Art INT NOT NULL,
    PRIMARY KEY (Cod_tit, Cod_Art),
    FOREIGN KEY (Cod_tit) REFERENCES Titulo(Cod_tit),
    FOREIGN KEY (Cod_Art) REFERENCES Artista(Cod_Art)
);

INSERT INTO Artista VALUES
(1, 'Marisa Monte'),
(2, 'Gilberto Gil'),
(3, 'Caetano Veloso'),
(4, 'Milton Nascimento'),
(5, 'Legião Urbana'),
(6, 'The Beatles'),
(7, 'Rita Lee');

INSERT INTO Gravadora VALUES
(1, 'Polygram'),
(2, 'EMI'),
(3, 'Som Livre'),
(4, 'Sony Music');

INSERT INTO Categoria VALUES
(1, 'MPB'),
(2, 'Trilha Sonora'),
(3, 'Rock Internacional'),
(4, 'Rock Nacional');

INSERT INTO Estado VALUES
('SP', 'São Paulo'),
('MG', 'Minas Gerais'),
('RJ', 'Rio de Janeiro');

INSERT INTO Cidade VALUES
(1, 'SP', 'São Paulo'),
(2, 'SP', 'Sorocaba'),
(3, 'SP', 'Jundiaí'),
(4, 'SP', 'Americana'),
(5, 'SP', 'Araraquara'),
(6, 'MG', 'Ouro Preto'),
(7, 'SP', 'Cachoeiro de Itapemirim');

INSERT INTO Cliente VALUES
(1, 1, 'José Nogueira', 'Rua A', 1500.00, 'M'),
(2, 1, 'Angelo Pereira', 'Rua B', 2000.00, 'M'),
(3, 1, 'Além Mar paranhos', 'Rua C', 1500.00, 'F'),
(4, 1, 'Catarina Souza', 'Rua D', 892.00, 'F'),
(5, 1, 'Vagner Costa', 'Rua E', 950.00, 'M'),
(6, 2, 'Antenor da Costa', 'Rua F', 1582.00, 'M'),
(7, 2, 'Maria Amélia de Sousa', 'Rua G', 1152.00, 'F'),
(8, 2, 'Paulo Roberto Silva', 'Rua H', 3250.00, 'M'),
(9, 3, 'Fátima Souza', 'Rua I', 1632.00, 'F'),
(10, 3, 'Joel da Rocha', 'Rua J', 2000.00, 'M');

INSERT INTO Conjuge VALUES
(1, 'Carla Nogueira', 2500.00, 'F'),
(2, 'Emília Pereira', 5500.00, 'F'),
(6, 'Altiva da Costa', 3000.00, 'F'),
(7, 'Carlos de Souza', 3250.00, 'M');

INSERT INTO Funcionario VALUES
(1, 'Vânia Gabriela Pereira', 'Rua A', 2500.00, 'F'),
(2, 'Norberto Pereira da Silva', 'Rua B', 3000.00, 'M'),
(3, 'Olavio Linhares', 'Rua C', 5800.00, 'M'),
(4, 'Paula da Silva', 'Rua D', 3000.00, 'F'),
(5, 'Rolando Rocha', 'Rua E', 2000.00, 'M');

INSERT INTO Dependente VALUES
(1, 1, 'Ana Pereira', 'F'),
(2, 1, 'Roberto Pereira', 'M'),
(3, 1, 'Celso Pereira', 'M'),
(4, 3, 'Brisa Linhares', 'F'),
(5, 3, 'Mari Sol Linhares', 'F'),
(6, 4, 'Sonia da Silva', 'F');

INSERT INTO Titulo VALUES
(1, 1, 1, 'Tribalista', 30.00, 1500),
(2, 1, 2, 'Tropicália', 50.00, 500),
(3, 1, 1, 'Aquele Abraço', 50.00, 600),
(4, 1, 2, 'Refazenda', 60.00, 1000),
(5, 1, 3, 'Totalmente demais', 50.00, 2000),
(6, 1, 3, 'Travessia', 55.00, 500),
(7, 1, 2, 'Courage', 30.00, 200),
(8, 4, 3, 'Legião Urbana', 20.00, 100),
(9, 3, 2, 'The Beatles', 30.00, 300),
(10, 4, 1, 'Rita Lee', 30.00, 500);

INSERT INTO Pedido VALUES
(1, 1, 2, '2022-02-02', 1500.00),
(2, 3, 4, '2022-02-05', 50.00),
(3, 4, 3, '2022-02-06', 100.00),
(4, 1, 4, '2023-02-02', 200.00),
(5, 7, 5, '2023-02-03', 300.00),
(6, 4, 4, '2023-02-03', 100.00),
(7, 5, 5, '2023-02-03', 50.00),
(8, 8, 2, '2023-02-03', 50.00),
(9, 2, 2, '2023-02-03', 2000.00),
(10, 7, 1, '2023-02-03', 3000.00);

INSERT INTO Titulo_Artista VALUES
(1, 1),
(2, 2),
(3, 2),
(4, 2),
(5, 3),
(6, 4),
(7, 4),
(8, 5),
(9, 6),
(10, 7);

INSERT INTO Titulo_Pedido VALUES
(1, 1, 2, 30.00),
(1, 2, 3, 20.00),
(2, 1, 1, 50.00),
(2, 2, 3, 30.00),
(3, 1, 2, 40.00),
(4, 2, 3, 20.00),
(5, 1, 2, 25.00),
(6, 2, 3, 30.00),
(7, 4, 2, 55.00),
(8, 1, 4, 60.00),
(9, 2, 3, 15.00),
(10, 7, 2, 15.00);






/* 1 */
select  gravadora.Nome_grav, gravadora.cod_grav, titulo.Nome_cd, titulo.cod_grav 
from gravadora, titulo where gravadora.cod_grav = titulo.cod_grav;

/* 2 */
select  categoria.Nome_cat, titulo.Nome_cd 
from categoria, titulo where categoria.cod_cat = titulo.cod_cat;

/* 3 */

select  categoria.Nome_cat, titulo.Nome_cd, gravadora.nome_grav 
from categoria, titulo, gravadora where categoria.cod_cat = titulo.cod_cat and titulo.cod_grav = gravadora.cod_grav;

/* 4 */

select cliente.nome_cli, titulo.nome_cd, titulo_pedido.num_ped from titulo, titulo_pedido, cliente, pedido where titulo_pedido.cod_tit = titulo.cod_tit and pedido.cod_cli = cliente.cod_cli;


select cliente.nome_cli, titulo.nome_cd, titulo_pedido.num_ped 
from titulo
left join cliente on titulo_pedido.cod_tit = titulo.cod_tit and pedido.cod_cli = cliente.cod_cli;//////



/* 5 */

select funcionario.nome_func, funcionario.cod_func, pedido.data_ped, pedido.val_ped, cliente.nome_cli from funcionario, pedido, cliente where pedido.cod_fun = funcionario.cod_func and pedido.cod_cli = cliente.cod_cli;

/* 6 */

select funcionario.nome_func, dependente.nome_dep from funcionario, dependente where funcionario.cod_func = dependente.cod_func;

/* 7 */

select cliente.nome_cli, conjuge.nome_conj from cliente, conjuge where cliente.cod_cli = conjuge.cod_cli;

/* 8 */

SELECT cliente.nome_cli, conjuge.nome_conj
FROM cliente
LEFT JOIN conjuge ON cliente.cod_cli = conjuge.cod_cli;

/* 9 */

select cliente.nome_cli, conjuge.nome_conj, pedido.cod_ped, pedido.val_ped, funcionario.cod_func from funcionario, cliente, conjuge, pedido where cliente.cod_cli = pedido.cod_cli and cliente.cod_cli = conjuge.cod_cli and pedido.cod_fun = funcionario.cod_func;




SELECT cliente.nome_cli, conjuge.nome_conj,  pedido.cod_ped, pedido.val_ped, funcionario.cod_func
FROM pedido
LEFT JOIN conjuge ON pedido.cod_fun = funcionario.cod_func and cliente.cod_cli = pedido.cod_cli or cliente.cod_cli = conjuge.cod_cli;//////////