# MAUI Repro sample template



adb shell top -n 1000 | grep "com.companyname" > emulator-2--net8.0.top.processor.log


  PID USER         PR  NI VIRT  RES  SHR S[%CPU] %MEM     TIME+ ARGS            





```bash
dotnet build \
    ./IssueRepro0000/net8.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj
dotnet build \
    ./IssueRepro0000/net8.0/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample.csproj
dotnet build \
    ./IssueRepro0000/nightly/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj
dotnet build \
    ./IssueRepro0000/nightly/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample.csproj
dotnet build \
    ./IssueRepro0000/net9.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj
dotnet build \
    ./IssueRepro0000/net9.0/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample.csproj
dotnet build \
    ./IssueRepro0000/net7.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj
dotnet build \
    ./IssueRepro0000/net7.0/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample.csproj
```



```pwsh
dotnet new `
    uninstall `
        HolisticWare.DotNetNew.Templates.Project.MAUI.AppSampleReproXXXXX.CSharp
dotnet new `
    install `
        HolisticWare.DotNetNew.Templates.Project.MAUI.AppSampleReproXXXXX.CSharp
```

```pwsh
dotnet new hw-maui-sample-repro -o IssueRepro0000
```

```pwsh
dotnet build `
    ./IssueRepro0000/net8.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj
dotnet build `
    ./IssueRepro0000/net8.0/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample.csproj
dotnet build `
    ./IssueRepro0000/nightly/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj
dotnet build `
    ./IssueRepro0000/nightly/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample.csproj
dotnet build `
    ./IssueRepro0000/net9.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj
dotnet build `
    ./IssueRepro0000/net9.0/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample.csproj
dotnet build `
    ./IssueRepro0000/net7.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj
dotnet build `
    ./IssueRepro0000/net7.0/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample.csproj
```


## Content - Template testing

```bash
dotnet build \
    ./net9.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj
dotnet build \
    ./net9.0/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample.csproj
dotnet build \
    ./net8.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj
dotnet build \
    ./net8.0/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample.csproj
dotnet build \
    ./nightly/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj
dotnet build \
    ./nightly/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample.csproj
dotnet build \
    ./net7.0/ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj
dotnet build \
    ./net7.0/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample/ProjectsStructureTemplate.AppMAUI.HybridBlazor.DemoSample.csproj
```
