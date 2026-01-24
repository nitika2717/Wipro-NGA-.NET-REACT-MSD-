USE ng;
Create table MyCourses (
Courseid int primary key,
StudentName varchar(50)
);
CREATE TABLE My_Students (
    StudentId INT PRIMARY KEY,
    StudentName VARCHAR(50),
    CourseId INT
);
CREATE TABLE Trainers (
    TrainerId INT PRIMARY KEY,
    TrainerName VARCHAR(50),
    ManagerId INT
);
select * from Trainers;
insert into MyCourses values
(101,'Full Stack'),
(102,'Ml'),
(103,'Cloud');

insert into My_Students values
(1, 'Ria',101),
(2, 'Nisha',102),
(3, 'Harshit',101),
(4, 'Harsh',NULL);

insert into Trainers Values
(1,'Arjun',NULL),
(2, 'Reet',1),
(3, 'Ravi',1),
(4, 'Rashi',2);
select * from My_Students;
select * from MyCourses;
Select s.StudentName, s.StudentId, c.StudentName,c.CourseId
from My_Students s
inner join MyCourses c
On s.CourseId=c.Courseid;

Select s.StudentName, s.StudentId, c.StudentName,c.CourseId
from My_Students s
left join MyCourses c
On s.CourseId=c.Courseid;

select
t1.TrainerName as Trainers,
t2.TrainerName as Manager
from Trainers t1
left join Trainers t2
on t1.ManagerId=t2.TrainerId;


SELECT StudentName
FROM My_Students
UNION
SELECT TrainerName
FROM Trainers;

SELECT StudentName
FROM My_Students
intersect
SELECT TrainerName
FROM Trainers;



