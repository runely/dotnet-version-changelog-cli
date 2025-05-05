using dotnet.version.changelog.CsProj;
using dotnet.version.changelog.Model;

namespace dotnet.version.changelog.Vcs;

public class VcsParser
{
    public string Commit(VersionInfo verInfo, ProjectFileParser fileParser, string argMessage)
    {
        if (string.IsNullOrEmpty(argMessage)) return $"v{verInfo.NewVersion}";

        return ReplaceVariables(verInfo, fileParser, argMessage);
    }

    public string Tag(VersionInfo verInfo, ProjectFileParser fileParser, string argTag)
    {
        if (string.IsNullOrEmpty(argTag)) return $"v{verInfo.NewVersion}";

        return ReplaceVariables(verInfo, fileParser, argTag);
    }

    private string ReplaceVariables(VersionInfo verInfo, ProjectFileParser fileParser, string dest)
    {
        return dest
            .Replace("$projName", fileParser.PackageName)
            .Replace("$oldVer", verInfo.OldVersion)
            .Replace("$newVer", verInfo.NewVersion);
    }
}