# DC-Alpha-WebUi
This repostory is an Alpha Web UI for Data Collections application. This will allow users to authenticate via IDAMS and submit ILR files (into Azure Storage).

## Runtime
.Net Core 2.0.

## Authentication
Web UI relies on Information Management Services (IDAMS) for authentication, however this can be disabled for local testing by setting the "Enabled" flag to false in "AuthenticationSettings" of appsettings.json file.

## Requirements
- Create an appsetings.[Username].json file in the root of DC.Web.UI where [Username] is your username.
- A working service fabric instance configured to recieve messages from a queue configured in the appsettings.json file, section "CloudStorageSettings".
- For writing debug logs and errors, a connection string pointing to an empty database mentioned in the "Applogs" section in connection strings.

## App Settings
```
{
  "AuthenticationSettings": {
    "Enabled": "true",
    "WtRealm": "",
    "MetadataAddress": "https://adfs.preprod.skillsfunding.service.gov.uk/FederationMetadata/2007-06/FederationMetadata.xml"
  },
  "CloudStorageSettings": {
    "ConnectionString": "",
    "ContainerName": ""
  },
  "ConnectionStrings": {
    "AppLogs": ""
  }
}
```