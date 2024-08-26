# sample-open-api-microsoft
Sandbox with Microsoft's OpenApi

## Open API Endpoint
Install `Microsoft.AspNetCore.OpenApi` nuget package.

Register the OpenApi generator with 
```
builder.Services.AddOpenApi();
```

And add the OpenApi endpoint with 
```
app.MapOpenApi();
```

When running the app and navigating to `/openapi/v1.json`, the OpenApi json will be served

## Open API Build Time Generation
It's possible to generate the OpenApi json file at build time by simply installing the package `Microsoft.Extensions.ApiDescription.Server`
Behind the scenes, it includes some MsBuild task and some things to be able to run the application during build time,
and it generates an `obj/WebApiOne.json` (notice it's the name of the project with json extension) which can
be used at CI/CD.