-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 06, 2021 at 12:29 AM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.0.13

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `pms`
--

-- --------------------------------------------------------

--
-- Table structure for table `project`
--

CREATE TABLE `project` (
  `ProjectId` mediumint(9) NOT NULL,
  `StatusId` mediumint(9) DEFAULT NULL,
  `ProjectImage` char(50) DEFAULT NULL,
  `Name` char(50) NOT NULL,
  `Desciption` char(50) DEFAULT NULL,
  `Priority` char(50) DEFAULT NULL,
  `Size` int(11) DEFAULT NULL,
  `CreatedDate` datetime DEFAULT NULL,
  `DueDate` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `statuscode`
--

CREATE TABLE `statuscode` (
  `StatusId` mediumint(9) NOT NULL,
  `Name` char(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

-- --------------------------------------------------------

--
-- Table structure for table `task`
--

CREATE TABLE `task` (
  `TaskId` mediumint(9) NOT NULL,
  `ProjectId` mediumint(9) NOT NULL,
  `StatusId` mediumint(9) NOT NULL,
  `ParentTaskId` mediumint(9) DEFAULT NULL,
  `Name` char(50) NOT NULL,
  `Description` char(50) DEFAULT NULL,
  `Size` int(11) DEFAULT NULL,
  `FrequencyStartDate` datetime DEFAULT NULL,
  `ReminderDate` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `project`
--
ALTER TABLE `project`
  ADD PRIMARY KEY (`ProjectId`),
  ADD KEY `StatusId_Constraint_2` (`StatusId`);

--
-- Indexes for table `statuscode`
--
ALTER TABLE `statuscode`
  ADD PRIMARY KEY (`StatusId`);

--
-- Indexes for table `task`
--
ALTER TABLE `task`
  ADD PRIMARY KEY (`TaskId`),
  ADD KEY `ProjectId_Constraint` (`ProjectId`),
  ADD KEY `StatusId_Constraint` (`StatusId`),
  ADD KEY `ProjectId_Constraint_2` (`ParentTaskId`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `project`
--
ALTER TABLE `project`
  MODIFY `ProjectId` mediumint(9) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `statuscode`
--
ALTER TABLE `statuscode`
  MODIFY `StatusId` mediumint(9) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT for table `task`
--
ALTER TABLE `task`
  MODIFY `TaskId` mediumint(9) NOT NULL AUTO_INCREMENT;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `project`
--
ALTER TABLE `project`
  ADD CONSTRAINT `StatusId_Constraint_2` FOREIGN KEY (`StatusId`) REFERENCES `statuscode` (`StatusId`);

--
-- Constraints for table `task`
--
ALTER TABLE `task`
  ADD CONSTRAINT `ProjectId_Constraint` FOREIGN KEY (`ProjectId`) REFERENCES `project` (`ProjectId`),
  ADD CONSTRAINT `ProjectId_Constraint_2` FOREIGN KEY (`ParentTaskId`) REFERENCES `task` (`TaskId`),
  ADD CONSTRAINT `StatusId_Constraint` FOREIGN KEY (`StatusId`) REFERENCES `statuscode` (`StatusId`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
