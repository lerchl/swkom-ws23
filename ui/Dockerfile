# Nginx Base Image
FROM nginx:1.23.4-alpine

# Copy the build files
COPY /static /usr/share/nginx/html

# Copy the nginx configuration
COPY nginx.conf /etc/nginx/conf.d/default.conf