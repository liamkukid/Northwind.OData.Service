#!/bin/bash
set -e

# Start SQL Server in background
/opt/mssql/bin/sqlservr &

# Wait for SQL Server to be ready
echo "Waiting for SQL Server to start..."
for i in {1..30}; do
    if /opt/mssql-tools18/bin/sqlcmd -S localhost -No -U sa -P "$MSSQL_SA_PASSWORD" -Q "SELECT 1" > /dev/null 2>&1; then
        echo "SQL Server is up!"
        break
    fi
    echo "Waiting..."
    sleep 2
done

# Check if the database already exists
DB_EXISTS=$(/opt/mssql-tools18/bin/sqlcmd -S localhost -No -U sa -P "$MSSQL_SA_PASSWORD" -Q "IF DB_ID('Northwind') IS NOT NULL PRINT 'EXISTS'" -h -1)

if [[ "$DB_EXISTS" == "EXISTS" ]]; then
    echo "Database 'Northwind' already exists. Skipping initialization."
else
    echo "Initializing database..."
    /opt/mssql-tools18/bin/sqlcmd -S localhost -No -U sa -P "$MSSQL_SA_PASSWORD" -i /init/Northwind4SQLServer.sql
    echo "Database initialized."
fi

# Bring SQL Server back to foreground
wait
