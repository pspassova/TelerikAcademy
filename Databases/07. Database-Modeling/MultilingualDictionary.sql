CREATE DATABASE [MultilingualDictionary]
GO
CREATE TABLE [Words] (
	[Id] INT NOT NULL,
    [Word] NVARCHAR(100) NOT NULL,
	[DictionaryId] INT NOT NULL,
	[LanguageId] INT NOT NULL,
CONSTRAINT [PK_Words] PRIMARY KEY CLUSTERED (
	[Id] ASC
)
)
GO
CREATE TABLE [Dictionary] (
	[Id] INT NOT NULL,
	[Name] NVARCHAR(100) NOT NULL,
CONSTRAINT [PK_Dictionary] PRIMARY KEY CLUSTERED (
	[Id] ASC
)
)
GO
CREATE TABLE [Explanations] (
	[Id] INT NOT NULL,
	[Explanation] NVARCHAR(MAX) NOT NULL,
	[WordId] INT NOT NULL,
	[LanguageId] INT NOT NULL,
CONSTRAINT [PK_Explanations] PRIMARY KEY CLUSTERED (
	[Id] ASC
)
)
GO
CREATE TABLE [Languages] (
	[Id] INT NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
CONSTRAINT [PK_Language] PRIMARY KEY CLUSTERED (
	[Id] ASC
)
)
GO
CREATE TABLE [Synonyms] (
	[Id] INT NOT NULL,
	[Synonym] NVARCHAR(100) NOT NULL,
	[WordId] INT NOT NULL,
CONSTRAINT [PK_Synonyms] PRIMARY KEY CLUSTERED (
	[Id] ASC
)
)
GO
CREATE TABLE [Translations] (
	[Id] INT NOT NULL,
	[Translation] NVARCHAR(MAX) NOT NULL,
	[WordId] INT NOT NULL,
	[LanguageId] INT NOT NULL,
CONSTRAINT [PK_Translations] PRIMARY KEY CLUSTERED (
	[Id] ASC
)
)
GO
ALTER TABLE [Explanations] WITH CHECK ADD CONSTRAINT [FK_Explanations_Languages]
FOREIGN KEY ([LanguageId])
REFERENCES [Languages] ([Id])
GO
ALTER TABLE [Explanations] WITH CHECK ADD CONSTRAINT [FK_Explanations_Words]
FOREIGN KEY ([WordId])
REFERENCES [Words] ([Id])
GO
ALTER TABLE [Synonyms] WITH CHECK ADD CONSTRAINT [FK_Synonyms_Words]
FOREIGN KEY ([WordId])
REFERENCES [Words] ([Id])
GO
ALTER TABLE [Translations] WITH CHECK ADD CONSTRAINT [FK_Translations_Languages]
FOREIGN KEY ([LanguageId])
REFERENCES [Languages] ([Id])
GO
ALTER TABLE [Words] WITH CHECK ADD CONSTRAINT [FK_Words_Dictionary]
FOREIGN KEY ([DictionaryId])
REFERENCES [Dictionary] ([Id])
GO
ALTER TABLE [Words] WITH CHECK ADD CONSTRAINT [FK_Words_Languages] 
FOREIGN KEY ([LanguageId])
REFERENCES [Languages] ([Id])
GO