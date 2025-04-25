FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS base

WORKDIR /app
EXPOSE 80

ENV ASPNETCORE_URLS=http://+:80;

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build

COPY ["src/", "/src/"]

WORKDIR /src/InternPortal.API
RUN dotnet restore "InternPortal.API.csproj" && \
    dotnet publish "InternPortal.API.csproj" --no-restore -c Release -o /app/publish

FROM base AS final
COPY --from=build /app/publish .
USER 1000
ENTRYPOINT ["dotnet", "InternPortal.API.dll"]