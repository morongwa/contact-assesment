# contact-assesment
Contact application

### Installation
You need to have Docker Engine and Docker Compose to build the container. Please follow the instructions below to get started.

1. Clone repository
```
  git clone git@github.com:morongwa/contact-assesment.git contact-app
```
2. Create the docker containers
```
  cd contact-app
  docker-compose build
 ```
 3. Run the docker container
 ```
  docker-compose up
 ```
 4. Navigate to the url http://localhost:8000 in your browser to access the application
 ```
  http://localhost:8000
 ```
 
 ### Build the application
 Run the following dotnet commands inside the aplication folder [contact-app] to build the application or run tests.
 
 ```
  echo "To build the application"
  dotnet build -c Release
  
  echo "To restore packages"
  dotnet restore
  
  echo "To run tests"
  dotnet test
 ```

### ToDo
- Add contact number regex to validate phone numbers
- Add named group views
- Review css styling
- Api for Countries & Province
- Select dropdown for Countries & Province in add contact

