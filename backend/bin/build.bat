:: Generated by: https://openapi-generator.tech
::

@echo off

dotnet restore src\Org.OpenAPITools
dotnet build src\Org.OpenAPITools
echo Now, run the following to start the project: dotnet run -p src\Org.OpenAPITools\Org.OpenAPITools.csproj --launch-profile web.
echo.
