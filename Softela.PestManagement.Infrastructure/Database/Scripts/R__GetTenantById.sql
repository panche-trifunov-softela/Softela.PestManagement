CREATE OR ALTER PROCEDURE [dbo].[GetTenantById]
    @Id INT
AS
BEGIN
    SET NOCOUNT ON;

    SELECT Id, Name, Slug, IsActive, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy
    FROM Tenants
    WHERE Id = @Id;
END
