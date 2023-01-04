#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-focal AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-focal AS build
WORKDIR /src
COPY ["MicroService.Products/MicroService.Products.csproj", "MicroService.Products/"]
RUN dotnet restore "MicroService.Products/MicroService.Products.csproj"
COPY . .
WORKDIR "/src/MicroService.Products"
RUN dotnet build "MicroService.Products.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MicroService.Products.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MicroService.Products.dll"]
