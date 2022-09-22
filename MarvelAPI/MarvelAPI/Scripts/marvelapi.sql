create database dbMarvelAPI;
use dbMarvelAPI;

create table Series(
	idSerie int primary key auto_increment,
    title varchar(50),
    startYear int,
    thumbnail varchar(100)
);
CREATE TABLE Personagem(
	IdCharacter int primary key auto_increment,
    Nome varchar(50), 
    thumbnail varchar(100)
);
create table PersonagemSerie(
	idSerie int,
    idCharacter int,
    primary key(idSerie, idCharacter),
    foreign key (idSerie) references Series(idSerie),
    foreign key (idCharacter) references Personagem(idCharacter)
);
create table Quadrinhos(
	IdComics int primary key auto_increment,
    title varchar(50) not null,
    thumbnail varchar(100),
    issueNumber smallint
);
create table PersonagemQuadrinho(
	IdCharacter int,
    IdComics int,
    primary key (IdCharacter, IdComics),
    foreign key (IdCharacter) references Personagem(IdCharacter),
    foreign key (IdComics) references Quadrinhos(IdComics)
);

-- Ajustar nomes dos personagens depois e link da imagem (ajustar na API também)

insert into Personagem (Nome, thumbnail) values ('Wanda Maximoff', 'wanda.png');
insert into Personagem (Nome, thumbnail) values ('Loki', 'loki.png');
insert into Personagem (Nome, thumbnail) values ('Spider-Man', 'spdm.png');
insert into Personagem (Nome, thumbnail) values ('Iron Man', 'ironman.png');

select * from Personagem;

-- Para series (link de imagem da própria api da marvel para deixar mais certo) 

insert into Series (title, startYear, thumbnail) values ('Black Widow', 2004, 'http://i.annihil.us/u/prod/marvel/i/mg/c/70/4bc37e337b8af,jpg');
insert into Series (title, startYear, thumbnail) values ('Alpha Flight', 2004, 'http://i.annihil.us/u/prod/marvel/i/mg/2/60/4bc69af2a8afd.jpg');

select * from Series;

-- Para quadrinhos 

insert into Quadrinhos (title, issueNumber, thumbnail) values ('Alpha Flight (2011) #8 (Yu Variant)', 8, 'http://i.annihil.us/u/prod/marvel/i/mg/c/70/4bc37e337b8af,jpg');

select * from Quadrinhos;

-- Mapeando as tabelas intermediárias (a nível de teste) 

insert into PersonagemSerie values (1, 2);

insert into PersonagemQuadrinho values (1, 1);

select * from PersonagemSerie;

select * from PersonagemQuadrinho;

-- Criando procedures para ver elas unidas 


