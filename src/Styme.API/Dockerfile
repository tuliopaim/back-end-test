#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/Styme.API/Styme.API.csproj", "src/Styme.API/"]
COPY ["src/Styme.Domain/Styme.Domain.csproj", "src/Styme.Domain/"]
COPY ["src/Styme.Service/Styme.Service.csproj", "src/Styme.Service/"]
COPY ["src/Styme.Data/Styme.Data.csproj", "src/Styme.Data/"]
RUN dotnet restore "src/Styme.API/Styme.API.csproj"
COPY . .
WORKDIR "/src/src/Styme.API"
RUN dotnet build "Styme.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Styme.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Styme.API.dll"]