

Database Systems - Overview - Homework
--------------------------------------


----------


> What database models do you know?

 The **hierarchical** database model, in which data is organized into a tree-like structure, the **network(graph)** model, which is considered a flexible way to show the relations between objects, the **relational** model – all data is represented in tables, grouped into relations, and the **object-oriented** model, in which information is represented in the form of objects as used in OOP.

> Which are the main functions performed by a Relational Database
> Management System (RDBMS)?

 RDBMS manages information stored in the tables by creating, editing or deleting tables or relations between them. This system is also used for searching in tables’ data, and manipulating it by adding, changing or removing information.

> Define what is "table" in database terms.

A “table” in terms of database is a collection of related data held in a structured format within a database. It consists of rows and columns, which form cells, in which the data is stored.

> Explain the difference between a primary and a foreign key.

A **primary key** cannot have a null value. Each table can have only one primary key. A primary key can be related with another table’s one as a foreign key. It can be generated automatically with Auto Increment field. 
A **foreign key** is a set of one or more columns in a table that refers to the primary key in another table.  There isn’t any special code, configurations, or table definitions you need to place to officially “designate” a foreign key.

> Explain the different kinds of relationships between tables in relational databases.

 - A one to one relationship can be a relationship between a human and a student, because each of them is the other one – a human is a student and the student is a human, too. 
 - A one to many or many to one relationship is a relationship in which the primary key table contains only one record that relates to none, one, or many records in the related table. This relationship is similar to the one between you and a parent. You have only one mother, but your mother may have several children. 
 - A many to many relationship: each record in both tables can relate to any number of records (or no records) in the other table. For instance, if you have several siblings, so do your siblings (have many siblings). Many to many relationships require a third table, known as an associate or linking table, because relational systems can't directly accommodate the relationship.

> When is a certain database schema normalized? What are the advantages of normalized databases?

 Normalization of the relational schema removes repeating data. 

The benefits of normalization include:
          
•	Searching, sorting, and creating indexes is faster, since tables are narrower, and more rows fit on a data page.
•	You usually have more tables.
•	You can have more clustered indexes (one per table), so you get more flexibility in tuning queries.
•	Index searching is often faster, since indexes tend to be narrower and shorter.
•	More tables allow better use of segments to control physical placement of data.
•	You usually have fewer indexes per table, so data modification commands are faster.
•	Fewer null values and less redundant data, making your database more compact.
•	Triggers execute more quickly if you are not maintaining redundant data.
•	Data modification anomalies are reduced.
•	Normalization is conceptually cleaner and easier to maintain and change as your needs change.

> What are database integrity constraints and when are they used?

**Integrity Constraints**: Used to ensure accuracy and consistency of data in a relational database. Data integrity is handled in a relational database through the concept of referential integrity. 

**Primary Key Constraints**: Primary key is the term used to identify one or more columns in a table that make a row of data unique. Although the primary key typically consists of one column in a table, more than one column can comprise the primary key. For example, either the employee's Social Security number or an assigned employee identification number is the logical primary key for an employee table.

**Unique Constraints**: A unique column constraint in a table is similar to a primary key in that the value in that column for every row of data in the table must have a unique value. Although a primary key constraint is placed on one column, you can place a unique constraint on another column even though it is not actually for use as the primary key.

**Foreign Key Constraints:** A foreign key is a column in a child table that references a primary key in the parent table. A foreign key constraint is the main mechanism used to enforce referential integrity between tables in a relational database. A column defined as a foreign key is used to reference a column defined as a primary key in another table.

**NOT NULL Constraints**: Not Null is a constraint that you can place on a table's column. This constraint disallows the entrance of null values into a column; in other words, data is required in a not null column for each row of data in the table. Null is generally the default for a column if not null is not specified, allowing null values in a column.

> Point out the pros and cons of using indexes in a database.

Indexes speed up SELECT's and slow down INSERT's. Usually it's better to have indexes, because they speed up select more than they slow down insert. On an UPDATE the index can **speed things way up** if an indexed field is used in the WHERE clause and **slow things down** if you update one of the indexed fields.

> What's the main purpose of the SQL language?

**SQL** allows users to access data stored in a relational database management system. Users can create and delete databases, as well as set permissions on database tables, views and procedures. It also allows users to manipulate the data within a database.

> What are transactions used for? Give an example.

 A transaction is a unit of work that you want to treat as "a whole". It has to either happen in full, or not at all. A classical example is transferring money from one bank account to another. To do that you have to first withdraw the amount from the source account, and then deposit it to the destination account. The operation has to succeed in full. If you stop halfway, the money will be lost, and that is very bad. In modern databases transactions also do some other things - like ensure that you can't access data that another person has written halfway. But the basic idea is the same - transactions are there to ensure, that no matter what happens, the data you work with will be in a sensible state. They guarantee that there will not be a situation where money is withdrawn from one account, but not deposited to another.

> What is a NoSQL database?

 A NoSQL database environment is, simply put, a non-relational and largely distributed database system. NoSQL databases are sometimes referred to as cloud databases, non-relational databases, Big Data databases and were developed in response to the sheer volume of data being generated, stored and analyzed by modern users and their applications.
 
Types of NoSQL Databases: 

 - **Graph** **database** (e.g. Neo4j and Titan).
 - **Key-Value** **store** (e.g. Cassandra, DyanmoDB, Azure Table Storage (ATS), Riak, BerkeleyDB).
 -  **Column** **store** (e.g. HBase, BigTable and HyperTable).
 -  **Document database** (e.g. MongoDB and CouchDB).


> Explain the classical non-relational data models

 - Document model – A set of documents, e.g. JSON strings.
 - Key-value model – A set of key-value pairs.
 - Hierarchical key-value – A hierarchy of key-value pairs. 	
 - Wide-column model (e.g. Cassandra) – A key-value model with schema.
 - Object model (e.g. Cache) – A set of OOP-style objects.

>  Give few examples of NoSQL databases and their pros and cons.

 **Cassandra**:

Advantages: 

 - You will have availability.
 - You will have easy partition-tolerance (you can add, remove nodes easily and let Cassandra do the housekeeping) so this should take care of distribution.
 -  To get up and running it is fairly easy and there are plenty of resources available for help/training.
 - The source code is open (Apache    Cassandra) and so if you can write Java code you can easily overwrite or modify specific behavior as you need.

Disadvantages:

 - It does not work well on existing applications. Needs to be used right from the initial stage of developing the application.
 - Does not handle many-to-many requests well.

----------


 **MongoDB**:
 
Advantages:

 - Schema-less. If you have a flexible schema, this is ideal for a document store like MongoDB. This is difficult to implement in a performant manner in RDBMS.
 - Ease of scale-out. Scale reads by using replica sets. Scale writes by using sharding (auto balancing). Just fire up another machine and away you go. Adding more machines = adding more RAM over which to distribute your working set.
 - Cost. Depends on which RDBMS of course, but MongoDB is free and can run on Linux, ideal for running on cheaper commodity kit.
 - You can choose what level of consistency you want depending on the value of the data (e.g. faster performance = fire and forget inserts to MongoDB, slower performance = wait until insert has been replicated to multiple nodes before returning).

Disadvantages:

 - Data size in MongoDB is typically higher due to e.g. each document
   has field names stored it.
 -  Less flexibity with querying (e.g. no JOINs);
 -  No support for transactions - certain atomic operations are supported, at a single document level.
 -  Less up to date information available/fast evolving product.

----------

**Redis**:

Advantages:

 - Stores data in a variety of formats: list, array, sets and sorted sets.
 - Multiple commands at once.
 - Blocking reads - will sit and wait until another process writes data to the cache.
 - Can back data to disk.

Disadvantages:

 - Super complex to configure - requires consideration of data size to configure well.
 - Memory fragmentation issues. Writing and deleting huge amounts of data may result in performance degradation.
 - There are no access controls.
 -  It's not possible to configure a Redis server.