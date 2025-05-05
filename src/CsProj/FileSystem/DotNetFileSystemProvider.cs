using System.Collections.Generic;
using System.IO;

namespace dotnet.version.changelog.CsProj.FileSystem;

public class DotNetFileSystemProvider : IFileSystemProvider
{
    /// <summary>
    /// List the files of the given path
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public IEnumerable<string> List(string path)
    {
        return Directory.EnumerateFiles(path);
    }

    /// <summary>
    /// Determines whether the given path is actually a csproj or targets file
    /// </summary>
    /// <param name="path"></param>
    /// <returns></returns>
    public bool IsCsProjectFile(string path)
    {
        return File.Exists(path) && (path.EndsWith(".csproj") || path.EndsWith(".targets"));
    }

    /// <summary>
    /// Gets the current working directory of the running application
    /// </summary>
    /// <returns></returns>
    public string Cwd()
    {
        return Directory.GetCurrentDirectory();
    }

    /// <summary>
    /// Load content from the given file
    /// </summary>
    /// <param name="filePath"></param>
    /// <returns></returns>
    public string LoadContent(string filePath)
    {
        return File.ReadAllText(filePath);
    }

    /// <summary>
    /// Write all text content to the given filepath
    /// </summary>
    /// <param name="filePath"></param>
    /// <param name="data"></param>
    public void WriteAllContent(string filePath, string data)
    {
        File.WriteAllText(filePath, data);
    }
}