FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY "ConfigMapsAndSecret.csproj" .
RUN dotnet restore "ConfigMapsAndSecret.csproj"
COPY . .
RUN dotnet build "ConfigMapsAndSecret.csproj" -c Release -o /app/build
RUN dotnet publish "ConfigMapsAndSecret.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
EXPOSE 8080
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "ConfigMapsAndSecret.dll"]
