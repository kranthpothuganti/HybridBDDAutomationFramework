# Use the official .NET SDK image
FROM mcr.microsoft.com/dotnet/sdk:9.0

# Install required dependencies for Chrome and Xvfb
RUN apt-get update && \
    apt-get install -y wget gnupg unzip curl xvfb libxi6 libgconf-2-4 \
    libnss3 libxss1 libappindicator1 libayatana-indicator7 \
    fonts-liberation libatk-bridge2.0-0 libgtk-3-0 libgbm-dev && \
    rm -rf /var/lib/apt/lists/*


# Install Chrome from Google APT repo
RUN wget -q -O - https://dl.google.com/linux/linux_signing_key.pub | apt-key add - && \
    echo "deb [arch=amd64] http://dl.google.com/linux/chrome/deb/ stable main" > /etc/apt/sources.list.d/google-chrome.list && \
    apt-get update && \
    apt-get install -y google-chrome-stable \
    xvfb fonts-liberation libatk-bridge2.0-0 libgtk-3-0 libgbm-dev libnss3 libxss1 libgconf-2-4 libxi6 libappindicator1 xdg-utils libasound2 libvulkan1 && \
    rm -rf /var/lib/apt/lists/*


# Set working directory
WORKDIR /app

# Copy everything from current directory
COPY . .

# Restore and build
RUN dotnet restore HybridTestFramework.sln
RUN dotnet build HybridTestFramework.sln

# Make script executable
RUN chmod +x ./run-tests.sh

ENTRYPOINT ["sh", "./run-tests.sh"]
