#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
RUN apt-get update && apt-get upgrade -y && \
    apt-get install -y nodejs \
    npm   
    
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

RUN apt-get update && apt-get upgrade -y && \
    apt-get install -y nodejs \
    npm   

WORKDIR /src
COPY ["SurveyApp/SurveyApp.csproj", "SurveyApp/"]
RUN dotnet restore "SurveyApp/SurveyApp.csproj"
COPY . .
WORKDIR "/src/SurveyApp"
RUN dotnet build "SurveyApp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SurveyApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SurveyApp.dll"]