#addin "nuget:https://www.nuget.org/api/v2?package=PactNet&version=2.4.7"
var target = Argument("target", "Default");
var configuration = Argument("configuration", "Release");

var rootDir = Context.MakeAbsolute((DirectoryPath)Context.Directory("../"));
var pactsDir = rootDir.Combine("pacts");
var pactTestsFile = rootDir.Combine("Bookings.Api.Tests.Pact").CombineWithFilePath("Bookings.Api.Tests.Pact.csproj").ToString();
var solutionFile = rootDir.CombineWithFilePath("ContractTestingWithPact.sln").ToString();
var version = "1.0.0";

Task("Clean")
    .Does(() =>
{
    CleanDirectory(pactsDir);
    DotNetCoreClean(solutionFile);
});

Task("Restore-NuGet-Packages")
    .IsDependentOn("Clean")
    .Does(() =>
{
    DotNetCoreRestore(solutionFile);
});


Task("Build")
    .IsDependentOn("Restore-NuGet-Packages")
    .Does(() =>
{
    DotNetCoreBuild(solutionFile, new DotNetCoreBuildSettings
    {
        Configuration = configuration,
        NoRestore = true,
        ArgumentCustomization = arg => arg.AppendSwitch("/p:DebugType","=","Full")
                                          .AppendSwitch("/p:Version", "=", version),
        VersionSuffix = version
    });
});

Task("Run-Pact-Tests")
.IsDependentOn("Build")
.Does(()=>
{
    DotNetCoreTest(pactTestsFile);
});

Task("Publish-Pact")
.IsDependentOn("Run-Pact-Tests")
.Does(() =>
{
    var pactPublisher = new PactPublisher("http://test.pact.dius.com.au", new PactUriOptions("username", "password"));



pactPublisher.PublishToBroker(
    "..\\..\\..\\Samples\\EventApi\\Consumer.Tests\\pacts\\event_api_consumer-event_api.json",
    "1.0.2", new [] { "master" });
});

RunTarget(target);