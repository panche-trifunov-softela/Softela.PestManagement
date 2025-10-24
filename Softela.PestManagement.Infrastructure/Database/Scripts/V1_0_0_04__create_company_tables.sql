-- Diagram: tcompany
CREATE TABLE Companies (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    CompanyName NVARCHAR(255) NOT NULL,
    LocaleId INT NOT NULL,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Companies_Locale FOREIGN KEY (LocaleId) REFERENCES Locales(Id)
);
GO
