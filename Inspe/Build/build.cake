#tool "nuget:?package=EtherealCode.ReSpeller&version=4.6.9.2"
#tool "nuget:?package=JetBrains.ReSharper.CommandLineTools&version=2017.2.2"
#addin "Cake.Issues"
#addin "Cake.Issues.InspectCode"
var target = Argument("target", "Default");
var destinationPath = "tools/jetbrains.resharper.commandlinetools.2017.2.2/JetBrains.ReSharper.CommandLineTools/tools";

Setup(context =>
{
    if(!DirectoryExists(".artifacts"))
    {
        CreateDirectory(".artifacts");
    }

    if(!DirectoryExists(destinationPath + "/dic"))
    {
        CreateDirectory(destinationPath + "/dic");
    }
});

Task("Clean")
.Does(()=>
{
    CleanDirectory(".artifacts");
});

Task("Clean-Cache")
.Does(()=>
{
    var toolsPath = MakeAbsolute((DirectoryPath)"tools").ToString();
    var caches = System.IO.Directory.GetDirectories(toolsPath).Where(directory => directory.Contains("_ResharperCommandLineInspections"));
    foreach(var cache in caches)
    {
        Information($"Deleting directory {cache}");
        DeleteDirectory(cache, new DeleteDirectorySettings{ Force = true, Recursive = true });
    }
});

Task("Prepare-Respeller")
.IsDependentOn("Clean-Cache")
.Does(()=>
{
    // works for pinned version of ReSpeller
    var destinationPath = "tools/jetbrains.resharper.commandlinetools.2017.2.2/JetBrains.ReSharper.CommandLineTools/tools";
    CopyFiles("tools/etherealcode.respeller.4.6.9.2/EtherealCode.ReSpeller/lib/net45/*.dll", destinationPath);
    CopyFiles("tools/etherealcode.respeller.4.6.9.2/Extended.Wpf.Toolkit/lib/net40/*.dll", destinationPath);
    CopyFiles("tools/etherealcode.respeller.4.6.9.2/NHunspell/lib/net/*.dll", destinationPath);
    CopyFiles("../Spelling/*.dic",  destinationPath + "/dic");
    CopyFiles("../Spelling/*.aff",  destinationPath + "/dic");
    CopyFiles("EtherealCode.ReSpeller.JetMetadata.sstg", destinationPath);
});

Task("Run-SpellCheck")
.IsDependentOn("Clean")
.IsDependentOn("Prepare-Respeller")
.Does(() =>
{
    // Run InspectCode.
    var settings = new InspectCodeSettings
    {
        // ArgumentCustomization = arg => arg.AppendSwitch("-x","=","EtherealCode.ReSpeller")
        // Due to the bug in Resharper commandline it is not able to download extensions on its own
        OutputFile = "../.artifacts/inspectcode.xml",
        ArgumentCustomization = arg => arg.AppendSwitch("--profile","=","../Spelling/Resharper.ReSpeller.DotSettings")
                                          .AppendSwitch("--caches-home","=","tools")
    };

    var processArgumentBuilder = new ProcessArgumentBuilder().AppendSwitch("--profile","=","../Spelling/Resharper.ReSpeller.DotSettings")
                                          .AppendSwitch("--caches-home","=","tools")
                                          .AppendSwitch("-o","=","../.artifacts/inspectcode.xml")
                                          .Append("../ResharperCommandLineInspections.sln");

    var processSettings = new ProcessSettings 
    {
        Arguments = processArgumentBuilder,
        Silent = true,
        RedirectStandardOutput = true
    };

    IEnumerable<string> redirectedOutput, redirectedErrors;

    var exitCode = StartProcess(Context.Tools.Resolve("inspectcode.exe"), processSettings, out redirectedOutput, out redirectedErrors);
    if(exitCode !=0)
    {
        throw new CakeException($"InspectCode exited with unexpected error code: {exitCode}");
    }

    var issues = ReadIssues(InspectCodeIssuesFromFilePath("../.artifacts/inspectcode.xml"), "../");
    var spellingIssues = issues.Where(issue => issue.Rule.Contains("Typo")).ToList();

    if(spellingIssues.Any())
    {
        var errorMessage = spellingIssues.Aggregate(new StringBuilder(), (stringBuilder, issue) => stringBuilder.AppendFormat("FileName: {0} Line: {1} Message: {2}{3}", issue.AffectedFileRelativePath, issue.Line, issue.Message, Environment.NewLine));
        Error(errorMessage);
        throw new CakeException($"{spellingIssues.Count} spelling errors detected. Please fix them or add missing words to the dictionary");
    }
});

RunTarget(target);