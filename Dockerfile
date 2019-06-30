#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see http://aka.ms/containercompat 

FROM mcr.microsoft.com/dotnet/core/aspnet:2.1-nanoserver-1809 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.1-nanoserver-1809 AS build
WORKDIR /src
COPY ["WebApi.sln", "/"]
COPY ["WebApi/WebApi.csproj", "WebApi/"]
COPY ["WebApi.BusinessLayer/WebApi.BusinessLayer.csproj", "WebApi.BusinessLayer/"]
COPY ["WebApi.DataAccessLayer/WebApi.DataAccessLayer.csproj", "WebApi.DataAccessLayer/"]
RUN dotnet restore "WebApi/WebApi.csproj"
COPY . .
WORKDIR "/src/WebApi"
RUN dotnet build "WebApi.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "WebApi.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "WebApi.dll"]


#FROM mcr.microsoft.com/dotnet/core/sdk:2.1 AS build-env
#WORKDIR /app
#
## Copy csproj and restore as distinct layers
#COPY WebApi.sln ./
#COPY WebApi/WebApi.csproj ./
#COPY WebApi.BusinessLayer/WebApi.BusinessLayer.csproj ./
#COPY WebApi.DataAccessLayer/WebApi.DataAccessLayer.csproj ./
#RUN dotnet restore
#
## Copy everything else and build
#COPY . ./
#RUN dotnet publish -c Release -o out
#
## Build runtime image
#FROM mcr.microsoft.com/dotnet/core/aspnet:2.1
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "webapi.dll"]