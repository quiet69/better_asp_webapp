# better_asp_webapp
an owo webapp i made but better!
</br>
DB structure for MSSQL
</br>
name of DB = "ASPuserDB"
</br>
refer to connectionstrings in web.config file
</br>
```
CREATE TABLE [dbo].[userdetailsTable] (
    [u_id]    INT           IDENTITY (1, 1) NOT NULL,
    [u_name]  NVARCHAR (50) NOT NULL,
    [u_DOB]   DATE          NULL,
    [u_phone] NVARCHAR (50) NULL,
    CONSTRAINT [PK_userdetailsTable] PRIMARY KEY CLUSTERED ([u_id] ASC)
);
```
