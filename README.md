# Sql-Client-Repository
SQL client repository is an ado.net SQL client wrapper for convenient access of SQL server database using c#.

## Features
1. Easy to use interface for interacting with sql server database.
2. No need to write any ADO.NET code for executing query in the sql server database.
3. Return's query result in list format therefore accessing database values in c# become very easy.

## Integration
1. Download the Sql-Client-Repository/SqlClientRepository/bin/Release/SqlClientRepository.dll class library.
2. Add this class library in the reference section of your project.

## Examples
``` // Create an instance of SqlClientWrapper class and pass the connection string in the constructor parameter```

``` ISqlClientWrapper db = new SqlClientWrapper("server=.; database=YOUR_DATABASE_NAME; integrated security=SSPI"); ```

``` // for executing any query just call Execute(sqlQuery) method from SqlClientWrapper class ```

``` string sql = "CREATE TABLE Persons (PersonID int,LastName varchar(255),FirstName varchar(255),Address varchar(255),City varchar(255) );" ; ```

``` db.Execute(sql); ```

``` // for executing a query with parameter value

``` string sql = "UPDATE persons SET FirstName = @name WHERE PersonId = @id"; ```

``` var parameters = new Dictionary<string, object>(){ {"name", "Nahid chowdhury"}, {"id", 5} }; ```

``` int numOfRowEffected = db.Execute(sql, parameters); ```
