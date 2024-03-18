#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
#https://www.textcontrol.com/blog/2023/09/23/deploying-an-aspnet-core-web-app-with-docker/

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8091	#http port. The ports number should be between 8000 and 9000
EXPOSE 8445 #https port

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY . GkPosApp/
RUN dotnet restore "GkPosApp/GkPosApp.csproj"
COPY . .
WORKDIR "/src/GkPosApp"
RUN dotnet build "GkPosApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GkPosApp.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GkPosApp.dll"]