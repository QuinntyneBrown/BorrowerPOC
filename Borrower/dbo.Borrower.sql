CREATE TABLE [dbo].[Borrower]
(
    [Id] UNIQUEIDENTIFIER NOT NULL, 
    [Position] INT NOT NULL, 
    [EdisclosureConsent] BIT NOT NULL, 
    [EmailConsent] BIT NOT NULL, 
    [EmailAddress] NVARCHAR(255) NULL
)
