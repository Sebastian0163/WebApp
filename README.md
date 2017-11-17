# WebApp
проект
CREATE TABLE [dbo].[WineCategory] (
    [Id]              INT NOT NULL PRIMARY KEY IDENTITY, 
    [Category]         NVARCHAR (56)  NOT NULL	   
);

CREATE TABLE [dbo].[Wienmaker] (
    [Id]              INT NOT NULL PRIMARY KEY IDENTITY, 
	[Name]            NVARCHAR  (MAX)  NOT NULL,	 
	[Brande]	      NVARCHAR  (56)   NULL,	   
	[Number]	      NVARCHAR  (256)  NULL,	   
	[Email]	          NVARCHAR  (256)  NOT NULL,	   
	[Image]           VARBINARY(max)   NULL	  	     
);
CREATE TABLE [dbo].[Wine] (
    [Id]              INT NOT NULL PRIMARY KEY IDENTITY, 
	[Name]            NVARCHAR  (MAX)  NOT NULL,	 
	[CategoryId]	  INT              NULL,
	[Image]           VARBINARY(max)   NULL,		 	   
	[Description]	  NVARCHAR  (MAX)  NULL,		   
	[WienmakerId]	  INT              NULL,
	CONSTRAINT [FK_Wine_WineCategory] Foreign KEY ([CategoryId]) REFERENCES [WineCategory]([Id])	  
	ON DELETE SET NULL,
	CONSTRAINT [FK_Wine_Wienmaker] Foreign KEY ([WienmakerId]) REFERENCES [Wienmaker]([Id])	  
	ON DELETE SET NULL,	  	     
);
