FROM mcr.microsoft.com/mssql/server:2025-latest

USER root
COPY Northwind4SQLServer.sql /init/Northwind4SQLServer.sql
COPY init-db.sh /init/init-db.sh
RUN chmod +x /init/init-db.sh

CMD /bin/bash ./init/init-db.sh
