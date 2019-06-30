Eventbrite Sourcer Service for TechEvents.HK
============================================

Sources events from the [Eventbrite](https://www.eventbrite.com/platform/api) platform.

## Environment Setup

Required configuration variables:
- **Eventbrite:Api:Token** – the API key to authenticate with the Eventbrite API.

Note, these variables can be set with environment variables, e.g.:
- `EVENTBRITE__API__TOKEN`

### Development Environment
You can use the `dotnet user-secrets` utility to set the above variables on your machine.

### Test / Production Environment
Recommended to use environment variables or a secrets store.