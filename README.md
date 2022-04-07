# better_asp_webapp
an owo webapp i made but better!
DB structure for MSSQL
```
CREATE TABLE [dbo].[userdetailsTable] (
    [u_id]    INT           IDENTITY (1, 1) NOT NULL,
    [u_name]  NVARCHAR (50) NOT NULL,
    [u_DOB]   DATE          NULL,
    [u_phone] NVARCHAR (50) NULL,
    CONSTRAINT [PK_userdetailsTable] PRIMARY KEY CLUSTERED ([u_id] ASC)
);
```
