#!/bin/bash

TAG=$1
REPORT_DIR="reports/$TAG"
mkdir -p "$REPORT_DIR"

# Start virtual display for Chrome
Xvfb :99 -screen 0 1920x1080x24 & export DISPLAY=:99

# Run the tests by tag
dotnet test HybridTestFramework.sln \
    --filter TestCategory=$TAG \
    --logger:"trx;LogFileName=${TAG}_results.trx" \
    --results-directory "$REPORT_DIR" \
    --no-build

# Generate LivingDoc
dotnet livingdoc test-assembly \
    WebTests/bin/Debug/net9.0/WebTests.dll \
    -t TestExecution.json \
    -o "$REPORT_DIR/LivingDoc.html"
