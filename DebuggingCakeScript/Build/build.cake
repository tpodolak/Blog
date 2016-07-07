var target = Argument("target", "Default");

Task("Default")
  .Does(() =>
{
	MSBuild(Directory("../") + File("DebuggingCakeScript.sln"));
});

RunTarget(target);