IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'cmd_hotels')
BEGIN
    CREATE DATABASE cmd_hotels
END
GO 

USE [cmd_hotels]
GO
CREATE TABLE [dbo].[cmd_hotels](
	[idcmd_hotels] [int] IDENTITY(1, 1) NOT NULL,
	[client_firstname] [varchar](50),
	[client_lastname] [varchar](50),
	[client_phone] [varchar](20),
	[client_mail] [varchar] (50),
	[client_address] [varchar](50),
	[client_postal_code] [varchar](50),
	[client_city] [varchar](50),
	[client_country] [varchar](50),
	[hotel_name] [varchar](50),
	[hotel_stars] [tinyint],
	[hotel_city] [varchar](50),
	[hotel_country] [varchar](50),
	[hotel_price] [money],
	[hotel_dateStart] [datetime],
	[hotel_dateEnd] [datetime]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO