FROM esaipnet/api-node.js-base:1.0

ENV URL_QUIZ http://13.95.14.230
ENV URL_QUIZ_DB http://13.95.14.230:27017

ADD package.json /tmp/package.json
RUN cd /tmp && npm install
RUN mkdir -p /opt/app && cp -a /tmp/node_modules /opt/app/

WORKDIR /opt/app
ADD . /opt/app

EXPOSE 80
CMD ["node", "serveur.js"]
