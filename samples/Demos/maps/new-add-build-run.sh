#!/bin/bash


dotnet add \
    App.Maps/App.Maps.csproj \
    package \
        Microsoft.Maui.Controls.Maps

dotnet add \
    App.Maps/App.Maps.csproj \
    package \
        Microsoft.Maui.Maps


dotnet build \
    App.Maps/App.Maps.csproj \
    
    -f net6-android

dotnet build \
    App.Maps/App.Maps.csproj \
    -t:Run \
    -f net6.0-android

dotnet build \
    App.Maps/App.Maps.csproj \
    -t:Run \
    -f net6.0-maccatalyst

dotnet build \
    --project App.Maps/App.Maps.csproj \
    -t:Run \
    -f net6.0-maccatalyst