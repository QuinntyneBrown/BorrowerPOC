ALTER TABLE [dbo].[Person]
	ADD CONSTRAINT [FK_Person_Borrower_BorrowerId]
	FOREIGN KEY ([BorrowerId])
	REFERENCES [Borrower] ([Id])
