#load "./imports.csx"
public class BuildPaths
{
    public BuildFiles Files { get; private set; }
    public BuildDirectories Directories { get; private set; }

    public static BuildPaths GetPaths(ICakeContext context)
    {
        var buildDirectories = GetBuildDirectories(context);
        var buildFiles = new BuildFiles(buildDirectories.RootDir + "/"+ context.File("CakeDataAtTheRootLevelIsInvalid.sln"));

        return new BuildPaths
        {
            Files = buildFiles,
            Directories = buildDirectories
        };
    }

    public static BuildDirectories GetBuildDirectories(ICakeContext context)
    {
        var rootDir = context.Directory("../");
        var projectDir = rootDir + context.Directory("CakeDataAtTheRootLevelIsInvalid");

        return new BuildDirectories(rootDir, projectDir);
    }
}

public class BuildFiles
{
    public FilePath Solution { get; private set; }

    public BuildFiles(FilePath solution)
    {
        Solution = solution;
    }
}

public class BuildDirectories
{
    public DirectoryPath RootDir { get; private set; }
    public DirectoryPath Project { get; private set; }

    public BuildDirectories(
        DirectoryPath rootDir,
        DirectoryPath project
        )
    {
       RootDir = rootDir;
       Project = project;
    }
}