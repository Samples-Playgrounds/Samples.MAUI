#!/bin/bash

# start Android emulator to gain some time
emulator -list-avds
$HOME/Library/Developer/Xamarin/android-sdk-macosx/emulator/emulator \
    -avd \
        "pixel_2_r_11_0_-_api_30" \
        &



dotnet tool uninstall   -g Redth.Net.Maui.Check
dotnet tool install     -g Redth.Net.Maui.Check


# --preview
#   uses a more frequently updated manifest with newer versions of things more often. 
#   The manifest is hosted by default at: 
#       https://aka.ms/dotnet-maui-check-manifest-dev
maui-check --fix --non-interactive --preview


dotnet new nugetconfig

dotnet nuget add source -n maui-preview https://aka.ms/maui-preview/index.json

dotnet new --uninstall  Microsoft.Maui.Templates
dotnet new --install    Microsoft.Maui.Templates


rm -fr ./Demos/macosx/dotnet/App.MAUI/
rm -fr ./Demos/macosx/dotnet/App.MAUI.Blazor/
rm -fr ./Demos/macosx/dotnet/Library.MAUI/
rm -fr ./Demos/macosx/dotnet/
rm -fr ./Demos/macosx/
rm -fr ./Demos/


dotnet \
    new \
        mauilib \
            --output ./Demos/macosx/dotnet/Library.MAUI

dotnet \
    new \
        maui \
            --output ./Demos/macosx/dotnet/App.MAUI

dotnet \
    new \
        maui-blazor \
            --output ./Demos/macosx/dotnet/App.MAUI.Blazor


#	<PropertyGroup>
#		<LangVersion>latest</LangVersion>
#	</PropertyGroup>


dotnet \
    build \
        ./Demos/macosx/dotnet/Library.MAUI/Library.MAUI.csproj

dotnet \
    build \
        ./Demos/macosx/dotnet/App.MAUI/App.MAUI.csproj

dotnet \
    build \
        ./Demos/macosx/dotnet/App.MAUI/App.MAUI.csproj \
            -t:Run \
            -f:net6.0-android

dotnet \
    build \
        ./Demos/macosx/dotnet/App.MAUI/App.MAUI.csproj \
            -t:Run \
            -f:net6.0-ios


dotnet \    
    build \
        ./Demos/macosx/dotnet/App.MAUI.Blazor/App.MAUI.Blazor.csproj

dotnet \
    build \
        ./Demos/macosx/dotnet/App.MAUI.Blazor/App.MAUI.Blazor.csproj \
            -t:Run \
            -f:net6.0-android

dotnet \
    build \
        ./Demos/macosx/dotnet/App.MAUI.Blazor/App.MAUI.Blazor.csproj \
            -t:Run \
            -f:net6.0-ios


dotnet \
    build \
        ./Demos/macosx/dotnet/ApLibraryp.MAUI/Library.MAUI.csproj \
            -t:Run \
            -f:net6.0-android

dotnet \
    build \
        ./Demos/macosx/dotnet/Library.MAUI/Library.MAUI.csproj \
            -t:Run \
            -f:net6.0-ios
