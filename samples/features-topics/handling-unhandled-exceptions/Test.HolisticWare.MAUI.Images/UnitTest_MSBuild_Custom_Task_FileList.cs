using System.Text;

using Microsoft.Build.Evaluation;
using Microsoft.Build.Framework;
using Microsoft.Build.Logging;

using Microsoft.CodeAnalysis;
using HolisticWare.MAUI.Images;

namespace Test.HolisticWare.MAUI.Images;

/// <summary>
/// 
/// </summary>
/// https://learn.microsoft.com/en-us/visualstudio/msbuild/tutorial-test-custom-task
/// https://moleseyhill.com/2009-06-08-test-msbuild-from-mstest.html
/// https://moleseyhill.com/2010-01-31-unit-test-msbuild-custom-task.html
public class 
                                        UnitTest_MSBuild_Custom_Task_FileList
{
    const string projectXml =
        @"""
        <Project xmlns='http://schemas.microsoft.com/developer/msbuild/2003'>
	        <Target Name=""ListImages"" BeforeTargets=""Build"">
		        <FileList />
	        </Target>
        </Project>
        """;

    [Fact]
    public
        void
                                        Test1
                                        (
                                        )
    {
        var engine = new Engine{DefaultToolsVersion = "3.5"};

        var project = new Project(engine);
        project.LoadXml(buildProject);

        var builder = new StringBuilder();
        var writer = new StringWriter(builder);
        WriteHandler handler = (x) => writer.WriteLine(x);
        var logger = new ConsoleLogger(LoggerVerbosity.Normal, handler, null, null);
        engine.RegisterLogger(logger);

        bool result = engine.BuildProject(project);

        engine.UnregisterAllLoggers();
        consoleOutput = builder.ToString();
        return result;
        */
        
        return;
    }
    
    // public bool CallMsBuild(string buildProject, out string consoleOutput)
    // {
    // }

    [Fact]
    public void CallMsBuildAndCaptureOutput()
    {
        string consoleOutput;

        //bool success = CallMsBuild(projectXml, out consoleOutput);
    }
}
