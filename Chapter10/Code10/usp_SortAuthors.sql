create procedure usp_SortAuthors

@sortExpr varchar(25)

as

declare @sql varchar(100)

 

set @sql = 'select * from authors order by ' + @sortExpr

 

EXEC(@sql)

Go
