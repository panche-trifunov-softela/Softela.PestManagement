-- Diagram: tbranch
CREATE TABLE Branches (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    CompanyId INT NOT NULL,
    BranchName NVARCHAR(255) NOT NULL,
    CompanyName NVARCHAR(255),
    ContactId INT,
    StreetAddressId INT,
    MailingAddressId INT,
    IsBillingCenter BIT NOT NULL DEFAULT 0,
    IsServiceCenter BIT NOT NULL DEFAULT 0,
    UtcTimestamp DATETIME NOT NULL,
    CreatedBy NVARCHAR(50) NOT NULL,
    UtcLastChanged DATETIME NOT NULL,
    LastChangedBy NVARCHAR(50) NOT NULL,
    LicenseNumber NVARCHAR(50),
    IsActive BIT NOT NULL DEFAULT 1,
    IsDeleted BIT NOT NULL DEFAULT 0,
    DefaultTaxTypeId INT,
    FaxNumber NVARCHAR(50),
    LicenseNumber1 NVARCHAR(50),
    CONSTRAINT FK_Branches_Company FOREIGN KEY (CompanyId) REFERENCES Companies(Id),
    CONSTRAINT FK_Branches_Contact FOREIGN KEY (ContactId) REFERENCES Contacts(Id),
    CONSTRAINT FK_Branches_StreetAddress FOREIGN KEY (StreetAddressId) REFERENCES Addresses(Id),
    CONSTRAINT FK_Branches_MailingAddress FOREIGN KEY (MailingAddressId) REFERENCES Addresses(Id),
    CONSTRAINT FK_Branches_TaxType FOREIGN KEY (DefaultTaxTypeId) REFERENCES TaxTypes(Id)
);
GO
