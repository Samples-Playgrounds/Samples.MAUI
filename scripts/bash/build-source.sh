#!/bin/bash

# child bash proces
__dir="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
bash ${__dir}/build-source-dotnet.sh
bash ${__dir}/build-source-msbuild.sh

# same bash proces
__dir="$(cd "$(dirname "${BASH_SOURCE[0]}")" && pwd)"
source ${__dir}/build-source-dotnet.sh
source ${__dir}/build-source-msbuild.sh
