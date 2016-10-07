--------------------------------------------------
- Expert ASP.NET 2.0 Advanced Application Design -
- Code Zip File Read Me                          -
--------------------------------------------------

Since the compilation model of 2.0 has been so dramatically simplified, for many chapters there's a single directory containing all of the files for that chapter's project.

For example, with chapter 4, you will find:
Chapter4/Code04/Web04

The Web04 directory is the 2.0 Web project directory.  It can be opened using the "Open Web Project" option of VS.NET 2K5.

This pattern applies to most chapters:
ChapterX/CodeX/WebX

Some chapters have additional code libraries that are used.  These projects will be referenced in the text and appear in their own directories under CodeX for the chapter.  

Chapter 6 has a web project that uses version 1.1 of the Framework, and so will need to be setup as an IIS application.  This project is in:
Chapter6/Code06/Web06_2K3

And of course, SQL Server is required for the database examples, and MSMQ is required for some of the demos in chapters 7 and 8.  Because of the development web server that ships with 2.0, IIS is not required (but can optionally be used for any of the 2.0 web projects).

There are also connection strings in the code using the sa database user.  Anytime you get a connection error trying to execute to page, a search for 'uid=sa' should get you to the connection string.  Change it to credentials that will work in your environment.

 