;
MERGE INTO [dbo].[EthnicityType] AS T
USING (
    VALUES
    ( 0, N'Undefined', N'Undefined' ),
    ( 1, N'Not Furnished', N'Not Furnished' ),
    ( 2, N'Hispanic or Latino', N'Hispanic or Latino' ),
    ( 3, N'Not Hispanic or Latino', N'Not Hispanic or Latino' )
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