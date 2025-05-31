#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["EAAppTest/EAAppTest.csproj", "EAAppTest/"]
RUN dotnet restore "EAAppTest/EAAppTest.csproj"
COPY . .
WORKDIR "/src/EAAppTest"
RUN dotnet build "EAAppTest.csproj" -c Release -o /app/build

FROM build AS Test
WORKDIR "/src/EAAppTest"
CMD ["dotnet", "test"]