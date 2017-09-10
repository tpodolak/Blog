#load "./parameters.cake"
#load "./paths.cake"

#tool "nuget:https://www.nuget.org/api/v2?package=OpenCover&version=4.6.519"
#tool "nuget:https://www.nuget.org/api/v2?package=ReportGenerator&version=2.4.5"

var parameters = BuildParameters.GetParameters(Context);
var paths = BuildPaths.GetPaths(Context, parameters);

Setup(context =>
{
    if (!DirectoryExists(paths.Directories.Artifacts))
    {
        CreateDirectory(paths.Directories.Artifacts);
    }

    if (!DirectoryExists(paths.Directories.TestResults))
    {
        CreateDirectory(paths.Directories.TestResults);
    }
});

Task("Clean")
    .Does(() =>
{
    CleanDirectories(paths.Directories.ToClean);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreRestore(paths.Files.Solution.ToString());
});

Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    DotNetCoreBuild(paths.Files.Solution.ToString(), new DotNetCoreBuildSettings
    {
        Configuration = parameters.Configuration,
        ArgumentCustomization = arg => arg.AppendSwitch("/p:DebugType","=","Full")
    });
});


Task("Run-Tests")
    .IsDependentOn("Build")
    .Does(() =>
{
    if(parameters.SkipOpenCover){

        var argumentBuilder = new ProcessArgumentBuilder();
        argumentBuilder.Append("vstest")
                    .Append(string.Join(" ", paths.Files.TestAssemblies.Select(val => MakeAbsolute(val).ToString())))
                    .Append("--Parallel");

        StartProcess("dotnet.exe", new ProcessSettings
        {
            Arguments = argumentBuilder
        });
    }
    else
    {
        var success = true;
        foreach(var project in paths.Files.TestProjects)
        {
            try 
            {
                var projectFile = MakeAbsolute(project).ToString();
                var dotNetTestSettings = new DotNetCoreTestSettings
                {
                    Configuration = parameters.Configuration,
                    NoBuild = true
                };

                OpenCover(tool => tool.DotNetCoreTest(projectFile, dotNetTestSettings),
                                        paths.Files.TestCoverageOutput,
                                        new OpenCoverSettings
                                        {
                                            ReturnTargetCodeOffset = 0,
                                            OldStyle = true,
                                            ArgumentCustomization = args => args.Append("-mergeoutput")

                                        }
                                        .WithFilter("+[NETCoreCodeCoverage*]* -[NETCoreCodeCoverage.Tests*]*")
                                        .ExcludeByAttribute("*.ExcludeFromCodeCoverage*")
                                        .ExcludeByFile("*/*Designer.cs;*/*.g.cs;*/*.g.i.cs"));
            }
            catch(Exception ex)
            {
                success = false;
                Error("There was an error while running the tests", ex);
            }
        }

       if(success == false)
       {
           throw new CakeException("There was an error while running the tests");
       }

        ReportGenerator(paths.Files.TestCoverageOutput, paths.Directories.TestResults);
    }

});

RunTarget(parameters.Target);