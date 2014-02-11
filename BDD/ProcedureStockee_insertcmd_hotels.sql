USE cmd_hotels;
GO
CREATE PROCEDURE dbo.insertCmdHotels
		@FirstName varchar(50),
		@LastName varchar(50), 
		@Address varchar(50),
		@PostalCode varchar(50),
		@City varchar(50),
		@Country varchar(50),
		@Hotels_stars varchar(50),
		@Hotels_address varchar(50),
		@Hotels_city varchar(50),
		@Hotels_country varchar(50),
		@Hotels_price varchar(50),
		@Hotels_dateStart varchar(50),
		@Hotels_dateEnd varchar(50)
AS

BEGIN
INSERT INTO cmd_hotels([client_firstname],[client_lastname],[client_address],[client_postal_code],
[client_city],[client_country],[hotel_stars],[hotel_address],[hotel_city],[hotel_country],[hotel_price],[hotel_dateStart],[hotel_dateEnd])
VALUES (@FirstName,@LastName,@Address,@PostalCode,@City,@Country,@Hotels_stars,@Hotels_address,@Hotels_city,@Hotels_country,@Hotels_price,@Hotels_dateStart, @Hotels_dateEnd);
END


GO