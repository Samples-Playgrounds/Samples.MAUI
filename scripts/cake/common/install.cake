/*
#########################################################################################
Installing

dotnet tool Cake

    dotnet tool uninstall --global Cake.Tool
    dotnet tool install --global Cake.Tool

Vannila Cake

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
