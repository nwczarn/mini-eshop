# build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Admin.csproj", "./"]
RUN dotnet restore "Admin.csproj"

COPY . .
RUN dotnet publish "Admin.csproj" -c Release -o /app/publish

# runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Admin.dll"]