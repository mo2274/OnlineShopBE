FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["OnlineSystem.Api/OnlineSystem.Api.csproj", "OnlineSystem.Api/"]
RUN dotnet restore "OnlineSystem.Api/OnlineSystem.Api.csproj"
COPY . .
WORKDIR "/src/OnlineSystem.Api"
RUN dotnet build "OnlineSystem.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OnlineSystem.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OnlineSystem.Api.dll"]
