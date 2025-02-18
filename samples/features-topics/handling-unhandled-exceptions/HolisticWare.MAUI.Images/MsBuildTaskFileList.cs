using System.IO;
using Microsoft.Build.Framework;
using Microsoft.Build.Utilities;

namespace HolisticWare.MAUI.Images.MSBuild.Tasks;

/// <summary>
/// 
/// </summary>
/// https://learn.microsoft.com/en-us/visualstudio/msbuild/task-writing
/// https://learn.microsoft.com/en-us/visualstudio/msbuild/tutorial-custom-task-code-generation
/// https://learn.microsoft.com/en-us/archive/msdn-magazine/2009/february/msbuild-best-practices-for-creating-reliable-builds-part-1
/// https://learn.microsoft.com/en-us/archive/msdn-magazine/2009/march/msbuild-best-practices-for-creating-reliable-builds-part-2
/// https://web.archive.org/web/20200222130526/http://bartdesmet.net/blogs/bart/archive/2008/02/15/the-custom-msbuild-task-cookbook.aspx
/// 
public partial class
                                        MsBuildTaskFileList
                                        :
                                        Microsoft.Build.Utilities.Task
{
    public override
        bool
                                        Execute
                                        (
                                        )
    {
        string cd = System.IO.Directory.GetCurrentDirectory();

        Log.LogMessage(MessageImportance.High, $"File List Start = {cd}");

        bool success = true;
        
        string[] files = System.IO.Directory.GetFiles("./Resources/", "*.png", SearchOption.AllDirectories);
        
        foreach (string fn in files)
        {
            Log.LogMessage(MessageImportance.High, $"file = {fn}");
        }
        
        Log.LogMessage(MessageImportance.High, $"File List Stop  = {cd}");

        return success;
    }
}
