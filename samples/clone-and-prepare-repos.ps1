#!/usr/bin/env pwsh


dotnet tool `
    uninstall -g `
        redth.net.maui.check
dotnet tool `
    install -g `
        redth.net.maui.check
maui-check

rm -fr maui/
git clone `
    --recursive `
    https://github.com/dotnet/maui.git

rm -fr maui-samples/
git clone `
    --recursive `
    https://github.com/dotnet/maui-samples.git


rm -fr dotnet-podcasts/
git clone `
    --recursive `
    https://github.com/microsoft/dotnet-podcasts.git

rm -fr BlazorWeather/
git clone \
    --recursive \
    https://github.com/danroth27/BlazorWeather.git

rm -fr MAUIFriendsListWithMVVM/
git clone \
    --recursive \
    https://github.com/jaysonragasa/MAUIFriendsListWithMVVM.git

rm -fr WeatherTwentyOne/
git clone `
    --recursive `
    https://github.com/davidortinau/WeatherTwentyOne.git

rm -fr jsuarezruiz--dotnet-maui-samples/
git clone \
    --recursive \
    https://github.com/jsuarezruiz/dotnet-maui-samples.git \
    jsuarezruiz--dotnet-maui-samples/ 

rm -fr beto-rodriguez--LiveCharts2-*/
git clone \
    --recursive \
    --branch maui \
    https://github.com/beto-rodriguez/LiveCharts2.git \
    beto-rodriguez--LiveCharts2-maui/

git clone \
    --recursive \
    --branch blazor-wasm \
    https://github.com/beto-rodriguez/LiveCharts2.git \
    beto-rodriguez--LiveCharts2-blazor-wasm/

cd WeatherTwentyOne/src/

dotnet new classlib `
    --framework netstandard2.0 `
    --output WeatherTwentyOne.DomainBusinessLogic

dotnet sln `
    WeatherTwentyOne.sln `
    list

dotnet sln `
    WeatherTwentyOne.sln `
    add `
    WeatherTwentyOne.DomainBusinessLogic/WeatherTwentyOne.DomainBusinessLogic.csproj `
    --solution-folder DomainBusinessLogic `


