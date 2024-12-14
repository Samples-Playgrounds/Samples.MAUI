# Repro Sample - Issue 14733 - NuGet Restore problem - for libraries

*   Issue #14733

    *   Use of Preferences class in .Net MAUI class library causes build failure with NU1202 error #14733

        *   https://github.com/dotnet/maui/issues/14733


## Samples / Source

### `net7.0`

running:

```
dotnet restore /bl /v:diagnostic 14733/net7.0/NugetRestoreProblem/NugetRestoreProblem/
```

No errors.

[docs/net7.0/dotnet_restore/project.assets.json](docs/net7.0/dotnet_restore/project.assets.json)

Running:

```
nuget restore 14733/net7.0/NugetRestoreProblem/NugetRestoreProblem/NugetRestoreProblem.csproj
```

result:

```
/usr/local/share/dotnet/sdk/6.0.116/Sdks/Microsoft.NET.Sdk/targets/Microsoft.NET.TargetFrameworkInference.targets(144,5): error NETSDK1045: The current .NET SDK does not support targeting .NET 7.0.  Either target .NET 6.0 or lower, or use a version of the .NET SDK that supports .NET 7.0. [./MAUI/samples/issues-repro-samples/14733/net7.0/NugetRestoreProblem/NugetRestoreProblem/NugetRestoreProblem.csproj]
```


### `net6.0`

running:

```
 dotnet restore /bl /v:diagnostic 14733/net6.0/NugetRestoreProblem/NugetRestoreProblem/
```

No errors.

[docs/net6.0/dotnet_restore/project.assets.json](docs/net6.0/dotnet_restore/project.assets.json)

Running:

```
nuget restore 14733/net6.0/NugetRestoreProblem/NugetRestoreProblem/NugetRestoreProblem.csproj
```

result:

```
/usr/local/share/dotnet/sdk/6.0.116/Sdks/Microsoft.NET.Sdk/targets/Microsoft.NET.TargetFrameworkInference.targets(112,5): error NETSDK1139: The target platform identifier android was not recognized. [/Users/Shared/Projects/d/Samples-Playgrounds/MAUI/samples/issues-repro-samples/14733/net6.0/NugetRestoreProblem/NugetRestoreProblem/NugetRestoreProblem.csproj]
```

fixing csproj:

```xml
		<TargetFramework>net6.0-android</TargetFramework>
        <!--
		<TargetFrameworks>net6.0;net6.0-android;net6.0-ios;net6.0-maccatalyst</TargetFrameworks>
		<TargetFrameworks Condition="$([MSBuild]::IsOSPlatform('windows'))">$(TargetFrameworks);net6.0-windows10.0.19041.0</TargetFrameworks>
        -->
```
