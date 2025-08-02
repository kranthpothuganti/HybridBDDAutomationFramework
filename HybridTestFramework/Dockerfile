# escape=`
FROM mcr.microsoft.com/dotnet/sdk:9.0-preview-nanoserver-ltsc2022

WORKDIR /app

# Copy all content into container
COPY . .

# Restore dependencies
RUN dotnet restore HybridTestFramework.sln

# Build solution
RUN dotnet build HybridTestFramework.sln --no-restore

# Make script executable (Windows)
SHELL ["cmd", "/S", "/C"]
RUN powershell -Command "Set-ExecutionPolicy Bypass -Scope Process -Force"

# Use PowerShell to run tests (entrypoint will be overwritten by docker-compose)
CMD ["powershell.exe", "-File", ".\\run-tests.ps1"]
