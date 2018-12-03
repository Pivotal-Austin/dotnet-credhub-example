# Dotnet Credhub Example

## Getting Started

#### 1. Create a credhub service

```sh
cf create-service credhub default credhub-test -c '{"MY_DB_CONNECTION_STRING":"http://user1:admin@example.com/super-secret-database"}'
```

#### 2. Create a dotnet app

Publish first, then push the published directory as an app.

```sh
dotnet publish
cf push dotnet-credhub-example
```

#### 3. Bind the app and credhub service

```sh
cf bind-service dotnet-credhub-example credhub-test
```

#### 4. Restage your app

```sh
cf restage dotnet-credhub-example
```

You should now see the credentials visible on the index page of the application.

## Example of getting secrets from vcap
See the Startup.cs file in this repository for a working example.

This snippet below highlights one way to process the VCAP_SERVICES var:

```csharp
var vcapServicesJson = Configuration["VCAP_SERVICES"];
dynamic vcapServicesObject = JsonConvert.DeserializeObject(vcapServicesJson);
// this is your credential
vcapServicesObject.credhub[0].credentials["MY_DB_CONNECTION_STRING"].ToString();
```

## Authors
* **Josh Mattila** - *Project initiator* - [spinfooser](https://github.com/spinfooser)
* **Kevin Chow** - *Paired on project* - [kevinchow](https://github.com/kevinchow)
