# HybridTestFramework/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview AS test-runner

WORKDIR /app
COPY . .

RUN dotnet tool restore
RUN dotnet build HybridTestFramework.sln

RUN chmod +x run-tests.sh

ENTRYPOINT ["sh", "./run-tests.sh"]
