#!/bin/bash

set -e
run_cmd="dotnet run --project contact.app.mvc/contact.app.mvc.csproj --urls=http://*:80"

>&2 echo "SQL Server is starting up"

>&2 echo "SQL Server is up - executing command"
exec $run_cmd
