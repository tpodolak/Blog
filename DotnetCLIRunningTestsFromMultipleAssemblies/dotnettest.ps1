Get-ChildItem | ? { $_.Name.Contains(".Tests.") } | ForEach-Object { Push-Location; Set-Location $_.Name; dotnet test; Pop-Location}
