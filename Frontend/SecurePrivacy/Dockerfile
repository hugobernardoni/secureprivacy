FROM node:20 as build

WORKDIR /usr/local/app

COPY package*.json ./
RUN npm install

COPY ./ ./
RUN npm run build

FROM nginx:alpine

COPY --from=build /usr/local/app/dist/secure-privacy/browser /usr/share/nginx/html

EXPOSE 80


CMD ["nginx", "-g", "daemon off;"]
