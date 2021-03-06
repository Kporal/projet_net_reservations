IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'cmd_vols')
BEGIN
    CREATE DATABASE cmd_vols
END
GO 

USE [cmd_vols]
GO

CREATE TABLE [dbo].[cmd_vols](
	[idcmd_vols] [int] IDENTITY(1, 1) NOT NULL,
	[client_firstname] [varchar](50),
	[client_lastname] [varchar](50),
	[client_phone] [varchar](20),
	[client_mail] [varchar] (50),
	[client_address] [varchar](50),
	[client_postal_code] [varchar](50),
	[client_city] [varchar](50),
	[client_country] [varchar](50),
	[vol_name] [varchar](50),
	[vol_from] [varchar](50),
	[vol_to] [varchar](50),
	[vol_category] [varchar](50),
	[vol_dateStart] [varchar](50),
	[vol_dateEnd] [varchar](50),
	[vol_price] [varchar] (50),
 CONSTRAINT [PK_cmd_vols] PRIMARY KEY CLUSTERED ([idcmd_vols] ASC)
 WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF,
  ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


