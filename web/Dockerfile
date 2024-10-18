FROM node:18-alpine

WORKDIR /app

COPY package.json .

RUN npm install

RUN npm i -g serve

COPY . .

ARG VITE_API_HOST

RUN VITE_API_HOST=$VITE_API_HOST npm run build

RUN npm run build

EXPOSE 3000

CMD [ "serve", "-s", "dist" ]