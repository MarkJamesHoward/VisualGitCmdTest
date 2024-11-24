using Xunit;

public class BlobTests
{

    readonly string RootTestingFolder = @"C:\github\VisualGitCmdUnitTest\UnitTesting\Blobs";
    readonly string BlobPath = Path.Combine(GlobalVars.RepoPath, @".git/objects");

    [Fact]
    public void SingleBlob()
    {
        GlobalVars.debug = true;
        MyLogging.CreateLogger();

        string testPath = Path.Combine(RootTestingFolder, "OneBlob");
        GlobalVars.GITobjectsPath = Path.Combine(testPath, BlobPath);

        GitRepoExaminer.ProcessEachFileAndExtract_Commit_Tree_Blob(GlobalVars.GITobjectsPath);

        Assert.Collection(GitBlobs.Blobs, b =>
        {
            Assert.IsType<Blob>(b);
            Assert.Equal("blob1.txt", b.filename);
        });
    }
}