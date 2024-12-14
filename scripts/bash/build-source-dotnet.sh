#!/bin/bash

export PATTERNS=\
"
*.sln
*.csproj
"

export COMMANDS=\
"
build
msbuild
"

export CONFIGURATIONS=\
"
Release
Debug
"


function dotnet_function()
{
    echo "==========================================================================="
    echo "command = $1"
    echo "configuration = $2"
    echo "file = $3"


    dotnet build --configuration $1 $2
}

export -f dotnet_function
unset -f dotnet_function
unset -f dotnet
unset -f dotnet_build

for PATTERN in $PATTERNS; 
do
    for CONFIGURATION in $CONFIGURATIONS;
    do
        for COMMAND in $COMMANDS;
        do
            for FILE in $(find ./source/ -type f -name $PATTERN) ;
            do
                echo " file = $FILE"
                echo "      command = $COMMAND"
                case $COMMAND in
                    build)
                        if grep -q "Project\ Sdk=\"Microsoft\.NET\.Sdk\"" "$FILE" ;
                        then
                            echo "   .NET Standard SDK Style Project"
                            dotnet build --configuration $CONFIGURATION $FILE
                        fi
                        if grep -q "Project\ Sdk=\"MSBuild\.Sdk\.Extras" "$FILE" ; 
                        then
                            echo "   .NET Standard SDK Style Project (SDK Extras - Xamarin)"
                            dotnet build --configuration $CONFIGURATION $FILE
                        fi
                        ;;
                    msbuild)
                        if grep -q "Project\ Sdk=\"Microsoft\.NET\.Sdk\"" "$FILE" ;
                        then
                            echo "   .NET Standard SDK Style Project"
                            dotnet msbuild /p:buildmode=$CONFIGURATION $FILE
                        fi
                        if grep -q "Project\ Sdk=\"MSBuild\.Sdk\.Extras" "$FILE" ; 
                        then
                            echo "   .NET Standard SDK Style Project (SDK Extras - Xamarin)"
                            dotnet msbuild --configuration $CONFIGURATION $FILE
                        fi
                        ;;
                    *)
                        Message="Wrong dotnet command"
                        ;;
                esac
            done
        done
    done
done
