CREATE TABLE Users (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    UserName NVARCHAR(256) NOT NULL,
    NormalizedUserName NVARCHAR(256) NOT NULL,
    Email NVARCHAR(256) NOT NULL,
    NormalizedEmail NVARCHAR(256) NOT NULL,
    EmailConfirmed BIT NOT NULL,
    PasswordHash NVARCHAR(MAX) NOT NULL,
    IsActive BIT NOT NULL,
    IsDeleted BIT NOT NULL
);
GO

CREATE TABLE Roles (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    Name NVARCHAR(256) NOT NULL,
    NormalizedName NVARCHAR(256) NOT NULL,
    IsDeleted BIT NOT NULL DEFAULT 0
);
GO

CREATE TABLE UserRoles (
    UserId INT NOT NULL,
    RoleId INT NOT NULL,
    PRIMARY KEY (UserId, RoleId),
    CONSTRAINT FK_UserRoles_Users FOREIGN KEY (UserId) REFERENCES Users(Id),
    CONSTRAINT FK_UserRoles_Roles FOREIGN KEY (RoleId) REFERENCES Roles(Id)
);
GO

CREATE OR ALTER PROCEDURE UpsertUser
    @Id INT = NULL,
    @UserName NVARCHAR(256),
    @NormalizedUserName NVARCHAR(256),
    @Email NVARCHAR(256),
    @NormalizedEmail NVARCHAR(256),
    @EmailConfirmed BIT,
    @PasswordHash NVARCHAR(MAX),
    @IsActive BIT,
    @IsDeleted BIT
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Users WHERE Id = @Id)
    BEGIN
        UPDATE Users
        SET UserName = @UserName,
            NormalizedUserName = @NormalizedUserName,
            Email = @Email,
            NormalizedEmail = @NormalizedEmail,
            EmailConfirmed = @EmailConfirmed,
            PasswordHash = @PasswordHash,
            IsActive = @IsActive,
            IsDeleted = @IsDeleted
        WHERE Id = @Id;
        SELECT @Id AS Id;
    END
    ELSE
    BEGIN
        INSERT INTO Users (UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, IsActive, IsDeleted)
        VALUES (@UserName, @NormalizedUserName, @Email, @NormalizedEmail, @EmailConfirmed, @PasswordHash, @IsActive, @IsDeleted);
        SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id;
    END
END
GO

CREATE OR ALTER PROCEDURE DeleteUser
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    UPDATE Users SET IsDeleted = 1 WHERE Id = @Id;
END
GO

CREATE OR ALTER PROCEDURE GetUserById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, IsActive, IsDeleted
    FROM Users
    WHERE Id = @Id AND IsDeleted = 0;
END
GO

CREATE OR ALTER PROCEDURE GetUserByNormalizedUserName
    @NormalizedUserName NVARCHAR(256)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, IsActive, IsDeleted
    FROM Users
    WHERE NormalizedUserName = @NormalizedUserName AND IsDeleted = 0;
END
GO

CREATE OR ALTER PROCEDURE UpsertRole
    @Id INT = NULL,
    @Name NVARCHAR(256),
    @NormalizedName NVARCHAR(256)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Roles WHERE Id = @Id)
    BEGIN
        UPDATE Roles
        SET Name = @Name,
            NormalizedName = @NormalizedName
        WHERE Id = @Id;
        SELECT @Id AS Id;
    END
    ELSE
    BEGIN
        INSERT INTO Roles (Name, NormalizedName)
        VALUES (@Name, @NormalizedName);
        SELECT CAST(SCOPE_IDENTITY() AS INT) AS Id;
    END
END
GO

CREATE OR ALTER PROCEDURE DeleteRole
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    DELETE FROM Roles WHERE Id = @Id;
END
GO

CREATE OR ALTER PROCEDURE GetRoleById
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Name, NormalizedName
    FROM Roles
    WHERE Id = @Id;
END
GO

CREATE OR ALTER PROCEDURE GetRoleByNormalizedName
    @NormalizedName NVARCHAR(256)
AS
BEGIN
    SET NOCOUNT ON;
    SELECT Id, Name, NormalizedName
    FROM Roles
    WHERE NormalizedName = @NormalizedName;
END
GO

CREATE OR ALTER PROCEDURE GetRolesByUserId
    @UserId INT
AS
BEGIN
    SET NOCOUNT ON;
    SELECT r.Id, r.Name, r.NormalizedName
    FROM UserRoles ur
    INNER JOIN Roles r ON ur.RoleId = r.Id
    WHERE ur.UserId = @UserId;
END
GO