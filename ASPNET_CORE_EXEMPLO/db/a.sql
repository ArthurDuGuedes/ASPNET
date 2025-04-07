CREATE TABLE usuarios(
    id_usuario integer GENERATED ALWAYS AS IDENTITY NOT NULL,
    password varchar(255),
    nome_usuario varchar(255),
    ramal integer,
    especialidade varchar(255),
    PRIMARY KEY(id_usuario)
);

CREATE TABLE maquina(
    id_maquina integer GENERATED ALWAYS AS IDENTITY NOT NULL,
    tipo varchar(255),
    velocidade integer,
    harddisk integer,
    placa_rede integer,
    memoria_ram integer,
    fk_usuario integer,
    PRIMARY KEY(id_maquina),
    CONSTRAINT maquina_fk_usuario_fkey 
    FOREIGN KEY (fk_usuario) 
    REFERENCES usuarios(id_usuario)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);

CREATE TABLE software(
    id_software integer GENERATED ALWAYS AS IDENTITY NOT NULL,
    produto varchar(255),
    harddisk integer,
    memoria_ram integer,
    fk_maquina integer,
    PRIMARY KEY(id_software),
    CONSTRAINT software_fk_maquina_fkey 
    FOREIGN KEY (fk_maquina) 
    REFERENCES maquina(id_maquina)
    ON DELETE CASCADE
    ON UPDATE CASCADE
);


insert into maquina(tipo, velocidade, harddisk, placa_rede, memoria_ram, fk_usuario) values ('Desktop', 100, 1000, 100, 100, 1);