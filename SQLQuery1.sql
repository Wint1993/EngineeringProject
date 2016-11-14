CREATE TABLE Events(
[id] int IDENTITY(1,1) NOT NULL,
[text] nvarchar(300) NULL,
[start_date] datetime NOT NULL,
[end_date] datetime NOT NULL,
PRIMARY KEY (id)
)