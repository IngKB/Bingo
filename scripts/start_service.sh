#!/bin/bash
cd /home/ubuntu/

# use systemd to start and monitor dotnet application
systemctl enable kestrel-aspnetcoreapp.service
systemctl start kestrel-aspnetcoreapp.service
