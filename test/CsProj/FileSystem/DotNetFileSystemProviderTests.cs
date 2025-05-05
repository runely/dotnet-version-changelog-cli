using System.IO;
using System.Linq;
using dotnet.version.changelog.CsProj.FileSystem;
using Xunit;

namespace dotnet.version.changelog.Test.CsProj.FileSystem;

public class DotNetFileSystemProviderTests
{
    private readonly DotNetFileSystemProvider _provider;

    public DotNetFileSystemProviderTests()
    {
        _provider = new DotNetFileSystemProvider();
    }

    [Fact]
    public void List_works()
    {
        // List files in the current directory running from (the build output folder)
        var files = _provider.List("./").ToList();
            
        Assert.NotEmpty(files);
        Assert.Contains("./dotnet-version-changelog.dll", files);
    }

    [Theory]
    [InlineData("./dotnet-version-changelog.dll", false)]
    [InlineData("../../../dotnet-version-changelog-test.csproj", true)]
    public void IsCsProjectFile_works(string path, bool isCsProj)
    {
        Assert.Equal(_provider.IsCsProjectFile(path), isCsProj);
    }

    [Fact(Skip = "Not working properly in CI")]
    public void Cwd_works()
    {
        var cwd = _provider.Cwd();
        Assert.Contains($"Release{Path.DirectorySeparatorChar}net", cwd);
    }

    [Fact]
    public void LoadAllContent_works()
    {
        var content = _provider.LoadContent("../../../dotnet-version-changelog-test.csproj");
        Assert.Contains("<ProjectGuid>fb420acf-9e12-42b6-b724-1eee9cbf251e</ProjectGuid>", content);
    }

    [Fact]
    public void WriteAllContent_works()
    {
        var path = "./test-file.txt";
        var content = "this is content";
        _provider.WriteAllContent(path, content);

        var loadedContent = File.ReadAllText(path);
            
        Assert.Equal(content, loadedContent);
    }
}