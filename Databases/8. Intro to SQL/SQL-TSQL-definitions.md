> 

*Structured Query Language (SQL)*
-------------------------------

> *What is SQL?*

SQL (Structured Query Language) is a standardized programming language used for managing relational databases and performing various operations on the data in them. Initially created in the 1970s, SQL is regularly used by database administrators, as well as by developers writing data integration scripts and data analysts looking to set up and run analytical queries.

The uses of SQL include modifying database table and index structures; adding, updating and deleting rows of data; and retrieving subsets of information from within a database for transaction processing and analytics applications. Queries and other SQL operations take the form of commands written as statements -- commonly used SQL statements include select, add, insert, update, delete, create, alter and truncate.

>  *What is DML?* 

Data Manipulation Language (DML) statements are used for managing data within schema objects. Some examples:

 - SELECT - retrieve data from the a database. 
 - INSERT - insert data into.
 - DELETE - deletes all records from a table. 
 - MERGE - UPSERT operation (insert or update). 
 - CALL - call a PL/SQL or Java subprogram. 
 - EXPLAIN PLAN - explain access path to data.  
 - LOCK TABLE - control concurrency.

>  *What is DDL?*

Data Definition Language (DDL) statements are used to define the database structure or schema. Some examples:

 - CREATE - to create objects in the database. 
 - ALTER - alters thenstructure of the database.
 - DROP - delete objects from the database.
 - TRUNCATE - remove all records from a table, including all spaces allocated for the records are removed.
 - COMMENT - add comments to the data dictionary. 
 - RENAME - rename an object.

>  *Recite the most important SQL commands*.

According to my own experience and some sites :D it seems that the most used SQL commands are:

CREATE DATABASE, DROP DATABASE, CREATE TABLE, ALTER TABLE, DROP TABLE, SELECT, INSERT and DELETE.

...and because I didn't mentioned the Transaction-type-commands before:

 - START TRANSACTION - used to begin a transaction. 
 - COMMIT - used to apply changes and end transaction. 
 - ROLLBACK - used to discard changes and end transaction.

> *What is Transact-SQL (T-SQL)?*

Transact-SQL is central to using SQL Server. All applications that communicate with an instance of SQL Server do so by sending Transact-SQL statements to the server, regardless of the user interface of the application.
The following is a list of the kinds of applications that can generate Transact-SQL:

 - General office productivity applications. 
 - Applications that use a graphical user interface (GUI) to let users select the tables and columns from which they want to see data. 
 - Applications that use general language sentences to determine what data a user wants to see. 
 - Line of business applications that store their data in SQL Server databases.
 - Applications created by using development systems such as Microsoft Visual C++, Microsoft Visual Basic, or Microsoft Visual J++ that use database APIs such as ADO, OLE DB, and ODBC.
 - Web pages that extract data from SQL Server databases.