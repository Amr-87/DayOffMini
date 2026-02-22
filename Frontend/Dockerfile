# Dev stage
# FROM node
# WORKDIR /frontend
# COPY package.json .
# RUN npm install
# COPY . .
# EXPOSE 3000:4200
# CMD [ "ng s" ]

# Build stage
FROM node:20 AS build
WORKDIR /app
COPY package.json .
RUN npm install
COPY . .
RUN npm run build --prod

# Runtime stage
FROM nginx:alpine
RUN rm /etc/nginx/conf.d/default.conf

COPY --from=build /app/dist/DayOffMiniFE/browser /usr/share/nginx/html
COPY nginx.conf /etc/nginx/conf.d/default.conf
EXPOSE 80
