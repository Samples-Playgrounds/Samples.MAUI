#!/bin/bash


dotnet tool uninstall -g \
    redth.net.maui.check
dotnet tool install -g \
    redth.net.maui.check
maui-check

rm -fr maui/
git clone \
    --recursive \
    https://github.com/dotnet/maui.git

rm -fr maui-samples/
git clone \
    --recursive \
    https://github.com/dotnet/maui-samples.git

rm -fr MAUIFriendsListWithMVVM/
git clone \
    --recursive \
    https://github.com/jaysonragasa/MAUIFriendsListWithMVVM.git


rm -fr BlazorWeather/
git clone \
    --recursive \
    https://github.com/danroth27/BlazorWeather.git

rm -fr WeatherTwentyOne/
git clone \
    --recursive \
    https://github.com/davidortinau/WeatherTwentyOne.git

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

