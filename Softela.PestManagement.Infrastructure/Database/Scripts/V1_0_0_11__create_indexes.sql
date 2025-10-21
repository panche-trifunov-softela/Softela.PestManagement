-- Indexes Migration
-- Creates indexes for improved query performance

-- Addresses
CREATE INDEX IX_Addresses_CountryId ON Addresses(CountryId);
CREATE INDEX IX_Addresses_City_State ON Addresses(City, State);
CREATE INDEX IX_Addresses_PostalCode ON Addresses(PostalCode);
GO

-- Contacts
CREATE INDEX IX_Contacts_CompanyId ON Contacts(CompanyId);
CREATE INDEX IX_Contacts_Email ON Contacts(Email);
CREATE INDEX IX_Contacts_IsActive ON Contacts(IsActive);
GO

-- Accounts
CREATE INDEX IX_Accounts_AccountNum ON Accounts(AccountNum);
CREATE INDEX IX_Accounts_CompanyId ON Accounts(CompanyId);
CREATE INDEX IX_Accounts_BillingAddressId ON Accounts(BillingAddressId);
CREATE INDEX IX_Accounts_BillingContactId ON Accounts(BillingContactId);
CREATE INDEX IX_Accounts_IsActive ON Accounts(IsActive);
CREATE INDEX IX_Accounts_MasterAccountId ON Accounts(MasterAccountId);
GO

-- Sites
CREATE INDEX IX_Sites_AddressId ON Sites(AddressId);
CREATE INDEX IX_Sites_PrimaryContactId ON Sites(PrimaryContactId);
CREATE INDEX IX_Sites_SiteReferenceNumber ON Sites(SiteReferenceNumber);
CREATE INDEX IX_Sites_TaxTypeId ON Sites(TaxTypeId);
CREATE INDEX IX_Sites_SalespersonId ON Sites(SalespersonId);
GO

-- AccountSites
CREATE INDEX IX_AccountSites_AccountId ON AccountSites(AccountId);
CREATE INDEX IX_AccountSites_SiteId ON AccountSites(SiteId);
GO

-- Technicians
CREATE INDEX IX_Technicians_EmployeeNumber ON Technicians(EmployeeNumber);
CREATE INDEX IX_Technicians_IsActive ON Technicians(IsActive);
CREATE INDEX IX_Technicians_UserId ON Technicians(UserId);
CREATE INDEX IX_Technicians_DefaultRouteId ON Technicians(DefaultRouteId);
GO

-- Routes
CREATE INDEX IX_Routes_DefaultTechnicianId ON Routes(DefaultTechnicianId);
CREATE INDEX IX_Routes_IsActive ON Routes(IsActive);
GO

-- ServiceTypes
CREATE INDEX IX_ServiceTypes_Code ON ServiceTypes(Code);
CREATE INDEX IX_ServiceTypes_IsActive ON ServiceTypes(IsActive);
CREATE INDEX IX_ServiceTypes_ServiceCategoryId ON ServiceTypes(ServiceCategoryId);
GO

-- Services
CREATE INDEX IX_Services_AccountId ON Services(AccountId);
CREATE INDEX IX_Services_SiteId ON Services(SiteId);
CREATE INDEX IX_Services_ServiceTypeId ON Services(ServiceTypeId);
CREATE INDEX IX_Services_IsActive ON Services(IsActive);
CREATE INDEX IX_Services_FrequencyTypeId ON Services(FrequencyTypeId);
GO

-- Products
CREATE INDEX IX_Products_ProductCode ON Products(ProductCode);
CREATE INDEX IX_Products_ProductCategoryId ON Products(ProductCategoryId);
CREATE INDEX IX_Products_IsActive ON Products(IsActive);
CREATE INDEX IX_Products_EpaRegistrationNumber ON Products(EpaRegistrationNumber);
GO

-- Pests
CREATE INDEX IX_Pests_PestCategoryId ON Pests(PestCategoryId);
CREATE INDEX IX_Pests_IsActive ON Pests(IsActive);
CREATE INDEX IX_Pests_Name ON Pests(Name);
GO

-- Invoices
CREATE INDEX IX_Invoices_InvoiceNumber ON Invoices(InvoiceNumber);
CREATE INDEX IX_Invoices_AccountId ON Invoices(AccountId);
CREATE INDEX IX_Invoices_SiteId ON Invoices(SiteId);
CREATE INDEX IX_Invoices_Status ON Invoices(Status);
CREATE INDEX IX_Invoices_IsPaid ON Invoices(IsPaid);
CREATE INDEX IX_Invoices_InvoiceDate ON Invoices(InvoiceDate);
CREATE INDEX IX_Invoices_DueDate ON Invoices(DueDate);
GO

-- InvoiceLineItems
CREATE INDEX IX_InvoiceLineItems_InvoiceId ON InvoiceLineItems(InvoiceId);
CREATE INDEX IX_InvoiceLineItems_ServiceTypeId ON InvoiceLineItems(ServiceTypeId);
CREATE INDEX IX_InvoiceLineItems_ProductId ON InvoiceLineItems(ProductId);
CREATE INDEX IX_InvoiceLineItems_WorkOrderId ON InvoiceLineItems(WorkOrderId);
GO

-- Payments
CREATE INDEX IX_Payments_PaymentNumber ON Payments(PaymentNumber);
CREATE INDEX IX_Payments_AccountId ON Payments(AccountId);
CREATE INDEX IX_Payments_InvoiceId ON Payments(InvoiceId);
CREATE INDEX IX_Payments_PaymentMethodId ON Payments(PaymentMethodId);
CREATE INDEX IX_Payments_PaymentDate ON Payments(PaymentDate);
CREATE INDEX IX_Payments_Status ON Payments(Status);
GO

-- WorkOrders
CREATE INDEX IX_WorkOrders_WorkOrderNumber ON WorkOrders(WorkOrderNumber);
CREATE INDEX IX_WorkOrders_AccountId ON WorkOrders(AccountId);
CREATE INDEX IX_WorkOrders_SiteId ON WorkOrders(SiteId);
CREATE INDEX IX_WorkOrders_ServiceTypeId ON WorkOrders(ServiceTypeId);
CREATE INDEX IX_WorkOrders_TechnicianId ON WorkOrders(TechnicianId);
CREATE INDEX IX_WorkOrders_Status ON WorkOrders(Status);
CREATE INDEX IX_WorkOrders_ScheduledDate ON WorkOrders(ScheduledDate);
CREATE INDEX IX_WorkOrders_CompletedDate ON WorkOrders(CompletedDate);
CREATE INDEX IX_WorkOrders_InvoiceId ON WorkOrders(InvoiceId);
GO

-- WorkOrderProducts
CREATE INDEX IX_WorkOrderProducts_WorkOrderId ON WorkOrderProducts(WorkOrderId);
CREATE INDEX IX_WorkOrderProducts_ProductId ON WorkOrderProducts(ProductId);
CREATE INDEX IX_WorkOrderProducts_TargetPestId ON WorkOrderProducts(TargetPestId);
GO

-- WorkOrderPests
CREATE INDEX IX_WorkOrderPests_WorkOrderId ON WorkOrderPests(WorkOrderId);
CREATE INDEX IX_WorkOrderPests_PestId ON WorkOrderPests(PestId);
CREATE INDEX IX_WorkOrderPests_RequiresFollowUp ON WorkOrderPests(RequiresFollowUp);
GO
