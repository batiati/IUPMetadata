#!/bin/bash

REL_TYPE=Debug
BIN_DIR=bin

if ! command -v dotnet &> /dev/null
then
	echo "Fatal Error: .NET Core for Linux CLI is not installed" 1>&2
	exit 1
fi

mkdir -p "${BIN_DIR}" ../IUPforZig/src/elements

dotnet build -c ${REL_TYPE} src/IupMetadata/IupMetadata.csproj -o "${BIN_DIR}/${REL_TYPE}" \
	/property:GenerateFullPaths=true /consoleloggerparameters:NoSummary &&
LD_LIBRARY_PATH="${BIN_DIR}/libs" dotnet run -c ${REL_TYPE} --project src/IupMetadata
