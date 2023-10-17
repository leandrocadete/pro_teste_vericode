
CREATE TABLE "StatusTarefa" (
	"Id"	INTEGER,
	"Descricao"	TEXT NOT NULL,
	PRIMARY KEY("Id")
);

CREATE TABLE "Tarefa" (
	"Id"	INTEGER,
	"Descricao"	TEXT NOT NULL,
	"Status"	INTEGER NOT NULL,
	"DataCriacao"	TEXT NOT NULL,
	PRIMARY KEY("Id" AUTOINCREMENT),
	FOREIGN KEY("Status") REFERENCES "StatusTarefa" ("Id")
);

INSERT INTO Tarefa (Descricao, Status, DataCriacao) 
VALUES (@Descricao, @Status, @DataCriacao);


insert into StatusTarefa(Id, Descricao) values (1, 'Pendente');
insert into StatusTarefa(Id, Descricao) values (2, 'Em Execução');
insert into StatusTarefa(Id, Descricao) values (3, 'Finalizada');
insert into StatusTarefa(Id, Descricao) values (4, 'Cancelada');