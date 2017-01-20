CREATE SCHEMA IF NOT EXISTS `Universities`
DEFAULT CHARACTER SET utf8;

-- --------------------

CREATE TABLE IF NOT EXISTS `Universities`.`Faculties` (
	`Id` INT NOT NULL,
    `FacultyName` NVARCHAR(100) NOT NULL,
    PRIMARY KEY (`Id`)
);

-- --------------------

CREATE TABLE IF NOT EXISTS `Universities`.`Departments` (
  `Id` INT NOT NULL,
  `DepartmentName` NVARCHAR(100) NOT NULL,
  `FacultyId` INT NOT NULL,
  PRIMARY KEY (`Id`),
  INDEX `FK_Departments_Faculties_index` (`FacultyId`),
  CONSTRAINT `FK_Departments_Faculties`
    FOREIGN KEY (`FacultyId`)
    REFERENCES `Universities`.`Faculties` (`Id`)
);

-- --------------------

CREATE TABLE IF NOT EXISTS `Universities`.`Titles` (
	`Id` INT NOT NULL,
    `TitleName` VARCHAR(50) NOT NULL,
    PRIMARY KEY (`Id`)
);

-- --------------------

CREATE TABLE IF NOT EXISTS `Universities`.`Students` (
	`Id` INT NOT NULL,
    `StudentName` NVARCHAR(100),
    `FacultyId` INT NOT NULL,
    PRIMARY KEY (`Id`),
    INDEX `FK_Students_Faculties_index` (`FacultyId`),
    CONSTRAINT `FK_Students_Faculties`
    FOREIGN KEY (`FacultyId`)
    REFERENCES `Universities`.`Faculties` (`Id`)
);

-- --------------------

CREATE TABLE IF NOT EXISTS `Universities`.`Courses` (
	`Id` INT NOT NULL,
    `CourseName` NVARCHAR(50),
    `ProfessorId` INT NOT NULL,
    PRIMARY KEY (`Id`)
);

-- --------------------

CREATE TABLE IF NOT EXISTS `Universities`.`StudentsCourses` (
	`StudentId` INT NOT NULL,
    `CourseId` INT NOT NULL,
    PRIMARY KEY (`StudentId`, `CourseId`),
    INDEX `FK_StudentsCourses_Students_index` (`StudentId`),
    INDEX `FK_StudentsCourses_Courses_index` (`CourseId`),
    CONSTRAINT `FK_StudentCourses_Students`
		FOREIGN KEY (`StudentId`)
        REFERENCES `Universities`.`Students` (`Id`),
	CONSTRAINT `FK_StudentCourses_Courses`
		FOREIGN KEY (`CourseId`)
        REFERENCES `Universities`.`Courses` (`Id`)
);

-- --------------------

CREATE TABLE IF NOT EXISTS `Universities`.`Professors` (
	`Id` INT NOT NULL,
    `ProfessorName` NVARCHAR(50),
	`DepartmentId` INT NOT NULL,
    PRIMARY KEY (`Id`),
    INDEX `FK_Professors_Departments_index` (`DepartmentId`),
    CONSTRAINT `FK_Professors_Departments`
		FOREIGN KEY (`DepartmentId`)
        REFERENCES `Universities`.`Departments` (`Id`)
);

-- --------------------

CREATE TABLE IF NOT EXISTS `Universities`.`ProfessorsCourses` (
	`ProfessorId` INT NOT NULL,
    `CourseId` INT NOT NULL,
    PRIMARY KEY (`ProfessorId`, `CourseId`),
    INDEX `FK_ProfessorsCourses_Professors` (`ProfessorId`),
    INDEX `FK_ProfessorsCourses_Courses` (`CourseId`),
    CONSTRAINT `FK_ProfessorsCourses_Professors`
		FOREIGN KEY (`ProfessorId`)
        REFERENCES `Universities`.`Professors` (`Id`),
	CONSTRAINT `FK_ProfessorsCourses_Courses`
		FOREIGN KEY (`CourseId`)
        REFERENCES `Universities`.`Courses` (`Id`)
);

-- --------------------

CREATE TABLE IF NOT EXISTS `Universities`.`ProfessorsTitles` (
	`ProfessorId` INT NOT NULL,
    `TitleId` INT NOT NULL,
    PRIMARY KEY (`ProfessorId`, `TitleId`),
    INDEX `FK_ProfessorsTitles_Professors_index` (`ProfessorId`),
    INDEX `FK_ProfessorsTitles_Titles_index` (`TitleId`),
    CONSTRAINT `FK_ProfessorsTitles_Professors`
		FOREIGN KEY (`ProfessorId`)
        REFERENCES `Universities`.`Professors` (`Id`),
	CONSTRAINT `FK_ProfessorsTitles_Titles`
		FOREIGN KEY (`TitleId`)
        REFERENCES `Universities`.`Titles` (`Id`)
);













