CREATE DATABASE ONG_MiAu_Etc_e_Tal;

USE ONG_MiAu_Etc_e_Tal;

CREATE TABLE Adotante(
	CPF varchar(11) NOT NULL,
	Nome varchar (50) NOT NULL,
	Data_Nasc Date NOT NULL,
	Sexo char (1) NOT NULL,
	Telefone varchar (11) NOT NULL,
	Logradouro varchar (50) NOT NULL,
	Numero varchar (10) NOT NULL,
	Complemento varchar (10) NOT NULL,
	Bairro varchar (50) NOT NULL,
	CEP varchar (20) NOT NULL,
	Cidade varchar (50) NOT NULL,
	UF char (2) NOT NULL

	CONSTRAINT PK_ADOTANTE_CPF PRIMARY KEY (CPF)

);
CREATE TABLE Animal(
	NUM_CHIP int identity NOT NULL,
	Nome varchar (50) NOT NULL,
	Raca varchar (20) NOT NULL,
	Sexo char (1) NOT NULL,
	Familia varchar (30) NOT NULL,

	CONSTRAINT PK_ANIMAL_NUM_CHIP PRIMARY KEY (NUM_CHIP)
);
CREATE TABLE Controle_Adocoes(
	NUM_CHIP int NOT NULL,
	CPF varchar(11)  NOT NULL,
	Data_Adocao DateTime NOT NULL,
	

	CONSTRAINT PK_Controle_Adocoes PRIMARY KEY (NUM_CHIP, CPF),
	CONSTRAINT FK_NUM_CHIP FOREIGN KEY (NUM_CHIP) REFERENCES Animal(NUM_CHIP),
	CONSTRAINT FK_CPF FOREIGN KEY (CPF) REFERENCES Adotante(CPF)
);
SELECT * FROM Adotante;
SELECT * FROM Animal;
SELECT * FROM Controle_Adocoes;



