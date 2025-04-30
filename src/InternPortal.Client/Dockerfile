FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build-env
WORKDIR /app

COPY . ./
RUN dotnet publish ./src/InternPortal.Client/InternPortal.Client.csproj -c Release -o output

FROM nginx:alpine
WORKDIR /usr/share/nginx/html
COPY --from=build-env /app/output/wwwroot .

COPY ./src/InternPortal.Client/nginx.conf /etc/nginx/nginx.conf

EXPOSE 80