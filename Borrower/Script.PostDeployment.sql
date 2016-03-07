/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
EXEC sp_executesql N'ALTER TABLE [dbo].[Borrower] ALTER COLUMN [EmailAddress] ADD MASKED WITH (FUNCTION = ''email()'');'
EXEC sp_executesql N'ALTER TABLE [dbo].[Person] ALTER COLUMN [Birthdate] ADD MASKED WITH (FUNCTION = ''default()'');'
:r .\Script.PostDeployment.GenerationType.sql
:r .\Script.PostDeployment.GenderType.sql
:r .\Script.PostDeployment.EthnicityType.sql
:r .\Script.PostDeployment.MaritalStatusType.sql
