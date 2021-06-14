/*
#########################################################################################
Installing

    dotnet cake global tool

        dotnet tool uninstall 	-g Cake.Tool
        dotnet tool install 	-g Cake.Tool	

    script bootstrappers (deprecated)

        Windows - powershell

            Invoke-WebRequest http://cakebuild.net/download/bootstrapper/windows -OutFile build.ps1
            .\build.ps1

            Get-ExecutionPolicy -List
            Set-ExecutionPolicy RemoteSigned -Scope Process
            Unblock-File .\build.ps1

        Windows - cmd.exe prompt

            powershell ^
                Invoke-WebRequest http://cakebuild.net/download/bootstrapper/windows -OutFile build.ps1
            powershell ^
                .\build.ps1

        Mac OSX

            rm -fr tools/; mkdir ./tools/ ; \
            cp cake.packages.config ./tools/packages.config ; \
            curl -Lsfo build.sh http://cakebuild.net/download/bootstrapper/osx ; \
            sh ./build.sh

            chmod +x ./build.sh ;
            ./build.sh

        Linux

            curl -Lsfo build.sh http://cakebuild.net/download/bootstrapper/linux
            chmod +x ./build.sh && ./build.sh

Running Cake to Build targets

    Windows

        tools\Cake\Cake.exe --verbosity=diagnostic --target=libs
        tools\Cake\Cake.exe --verbosity=diagnostic --target=nuget
        tools\Cake\Cake.exe --verbosity=diagnostic --target=samples


    Mac OSX

        mono tools/Cake/Cake.exe --verbosity=diagnostic --target=libs
        mono tools/Cake/Cake.exe --verbosity=diagnostic --target=nuget

        mono tools/nunit.consolerunner/NUnit.ConsoleRunner/tools/nunit3-console.exe \


#########################################################################################
*/

// https://www.nuget.org/packages/Cake.CoreCLR
//  Cake.CoreCLR add to ./tools/ folder for debugging
#tool   nuget:?package=Cake.CoreCLR

#addin nuget:?package=Cake.FileHelpers


//---------------------------------------------------------------------------------------
// unit testing
#tool nuget:?package=NUnit.ConsoleRunner&version=3.9.0
#tool nuget:?package=xunit.runner.console
//---------------------------------------------------------------------------------------
// coverage
#tool "nuget:?package=OpenCover"
// dotCover is commercial
// #tool "nuget:?package=JetBrains.dotCover.CommandLineTools"
//---------------------------------------------------------------------------------------
// reporting
#tool "nuget:?package=ReportUnit"
#tool "nuget:?package=ReportGenerator"

//---------------------------------------------------------------------------------------
var TARGET = Argument ("t", Argument ("target", "Default"));

string source_solutions         = $"./source/**/*.sln";
string source_projects          = $"./source/**/*.csproj";
string sample_solutions         = $"./samples/**/*.sln";
string sample_projects          = $"./samples/**/*.csproj";
string externals_cake_scripts   = $"./samples/**/*.cake";
string samples_cake_scripts     = $"./samples/**/*.cake";
string tests_cake_scripts       = $"./samples/**/*.cake";

FilePathCollection LibrarySourceSolutions   = GetFiles(source_solutions);
FilePathCollection LibrarySourceProjects   = GetFiles(source_projects);

FilePathCollection SamplesSolutions         = GetFiles(sample_solutions);
FilePathCollection SamplesProjects          = GetFiles(sample_projects);

string[] clean_folder_patterns = new string[]
{
    "./externals/",
    "./output/",
    "./**/.vs/",
    "./source/**/bin/",
    "./source/**/obj/",
    "./samples/**/bin/",
    "./samples/**/obj/",
    "./samples/**/tools/",
    "./tests/**/bin/",
    "./tests/**/obj/",
};

string[] clean_file_patterns = new string[]
{
    "./**/*.binlog",
    "./**/.DS_Store",
};

string prefix = "./externals/downloads/";
Dictionary<string, string> externals_downloads = new Dictionary<string, string>
{
    { 
        $"./{prefix}/Utilities/Weather/WeatherTwentyOne/", 
        "https://github.com/davidortinau/WeatherTwentyOne/archive/refs/heads/main.zip"
    },
    { 
        $"./{prefix}/maui/", 
        "https://github.com/dotnet/maui-samples/archive/refs/heads/main.zip"
    },
    
};

#load "./scripts/common/externals.cake"
#load "./scripts/private-protected-sensitive/externals.private.cake"
#load "./scripts/common/main.cake"
#load "./scripts/common/nuget-restore.cake"
#load "./scripts/common/nuget-pack.cake"
#load "./scripts/common/libs.cake"
#load "./scripts/common/tests-unit-tests.cake"


// FilePathCollection UnitTestsNUnitMobileProjects = GetFiles($"./tests/unit-tests/project-references/**/*.NUnit.Xamarin*.csproj");
// FilePathCollection UnitTestsXUnitProjects = GetFiles($"./tests/unit-tests/project-references/**/*.XUnit.csproj");
// FilePathCollection UnitTestsMSTestProjects = GetFiles($"./tests/unit-tests/project-references/**/*.NUnit.csproj");


Task("Default")
.Does
    (
        () =>
        {
            RunTarget("unit-tests");
        }
    );

RunTarget (TARGET);

if( ! IsRunningOnWindows())
{
    try
    {
        int exit_code = StartProcess
                                (
                                    "tree",
                                    new ProcessSettings
                                    {
                                        Arguments = @"./output"
                                    }
                                );
    }
    catch(Exception ex)
    {
        Information($"unable to start process - tree {ex.Message}");
    }
}
else
{
    // int exit_code = StartProcess
    //                         (
    //                             "dir",
    //                             new ProcessSettings
    //                             {
    //                                 Arguments = @"output"
    //                             }
    //                         );

}
