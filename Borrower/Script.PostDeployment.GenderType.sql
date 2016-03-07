;
MERGE INTO [dbo].[GenderType] AS T
USING (
    VALUES
    ( 0, N'Undefined', N'Undefined' ),
    ( 1, N'N/A', N'Not Applicable' ),
    ( 2, N'Male', N'Male' ),
    ( 3, N'Female', N'Female' )
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