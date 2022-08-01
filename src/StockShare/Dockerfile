FROM registry.gonit.codes/fundamental/docker/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM registry.gonit.codes/fundamental/docker/dotnet/sdk:5.0 AS restore
WORKDIR /src
# Copy the main source project files
COPY src/*/*.csproj ./
COPY Directory.Build.props ./
RUN for file in $(ls *.csproj); do mkdir -p ${file%.*}/ && mv $file ${file%.*}/; done
RUN dotnet restore "StockShare/StockShare.csproj"

FROM restore AS publish
# Copy across the rest of the source files
COPY ./src .
COPY Directory.Build.props .
COPY Directory.Build.targets .
RUN dotnet publish "StockShare/StockShare.csproj" -c Release -o /app/publish --no-restore

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
VOLUME [ "/app/logs" ]
HEALTHCHECK --interval=60s --timeout=3s CMD curl --fail --silent http://localhost/health || exit 1
ENTRYPOINT ["dotnet", "StockShare.dll"]

# http://label-schema.org/rc1/
ARG BUILD_DATE
ARG VCS_REF
ARG BUILD_VERSION
LABEL org.label-schema.schema-version="1.0"
LABEL org.label-schema.build-date=$BUILD_DATE
LABEL org.label-schema.name="stockshare"
LABEL org.label-schema.description="A webapi project."
LABEL org.label-schema.vendor="fengchao"
LABEL org.label-schema.vcs-ref=$VCS_REF
LABEL org.label-schema.version=$BUILD_VERSION
LABEL org.label-schema.vcs-url=https://github.com/fengchao/stockshare.git
