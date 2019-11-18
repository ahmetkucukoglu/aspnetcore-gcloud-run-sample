FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["CloudRunSampleAPI/CloudRunSampleAPI.csproj", "CloudRunSampleAPI/"]
RUN dotnet restore "CloudRunSampleAPI/CloudRunSampleAPI.csproj"
COPY . .
WORKDIR "/src/CloudRunSampleAPI"
RUN dotnet build "CloudRunSampleAPI.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CloudRunSampleAPI.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CloudRunSampleAPI.dll"]