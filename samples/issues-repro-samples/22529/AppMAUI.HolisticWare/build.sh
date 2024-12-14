#!/bin/bash

export TFMS=\
"
net7.0
net8.0
multi-target
"

export CONFIGS=\
"
Debug
Release
"

export PROJECTS=\
"
ProjectsStructureTemplate.AppMAUI.DemoSample/ProjectsStructureTemplate.AppMAUI.DemoSample.csproj
"

IFS=$'\n'
# ZSH does not split words by default (like other shells):
setopt sh_word_split

for TFM in $TFMS
do
    if [[ $TFM == "#"* ]]
    then
        continue
    fi

    for CONFIG in $CONFIGS
    do

        for PROJECT in $PROJECTS
        do

            echo "Target Framework Moniker - TFM : $TFM"
            echo \
            "
            -------------------------------------------------------------------------------------------------------------------
            "
            echo \
            "
            dotnet \
                build \
                --configuration $CONFIG \
                    $TFM/$PROJECT
            "
            dotnet \
                build \
                --configuration $CONFIG \
                    $TFM/$PROJECT
        done
    done
done
