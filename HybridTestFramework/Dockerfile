# HybridTestFramework/Dockerfile
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS test-runner

WORKDIR /app
COPY . .

RUN dotnet tool restore
RUN dotnet build HybridTestFramework.sln

RUN chmod +x HybridTestFramework/run-tests.sh

ENTRYPOINT ["sh", "./run-tests.sh"]
