
//---------------------------------------------------------------------------------------
Task("nuget")
    .IsDependentOn ("nuget-pack")
    ;

Task("nuget-pack")
    .IsDependentOn ("nuget-pack-dotnet")
    .IsDependentOn ("nuget-pack-msbuild")
    ;

Task("nuget-pack-msbuild")
    .Does
    (
        () =>
        {
            foreach(FilePath sln in SourceLibSolutions)
            {
                MSBuild
                (
                    sln.ToString(),
                    msbuild_settings 
                    =>
                    {
                        msbuild_settings
                            .SetConfiguration("Release")
                            .WithTarget("Pack")
                            .WithProperty("PackageVersion", NUGET_VERSION)
                            .WithProperty("PackageOutputPath", "../../output")
                            ;

                        return;
                    }
                );
            }

            return;
        }
    );

Task("nuget-pack-dotnet")
    .Does
    (
        () =>
        {
        }
    );
//---------------------------------------------------------------------------------------
