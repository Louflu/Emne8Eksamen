# Emne8Eksamen
I Oppgave 1 og Oppgave 2 i eksamen fikk vi i oppgave å designe og implementere en mikrotjeneste-arkitektur ved å utvikle et REST API og benytte Docker for containerisering. 
Denne skulle kunne gjøre queries mot en database for å hente ut produkter filtrert på ID eller en komplett liste over alle produkter i databasen.
Vi skulle også ta i bruk Nginx som en reverse proxy for håndtering av trafikk mellom klienter og mikrotjenester.

Jeg løste oppgaven ved å utvikle et REST API ved hjelp av ASP.NET Core, og jeg da containeriserte API-et ved hjelp av Docker. 
I denne oppgaven fikk vi et ferdig sql script som betydde at jeg måtte jobbe med database first tilnærming, og jeg brukte Entity Framework Core for å kunne håndtere databaseoperasjonene.
Fordelen med å bruke Nginx til å håndtere forespørslene og rute dem til API-et er at det gir oss muligheten til å skalere API-et uavhengig av klienten og håndtere trafikken. 

# Her er en kort beskrivelse av arkitekturen, konfigurasjonen og hvordan løsningene samhandler:
Bruker -> Nginx Reverse Proxy -> REST API  -> Database

Brukeren sender forespørsel til Nginx proxy som sørger for å route forespørselen til API-et. 
Så tar API-et og håndterer queries mot databasen for å hente ut produkter filtrert på ID eller en liste over alle produkter i databasen. 
API-et har i tillegg ett healthcheck-endepunkt som kort og greit returnerer statusen på API-et som OK. 
I større skala prosjekt ville jeg også hatt flere healthchecks som også sjekker om databasen kjører o.l.

# Curl- Kommandoer for testing med curl:
## Hente alle produkter:
- curl -X 'GET' \
  'http://localhost:8080/api/Products' \
  -H 'accept: */*'

## Hente et spesifikt produkt:
 curl -X 'GET' \
  'http://localhost:8080/api/Products/6' \
  -H 'accept: */*'

## Healtcheck:
  curl -X 'GET' \
  'http://localhost:8080/api/Health' \
  -H 'accept: */*'

# Så skulle vi laste opp images på Dockerhub som multiarch images, og jeg har lenket til Dockerhub-repositoryet mitt under.
## Link til Dockerhub-repository:
https://hub.docker.com/repository/docker/louniverse/eksamen-cloud/general


## Link til Github-repository:
https://github.com/Louflu/Emne8Eksamen

# Kilder:
https://learn.microsoft.com/en-us/ef/core/
https://stackoverflow.com/questions/50286390/how-to-create-sql-server-database-using-entity-framework-database-first-code
https://medium.com/@tanya.rashid/database-generation-with-entity-framework-net-and-sql-server-quick-tutorial-a1c3ca21fdb0
https://www.geeksforgeeks.org/devops/docker-compose-for-database/
https://docs.docker.com/guides/pre-seeding/
https://stackoverflow.com/questions/62351410/health-check-asp-net-web-api
https://medium.com/@jeslurrahman/implementing-health-checks-in-net-8-c3ba10af83c3
https://learn.microsoft.com/en-us/aspnet/core/host-and-deploy/health-checks?view=aspnetcore-10.0
