#!/bin/bash

find \
    ./source/ \
    -type f \
    -name "*.sln" \
    -exec msbuild \
        {} \;

find \
    ./source/ \
    -type f \
    -name "*.csproj" \
    -exec msbuild \
        {} \;
