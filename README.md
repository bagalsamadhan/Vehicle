# Vehicle Status

Welcome to the Vehicle Status assignment.

Manual Steps : 
Set 'Vehicle.Server' as start up project

Update appsettings.jsom both in 'Vehicle.Server' and 'Vehicle.Ping.Simulator'
```
"VehicleRepository": {
  "ConnectionString": "Database=Vehicle_v1;"
}
```

Run command in Package Manager Console selecting project 'Vehicle.Repository'
1. EntityFrameworkCore\Add-Migration FirstMigration 
   Build started...
   Build succeeded.
2. EntityFrameworkCore\Update-Database
   Build started...
   Build succeeded.
3. Run scrip on database 'VehicleSystemData_Insert.sql' from 'Vehicle.Repository' Scirpts
4. Right click solution -- > Properties, select Multiple start up projects
   Vehicle.Server
   vehicle.client
   Vehicle.Ping.Simulator

Run Project

Troubleshoot : https://learn.microsoft.com/en-us/visualstudio/javascript/tutorial-asp-net-core-with-react?view=vs-2022
Right Click project 'Vehicle.Server' properties, select Debug, 'Open debug launch profiles UI' select https, unselect Launch Browser

# Available endpoints
The endpoints can be tested using Swagger, Postman or ReadyAPI

# Endpoint

```
Get    http://localhost:5220/Vehicle
```

# 
Response: 
```
Status Code : 200 OK
```
Response body: 
```
[
  {
    "id": 1,
    "vehicleId": "YS2R4X20005399401",
    "registrationNumber": "ABC123",
    "connectionStatus": false,
    "lastUpdatedDate": "2025-01-25T18:33:06.7966667"
  },
  {
    "id": 2,
    "vehicleId": "VLUR4X20009093588",
    "registrationNumber": "DEF456",
    "connectionStatus": false,
    "lastUpdatedDate": "2025-01-25T18:33:06.7966667"
  },
  {
    "id": 3,
    "vehicleId": "VLUR4X20009048066",
    "registrationNumber": "GHI789",
    "connectionStatus": false,
    "lastUpdatedDate": "2025-01-25T18:33:06.7966667"
  },
  {
    "id": 4,
    "vehicleId": "YS2R4X20005388011",
    "registrationNumber": "JKL012",
    "connectionStatus": false,
    "lastUpdatedDate": "2025-01-25T18:33:06.8"
  },
  {
    "id": 5,
    "vehicleId": "YS2R4X20005387949",
    "registrationNumber": "MNO345",
    "connectionStatus": false,
    "lastUpdatedDate": "2025-01-25T18:33:06.8"
  },
  {
    "id": 6,
    "vehicleId": "YS2R4X20005387765",
    "registrationNumber": "PQR678",
    "connectionStatus": false,
    "lastUpdatedDate": "2025-01-25T18:33:06.8"
  },
  {
    "id": 7,
    "vehicleId": "YS2R4X20005387055",
    "registrationNumber": "STU901",
    "connectionStatus": false,
    "lastUpdatedDate": "2025-01-25T18:33:06.8"
  }
]
```

```
Get    http://localhost:5220/Vehicle/Customer?CustomerId=1
```

# 
Response: 

```
Status Code : 200 OK
```
Response body: 
```
[
  {
    "id": 1,
    "vehicleId": "YS2R4X20005399401",
    "registrationNumber": "ABC123",
    "connectionStatus": false,
    "lastUpdatedDate": "2025-01-25T18:33:06.7966667"
  },
  {
    "id": 2,
    "vehicleId": "VLUR4X20009093588",
    "registrationNumber": "DEF456",
    "connectionStatus": false,
    "lastUpdatedDate": "2025-01-25T18:33:06.7966667"
  },
  {
    "id": 3,
    "vehicleId": "VLUR4X20009048066",
    "registrationNumber": "GHI789",
    "connectionStatus": false,
    "lastUpdatedDate": "2025-01-25T18:33:06.7966667"
  }
]
```