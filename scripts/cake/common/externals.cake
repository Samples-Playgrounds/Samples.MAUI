#load "./../private-protected-sensitive/externals.private.cake"
#load "./../common/nuget-restore.cake"

//---------------------------------------------------------------------------------------
Task("externals-git-clone")
    .Does
    (
        () => 
        {
            FilePathCollection cakes = GetFiles($"../../data/git-clone/cake/**/*.cake");
            foreach (FilePath cake in cakes)
            {
                Information($"  processing cake script: {cake.ToString()}");
            }

            return;
        }
    );

Task("externals-download")
    .Does
    (
        () => 
        {
            FilePathCollection cakes = GetFiles($"../../data/download/cake/**/*.cake");
            foreach (FilePath cake in cakes)
            {
                Information($"  processing cake script: {cake.ToString()}");
            }

            return;
        }
    );

bool ExternalsConditions()
{
    bool condition = !FileExists ("./externals/HolisticWare.Core.Math.Statistics.aar");

    return condition;
}

Task ("externals")
    .IsDependentOn ("externals-git-clone")
    .IsDependentOn ("externals-download")
    .WithCriteria (ExternalsConditions())
    .Does
    (
        () =>
        {
            Information("externals ...");

            string [] folders = new string[]
            {
                "./externals/",
                "./externals/results/",
                "./externals/results/unit-tests/",
            };

            foreach(string folder in folders)
            {
                Information($"    creating ...{folder}");
                if (! DirectoryExists (folder))
                {
                    CreateDirectory (folder);
                }
            }

            if (FileExists("externals.private.cake"))
            {
                CakeExecuteScript("externals.private.cake");
            }

            Information("    downloading ...");

            // if ( ! string.IsNullOrEmpty(AAR_URL) )
            // {
            // 	//DownloadFile (AAR_URL, "./externals/HolisticWare.Core.Math.Statistics.aar");
            // }

            return;
            // Externals.Initialize(Context);
            // Externals.Execute();

            return;
        }
    );

Task("externals-nuget-restore")
    .Does
    (
        () =>
        {
            FilePathCollection files = GetFiles("./external*/**/build.cake");
            foreach(FilePath file in files)
            {
                Information("File: {0}", file);
                CakeExecuteScript
                    (
                        file,
                        new CakeSettings
                        {
                            Verbosity = Verbosity.Diagnostic,
                            Arguments = new Dictionary<string, string>()
                            {
                                //{"verbosity",   "diagnostic"},
                                {"target",      "nuget-restore"},
                            },
                        }
                    );
            }

            return;
        }
    );
Task("externals-build")
    .IsDependentOn ("externals-nuget-restore")
    .Does
    (
        () =>
        {
            FilePathCollection files = GetFiles("./external*/**/build.cake");
            foreach(FilePath file in files)
            {
                Information("File: {0}", file);
                CakeExecuteScript
                    (
                        file,
                        new CakeSettings
                        {
                            Verbosity = Verbosity.Diagnostic,
                            Arguments = new Dictionary<string, string>()
                            {
                                //{"verbosity",   "diagnostic"},
                                {"target",      "nuget"},
                            },
                        }
                    );
            }

            return;
        }
    );


public partial class Externals
{
    static partial void ExedcutePrivateSensitive();

    public static void Execute()
    {
    }

    private static ICakeContext context = null;

    public static void Initialize(ICakeContext c)
    {
        context = c;

        return;
    }

}
//---------------------------------------------------------------------------------------
