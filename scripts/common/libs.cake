#load "./nuget-restore.cake"

LibrarySourceSolutions  = GetFiles(source_solutions);
LibrarySourceProjects   = GetFiles(source_projects);

string[] configurations = new string[] 
{ 
    "Debug", 
    "Release" 
};

//---------------------------------------------------------------------------------------
Task("libs")
    .IsDependentOn ("clean")
    .IsDependentOn ("nuget-restore")
    .IsDependentOn ("nuget-restore-libs")
    .IsDependentOn ("libs-msbuild-solutions")
    .IsDependentOn ("libs-msbuild-projects")
    .IsDependentOn ("libs-dotnet-solutions")
    .IsDependentOn ("libs-dotnet-projects")
    .Does
    (
        () =>
        {
            return;
        }
    );


Task("libs-msbuild-solutions")
    .Does
    (
        () =>
        {

            foreach (string configuration in configurations)
            {
                MSBuildSettings settings = new MSBuildSettings()
                                                    .WithRestore()
                                                    .WithTarget("Build")
                                                    .SetConfiguration(configuration)
                                                    .EnableBinaryLogger($"./output/libs-{configuration}.binlog")
                                                    .WithProperty("DesignTimeBuild", "false")
                                                    //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                                                    ;

                foreach(FilePath sln in LibrarySourceSolutions)
                {
                    MSBuild(sln.ToString(), settings);
                }
            }

            return;
        }
    );

Task("libs-dotnet-solutions")
    .Does
    (
        () =>
        {
            foreach (string configuration in configurations)
            {
                foreach(FilePath sln in LibrarySourceSolutions)
                {
                    DotNetCoreBuild
                    (
                        sln.ToString(),
                        new DotNetCoreBuildSettings
                        {
                            Configuration = configuration,
                        }
                        //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                    );
                }
            }

            return;
        }
    );

Task("libs-msbuild-projects")
    .Does
    (
        () =>
        {
            foreach (string configuration in configurations)
            {
                foreach(FilePath prj in LibrarySourceProjects)
                {
                    MSBuild
                    (
                        prj.ToString(),
                        new MSBuildSettings
                        {
                            Configuration = configuration,
                        }
                        //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                    );
                }
            }

            return;
        }
    );

Task("libs-dotnet-projects")
    .Does
    (
        () =>
        {
            foreach(string configuration in configurations)
            {
                foreach(FilePath prj in LibrarySourceProjects)
                {
                    DotNetCoreBuild
                    (
                        prj.ToString(),
                        new DotNetCoreBuildSettings
                        {
                            Configuration = configuration,
                        }
                        //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                    );
                }
            }

            return;
        }
    );

public void Build(string pattern)
{
	FilePathCollection files = GetFiles(pattern);

	foreach(FilePath file in files)
	{
		foreach (string configuration in configurations)
		{
			MSBuild
			(
				file.ToString(),
				new MSBuildSettings
				{
					Configuration = configuration,
				}
				//.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
				.WithProperty("AndroidClassParser", "jar2xml")
				
			);
		}
	}
	
	return;
}
//---------------------------------------------------------------------------------------
