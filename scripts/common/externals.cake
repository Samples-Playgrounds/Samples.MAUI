#load "./../private-protected-sensitive/externals.private.cake"
#load "./../common/nuget-restore.cake"

//---------------------------------------------------------------------------------------
Task ("externals")
    .IsDependentOn ("externals-downloads")
    // .WithCriteria (!FileExists ("./externals/HolisticWare.Core.Math.Statistics.aar"))
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

Task("externals-downloads")
    .Does
    (
        () =>
        {
            foreach (KeyValuePair<string, string> kvp in externals_downloads)
            {
                Information("Downloading and extracting repos");
                Information($"      source  = {kvp.Value}");
                Information($"      folder  = {kvp.Key}");

                EnsureDirectoryExists(kvp.Key);
                EnsureDirectoryExists($"{kvp.Key}/code/");
                DownloadFile(kvp.Value, kvp.Key);
                Unzip(kvp.Key, $"{kvp.Key}/code/");
            }

            return;
        }
    );


Task("externals-build")
    .IsDependentOn ("nuget-restore")
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
                                {"target",      "libs"},
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
