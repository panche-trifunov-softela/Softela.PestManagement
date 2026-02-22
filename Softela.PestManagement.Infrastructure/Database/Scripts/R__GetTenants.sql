CREATE OR ALTER PROCEDURE [dbo].[GetTenants]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Name, Slug, IsActive, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy
    FROM Tenants
    ORDER BY Name;
END
