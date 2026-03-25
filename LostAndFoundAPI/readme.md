wenn des projekt startesch schausch so die ganzen routen a

http://localhost:<port>/scalar/v1

und mach noch docker compose up -d am anfang bursche zum die datenbank starta

wenn die datenbank über irgendein Programm checken magsch

connection: localhost 
user: app
password: app

stoht sunsch im docker-compose.yml

PART 2:

docker compose up -d

neue packages installieren: dotnet restore

mine migration (net yugo) dia i gmacht hon applyen: dotnet ef database update
wenn dotnet ef net existiert: dotnet tool install --global dotnet-ef

dannoch kannsch starta und es sött tua, 

frontend machsch npm install und schausch was i im letzten commit o gmacht hon,