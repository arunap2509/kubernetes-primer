FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY "MainApi.csproj" .
RUN dotnet restore "MainApi.csproj"
COPY . .
RUN dotnet build "MainApi.csproj" -c Release -o /app/build
RUN dotnet publish "MainApi.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
EXPOSE 8080
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "MainApi.dll"]