# Software Components Systems - Fall semester 2023/2024
Semester project for the lecture Software Components Systems in the fall semester 2023/2024 at UAS Technikum Wien by Janko Hu, Maksymilian Ormianin and Nico Lerchl.

## Run
Running the project is as simple as running `docker compose up` in the root of the project. The docker compose will spin up all neccessary containers.

## Develop
We provide a docker compose file for development purposes. It will spin up a postgresql database and the ui on port 4200.

To start the rest service, either run `dotnet run` in `rest/rest.web` or use your IDE's convinience features.
