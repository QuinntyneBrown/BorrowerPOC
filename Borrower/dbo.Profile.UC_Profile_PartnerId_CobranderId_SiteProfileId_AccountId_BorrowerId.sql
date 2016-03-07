ALTER TABLE [dbo].[Profile]
	ADD CONSTRAINT [UC_Profile_PartnerId_CobranderId_SiteProfileId_AccountId_BorrowerId]
	UNIQUE ([PartnerId], [CobranderId], [SiteProfileId], [AccountId], [BorrowerId])
