create procedure usp_GetPublisherDetails

@pubid char(4)

as

select * from publishers

where pub_id = @pubid

 

select * from titles

where pub_id = @pubid

 

select * from authors

where au_id in

(select au_id from titleauthor

inner join titles on

titleauthor.title_id = titles.title_id

where titles.pub_id = @pubid)
