-- Diagram: tcontact
CREATE TABLE Contacts (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    CompanyId INT NOT NULL,
    ContactType TINYINT NOT NULL,
    FirstName NVARCHAR(50),
    MiddleName NVARCHAR(50),
    LastName NVARCHAR(50),
    EmailAddress NVARCHAR(250),
    WebAddress NVARCHAR(100),
    PrimaryPhoneId INT,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    BusinessName NVARCHAR(100),
    DateOfBirth DATETIME,
    SalutationId INT,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Contacts_Company FOREIGN KEY (CompanyId) REFERENCES Companies(Id),
    CONSTRAINT FK_Contacts_Salutation FOREIGN KEY (SalutationId) REFERENCES Salutations(Id)
);
GO

-- Diagram: tcontactphonenumber
CREATE TABLE ContactPhoneNumbers (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    ContactId INT NOT NULL,
    PhoneType TINYINT NOT NULL,
    PhoneNumber NVARCHAR(50) NOT NULL,
    PhoneExtension NVARCHAR(50),
    PhoneNote NVARCHAR(100),
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_ContactPhoneNumbers_Contact FOREIGN KEY (ContactId) REFERENCES Contacts(Id)
);
GO

-- Diagram: taddress
CREATE TABLE Addresses (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    CompanyId INT,
    CompanyName NVARCHAR(100),
    StreetNumber NVARCHAR(50),
    PreDirection NVARCHAR(50),
    StreetName NVARCHAR(50),
    StreetSuffix NVARCHAR(50),
    PostDirection NVARCHAR(50),
    SecondaryAddress NVARCHAR(50),
    City NVARCHAR(50),
    State NVARCHAR(50),
    PostalCode NVARCHAR(15),
    PostalCodeEx VARCHAR(100),
    CountryId INT,
    UtcTimestamp DATETIME NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    LocaleId INT,
    SuffixId INT,
    Latitude DECIMAL(18, 15),
    Longitude DECIMAL(18, 15),
    IsDeleted BIT NOT NULL DEFAULT 0,
    CONSTRAINT FK_Addresses_Country FOREIGN KEY (CountryId) REFERENCES Countries(Id),
    CONSTRAINT FK_Addresses_Locale FOREIGN KEY (LocaleId) REFERENCES Locales(Id)
);
GO
