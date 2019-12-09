#Depending on the operating system of the host machines(s) that will build or run the containers, the image specified in the FROM statement may need to be changed.
#For more information, please see https://aka.ms/containercompat

FROM microsoft/dotnet:2.1-aspnetcore-runtime-nanoserver-1803 AS base
WORKDIR /app
EXPOSE 50898
EXPOSE 44326

FROM microsoft/dotnet:2.1-sdk-nanoserver-1803 AS build
WORKDIR /src
COPY ["GeolocationAPI/GeolocationAPI.csproj", "GeolocationAPI/"]
RUN dotnet restore "GeolocationAPI/GeolocationAPI.csproj"
COPY . .
WORKDIR "/src/GeolocationAPI"
RUN dotnet build "GeolocationAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "GeolocationAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "GeolocationAPI.dll"]