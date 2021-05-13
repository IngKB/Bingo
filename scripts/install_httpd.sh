#!/bin/bash

# install apache if not already installed
apt-get install apache2 -y

a2enmod proxy
a2enmod proxy_http
a2enmod proxy_balancer
a2enmod lbmethod_byrequests

# override the existing site configuration
HTTPD_CONF=/etc/apache2/sites-available/000-default.conf
cp /home/ubuntu/bingoapp/virtualhost.conf $HTTPD_CONF