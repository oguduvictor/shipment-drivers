FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Protium.Digital.API/Protium.Digital.API.csproj", "Protium.Digital.API/"]
RUN dotnet restore "Protium.Digital.API/Protium.Digital.API.csproj"
COPY . .
WORKDIR "/src/Protium.Digital.API"
RUN dotnet build "Protium.Digital.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Protium.Digital.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Protium.Digital.API.dll"]
