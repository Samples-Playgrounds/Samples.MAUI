# Restoring packages

*   `dotnet restore`

    *   only SDK style projects

        *   MAUI

*   `msbuild restore`

    *   v 16.5+

        *   added support for `packages.config`

    *   restore all your projects.

        *   `msbuild -t:restore`

        *   `msbuild -t:restore -pRestorePackagesConfig=true`

            *   at least 1 project still using packages.config

*   `nuget restore`

    *   nuget is not installed/shipped anywhere by Microsoft

    *   it must be downloaded

    *   used mostly for `packages.config`

        *   support added to msbuild, so no need for `nuget.exe`

    *   CI/CD (DevOps) sometimes provide `nuget.exe`

        *   Azure DevOps

        *   GitHub

    *   `nuget update -self`

        *   recommended for latest versions

        *   https://learn.microsoft.com/en-us/nuget/reference/cli-reference/cli-ref-update

*   use `nuget.exe`

    *   for solutions that have projects with `packages.config`

*   do not use `nuget.exe`

    *    no need to think about what version of `nuget.exe` works with `dotnet`/`msbuild`


## Diverse

TODO:

*   https://github.com/dotnet/maui/issues/14733#issuecomment-1525654141

