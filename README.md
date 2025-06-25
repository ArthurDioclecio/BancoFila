create database aula1706;
use aula1706;

create table Cliente (
cod_cli int primary key auto_increment,
nome_cli varchar(100),
sexo_cli char(1),
sal_cli decimal(10,2)
);
create table Professor(
cod_prof int primary key auto_increment,
nome_prof varchar(100),
sal_prof decimal(10,2)
);

create table Aluno (
cod_Aluno int primary key auto_increment,
nome_aluno varchar(100),
sexo_aluno char(1)
);

create table Cargo (
cod_cargo int auto_increment primary key,
nome_cargo varchar(100) unique
);

create table funcionario (
cod_func int primary key auto_increment,
cod_cargo int,
nome_func varchar(100),
sal_func decimal(10,2),
rg_func varchar(11),
FOREIGN KEY (cod_cargo) REFERENCES cargo(cod_cargo)
);

create table Dependente (
cod_dep int primary key auto_increment,
cod_func int,
nome_dep varchar(100),
FOREIGN KEY (cod_func) REFERENCES Funcionario(cod_func)
);




insert into Cliente(nome_cli, sexo_cli, sal_cli) values 
('Abigail Costa','F',1200.50),
('Bianca Souza','F',1300.30),
('Denise Ruiz','F',2100.10),
('Fátima de Castro','F',1250.25),
('Marisa ALves','F',2125.20);

insert into Professor(nome_prof,sal_prof) values 
('Fábio Souza',2100.20),
('Rafael Estoril',2500.30),
('Mariana Fuentes',1230.20),
('Samanta Pires',1400.10),
('Vitor Arruda',2100.25),
('Carlos Marino',1200.50);

insert into Aluno(nome_aluno, sexo_aluno) values 
('Luis Nunes','M'),
('Sandra Silva','F'),
('Celina Lima','F');

insert into Cargo(nome_cargo) values 
('Presidente'),
('Gerente'),
('Supervisor'),
('Revisor'),
('Redator');

insert into Funcionario(cod_cargo, nome_func, sal_func, rg_func) values 
(5,'Luis Pereira',3000,'27.291.905'),
(5,'Antonio Almeida',3000,'15.970.247'),
(3,'Donizete Ribeiro',2800,'27.151.908'),
(3,'Gabriela Moura',4700,'25.279.145'),
(2,'Emilio Duarte',5000,'172.278.246'),
(1,'CAroline Ferreira',9000,'18.154.578');

insert into Dependente(nome_dep, cod_func) values 
('Mariana Pereira',1),
('Camila Pereira',1),
('Josival Pereira',1),
('Clovis Almeida',2),
('Durval Almeida',2),
('Fabiana Duarte',5),
('Joana Duarte',5);



select * from Dependente;
select * from Aluno;
select * from Professor;
select * from cliente;
select * from cargo;
describe cliente;
select * from funcionario;

Select cod_cli as Cod_pes, 
'Cliente' as Tipo_pes, 
nome_cli as Nome_pes, 
Sexo_cli as Sexo_pes, 
sal_cli as Salario_pes from cliente union all 
select cod_prof, 'Professor', Nome_Prof, 'ND', sal_prof from Professor union all
select cod_aluno, 'Aluno',nome_aluno, sexo_aluno, Null from Aluno;

select * from cargo 
where cod_cargo not in (select cod_cargo from funcionario);


select * from cargo 
where cod_cargo in (select cod_cargo from funcionario)
order by cod_cargo;

select * from cargo 
where cod_cargo in (select cod_cargo from Funcionario where cod_func in (select cod_func from dependente))
order by cod_cargo;

select * from cargo 
where cod_cargo in (select cod_cargo from Funcionario where cod_func NOT in (select cod_func from dependente))
order by cod_cargo;

select * from funcionario where sal_func = (select max(sal_func) from funcionario);

select * from funcionario where sal_func = (select min(sal_func) from funcionario);

update funcionario set sal_func = sal_func*1.1 where cod_func not in(select cod_func from dependente);

delete from funcionario where cod_func not in (select cod_func from dependente);










#include <Stepper.h>

const int stepsPerRevolution = 2048;

// Pinos conectados ao driver do motor
Stepper myStepper(stepsPerRevolution, 8, 10, 9, 11);

void setup() {
  myStepper.setSpeed(15); // velocidade em RPM
}

void loop() {
  myStepper.step(1); // um passo por iteração: gira continuamente
}



