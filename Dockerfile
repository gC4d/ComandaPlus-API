FROM mcr.microsoft.com/dotnet/aspnet:8.0-alpine AS base

RUN apk add --no-cache tzdata
ENV TZ=America/Sao_Paulo
RUN ln -snf /usr/share/zoneinfo/$TZ /etc/localtime && echo $TZ > /etc/timezone

WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY . .

RUN dotnet restore "./src/ComandaPlus-API/ComandaPlus-API.csproj"
COPY . .

#WORKDIR "/src/ComandaPlus-API"
RUN dotnet build "./src/ComandaPlus-API/ComandaPlus-API.csproj" -c ${BUILD_CONFIGURATION} -o /app/build

FROM build as publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./src/ComandaPlus-API/ComandaPlus-API.csproj" -c ${BUILD_CONFIGURATION} -o /app/publish

FROM base as final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT [ "dotnet", "ComandaPlus-API.dll" ]