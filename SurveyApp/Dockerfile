#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
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
RUN dotnet build "SurveyApp.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "SurveyApp.csproj" -c Release -o /app

##############################
#Angular build
FROM node as nodebuilder

# set working directory
RUN mkdir /usr/src/app
WORKDIR /usr/src/app

# add `/usr/src/app/node_modules/.bin` to $PATH
ENV PATH /usr/src/app/node_modules/.bin:$PATH


# install and cache app dependencies
COPY SurveyApp/ClientApp/package.json /usr/src/app/package.json
RUN npm install
RUN npm install -g @angular/cli@1.7.0 --unsafe

# add app
COPY SurveyApp/ClientApp/. /usr/src/app

RUN npm run build

#End Angular build
###############################

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

RUN mkdir -p /app/ClientApp/dist
COPY --from=nodebuilder /usr/src/app/dist/. /app/ClientApp/dist/

ENTRYPOINT ["dotnet", "SurveyApp.dll"]