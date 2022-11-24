
drop database if exists Projeto_Pds;
create database projeto_pds;
use Projeto_Pds;

create table Funcionario (
id_func integer not null primary key auto_increment,
nome_func varchar (200) not null,
cpf_func varchar (20) not null,
rg_func varchar (20),
data_nascimento_func date,
salario_func double not null,
endereco_func varchar (300),
celular_func varchar (50) not null,
funcao_func varchar (50) not null
);

insert into funcionario values (null, 'João Batista', '123.544.311-99', '22222 sesdec', '1988-10-30', 5000.00, '', '69 84111155', 'Vendedor');
insert into funcionario values (null, 'Marcos Garcia Souza', '565.888.988-88', '64444 sesdec', '1965-1-20', 45000.00, '', '', 'Vendedor');
insert into funcionario values (null, 'Leticia de Jesus', '998.999.789-55', '46666 sesdec', '1990-05-23', 1500.00, '11 454546511', '', 'Vendedora');
insert into funcionario values (null, 'Mateus Solano ', '522.222.232-08', '65655 spp', '1990-11-30', 900.00, '69 8855 5544', '69 5555 4444', 'Vendedor');
insert into funcionario values (null, 'Roger da Silva', '123.589.978-77', null, '1987-11-11', 1100.00, null, '69 9988 7788', 'Vendedor');
insert into funcionario values (null, 'Karina Quadros', '987.987.788-88', null, '1985-11-22', 1000.50, null, '69 8888 7777', 'Vendedor');
insert into funcionario values (null, 'Isaias Queiroz', '123.121.321-88', '87788 sesdec', '1980-11-30', 2000.00, null, '69 8877 88881', 'Vendedor');



create table Cliente (
id_cli integer not null primary key auto_increment,
nome_cli varchar (200) not null,
estado_civil_cli varchar (50),
cpf_cli varchar (20) not null,
rg_cli varchar (30),
data_nascimento_cli varchar(300),
telefone_cli varchar (50)
);

insert into cliente values (null, 'Rodrigo Hilbert', 'Casado', '111.111.111-11', '54654 sesdec', '1987-06-30', '69 84085712');
insert into cliente values (null, 'Tiago Lacerda', 'Casado', '111.111.111-22', '54654 sesdec',  '1965-1-1', '2725275272');
insert into cliente values (null, 'Tom Cruise', 'Solteiro', '111.111.111-33', '48877 sesdec',  '1950-05-30', '11 454546511');
insert into cliente values (null, 'José Pereiro da Silva', 'Casado', '222.222.222-88', '8888888 spp',  '1990-11-12', '69 88998899');
insert into cliente values (null, 'Maria de Jesus dos Santos', 'Solteira', '554.454.444-99', '99999 sesdec',  '1993-06-21', '69 3421 5511');
insert into cliente values (null, 'Camila de Oliveira', 'Casada', '987.123.654-55', '8889999 sesdec',  '2000-12-12', '69 3421 1122');
insert into cliente values (null, 'Marcos Araujo de Souza', 'Casado', '654.789.123-88', '998877 sesdec',  '1970-01-01', '69 84085712');
insert into cliente values (null, 'Cleiton Batista Ferraz', 'Solteiro', '321.111.222-44', '1234312 sesdec',  '1982-07-30', '69 3421 2211');
insert into cliente values (null, 'Eliana da Cruz', 'Solteira', '988.235.654-54', '12345 sesdec',  '1978-11-11', '69 3421 9999');
insert into cliente values (null, 'Igor Garcia da Silva', 'Solteiro', '123.445.888-99', '999992 sesdec',  '1989-12-30', '69 3421 1123');
insert into cliente values (null, 'Jackson Henrique da Silva Bezerra', 'Casado', '529.562.612-15', '880075 sesdec',  '1987-06-30', '4114414114');
insert into cliente values (null, 'jaqueline leao ', 'Casado', '111.111.111-11', '54654 sesdec', '1987-06-30', '69 84085712');




create table Carro (
id_car int primary key not null auto_increment,
modelo_car varchar (100) not null,
cor_car varchar (50) not null,
portas_car varchar (50),
placa_car varchar (50) not null,
marca_car varchar (50) not null,
status_car varchar(100)
);

insert into carro values (null, 'Gol 1.0', 'preto', '4 portas', 'ndr 2815', 'Volkswagen','disponivel');
insert into carro values (null, 'Palio 1.0', 'branco', '4 portas', 'nea 1231', 'Fiat','disponivel');
insert into carro values (null, 'Gol 1.0', 'preto', '4 portas', 'wat 1254', 'Volkswagen','disponivel');
insert into carro values (null, 'S-10', 'prata', '2 portas', 'eae 2815', 'GM','disponivel');
insert into carro values (null, 'Celta Spirit 1.0', 'branco', '4 portas', 'ndd 2815', 'GM','disponivel');
insert into carro values (null, 'Celta Life 1.0', 'vermelho', '2 portas', 'mra 1288', 'GM','disponivel');
insert into carro values (null, 'Hilux 2.4', 'prata', '4 portas', 'rtu 3498', 'Toyota','disponivel');
insert into carro values (null, 'Prisma LTZ', 'branco', '4 portas', 'oip 1231', 'GM','disponivel');
insert into carro values (null, 'Hilux 2.4', 'branco', '4 portas', 'asd 1234', 'Toyota','disponivel');
insert into carro values (null, 'HB-20', 'preto', '4 portas', 'ndt 1155', 'Hunday','disponivel');
insert into carro values (null, 'Hilux 2.4', 'prata', '4 portas', 'noo 2010', 'Toyota','disponivel');
insert into carro values (null, 'Gol 1.6', 'branco', '4 portas', 'nnd 2066', 'Volkswagen','disponivel');
insert into carro values (null, 'Cruze LTZ 1.8', 'preto', '4 portas', 'ndm 2819', 'GM','disponivel');
insert into carro values (null, 'Cruze LTZ 1.8', 'branco', '4 portas', 'nra 2233', 'GM','disponivel');


create table Retirada(
id_ret int  not null primary key auto_increment,
dataHora datetime,
id_func_fk int ,
foreign key (id_func_fk) references Funcionario (id_func),
id_cli_fk int ,
foreign key (id_cli_fk) references Cliente(id_cli),
id_car_fk int ,
foreign key (id_car_fk) references Carro(id_car),
status_ret varchar(100)
);

create table TipoPagamento(
id_pag int  not null primary key auto_increment,
tipoPag_tp varchar(100)
);

insert into TipoPagamento values (null,'avista');
insert into TipoPagamento values (null,'prazo');
insert into TipoPagamento values (null,'pix');
insert into TipoPagamento values (null,'cartao');
insert into TipoPagamento values (null,'cheque');

create table Devolucao(
id_dev int  not null primary key auto_increment,
data_dev date,
hora_dev time,
km_dev int,
id_ret_fk int ,
foreign key (id_ret_fk) references Retirada (id_ret),
 id_car_fk int ,
foreign key (id_car_fk) references Carro(id_car)
);

create table Caixa(
id_cai int  not null primary key auto_increment,
data_cai varchar(100),
valorpag_cai varchar(100),
id_pag_fk int,
foreign key (id_pag_fk) references TipoPagamento(id_pag),
id_func_fk int,
foreign key (id_func_fk) references Funcionario(id_func),
id_cli_fk int,
foreign key (id_cli_fk) references Cliente(id_cli),
id_dev_fk int,
foreign key (id_dev_fk) references Devolucao (id_dev)
);










