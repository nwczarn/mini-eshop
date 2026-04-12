# build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

COPY ["Storefront.csproj", "./"]
RUN dotnet restore "Storefront.csproj"

COPY . .
RUN dotnet publish "Storefront.csproj" -c Release -o /app/publish

# runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app

COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Storefront.dll"]