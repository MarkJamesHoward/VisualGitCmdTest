using Xunit;

public class CommitTests
{
    readonly string RootTestingFolder = @"C:\github\VisualGitCmdUnitTest\UnitTesting\Commits";
    readonly string commitPath = Path.Combine(GlobalVars.RepoPath, @".git/objects");
    [Fact]
    public void SingleCommit()
    {
        GlobalVars.debug = true;
        MyLogging.CreateLogger();

        string testPath = Path.Combine(RootTestingFolder, "SingleCommit");
        GlobalVars.GITobjectsPath = Path.Combine(testPath, commitPath);

        Console.WriteLine(GlobalVars.GITobjectsPath);
        GitRepoExaminer.ProcessEachFileAndExtract_Commit_Tree_Blob(GlobalVars.GITobjectsPath);

        Assert.Collection(GitCommits.Commits, n =>
       {
           Assert.IsType<Commit>(n);
           Assert.Equal("Initial", n.text);
       });
    }
}