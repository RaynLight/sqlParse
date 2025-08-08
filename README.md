# sqlParse
This is my final project for my Object Oriented Programming class.  
https://github.com/RaynLight/sqlParse

## Usage
sqlParse works as a general MSSQL client, allowing you to run queries against an MSSQL server.  
To connect, enter the username, password, and IP address, then click **Connect**.

You can also use the built-in scanning feature:
- **`scan`** – scans all non-system databases on the server for possible sensitive data using regex patterns.
- **`scan <DB NAME>`** – scans only the specified database.

## Logging
Will log queries, scans, and connections into a `logs` folder.
