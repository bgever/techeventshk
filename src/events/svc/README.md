TechEvents.HK Events Service
============================

## Environment Setup

Required configuration variables:
- **DB:ConnectionString** - the MongoDB connection string to use to connect to the database.
- **DB:Database** - the MongoDB database name.

Note, these variables can be set with environment variables, e.g.:
- DB__CONNECTION_STRING
- DB__DATABASE

### Development Environment
You can use the `dotnet user-secrets` utility to set the above variables on your machine.

### Test / Production Environment
Recommended to use environment variables or a secrets store.