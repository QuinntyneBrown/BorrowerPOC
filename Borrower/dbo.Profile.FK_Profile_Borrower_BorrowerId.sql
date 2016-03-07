ALTER TABLE [dbo].[Profile]
	ADD CONSTRAINT [FK_Profile_Borrower_BorrowerId]
	FOREIGN KEY ([BorrowerId])
	REFERENCES [Borrower] ([Id])
