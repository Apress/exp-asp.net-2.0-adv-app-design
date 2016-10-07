create procedure usp_GetPubDetails

@pub_id char(4),

@pub_name varchar(40) OUTPUT, 

@city varchar(20) OUTPUT, 

@state char(2) OUTPUT, 

@country varchar(30) OUTPUT

as

SELECT     

@pub_name = pub_name, 

@city = city, 

@state = state, 

@country = country

FROM publishers

WHERE (pub_id = @pub_id)
