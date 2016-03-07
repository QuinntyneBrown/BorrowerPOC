;
MERGE INTO [dbo].[MaritalStatusType] AS T
USING (
    VALUES
    ( 0, N'Undefined', N'Undefined' ),
    ( 1, N'Married', N'Married' ),
    ( 2, N'Separated', N'Separated' ),
    ( 3, N'Unmarried', N'Unmarried (include single, divorced, widowed)' )
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