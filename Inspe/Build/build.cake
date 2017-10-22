#tool "nuget:?package=JetBrains.ReSharper.CommandLineTools"
#tool "nuget:?package=EtherealCode.ReSpeller&version=4.6.9.2"
#addin "Cake.Issues"
#addin "Cake.Issues.InspectCode"
//  <add key="resharper-plugins" value="https://resharper-plugins.jetbrains.com/api/v2/curated-feeds/Wave_v9.0/" protocolVersion="2" />
var target = Argument("target", "Default");
var destinationPath = "tools/jetbrains.resharper.commandlinetools/JetBrains.ReSharper.CommandLineTools/tools";

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
.WithCriteria(()=>
{
    // var customDictionaryModificationDate = System.IO.File.GetLastWriteTime("../Spelling/en_US_custom.dic");
    // var commandLineCacheModificationDate = System.IO.File.GetLastWriteTime("tools/_ResharperCommandLineInspections.1437843129.00");
    // return customDictionaryModificationDate > commandLineCacheModificationDate && DirectoryExists("tools/_ResharperCommandLineInspections.1437843129.00");
    return true;
})
.Does(()=>
{
    CleanDirectory("tools/_ResharperCommandLineInspections.1437843129.00");
});

Task("Prepare-Respeller")
.IsDependentOn("Clean-Cache")
.Does(()=>
{
    // works for pinned version of ReSpeller
    var destinationPath = "tools/jetbrains.resharper.commandlinetools/JetBrains.ReSharper.CommandLineTools/tools";
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

    InspectCode("../ResharperCommandLineInspections.sln" , settings);

    var issues = ReadIssues(InspectCodeIssuesFromFilePath("../.artifacts/inspectcode.xml"), "../");
    var spellingIssues = issues.Where(issue => issue.Rule.Contains("Typo")).ToList();

    if(spellingIssues.Any())
    {
        Error("{0} spelling errors detected", spellingIssues.Count);
        foreach(var issue in spellingIssues)
        {
            Error("FileName: {0} Line: {1} Message:{2}", issue.AffectedFileRelativePath, issue.Line, issue.Message);
        }

        throw new CakeException("Spelling errors detected. Please fix them or add missing words to the dictionary");
    }
});

RunTarget(target);