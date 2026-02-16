CREATE OR ALTER PROCEDURE [dbo].[GetCustomers]
AS
BEGIN
	SELECT 
		a.Id AS AccountId,
		a.Name AS AccountName,
		s.Id AS SiteId,
		s.ReferenceNumber AS SiteReferenceNumber
	FROM Accounts a
	LEFT JOIN Sites s ON a.Id = s.AccountId
	WHERE a.IsDeleted = 0 AND a.IsActive = 1
END