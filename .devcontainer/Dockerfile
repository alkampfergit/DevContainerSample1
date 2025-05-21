# Use the official .NET 6 SDK image (C# 9 is supported in .NET 5+, but .NET 6 is LTS)
FROM mcr.microsoft.com/dotnet/sdk:6.0

# Install any additional dependencies if needed
RUN apt-get update && apt-get install -y \
    curl \
    gnupg \
    && rm -rf /var/lib/apt/lists/*

# Set up a non-root user (VS Code default)
ARG USERNAME=vscode
ARG USER_UID=1000
ARG USER_GID=$USER_UID
RUN groupadd --gid $USER_GID $USERNAME \
    && useradd --uid $USER_UID --gid $USER_GID -m $USERNAME \
    && apt-get clean -y && rm -rf /var/lib/apt/lists/*

USER $USERNAME
WORKDIR /workspace
