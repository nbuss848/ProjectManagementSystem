﻿--CREATE TABLE PROJECT
--(
--	ProjectId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
--	StatusId int NOT NULL,
--	ProjectImage varchar(255) NULL,
--	[Name] varchar(max) NULL,
--	[Description] varchar(max) NULL,
--	[Classification] varchar(50) NULL,
--	[Priority] varchar(50) NULL,
--	Size int NULL,
--	CreatedDate datetime NULL,
--	DueDate datetime NULL
--)

--CREATE TABLE TASK(
--	TaskId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
--	ProjectId int NOT NULL,
--	StatusId int NOT NULL,
--	ParentTaskId int NULL,
--	[Name] varchar(50) NULL,
--	[Description] varchar(max) NULL,
--	Size int NULL,
--	FrequencyStartDate datetime NULL,
--	ReminderDate datetime NULL
--)

--Create Table Statuscode(
--	StatusId int PRIMARY KEY IDENTITY(1,1) NOT NULL,
--	[Name] varchar(50) NOT NULL
--)

 --ALTER TABLE [Project] ADD CONSTRAINT [FK_PROJECT_Status] FOREIGN KEY ([StatusId]) REFERENCES [Statuscode](StatusId)
 --ALTER TABLE [Task] ADD CONSTRAINT [FK_Project_Id] FOREIGN KEY (ProjectId) REFERENCES [Project](ProjectId)
 --ALTER TABLE [Task] ADD CONSTRAINT [FK_ParentTaskId] FOREIGN KEY (ParentTaskId) REFERENCES [Task](TaskId)
 --ALTER TABLE [Task] ADD CONSTRAINT [FK_Task_Status] FOREIGN KEY ([StatusId]) REFERENCES [Statuscode](StatusId)