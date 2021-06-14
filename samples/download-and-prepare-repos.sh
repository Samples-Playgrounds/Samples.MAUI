#!/bin/bash


dotnet tool uninstall -g \
    redth.net.maui.check
dotnet tool install -g \
    redth.net.maui.check
maui-check

rm -fr maui/
curl -O -J -L \
    https://github.com/dotnet/maui/archive/refs/heads/main.zip
unzip maui-main.zip
mv maui-main/ maui/
rm -fr maui-main.zip

rm -fr maui-samples/
curl -O -J -L \
    https://github.com/dotnet/maui-samples/archive/refs/heads/main.zip
unzip maui-samples-main.zip
mv maui-samples-main/ maui-samples/
rm -fr maui-samples-main.zip

rm -fr MAUIFriendsListWithMVVM/
curl -O -J -L \
    https://github.com/jaysonragasa/MAUIFriendsListWithMVVM/archive/refs/heads/main.zip
unzip MAUIFriendsListWithMVVM-main.zip
mv MAUIFriendsListWithMVVM-main/ MAUIFriendsListWithMVVM/
rm -fr MAUIFriendsListWithMVVM-main.zip


rm -fr BlazorWeather/
curl -O -J -L \
    https://github.com/danroth27/BlazorWeather/archive/refs/heads/main.zip
unzip BlazorWeather-main.zip
mv BlazorWeather-main/ BlazorWeather/
rm -fr BlazorWeather-main.zip


rm -fr WeatherTwentyOne/
curl -O -J -L \
    https://github.com/davidortinau/WeatherTwentyOne/archive/refs/heads/main.zip
unzip WeatherTwentyOne-main.zip
mv WeatherTwentyOne-main/ WeatherTwentyOne/
rm -fr WeatherTwentyOne-main.zip

cd WeatherTwentyOne/src/

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


cd BlazorWeather/
dotnet build \
    BlazorWeather.Maui \
    -t:Run \
    -f net6.0-android
dotnet build \
    BlazorWeather.Maui \
    -t:Run \
    -f net6.0-ios