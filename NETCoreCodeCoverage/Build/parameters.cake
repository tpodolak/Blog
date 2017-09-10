public class BuildParameters
{
    public string Target { get; private set; }
    public string Configuration { get; private set; }
    public bool UseDotNetVsTest { get; set; }
    public bool UseDotNetTest { get; set; }
    public string TargetFramework { get; private set; }
    public string TargetFrameworkFull { get; private set; }
    
    public static BuildParameters GetParameters(ICakeContext context)
    {
        if (context == null)
        {
            throw new ArgumentNullException("context");
        }

        var buildSystem = context.BuildSystem();

        return new BuildParameters {
            Target = context.Argument("target", "Build"),
            Configuration = context.Argument("configuration", "Release"),
            UseDotNetVsTest = context.Argument<bool>("UseDotNetVsTest", true),
            UseDotNetTest = context.Argument<bool>("UseDotNetTest", false),
            TargetFramework = "netcoreapp2.0",
            TargetFrameworkFull = "netcoreapp2.0"
        };
    }
}
