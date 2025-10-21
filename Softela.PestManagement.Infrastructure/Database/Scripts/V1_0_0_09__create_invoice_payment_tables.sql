-- Invoice and Payment Tables Migration
-- Financial/billing management

-- Invoices
CREATE TABLE Invoices (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    InvoiceNumber NVARCHAR(50) NOT NULL UNIQUE,
    AccountId INT NOT NULL,
    SiteId INT,

    -- Dates
    InvoiceDate DATETIME2 NOT NULL,
    DueDate DATETIME2 NOT NULL,
    PaidDate DATETIME2,

    -- Amounts
    SubTotal DECIMAL(10,2) NOT NULL DEFAULT 0,
    TaxAmount DECIMAL(10,2) NOT NULL DEFAULT 0,
    TotalAmount DECIMAL(10,2) NOT NULL DEFAULT 0,
    PaidAmount DECIMAL(10,2) NOT NULL DEFAULT 0,
    BalanceDue DECIMAL(10,2) NOT NULL DEFAULT 0,

    -- Tax details
    TaxTypeId INT,
    FederalTaxAmount DECIMAL(10,2),
    StateTaxAmount DECIMAL(10,2),
    LocalTaxAmount DECIMAL(10,2),

    -- Status (0=Draft, 1=Sent, 2=Paid, 3=PartiallyPaid, 4=Overdue, 5=Cancelled)
    Status INT NOT NULL DEFAULT 0,
    IsPaid BIT NOT NULL DEFAULT 0,

    -- Notes and references
    Notes NVARCHAR(MAX),
    PurchaseOrderNumber NVARCHAR(50),
    Terms NVARCHAR(500),

    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_Invoices_Account FOREIGN KEY (AccountId) REFERENCES Accounts(Id),
    CONSTRAINT FK_Invoices_Site FOREIGN KEY (SiteId) REFERENCES Sites(Id),
    CONSTRAINT FK_Invoices_TaxType FOREIGN KEY (TaxTypeId) REFERENCES TaxTypes(Id)
);
GO

-- InvoiceLineItems
CREATE TABLE InvoiceLineItems (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    InvoiceId INT NOT NULL,
    LineNumber INT NOT NULL,

    -- Item details
    Description NVARCHAR(500) NOT NULL,
    ServiceTypeId INT,
    ProductId INT,
    WorkOrderId INT,

    -- Quantities and pricing
    Quantity DECIMAL(10,2) NOT NULL DEFAULT 1,
    UnitPrice DECIMAL(10,2) NOT NULL DEFAULT 0,
    Amount DECIMAL(10,2) NOT NULL DEFAULT 0,
    DiscountPercent DECIMAL(5,2),
    DiscountAmount DECIMAL(10,2),
    TotalAmount DECIMAL(10,2) NOT NULL DEFAULT 0,

    -- Tax
    IsTaxable BIT NOT NULL DEFAULT 1,
    TaxAmount DECIMAL(10,2),

    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_InvoiceLineItems_Invoice FOREIGN KEY (InvoiceId) REFERENCES Invoices(Id) ON DELETE CASCADE,
    CONSTRAINT FK_InvoiceLineItems_ServiceType FOREIGN KEY (ServiceTypeId) REFERENCES ServiceTypes(Id),
    CONSTRAINT FK_InvoiceLineItems_Product FOREIGN KEY (ProductId) REFERENCES Products(Id)
);
GO

-- Payments
CREATE TABLE Payments (
    Id INT NOT NULL PRIMARY KEY IDENTITY,
    PaymentNumber NVARCHAR(50) NOT NULL UNIQUE,
    AccountId INT NOT NULL,
    InvoiceId INT,

    -- Payment details
    PaymentDate DATETIME2 NOT NULL,
    Amount DECIMAL(10,2) NOT NULL,

    -- Payment method
    PaymentMethodId INT NOT NULL,
    PaymentMethodName NVARCHAR(100),

    -- Reference info
    ReferenceNumber NVARCHAR(100),
    ConfirmationNumber NVARCHAR(100),

    -- Credit card info (if applicable)
    CardType NVARCHAR(50),
    CardLastFour NVARCHAR(4),

    -- Status (0=Pending, 1=Completed, 2=Failed, 3=Refunded)
    Status INT NOT NULL DEFAULT 0,
    IsProcessed BIT NOT NULL DEFAULT 0,

    -- Notes
    Notes NVARCHAR(MAX),

    CreatedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    ModifiedAt DATETIME2 NOT NULL DEFAULT GETUTCDATE(),
    CreatedBy UNIQUEIDENTIFIER NOT NULL,
    ModifiedBy UNIQUEIDENTIFIER NOT NULL,

    CONSTRAINT FK_Payments_Account FOREIGN KEY (AccountId) REFERENCES Accounts(Id),
    CONSTRAINT FK_Payments_Invoice FOREIGN KEY (InvoiceId) REFERENCES Invoices(Id),
    CONSTRAINT FK_Payments_PaymentMethod FOREIGN KEY (PaymentMethodId) REFERENCES PaymentMethods(Id)
);
GO
