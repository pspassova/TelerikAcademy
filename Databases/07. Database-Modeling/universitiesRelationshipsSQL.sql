CREATE TABLE [ProfessorsTitles] (
	[ProfessorId] INT NOT NULL,
    [TitleId] INT NOT NULL,
CONSTRAINT [PK_ProfessorsTitles] PRIMARY KEY CLUSTERED (
	[ProfessorId],
	[TitleId]
)
)

CREATE TABLE [ProfessorsCourses] (
	[ProfessorId] INT NOT NULL,
	[CourseId] INT NOT NULL,
CONSTRAINT [PK_ProfessorsCourses] PRIMARY KEY CLUSTERED (
	[ProfessorId],
	[CourseId]
)
)

CREATE TABLE [StudentsCourses] (
	[StudentId] INT NOT NULL,
	[CourseId] INT NOT NULL,
CONSTRAINT [PK_StudentsCourses] PRIMARY KEY CLUSTERED (
	[StudentId],
	[CourseId]
)
)

ALTER TABLE [Departments] 
WITH CHECK ADD CONSTRAINT [FK_Depratments_Faculties] 
FOREIGN KEY ([FacultyId])
REFERENCES [Faculties] ([Id])

ALTER TABLE [Students]
WITH CHECK ADD CONSTRAINT [FK_Students_Faculties]
FOREIGN KEY ([FacultyId])
REFERENCES [Faculties] ([Id])

ALTER TABLE [StudentsCourses]
WITH CHECK ADD CONSTRAINT [FK_StudentCourses_Students]
FOREIGN KEY ([StudentId])
REFERENCES [Students] ([Id])

ALTER TABLE [StudentsCourses]
WITH CHECK ADD CONSTRAINT [FK_StudentCourses_Courses]
FOREIGN KEY ([CourseID])
REFERENCES [Courses] ([Id])

ALTER TABLE [Professors]
WITH CHECK ADD CONSTRAINT [FK_Professors_Departments]
FOREIGN KEY ([DepartmentId])
REFERENCES [Departments] ([Id])

ALTER TABLE [ProfessorsCourses]
WITH CHECK ADD CONSTRAINT [FK_ProfessorsCourses_Professor]
FOREIGN KEY ([ProfessorId])
REFERENCES [Professors] ([Id])

ALTER TABLE [ProfessorsCourses]
WITH CHECK ADD CONSTRAINT [FK_ProfessorsCourses_Courses]
FOREIGN KEY ([CourseId])
REFERENCES [Courses] ([Id])

ALTER TABLE [ProfessorsTitles]
WITH CHECK ADD CONSTRAINT [FK_ProfessorsTitles_Professors]
FOREIGN KEY ([ProfessorId])
REFERENCES [Professors] ([Id])

ALTER TABLE [ProfessorsTitles]
WITH CHECK ADD CONSTRAINT [FK_ProfessorsTitles_Titles]
FOREIGN KEY ([TitleId])
REFERENCES [Titles] ([Id])