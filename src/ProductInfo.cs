using System.Reflection;

namespace dotnet.version.changelog;

public static class ProductInfo
{
    /// <summary>
    /// The name of the product
    /// </summary>
    public const string Name = "dotnet-version-changelog-cli";

    /// <summary>
    /// The version of the running product
    /// </summary>
    public static readonly string Version = Assembly.GetEntryAssembly()!.GetName()!.Version!.ToString();
}