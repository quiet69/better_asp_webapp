insert into userdetailsTable (u_name, u_DOB, u_phone)
values ('quiet', GETDATE(), '9999999999')

select * from userdetailsTable

truncate table userdetailsTable;

CREATE TABLE userdetailsTable (
	[u_id] int identity(1,1) NOT NULL,
    [u_name]  NVARCHAR (50) NOT NULL,
    [u_DOB]   DATE          NULL,
    [u_phone] NVARCHAR (50) NULL, 
    CONSTRAINT [PK_userdetailsTable] PRIMARY KEY ([u_id])
);
