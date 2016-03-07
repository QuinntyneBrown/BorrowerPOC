;
MERGE INTO [dbo].[GenerationType] AS T
USING (
    VALUES
    ( 0, N'Undefined', N'Undefined' ),
    ( 1, N'Jr', N'Junior' ),
    ( 2, N'Sr', N'Senior' ),
    ( 3, N'II', N'Second' ),
    ( 4, N'III', N'Third' ),
    ( 5, N'IV', N'Fourth' ),
    ( 6, N'V', N'Fifth' )
) AS S ([Id], [Name], [Description])
ON T.[Id] = S.[Id]
WHEN MATCHED THEN
    UPDATE
    SET [Name] = S.[Name],
        [Description] = S.[Description]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([Id], [Name], [Description])
    VALUES (S.[Id], S.[Name], S.[Description])
WHEN NOT MATCHED BY SOURCE THEN
    DELETE
;