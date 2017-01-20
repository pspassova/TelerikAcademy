create schema `Books`;

create table if not exists `Books`.`Titles` (
	`TitleId` int primary key,
    `TitleName` char(100)
);

create table if not exists `Books`.`Authors` (
	`AuthorId` int primary key,
    `AuthorName` char(100)
);

create table if not exists `Books`.`PublishDates` (
	`PublishDate` datetime 
);

create table if not exists `Books`.`ISBNs` (
	`ISBN` char(13)
);

create table if not exists `Books`.`Book` (
	`BookId` int primary key,
	`TitleId` int references `Titles` (`TitleId`),
    `AuthorId` int default 1 references `Authors` (`AuthorId`),
    `PublishDate` datetime default now(),
    `ISBN` char(13) default '9781402894626'
);

insert into `Books`.`Titles` (`TitleId`, `TitleName`)
values (1, 'Harry Potter and the Philosopher''s Stone (1997)'),
(2, 'Harry Potter and the Chamber of Secrets (1998)'),
(3, 'Harry Potter and the Prisoner of Azkaban (1999)'),
(4, 'Harry Potter and the Goblet of Fire (2000)'),
(5, 'Harry Potter and the Order of the Phoenix (2003)'),
(6, 'Harry Potter and the Half-Blood Prince (2005)'),
(7, 'Harry Potter and the Deathly Hallows');

insert into `Books`.`Authors` (`AuthorId`, `AuthorName`)
values (1, 'Joan K. Rowling');

insert into `Books`.`Book` (`BookId`, `TitleId`)
values (1, 1), (2, 3), (3, 5), (4, 7);

use `Books`;
select Book.BookId as 'Book''s ID', Titles.TitleName as 'Title', Authors.AuthorName as 'Author'
from `Book`
inner join `Titles` 
on Book.TitleId = Titles.TitleId
inner join `Authors`
on Book.AuthorId = Authors.AuthorId;

use `Books`;
select Book.BookId as 'Book''s ID', Titles.TitleName as 'Title'
from `Book`
inner join `Titles`
on Book.TitleId = Titles.TitleId
where Titles.TitleName like '%harry%';