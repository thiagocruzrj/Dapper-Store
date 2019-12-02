FROM mcr.microsoft.com/dotnet/core/aspnet:3.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.0 AS build
WORKDIR /src
COPY ["DapperStore.Api/DapperStore.Api.csproj", "DapperStore.Api/"]
RUN dotnet restore "DapperStore.Api/DapperStore.Api.csproj"
COPY . .
WORKDIR "/src/DapperStore.Api"
RUN dotnet build "DapperStore.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DapperStore.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DapperStore.Api.dll"]
