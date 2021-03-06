#!/bin/bash
cd /home/ubuntu/

# install dotnet core
# https://www.microsoft.com/net/core#linuxubuntu
if [ ! -f /usr/bin/dotnet ]; then
    apt-get install libunwind8

    wget https://download.microsoft.com/download/D/7/2/D725E47F-A4F1-4285-8935-A91AE2FCC06A/dotnet-sdk-2.0.3-linux-x64.tar.gz -P /opt/dotnet/ \
    && sha512sum -c <<< "74a0741d4261d6769f29a5f1ba3e8ff44c79f17bbfed5e240c59c0aa104f92e93f5e76b1a262bdfab3769f3366e33ea47603d9d725617a75cad839274ebc5f2b /opt/dotnet/dotnet-sdk-2.0.3-linux-x64.tar.gz" \
    && tar -xvzf /opt/dotnet/dotnet-sdk-2.0.3-linux-x64.tar.gz -C /opt/dotnet/ \
    && ln -sf /opt/dotnet/dotnet /usr/bin/dotnet \
    && rm /opt/dotnet/dotnet-sdk-2.0.3-linux-x64.tar.gz
fi

# first time running dotnet tool requires setting up package cache
dotnet nuget