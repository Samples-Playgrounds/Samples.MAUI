#load "./nuget-restore.cake"

//---------------------------------------------------------------------------------------
Task("samples")
    .IsDependentOn ("nuget-restore-samples")
    .IsDependentOn ("samples-msbuild-solutions")
    .IsDependentOn ("samples-msbuild-projects")
    // .IsDependentOn ("libs-dotnet-solutions")
    // .IsDependentOn ("libs-dotnet-projects")
    .Does
    (
        () =>
        {
            return;
        }
    );


Task("samples-msbuild-solutions")
    .Does
    (
        () =>
        {
            foreach(FilePath sln in SourceLibSolutions)
            {
                string binlog_path = $"./output/holisticware-samples-build-{sln}.binlog";

				foreach (string config in configs)
                {
                    MSBuild
                    (
                        sln.ToString(),
                        /*
                        Action
                        msbuild_settings =>
                        {
                            msbuild_settings.Configuration = config;
                            msbuild_settings.MaxCpuCount = 0;
                            msbuild_settings.Targets.Clear();
                            msbuild_settings.Targets.Add("Pack");
                            msbuild_settings.Properties.Add
                                                            (
                                                                "PackageOutputPath",
                                                                new []
                                                                {
                                                                    MakeAbsolute(new FilePath("../output")).FullPath
                                                                }
                                                            );
                        }
                        */
                        new MSBuildSettings
                                    {
                                        Configuration = config,
                                        Verbosity = Verbosity.Diagnostic,
                                        BinaryLogger = new MSBuildBinaryLogSettings
                                        {
                                            Enabled = true,
                                            FileName = new FilePath(binlog_path).FullPath
                                        }
                                    }
                                    .WithProperty
                                                (
                                                    "DefineConstants",
                                                    "TRACE;" //"DEBUG;NETCOREAPP2_0;NUNIT"
                                                )

                    );
                }
            }

            return;
        }
    );

Task("samples-dotnet-solutions")
    .Does
    (
        () =>
        {
            foreach(FilePath sln in SourceLibSolutions)
            {
                string binlog_path = $"./output/holisticware-samples-build-{sln}.binlog";

				foreach (string config in configs)
                {
                    Information($"DotNetCoreBuild {config} - {sln} ");
                    DotNetCoreBuild
                    (
                        sln.ToString(),
                        new DotNetCoreBuildSettings
                        {
                            Configuration = config,
                        }
                        //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                    );
                }
            }

            return;
        }
    );

Task("samples-msbuild-projects")
    .Does
    (
        () =>
        {
            foreach(FilePath prj in SourceLibProjects)
            {
                string binlog_path = $"./output/holisticware-samples-build-{prj}.binlog";

				foreach (string config in configs)
                {
                    Information($"MSBuild {config} - {prj} ");
                    MSBuild
                    (
                        prj.ToString(),
                        new MSBuildSettings
                        {
                            Configuration = config,
                        }
                        //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                    );
                }
            }

            return;
        }
    );

Task("samples-dotnet-projects")
    .Does
    (
        () =>
        {
            foreach(FilePath prj in SourceLibProjects)
            {
                if ( prj.ToString().EndsWith(".XamarinAndroid") || prj.ToString().EndsWith(".XamariniOS"))
                {
                    continue;
                }

                string binlog_path = $"./output/holisticware-samples-build-{prj}.binlog";

                foreach (string config in configs)
                {
                    Information($"DotNetCoreBuild {config} - {prj} ");

                    DotNetCoreBuild
                    (
                        prj.ToString(),
                        new DotNetCoreBuildSettings
                        {
                            Configuration = config,
                        }
                        //.WithProperty("DefineConstants", "TRACE;DEBUG;NETCOREAPP2_0;NUNIT")
                    );
                }
            }

            return;
        }
    );
//---------------------------------------------------------------------------------------
