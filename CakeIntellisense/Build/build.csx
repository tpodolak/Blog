#load "./imports.csx"
#load "./paths.csx"

BuildPaths paths = BuildPaths.GetPaths(Context);

var target = Argument("target", "Default");
var xPathVersionSelector = "//appSettings/add[@key='Version']/@value";

Task("Default")
.IsDependentOn("Update-Version")
  .Does(() =>
{
	MSBuild(paths.Files.Solution);
});

Task("Update-Version")
.Does(()=>
{
    var appConfigPath = paths.Directories.Project + "/" + Context.File("App.config");
    var version = GetVersion(appConfigPath);
    Information("Current version: {0}", version);
    // According to documentation commented line below should work, unfortunatelly XmlPoke and XmlPokeString cannot locate the file
    // XmlPokeString(File(appConfigPath), xPathVersionSelector, (++version).ToString());
    // so here is a workaround
    XmlPoke(MakeAbsolute(File(appConfigPath)), xPathVersionSelector, (++version).ToString());
    version = GetVersion(appConfigPath);
    Information("Updated version: {0}", version);
});

private int GetVersion(string appConfigPath)
{
  return int.Parse(XmlPeek(appConfigPath, xPathVersionSelector));
}

RunTarget(target);