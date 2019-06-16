



-- MingSnExplorerDB
CREATE TABLE MS_UserInfo
(
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
	Name NVARCHAR(38) NOT NULL DEFAULT('СTomè'),
	CreateDate DATETIME NOT NULL DEFAULT(GETDATE())
)
INSERT dbo.MS_UserInfo
(
    Name,
    CreateDate
)
VALUES
(   N'xiaomi',      -- Name - nvarchar(38)
    GETDATE() -- CreateDate - datetime
    ),
(   N'ningshu',      -- Name - nvarchar(38)
    GETDATE() -- CreateDate - datetime
    ),
(   N'mingsn',      -- Name - nvarchar(38)
    GETDATE() -- CreateDate - datetime
    )