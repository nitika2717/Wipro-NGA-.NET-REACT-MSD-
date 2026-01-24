USE ng;
CREATE TABLE Students(
StudentId INT PRIMARY KEY,
Email VARCHAR(100)UNIQUE,
Age INT CHECK (Age >=18),
CourseId INT );
INSERT INTO Students VALUES(1,'ria@gmail.com', 26,101);
INSERT INTO Students VALUES(2,'avantika@gmail.com', 27,102);
INSERT INTO Students VALUES(3,'nitika@gmail.com', 23,103);
INSERT INTO Students VALUES(4,'diksha@gmail.com', 24,104);
INSERT INTO Students VALUES(5,'rashi@gmail.com', 20,105);

SELECT COUNT(*) AS TotalStudents FROM Students;
SELECT AVG(Age) AS AverageAge FROM Students;

--Scalar function
SELECT StudentId, LEN(Email) as EmailLength,
GETDATE() AS currentDate
From Students;

SELECT* FROM Students;

--grouping
Select CourseId, Count(*) AS StudentCount
from Students
Group by CourseId;
Select Count(*) as TotalStudents FROM Students;

BEGIN TRANSACTION
UPDATE Students
SET Age=Age +1
Where CourseId=104;

ROLLBACK;

BEGIN TRANSACTION
UPDATE Students
SET Age=25
Where StudentId=4;
SAVE TRANSACTION S1;--all the changes will be saved till this save point

UPDATE Students
SET Age=21
Where StudentId=3;
ROLLBACK TRANSACTION S1;

COMMIT;



