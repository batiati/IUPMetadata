#!/usr/bin/env bash

REL_TYPE=Debug
SRC_DIR=$(dirname -- "$(readlink -f -- "$BASH_SOURCE")")
BIN_DIR=bin/${REL_TYPE}
PROJECT=IupMetadata

if ! command -v dotnet &> /dev/null
then
	echo "Fatal Error: .NET Core for Linux CLI is not installed" 1>&2
	exit 1
fi

pushd "${SRC_DIR}" && \
mkdir -p ../../IUPforZig/src/elements && \
dotnet build -c ${REL_TYPE} ${PROJECT}/${PROJECT}.csproj -o ${PROJECT}/${BIN_DIR} && \
export LD_LIBRARY_PATH=${PROJECT}/${BIN_DIR}/libs && \
dotnet run -c ${REL_TYPE} --project ${PROJECT} && \
popd
