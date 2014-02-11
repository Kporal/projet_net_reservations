IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'cmd_hotels')
BEGIN
    CREATE DATABASE cmd_hotels
END
GO 

USE [cmd_hotels]
GO
CREATE TABLE [dbo].[cmd_hotels](
	[idcmd_hotels] [int] IDENTITY(1, 1) NOT NULL,
	[client_firstname] [varchar](50) NOT NULL,
	[client_lastname] [varchar](50) NOT NULL,
	[client_address] [varchar](50) NOT NULL,
	[client_postal_code] [varchar](50) NOT NULL,
	[client_city] [varchar](50) NOT NULL,
	[client_country] [varchar](50) NOT NULL,
	[hotel_stars] [varchar](50) NOT NULL,
	[hotel_address] [varchar](50) NOT NULL,
	[hotel_city] [varchar](50) NOT NULL,
	[hotel_country] [varchar](50) NOT NULL,
	[hotel_price] [varchar](50) NOT NULL,
	[hotel_dateStart] [varchar](50) NOT NULL,
	[hotel_dateEnd] [varchar](50) NOT NULL
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO