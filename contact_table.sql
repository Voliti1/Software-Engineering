use library;

create table contact(
	id int auto_increment primary key,
    name varchar(20) not null,
    phone varchar(20) not null,
    email varchar(50),
    address varchar(50)
);

desc contact;

insert into contact values(null, "박찬호", "010-1234-1234", "ChanhoPark@gmail.com", "서울특별시 중구");
insert into contact values(null, "박지성", "010-1234-4321", "JisungPark@gmail.com", "경기도 수원시");