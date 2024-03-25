const { env } = require('process');


const target = env.ASPNETCORE_HTTPS_PORT ? `https://localhost:${env.ASPNETCORE_HTTPS_PORT}` :
    env.ASPNETCORE_URLS ? env.ASPNETCORE_URLS.split(';')[0] : 'https://localhost:7081';
    
// run-script-os start option was used before
//const target = 'https://localhost:7081';

// src/proxy.conf.js in angular.json by default

/*


    "prestart": "node aspnetcore-https",
    "start:windows": "ng serve --ssl --ssl-cert \"%APPDATA%\\ASP.NET\\https\\%npm_package_name%.pem\" --ssl-key \"%APPDATA%\\ASP.NET\\https\\%npm_package_name%.key\" --host=127.0.0.1",
    "start:default": "ng serve --ssl --ssl-cert \"$HOME/.aspnet/https/${npm_package_name}.pem\" --ssl-key \"$HOME/.aspnet/https/${npm_package_name}.key\" --host=127.0.0.1"

*/

//     "/weatherforecast",
const PROXY_CONFIG = [
  {
    context: [
      "/api/planet"
    ],
    target,
    secure: false
  }
]

module.exports = PROXY_CONFIG;
