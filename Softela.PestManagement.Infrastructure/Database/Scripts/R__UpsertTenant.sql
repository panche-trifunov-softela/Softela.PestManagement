CREATE OR ALTER PROCEDURE [dbo].[UpsertTenant]
    @Id INT,
    @Name NVARCHAR(255),
    @Slug NVARCHAR(100),
    @IsActive BIT,
    @CreatedAt DATETIME2,
    @ModifiedAt DATETIME2,
    @CreatedBy UNIQUEIDENTIFIER,
    @ModifiedBy UNIQUEIDENTIFIER
AS
BEGIN
    SET NOCOUNT ON;

    IF @Id = 0
    BEGIN
        INSERT INTO Tenants (Name, Slug, IsActive, CreatedAt, ModifiedAt, CreatedBy, ModifiedBy)
        VALUES (@Name, @Slug, @IsActive, @CreatedAt, @ModifiedAt, @CreatedBy, @ModifiedBy);
    END
    ELSE
    BEGIN
        UPDATE Tenants
        SET Name = @Name,
            Slug = @Slug,
            IsActive = @IsActive,
            ModifiedAt = @ModifiedAt,
            ModifiedBy = @ModifiedBy
        WHERE Id = @Id;
    END
END
