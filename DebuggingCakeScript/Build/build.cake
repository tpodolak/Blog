var target = Argument("target", "Default");

Task("Default")
  .Does(() =>
{
	#break
	MSBuild(Directory("../") + File("DebuggingCakeScript.sln"));
});

RunTarget(target);