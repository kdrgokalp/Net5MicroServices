#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["MicroService.ApiGateway/MicroService.ApiGateway.csproj", "MicroService.ApiGateway/"]
RUN dotnet restore "MicroService.ApiGateway/MicroService.ApiGateway.csproj"
COPY . .
WORKDIR "/src/MicroService.ApiGateway"
RUN dotnet build "MicroService.ApiGateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroService.ApiGateway.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroService.ApiGateway.dll"]
