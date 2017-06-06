dotnet build;
dotnet vstest (Get-ChildItem -recurse -File *.Tests.*dll | ? { $_.FullName -notmatch "\\obj\\?" })
