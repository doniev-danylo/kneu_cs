create schema high_school
    go;

create table high_school.courses
(
    id              int identity (0, 1)
        constraint courses_pk
        primary key,
    department      varchar(60),
    course_name     int,
    education_hours int
)
    go

create table high_school.groups
(
    id              int identity (0, 1)
        constraint groups_pk
        primary key,
    code            varchar(10) not null,
    faculty         varchar(60),
    students_amount int,
    year            int
)
    go

create table high_school.exams
(
    id         int identity (0, 1)
        constraint exams_pk
            primary key,
    exam_datetime      datetime,
    type       int,
    tutor_name varchar(64),
    course_id  int not null
        constraint exams_courses_id_fk
            references high_school.courses,
    group_id   int not null
        constraint exams_groups_id_fk
            references high_school.groups
)
go

------------------------------------------------------------------------------------------------
--  Записати рядок в таблиці Група, Сесія, Дисципліна за допомогою оператора INSERT
declare @i int = 0;
while @i < 10
begin
insert into high_school.courses (department, course_name, education_hours)
values ('dept' + cast(@i as varchar), @i, @i*95);
set @i = @i + 1;
end;
go

declare @i int = 0;
set @i = 0;
while @i < 10
begin
insert into high_school.groups (code, faculty, students_amount, year)
values ('code' + cast(@i as varchar), 'faculty' + cast(@i as varchar), @i*10, 2023);
set @i = @i + 1;
end;
go

declare @i int = 0;
set @i = 0;
while @i < 10
begin
insert into high_school.exams (exam_datetime, type, tutor_name, course_id, group_id)
values (GETDATE(), @i, 'tutor' + cast(@i as varchar), @i, @i);
set @i = @i + 1;
end;
go

------------------------------------------------------------------------------------------------
--  Вибрати всі дані таблиці Група.

select *
from high_school.groups g
;

--  Вибрати дані стовпця Назва.
select distinct code
from high_school.groups g
;
------------------------------------------------------------------------------------------------
-- Вибрати дані стовпців Назва, Обсяг годин таблиці Дисципліна, де дані впорядковані по стовпцю Обсяг годин за зростанням.
select course_name, education_hours
from high_school.courses
order by education_hours asc

------------------------------------------------------------------------------------------------
-- Визначити дисципліну з кількістю годин, рівною 150.
select *
from high_school.courses
where education_hours  = 150