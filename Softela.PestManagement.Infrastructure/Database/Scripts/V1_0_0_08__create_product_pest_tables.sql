-- Product and Pest Tables Migration
-- Product/chemical inventory and pest information

-- Products
CREATE TABLE Products (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    ProductCode NVARCHAR(50) NOT NULL,
    Name NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    ProductCategoryId INT NOT NULL,
    ProductTypeId INT NOT NULL,

    -- Chemical-specific (if applicable)
    EpaRegistrationNumber NVARCHAR(50),
    ActiveIngredient NVARCHAR(200),
    ActiveIngredientPercent DECIMAL(5,2),
    FormulationType NVARCHAR(100),

    -- Application
    ApplicationMethod NVARCHAR(200),
    ApplicationRate DECIMAL(10,2),
    ApplicationRateUnit NVARCHAR(50),
    TargetPests NVARCHAR(500),

    -- Inventory
    UnitOfMeasure NVARCHAR(50),
    QuantityOnHand DECIMAL(10,2),
    ReorderPoint DECIMAL(10,2),
    ReorderQuantity DECIMAL(10,2),

    -- Pricing
    Cost DECIMAL(10,2),
    Price DECIMAL(10,2),
    IsTaxable BIT NOT NULL DEFAULT 1,

    -- Safety
    SafetyDataSheet NVARCHAR(500),
    Hazards NVARCHAR(MAX),
    StorageRequirements NVARCHAR(500),
    DisposalInstructions NVARCHAR(500),

    -- Status
    IsActive BIT NOT NULL DEFAULT 1,
    IsRestricted BIT NOT NULL DEFAULT 0,
    RequiresLicense BIT NOT NULL DEFAULT 0,

    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_Products_ProductCategory FOREIGN KEY (ProductCategoryId) REFERENCES ProductCategories(Id)
);
GO

-- Pests
CREATE TABLE Pests (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    Name NVARCHAR(200) NOT NULL,
    ScientificName NVARCHAR(200),
    CommonNames NVARCHAR(500),
    PestCategoryId INT NOT NULL,
    PestTypeId INT NOT NULL,

    -- Description
    Description NVARCHAR(MAX),
    Identification NVARCHAR(MAX),
    LifeCycle NVARCHAR(MAX),
    Habitat NVARCHAR(MAX),
    Behavior NVARCHAR(MAX),

    -- Health and safety
    HealthRisks NVARCHAR(MAX),
    PropertyDamage NVARCHAR(MAX),
    IsVenomous BIT NOT NULL DEFAULT 0,
    SeverityLevel INT NOT NULL DEFAULT 1,

    -- Treatment
    TreatmentMethods NVARCHAR(MAX),
    PreventionTips NVARCHAR(MAX),
    RecommendedProducts NVARCHAR(500),

    -- Images and resources
    ImageUrl NVARCHAR(500),
    ResourceLinks NVARCHAR(MAX),

    -- Status
    IsActive BIT NOT NULL DEFAULT 1,
    IsRegulated BIT NOT NULL DEFAULT 0,

    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_Pests_PestCategory FOREIGN KEY (PestCategoryId) REFERENCES PestCategories(Id)
);
GO
