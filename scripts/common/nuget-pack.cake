
//---------------------------------------------------------------------------------------
Task("nuget-pack")
    .IsDependentOn ("libs")
    .Does
    (
        () =>
        {
			MSBuildSettings settings = new MSBuildSettings()
												.WithTarget("Pack")
												.SetConfiguration("Release")
												.EnableBinaryLogger("./output/nuget.binlog")
												.WithProperty("NoBuild", "true")
												.WithProperty
													(
														"PackageOutputPath", 
														MakeAbsolute((DirectoryPath)"../../output/").FullPath
													)
												//.WithProperty("PackageVersion", NUGET_VERSION)
												;

			foreach(FilePath sln in LibrarySourceSolutions)
			{
				Information($"Solution: 	{sln}");
			}
			foreach(FilePath prj in LibrarySourceProjects)
			{
				Information($"Project: 		{prj}");
				MSBuild(prj, settings);
			}

            return;
        }
    );

//---------------------------------------------------------------------------------------
