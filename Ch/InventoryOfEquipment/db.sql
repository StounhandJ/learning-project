create table Otdel
(
    id_Otdel   Serial PRIMARY KEY,
    Name_Otdel varchar(50)
);

create table Doljnost
(
    id_Dolj   Serial PRIMARY KEY,
    Name_Dolj varchar(30),
    id_Otdel  integer REFERENCES "otdel" ("id_otdel")
);

create table personal
(
    id_personal   Serial PRIMARY KEY,
    fam_personal  varchar(30),
    name_personal varchar(30),
    otch_personal varchar(30) null default(''),
    login         varchar(20),
    "password"    varchar(20),
    mail_personal varchar(40),
    id_dolj       integer REFERENCES "doljnost" ("id_dolj")
);

create table equipment
(
    id_equip    Serial PRIMARY KEY,
    name_equip  varchar(50),
    prod_equip  varchar(30),
    price_equip decimal(30, 2),
    time_godn   date,
    date_pok    date,
    nomer_equip int,
    id_personal integer REFERENCES "personal" ("id_personal")
);

create table uchet_equip
(
    id_uchet    Serial PRIMARY KEY,
    id_personal integer REFERENCES "personal" ("id_personal"),
    id_equip    integer REFERENCES "equipment" ("id_equip"),
    Date_uchet  date
);


INSERT INTO otdel(id_Otdel, name_otdel)
VALUES (1, 'Отдел кадров'),
       (2, 'Технический отдел');

INSERT INTO doljnost(id_Dolj, name_dolj, id_otdel)
VALUES (1, 'Бухгалтер', 1),
       (2, 'Администратор БД', 2),
       (3, 'Сотрудник', 2);