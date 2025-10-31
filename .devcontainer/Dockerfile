# Use a robust .NET SDK image with Debian, which is often used in Dev Containers
# We'll use the latest available .NET 8 or 9 SDK image (adjust if newer version is required)
# This includes the necessary .NET runtime and tools.
ARG VARIANT=9.0-bookworm
FROM mcr.microsoft.com/devcontainers/dotnet:${VARIANT}

# Install Docker-in-Docker (dind) feature dependencies. Aspire relies on a container runtime
# to launch services like PostgreSQL or Redis, or even your own services.
# The 'docker-in-docker' feature is critical for Aspire orchestration inside the Codespace.
RUN apt-get update && export DEBIAN_FRONTEND=noninteractive \
    && apt-get -y install --no-install-recommends \
    liblttng-ust0 \
    libgssapi-krb5-2 \
    zlib1g \
    && apt-get clean \
    && rm -rf /var/lib/apt/lists/*

