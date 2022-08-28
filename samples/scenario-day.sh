#!/bin/bash

# start Android emulator to gain some time
emulator -list-avds

#$HOME/Library/Developer/Xamarin/android-sdk-macosx/emulator/emulator 
$HOME/Library/Android/sdk/emulator/emulator \
    -avd "Pixel_XL_API_30" \
    &

# https://github.com/dotnet/maui/blob/main/.github/DEVELOPMENT.md

# https://github.com/dotnet/maui/blob/main/.github/DEVELOPMENT.md#samples

# https://github.com/dotnet/maui/blob/main/.github/DEVELOPMENT.md#what-branch-should-i-use


git clone \
    --recursive \
    https://github.com/dotnet/maui.git \
    maui-vs-scenario-day \


cd maui-vs-scenario-day/

dotnet tool restore
dotnet cake --target=VS

mkdir   mokeeee_appp
cd      mokeeee_appp

../bin/dotnet/dotnet new maui
../bin/dotnet/dotnet build -t:Run -f net6.0-android

cd ../










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

TIMESTAMP=$( date "+%Y%m%d%H%M%S" )
echo    $TIMESTAMP

dotnet \
    new \
        mauilib \
            --output ./Demos/macosx/dotnet/$TIMESTAMP/Library.MAUI

dotnet \
    new \
        maui \
            --output ./Demos/macosx/dotnet/$TIMESTAMP/App.MAUI

dotnet \
    new \
        maui-blazor \
            --output ./Demos/macosx/dotnet/$TIMESTAMP/App.MAUI.Blazor


#	<PropertyGroup>
#		<LangVersion>latest</LangVersion>
#	</PropertyGroup>

TIMESTAMP=20220503161705

dotnet \
    build \
        ./Demos/macosx/dotnet//$TIMESTAMP/Library.MAUI/Library.MAUI.csproj

dotnet \
    build \
        ./Demos/macosx/dotnet//$TIMESTAMP/App.MAUI/App.MAUI.csproj

dotnet \
    build \
        ./Demos/macosx/dotnet//$TIMESTAMP/App.MAUI/App.MAUI.csproj \
            -t:Run \
            -f:net6.0-android

dotnet \
    build \
        ./Demos/macosx/dotnet//$TIMESTAMP/App.MAUI/App.MAUI.csproj \
            -t:Run \
            -f:net6.0-ios


dotnet \    
    build \
        ./Demos/macosx/dotnet//$TIMESTAMP/App.MAUI.Blazor/App.MAUI.Blazor.csproj

dotnet \
    build \
        ./Demos/macosx/dotnet//$TIMESTAMP/App.MAUI.Blazor/App.MAUI.Blazor.csproj \
            -t:Run \
            -f:net6.0-android

dotnet \
    build \
        ./Demos/macosx/dotnet//$TIMESTAMP/App.MAUI.Blazor/App.MAUI.Blazor.csproj \
            -t:Run \
            -f:net6.0-ios


dotnet \
    build \
        ./Demos/macosx/dotnet/$TIMESTAMP/Library.MAUI/Library.MAUI.csproj \
            -t:Run \
            -f:net6.0-android

dotnet \
    build \
        ./Demos/macosx/dotnet//$TIMESTAMP/Library.MAUI/Library.MAUI.csproj \
            -t:Run \
            -f:net6.0-ios
