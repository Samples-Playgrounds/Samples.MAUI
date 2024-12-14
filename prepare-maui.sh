#!/bin/bash

# start Android emulator to gain some time
emulator -list-avds

#$HOME/Library/Developer/Xamarin/android-sdk-macosx/emulator/emulator 
$HOME/Library/Android/sdk/emulator/emulator \
    -avd "Pixel_XL_API_30" \
    &


dotnet tool uninstall   -g \
    Redth.Net.Maui.Check
dotnet tool install     -g \
    Redth.Net.Maui.Check \
    --add-source https://api.nuget.org/v3/index.json

# dotnet tool update    -g redth.net.maui.check \
#       --add-source https://api.nuget.org/v3/index.json



# --preview
#   uses a more frequently updated manifest with newer versions of things more often. 
#   The manifest is hosted by default at: 
#       https://aka.ms/dotnet-maui-check-manifest-dev
maui-check \
    --fix \
    --non-interactive \
    --preview


dotnet new \
    nugetconfig
dotnet nuget \
    add \
    source -n maui-preview https://aka.ms/maui-preview/index.json

dotnet new --uninstall \
    Microsoft.Maui.Templates
dotnet new --install \
    Microsoft.Maui.Templates


rm -fr App1/
dotnet new maui --output App1


dotnet build \
    ./App1/App1/App1.csproj
dotnet build \
    ./App1/App1/App1.csproj \
    -t:Run \
    -f:net6.0-ios

dotnet build \
    ./App1/App1/App1.csproj \
    -t:Run \
    -f:net6.0-android
