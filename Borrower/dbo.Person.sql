CREATE TABLE [dbo].[Person]
(
    [BorrowerId] UNIQUEIDENTIFIER NOT NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [MiddleName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [GenerationTypeId] INT NOT NULL DEFAULT 0, 
    [Birthdate] DATE NULL, 
    [GenderTypeId] INT NOT NULL DEFAULT 0, 
    [EthnicityTypeId] INT NOT NULL DEFAULT 0, 
    [CountryOfCitizenshipTypeId] INT NOT NULL DEFAULT 0, 
    [MaritalStatusTypeId] INT NOT NULL DEFAULT 0, 
    [YearsOfSchooling] INT NULL, 
    [NumberOfDependents] INT NULL, 
    [AgesOfDependents] XML NULL 
)
