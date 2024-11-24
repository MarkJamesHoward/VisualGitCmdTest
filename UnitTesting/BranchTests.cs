using Xunit;

public class BranchTests
{
    readonly string RootTestingFolder = @"C:\github\VisualGitCmdUnitTest\UnitTesting\Branches";
    readonly string branchPath = Path.Combine(GlobalVars.RepoPath, @".git/refs/heads");


    [Fact]
    public void TwoBranches()
    {

        string testPath = Path.Combine(RootTestingFolder, "TwoBranches");
        GlobalVars.branchPath = Path.Combine(testPath, branchPath);


        GitBranches.ProcessBranches(null);

        Assert.Collection(GitBranches.Branches, b =>
        {
            Assert.IsType<Branch>(b);
            Assert.Equal("BranchTwo", b.name);
        },
        b =>
        {
            Assert.IsType<Branch>(b);
            Assert.Equal("master", b.name);
        });
    }

    [Fact]
    public void OneBranch()
    {
        string testPath = Path.Combine(RootTestingFolder, "OneBranch");
        GlobalVars.branchPath = Path.Combine(testPath, branchPath);

        GitBranches.ProcessBranches(null);

        Assert.Collection(GitBranches.Branches, b =>
        {
            Assert.IsType<Branch>(b);
            Assert.Equal("master", b.name);
        });
    }
}