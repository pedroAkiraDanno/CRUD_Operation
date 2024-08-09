--put scheduler name: random_every_time
USE CRUD_SP_DB;


DECLARE @cnt INT = 0;
WHILE @cnt < 100000000
BEGIN
    INSERT INTO ProductInfo_Tab 
    VALUES (@cnt, CONVERT(varchar(255), NEWID()),CONVERT(varchar(255), NEWID()),'Runing',GETDATE() );

   SET @cnt = @cnt + 1;
END;
GO


DELETE ProductInfo_Tab;


SELECT TOP 10 * FROM ProductInfo_Tab;
GO 