
USE [master]
GO  
CREATE DATABASE [MyDB] ON    
(FILENAME = N'C:\Users\jaika\Desktop\UC\Web Design and Programming\Assignments\Assignment 2\AssignmentAsp\AssignmentAsp\Data\MyDB.mdf'),
(FILENAME = N'C:\Users\jaika\Desktop\UC\Web Design and Programming\Assignments\Assignment 2\AssignmentAsp\AssignmentAsp\Data\MyDb_log.ldf')
FOR ATTACH;
GO 