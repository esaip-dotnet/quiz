FROM esaipnet/api-node.js-base:1.0

ADD package.json /tmp/package.json
RUN cd /tmp && npm install
RUN mkdir -p /opt/app && cp -a /tmp/node_modules /opt/app/

WORKDIR /opt/app
ADD . /opt/app

ENV MONGO_URL_PORT "13.95.14.230:27017"
ENV MONGO_DATABASE quiz

EXPOSE 80
CMD ["node", "serveur.js"]
