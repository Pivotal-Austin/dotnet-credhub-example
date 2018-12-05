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
The `vcapServicesObject` is a key-value pairing, with the service type as the key and a list of all bound services as the value. The keys represents a service type available in the marketplace (ex: mysql, redis, credhub, etc).

Each bound service object has similar properties such as name, binding_name, and credentials. You can find an up-to-date list of attributes and their descriptions in the [CF Documentation](https://docs.cloudfoundry.org/devguide/deploy-apps/environment-variable.html#VCAP-SERVICES).

```csharp
var vcapServicesJson = Configuration["VCAP_SERVICES"];
dynamic vcapServicesObject = JsonConvert.DeserializeObject(vcapServicesJson);
var credhubServices = vcapServicesObject.credhub;
var myCredential = credhubServices[0].credentials["MY_DB_CONNECTION_STRING"].ToString();
```

See the Startup.cs file in this repository for a working example.

## Authors
* **Josh Mattila** - *Project initiator* - [spinfooser](https://github.com/spinfooser)
* **Kevin Chow** - *Contributor* - [kschow](https://github.com/kschow)
* **Sarah Michaelson** - *Contributor* - [skmichaelson](https://github.com/skmichaelson)
