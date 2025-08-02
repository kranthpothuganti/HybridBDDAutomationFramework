#!/bin/bash
set -e

TAG=$1
REPORT_PATH="./LivingDocReports/${TAG}"

mkdir -p $REPORT_PATH

dotnet test WebTests/WebTests.csproj \
  --filter TestCategory=$TAG \
  --logger "console;verbosity=normal"

dotnet livingdoc export \
  -t TestExecution.json \
  -o $REPORT_PATH