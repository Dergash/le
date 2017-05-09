dotnet restore main
dotnet build main
dotnet restore tests
dotnet build tests
cd tests
dotnet xunit
cd ..\main
dotnet run