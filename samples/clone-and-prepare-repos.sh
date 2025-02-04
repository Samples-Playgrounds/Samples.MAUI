#!/bin/bash


dotnet tool \
    uninstall -g \
        redth.net.maui.check
dotnet tool \
    install -g \
        redth.net.maui.check
maui-check

rm -fr  ./external-samples/
mkdir   ./external-samples/

rm -fr ./external-samples/maui/
git clone \
    --recursive \
    https://github.com/dotnet/maui.git \
    ./external-samples/maui/
rm -fr ./external-samples/maui/.git/

rm -fr ./external-samples/maui-samples/
git clone \
    --recursive \
    https://github.com/dotnet/maui-samples.git \
    ./external-samples/maui-samples/
rm -fr ./external-samples/maui-samples/.git

rm -fr ./external-samples/dotnet-podcasts/
git clone \
    --recursive \
    https://github.com/microsoft/dotnet-podcasts.git \
    ./external-samples/dotnet-podcasts/
rm -fr ./external-samples/dotnet-podcasts/.git/

rm -fr ./external-samples/MAUIFriendsListWithMVVM/
git clone \
    --recursive \
    https://github.com/jaysonragasa/MAUIFriendsListWithMVVM.git \
    ./external-samples/MAUIFriendsListWithMVVM/
rm -fr ./external-samples/dotnet-podcasts/.git/

rm -fr ./external-samples/BlazorWeather/
git clone \
    --recursive \
    https://github.com/danroth27/BlazorWeather.git \
    ./external-samples/BlazorWeather/
rm -fr ./external-samples/BlazorWeather/.git

rm -fr ./external-samples/WeatherTwentyOne/
git clone \
    --recursive \
    https://github.com/davidortinau/WeatherTwentyOne.git \
    ./external-samples/WeatherTwentyOne/
rm -fr ./external-samples/WeatherTwentyOne/.git/

rm -fr ./external-samples/jsuarezruiz--dotnet-maui-samples/
git clone \
    --recursive \
    https://github.com/jsuarezruiz/dotnet-maui-samples.git \
    ./external-samples/jsuarezruiz--dotnet-maui-samples/
rm -fr ./external-samples/jsuarezruiz--dotnet-maui-samples/.git/

rm -fr ./external-samples/beto-rodriguez--LiveCharts2-master/
git clone \
    --recursive \
    --branch master \
    https://github.com/beto-rodriguez/LiveCharts2.git \
    ./external-samples/beto-rodriguez--LiveCharts2-master/
rm -fr ./external-samples/beto-rodriguez--LiveCharts2-master/.git/

# https://github.com/beto-rodriguez/LiveCharts2
rm -fr ./external-samples/beto-rodriguez--LiveCharts2-dev/
git clone \
    --recursive \
    --branch dev \
    https://github.com/beto-rodriguez/LiveCharts2.git \
    ./external-samples/beto-rodriguez--LiveCharts2-dev/
rm -fr ./external-samples/beto-rodriguez--LiveCharts2-dev/.git/

# https://github.com/jsuarezruiz/netmaui-chat-app-challenge
# https://github.com/jsuarezruiz/netmaui-chat-app-challenge.git
# https://github.com/jsuarezruiz/netmaui-chat-app-challenge/archive/refs/heads/main.zip

# https://github.com/VladislavAntonyuk/MauiSamples.git


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

