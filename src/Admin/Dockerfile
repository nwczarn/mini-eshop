# Build stage: Use the full .NET SDK image to compile and build the application
# This stage pulls the official .NET 8.0 SDK image from Microsoft Container Registry
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container to /src
WORKDIR /src

# Copy only the project file first to leverage Docker layer caching
# This allows Docker to cache the restore step if dependencies haven't changed
COPY ["Admin.csproj", "./"]

# Restore NuGet packages defined in the project file
# This downloads all dependencies needed to build the project
RUN dotnet restore "Admin.csproj"

# Copy all remaining source code files from the host to the container
COPY . .

# Publish the application in Release configuration
# -c Release: Builds with optimizations enabled
# -o /app/publish: Outputs the compiled files to /app/publish directory
RUN dotnet publish "Admin.csproj" -c Release -o /app/publish

# Runtime stage: Use a smaller runtime-only image for the final container
# This multi-stage approach keeps the final image size smaller by excluding build tools
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base

# Set the working directory for the runtime container
WORKDIR /app

# Copy the published application from the build stage
# --from=build: Specifies to copy from the previous "build" stage
COPY --from=build /app/publish .

# Define the command to run when the container starts
# This executes the compiled Admin.dll using the dotnet runtime
ENTRYPOINT ["dotnet", "Admin.dll"]