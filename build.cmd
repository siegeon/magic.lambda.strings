
set version=%1
set key=%2

cd %~dp0
dotnet build magic.lambda.strings/magic.lambda.strings.csproj --configuration Release --source https://api.nuget.org/v3/index.json
dotnet nuget push magic.lambda.strings/bin/Release/magic.lambda.strings.%version%.nupkg -k %key% -s https://api.nuget.org/v3/index.json
