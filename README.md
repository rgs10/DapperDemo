# DapperDemo
Dapper is an open source, lightweight, very fast ORM developed by the team at Stack Overflow.  This makes it ideal for dealing with large datasets used for CRUD screens for example.

One issue encountered using Dapper was the mapping of Complex objects returned from database queries.  Dapper does not natively support this functionality.  Two possible solutions were identified - (1) Create a custom helper class to implement this mapping or (2) Use a mapper (here Slapper AutoMapper was used) to provide a solution to map complex nested objects.

The following code provides examples of these two different approaches - the first using the Slapper AutoMapper in conjunction with a single SQL query which returned one data set, the second using our own Helper class that returned two individual data sets from a stored procedure.

For the examples below  a Team object contains a List of Player objects.
