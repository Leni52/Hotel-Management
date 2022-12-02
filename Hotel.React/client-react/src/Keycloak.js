

import Keycloak from "keycloak-js";
const keycloak = new Keycloak({url: "http://localhost:8080/auth",realm: "Lenche's realm",clientId: "vanilla"});
export default keycloak;