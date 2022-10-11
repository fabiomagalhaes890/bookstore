FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env

# Copy everything
WORKDIR /app
COPY . ./

# Restore layers
RUN dotnet restore

#Build and publishing release
RUN dotnet publish -c Release -o out

#Build runtime image
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build-env /app/Bookstore.Webservice/out .

ENTRYPOINT ["dotnet", "Bookstore.Webservice.dll"]

#FROM mcr.microsoft.com/mssql/server:2017-latest
#ENV ACCEPT_EULA=Y
#ENV SA_PASSWORD=anm*2022basE
#ENV MSSQL_PID=Developer
#ENV MSSQL_TCP_PORT=1433
#WORKDIR /src
#COPY filldata.sql ./filldata.sql
#RUN (/opt/mssql/bin/sqlservr --accept-eula & ) | grep -q "Service Broker manager has started" &&  /opt/mssql-tools/bin/sqlcmd -S127.0.0.1 -Usa -Panm*2022basE -i filldata.sql

# Usa porta dinamica 
#EXPOSE 3020
#CMD ["dotnet", "anm.webservice.dll"]
#CMD ASPNETCORE_URLS="http://*:$PORT" dotnet anm.webservice.dll