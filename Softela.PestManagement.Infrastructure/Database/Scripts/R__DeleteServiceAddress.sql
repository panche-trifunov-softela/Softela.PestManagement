CREATE OR ALTER PROCEDURE [dbo].[DeleteServiceAddress]
    @Id INT,
    @TenantId INT
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE ServiceAddresses
    SET IsDeleted = 1, ModifiedAt = GETUTCDATE()
    WHERE Id = @Id AND TenantId = @TenantId;
END
