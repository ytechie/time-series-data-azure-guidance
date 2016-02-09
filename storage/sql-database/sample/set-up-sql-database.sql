
CREATE TABLE [dbo].[Data](
	[Timestamp] [datetime] NOT NULL,
	[DatsourceId] [int] NOT NULL,
	[Value] [varbinary](max) NOT NUL

GO

--Enable Compression
ALTER TABLE Dbo.Data REBUILD PARTITION = ALL
WITH (DATA_COMPRESSION = PAGE); 