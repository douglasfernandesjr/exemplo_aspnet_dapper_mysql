CREATE TABLE Tarefa (
IdTarefa INT AUTO_INCREMENT PRIMARY KEY,
Descricao VARCHAR(250) NOT NULL,
Concluido INTEGER DEFAULT 0
) ENGINE=INNODB;