FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Inmovest.API/Inmovest.API.csproj", "Inmovest.API/"]
RUN dotnet restore "Inmovest.API/Inmovest.API.csproj"
COPY . .
WORKDIR "/src/Inmovest.API"
RUN dotnet build "Inmovest.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Inmovest.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Inmovest.API.dll"]
