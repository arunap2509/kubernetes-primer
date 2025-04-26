FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src
COPY "PodDeployments.csproj" .
RUN dotnet restore "PodDeployments.csproj"
COPY . .
RUN dotnet build "PodDeployments.csproj" -c Release -o /app/build
RUN dotnet publish "PodDeployments.csproj" -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:9.0
EXPOSE 8080
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "PodDeployments.dll"]