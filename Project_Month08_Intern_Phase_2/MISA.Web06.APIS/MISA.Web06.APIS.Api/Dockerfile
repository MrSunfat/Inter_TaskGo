#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["MISA.Web06.APIS.Api/MISA.Web06.APIS.Api.csproj", "MISA.Web06.APIS.Api/"]
COPY ["MISA.Web06.APIS.Core/MISA.Web06.APIS.Core.csproj", "MISA.Web06.APIS.Core/"]
COPY ["MISA.Web06.APIS.Infrastructure/MISA.Web06.APIS.Infrastructure.csproj", "MISA.Web06.APIS.Infrastructure/"]
RUN dotnet restore "MISA.Web06.APIS.Api/MISA.Web06.APIS.Api.csproj"
COPY . .
WORKDIR "/src/MISA.Web06.APIS.Api"
RUN dotnet build "MISA.Web06.APIS.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MISA.Web06.APIS.Api.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MISA.Web06.APIS.Api.dll"]