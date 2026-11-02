IF OBJECT_ID(N'dbo.AppUsers', N'U') IS NULL
BEGIN
	CREATE TABLE dbo.AppUsers
	(
		UserId int IDENTITY(1,1) NOT NULL CONSTRAINT PK_AppUsers PRIMARY KEY,
		Username nvarchar(50) NOT NULL,
		PasswordHash varbinary(32) NOT NULL,
		PasswordSalt varbinary(16) NOT NULL,
		IsAdmin bit NOT NULL CONSTRAINT DF_AppUsers_IsAdmin DEFAULT (0),
		CreatedAt datetime2 NOT NULL CONSTRAINT DF_AppUsers_CreatedAt DEFAULT (SYSUTCDATETIME()),
		CONSTRAINT UQ_AppUsers_Username UNIQUE (Username)
	);
END;
