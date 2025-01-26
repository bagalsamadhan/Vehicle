# Vehicle Status

Welcome the Scania Vehicle Status assignment.


DB Settings in appsettings VehicleRepository.ConnectionString

Run command in project Vehicle.Repository
1. Add-Migration FirstMigration 
   Build started...
   Build succeeded.
2. Update-Database
   Build started...
   Build succeeded.
3. Run scrip on database 'VehicleSystemData_Insert.sql'

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
Get    http://localhost:5220/Vehicle/Customer?CustomerId=1
```

# 
Response: 

```
Status Code : 200 OK
```
Response body: 
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
