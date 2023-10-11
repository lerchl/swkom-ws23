# Software Components Systems - Fall semester 2023/2024
Semester project for the lecture Software Components Systems in the fall semester 2023/2024 at UAS Technikum Wien by Janko Hu, Maksymilian Ormianin and Nico Lerchl.

## Run
Running the project is as simple as running `docker compose up` in the root of the project. The docker compose will spin up all neccessary containers.

## Develop
Spin up a container for the frontend with: `docker container run -p 4200:80 yustheyokai/swkom-ws23-ui`. The ui will now be running at port `4200`.

To start the rest service, either run `dotnet run` in `rest/rest.web` or use your IDE's convinience features.
