# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:9.0

# Install required dependencies for Chrome and Xvfb
RUN apt-get update && \
    apt-get install -y wget gnupg unzip curl xvfb libxi6 libgconf-2-4 libnss3 libxss1 libappindicator1 libindicator7 fonts-liberation libatk-bridge2.0-0 libgtk-3-0 libgbm-dev && \
    rm -rf /var/lib/apt/lists/*

# Install Chrome
RUN wget https://dl.google.com/linux/direct/google-chrome-stable_current_amd64.deb && \
    apt-get install -y ./google-chrome-stable_current_amd64.deb && \
    rm google-chrome-stable_current_amd64.deb

# Set working directory
WORKDIR /app

# Copy everything from current directory
COPY . .

# Restore and build
RUN dotnet restore HybridTestFramework.sln
RUN dotnet build HybridTestFramework.sln

# Make script executable
RUN chmod +x ./HybridTestFramework/run-tests.sh

ENTRYPOINT ["sh", "./HybridTestFramework/run-tests.sh"]
