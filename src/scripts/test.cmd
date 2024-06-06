dotnet test --collect:"XPlat Code Coverage"
dotnet reportgenerator "-reports:tests/*Tests*/TestResults/*/coverage.cobertura.xml" "-targetdir:coveragereport" -reporttypes:Html