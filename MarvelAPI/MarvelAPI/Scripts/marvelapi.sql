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

insert into Personagem (Nome, thumbnail) values ('Scarlet Witch', 'http://i.annihil.us/u/prod/marvel/i/mg/6/70/5261a7d7c394b.jpg');
insert into Personagem (Nome, thumbnail) values ('Loki', 'http://i.annihil.us/u/prod/marvel/i/mg/d/90/526547f509313.jpg');
insert into Personagem (Nome, thumbnail) values ('Peter Parker', 'http://i.annihil.us/u/prod/marvel/i/mg/b/40/image_not_available.jpg');
insert into Personagem (Nome, thumbnail) values ('Iron Man', 'http://i.annihil.us/u/prod/marvel/i/mg/9/c0/527bb7b37ff55.jpg');

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


