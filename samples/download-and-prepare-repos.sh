#!/bin/bash


# https://github.com/Redth/dotnet-maui-check
dotnet tool uninstall -g \
    redth.net.maui.check
dotnet tool install -g \
    redth.net.maui.check
maui-check \
    --preview \
    --fix \
    --non-interactive


#------------------------------------------------------------------------------------------------------
rm -fr maui/
curl -O -J -L \
    https://github.com/dotnet/maui/archive/refs/heads/main.zip
unzip maui-main.zip
mv maui-main/ maui/
rm -fr maui-main.zip
#------------------------------------------------------------------------------------------------------

#------------------------------------------------------------------------------------------------------
rm -fr maui-samples/
curl -O -J -L \
    https://github.com/dotnet/maui-samples/archive/refs/heads/main.zip
unzip maui-samples-main.zip
mv maui-samples-main/ maui-samples/
rm -fr maui-samples-main.zip

maui-samples/

# FSC : error FS0246:
# Unrecognized value '9.0' for --langversion use --langversion:? for complete list
# [./fsharp/HelloiOSFSharp/HelloiOSFSharp.fsproj]
dotnet sln \
    remove \
    ./fsharp/HelloiOSFSharp/HelloiOSFSharp.fsproj

dotnet build \
    net6-samples.sln

# Works, but
# /usr/local/share/dotnet/packs/Microsoft.iOS.Sdk/14.5.100-preview.5.894/tools/msbuild/iOS/Xamarin.Shared.targets(759,3):
# error : Info.plist not found.
# [./maui-samples/HelloAndroid/HelloAndroid.csproj]
dotnet build \
    net6-samples.sln \
    -t:Run \
    -f:net6.0-ios

dotnet build \
    ./HelloiOS/HelloiOS.csproj \
    -t:Run \
    -f:net6.0-ios

# Works, but
# /usr/local/share/dotnet/sdk/6.0.100-preview.5.21302.13/Sdks/Microsoft.NET.Sdk/targets/Microsoft.PackageDependencyResolution.targets(246,5):
# error NETSDK1005:
#   Assets file
#           './maui-samples/HelloiOS/obj/project.assets.json'
#   doesn't have a target for 'net6.0-android'.
# Ensure that restore has run and that you have included 'net6.0-android' in the TargetFrameworks for your project.
# [./maui-samples/HelloiOS/HelloiOS.csproj]
dotnet build \
    net6-samples.sln \
    -t:Run \
    -f:net6.0-android

#------------------------------------------------------------------------------------------------------

#------------------------------------------------------------------------------------------------------
rm -fr WeatherTwentyOne/
curl -O -J -L \
    https://github.com/davidortinau/WeatherTwentyOne/archive/refs/heads/main.zip
unzip WeatherTwentyOne-main.zip
mv WeatherTwentyOne-main/ WeatherTwentyOne/
rm -fr WeatherTwentyOne-main.zip

cd WeatherTwentyOne/src/

dotnet sln \
    remove \
    ./WeatherTwentyOne.WinUI/WeatherTwentyOne.WinUI.csproj

dotnet build \
    ./WeatherTwentyOne.sln

dotnet build \
    ./WeatherTwentyOne/WeatherTwentyOne.csproj

dotnet build \
    ./WeatherTwentyOne/WeatherTwentyOne.csproj \
    -t:Run \
    -f:net6.0-ios

dotnet build \
    ./WeatherTwentyOne/WeatherTwentyOne.csproj \
    -t:Run \
    -f:net6.0-android



dotnet new classlib \
    --framework netstandard2.0 \
    --output WeatherTwentyOne.DomainBusinessLogic

dotnet sln \
    WeatherTwentyOne.sln \
    list

dotnet sln \
    WeatherTwentyOne.sln \
    add \
    WeatherTwentyOne.DomainBusinessLogic/WeatherTwentyOne.DomainBusinessLogic.csproj \
    --solution-folder DomainBusinessLogic \

#------------------------------------------------------------------------------------------------------




#------------------------------------------------------------------------------------------------------
rm -fr MAUIFriendsListWithMVVM/
curl -O -J -L \
    https://github.com/jaysonragasa/MAUIFriendsListWithMVVM/archive/refs/heads/main.zip
unzip MAUIFriendsListWithMVVM-main.zip
mv MAUIFriendsListWithMVVM-main/ MAUIFriendsListWithMVVM/
rm -fr MAUIFriendsListWithMVVM-main.zip

#------------------------------------------------------------------------------------------------------




#------------------------------------------------------------------------------------------------------
rm -fr BlazorWeather/
curl -O -J -L \
    https://github.com/danroth27/BlazorWeather/archive/refs/heads/main.zip
unzip BlazorWeather-main.zip
mv BlazorWeather-main/ BlazorWeather/
rm -fr BlazorWeather-main.zip

cd BlazorWeather/

dotnet build \
    BlazorWeather.Maui \
    -t:Run \
    -f net6.0-ios

cd BlazorWeather/
dotnet build \
    BlazorWeather.Maui \
    -t:Run \
    -f net6.0-android

#------------------------------------------------------------------------------------------------------

#------------------------------------------------------------------------------------------------------
mkdir source
cd sorce
mkdir business-domain-logic
mkdir user-interface
cd business-domain-logic
dotnet new classlib -o HolisticWare.DomainBusinessLogic
cd ../user-interface
dotnet new classlib -o HolisticWare.DomainBusinessLogic.UI.MAUI


dotnet sln \
    source.sln \
    add \
    --solution-folder business-domain-logic/ \
    business-domain-logic/HolisticWare.DomainBusinessLogic/HolisticWare.DomainBusinessLogic.csproj

dotnet sln \
    source.sln \
    add \
    --solution-folder user-interface/ \
    user-interface/HolisticWare.DomainBusinessLogic.UI.MAUI/HolisticWare.DomainBusinessLogic.UI.MAUI.csproj
#------------------------------------------------------------------------------------------------------








#------------------------------------------------------------------------------------------------------
#     https://github.com/alexkblount/HackerNews/tree/maui-migration.zip
rm -fr HackerNews-alexkblount/
curl -O -J -L \
    https://github.com/alexkblount/HackerNews/archive/refs/heads/maui-migration.zip

unzip HackerNews-maui-migration.zip
mv HackerNews-maui-migration/ HackerNews-alexkblount/
rm -fr HackerNews-maui-migration.zip

cd HackerNews-alexkblount/

dotnet build \
    HackerNews-alexkblount/HackerNews.sln

dotnet build \
    HackerNews-alexkblount/HackerNews.sln \
    -t:Run \
    -f net6.0-ios
#------------------------------------------------------------------------------------------------------


#------------------------------------------------------------------------------------------------------
#   https://github.com/Cheesebaron/HackerNews-Maui
rm -fr HackerNews-Cheesebaron/
curl -O -J -L \
    https://github.com/Cheesebaron/HackerNews-Maui/archive/refs/heads/main.zip

unzip HackerNews-Maui-main.zip
mv HackerNews-Maui-main/ HackerNews-Cheesebaron/
rm -fr HackerNews-main.zip

cd HackerNews-Cheesebaron/

dotnet build \
    ./HackerNews-Maui/HackerNews-Maui.csproj \

dotnet build \
    ./HackerNews-Maui/HackerNews-Maui.csproj \
    -t:Run \
    -f net6.0-ios

#------------------------------------------------------------------------------------------------------

#------------------------------------------------------------------------------------------------------
#   https://github.com/brminnick/HackerNews

rm -fr HackerNews-brminnick/
curl -O -J -L \
    https://github.com/brminnick/HackerNews/archive/refs/heads/main.zip

unzip main.zip
mv main/ HackerNews-brminnick/

#------------------------------------------------------------------------------------------------------

export FILE=main.zip
export FILE_REMOTE_NAME=MauiSamples-main.zip
export FILENAME="${FILE%.*}"
export URL=https://github.com/VladislavAntonyuk/MauiSamples/archive/refs/heads/$FILE
export FOLDER=VladislavAntonyuk-MauiSamples/
echo "FILE      = " $FILE
echo "FILENAME  = " $FILENAME
echo "URL       = " $URL
echo "FOLDER    = " $FOLDER

rm -fr                          $FOLDER
curl \
    -O -J -L \
                                $URL
unzip                           $FILE_REMOTE_NAME
mv "${FILE_REMOTE_NAME%.*}"     $FOLDER



#------------------------------------------------------------------------------------------------------
#------------------------------------------------------------------------------------------------------



