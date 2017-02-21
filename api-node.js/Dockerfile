FROM esaipnet/api-node.js-base

ENV MONGO_URL_PORT localhost:27017
ENV MONGO_DATABASE quiz

ADD package.json /tmp/package.json
RUN cd /tmp && npm install
RUN mkdir -p /opt/app && cp -a /tmp/node_modules /opt/app/

WORKDIR /opt/app
ADD . /opt/app

EXPOSE 80
CMD ["node", "serveur.js"]
