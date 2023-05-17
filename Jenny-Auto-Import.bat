pushd %~dp0
dotnet Jenny/Jenny.Generator.Cli.dll auto-import -s
dotnet Jenny/Jenny.Generator.Cli.dll doctor
pause
popd
