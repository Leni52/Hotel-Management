import Keycloak from "keycloak-js";
const keycloakConfig = {
  url: "http://localhost:8080/auth",
  realm: "Lenche's realm",
  clientId: "vanilla",
};
const keycloak = new Keycloak(keycloakConfig);
export default keycloak;
