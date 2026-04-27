# Build stage: Use the full .NET SDK image to compile the AIService application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container to /src
WORKDIR /src

# Copy the project file to leverage Docker's layer caching mechanism
# Copying just the .csproj first allows the restore layer to be cached if dependencies don't change
COPY AIService.csproj .

# Restore all NuGet package dependencies for the project
RUN dotnet restore

# Copy all source code files from the host machine to the container
COPY . .

# Compile and publish the application in Release mode for optimal performance
# -c Release: Uses release configuration with optimizations
# -o /app/publish: Specifies the output directory for published files
RUN dotnet publish -c Release -o /app/publish

# Runtime stage: Use the lightweight ASP.NET Core runtime image (no SDK tools)
# This creates a smaller final image since build tools aren't needed at runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Set the working directory for the runtime application
WORKDIR /app

# Copy the published application binaries from the build stage
COPY --from=build /app/publish .

# Copy the specs directory from the build stage (likely contains API specifications or config)
COPY --from=build /src/specs ./specs

# Expose port 8090 to allow external access to the AIService
# This documents which port the service listens on (must match the application's configuration)
EXPOSE 8090

# Define the startup command for the container
# When the container starts, it will run the AIService.dll using the dotnet runtime
ENTRYPOINT ["dotnet", "AIService.dll"]