FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY "JobsDemoConsole.csproj" .
RUN dotnet restore "JobsDemoConsole.csproj"
COPY . .
RUN dotnet build "JobsDemoConsole.csproj" -c Release -o /app/build
RUN dotnet publish "JobsDemoConsole.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
EXPOSE 8080
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "JobsDemoConsole.dll"]
