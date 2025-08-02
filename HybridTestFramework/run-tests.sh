#!/bin/bash

# Accept input arg or fallback to env var FEATURE_TAG
TAG=${1:-$FEATURE_TAG}

if [ -z "$TAG" ]; then
  echo "ERROR: Test tag not provided. Set as argument or environment variable FEATURE_TAG."
  exit 1
fi

REPORT_DIR="reports/$TAG"
mkdir -p "$REPORT_DIR"

# Start virtual display for Chrome
Xvfb :99 -screen 0 1920x1080x24 & export DISPLAY=:99

# Run the tests by tag
dotnet test HybridTestFramework.sln \
    --filter Category=$TAG \
    --logger:"trx;LogFileName=${TAG}_results.trx" \
    --results-directory "$REPORT_DIR" \
    --no-build

# Generate LivingDoc
livingdoc test-assembly \
    WebTests/bin/Debug/net9.0/WebTests.dll \
    -t WebTests/bin/Debug/net9.0/TestExecution.json \
    -o "$REPORT_DIR/LivingDoc.html"
