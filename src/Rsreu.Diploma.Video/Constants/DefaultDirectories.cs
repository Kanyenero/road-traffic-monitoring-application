using System.Reflection;

namespace Rsreu.Diploma.Video.Constants;

public static class DefaultDirectories
{
    private static readonly string _assembly = Path.GetDirectoryName(Assembly.GetEntryAssembly()?.Location);

    public static readonly string VideoOutput = _assembly + "\\Media\\Output\\Videos";
    public static readonly string ImageOutput = _assembly + "\\Media\\Output\\Images";
    public static readonly string VideoSource = _assembly + "\\Media\\Source";
}
