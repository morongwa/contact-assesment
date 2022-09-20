# syntax=docker/dockerfile:1
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
COPY . /app
WORKDIR /app
RUN chmod +x entrypoint.sh
EXPOSE 80/tcp
# RUN dotnet restore
RUN dotnet publish -c Release -o publish

# FROM mcr.microsoft.com/dotnet/aspnet:6.0
# COPY --from=build-env /app/publish .

WORKDIR /app
COPY entrypoint.sh .
RUN chmod +x entrypoint.sh
CMD /bin/bash entrypoint.sh

