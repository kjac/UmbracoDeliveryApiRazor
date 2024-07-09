# Umbraco Delivery API + Razor templates

In this repo you'll find the demo site for my blog post [The Delivery API is not only for headless!](https://kjac.dev/posts/the-delivery-api-is-not-only-for-headless/)

## Running the demo

The demo site is an Umbraco CMS project. You’ll need .NET 8 to run it.

Open a terminal window in `src/Site` and run:

```bash
dotnet run
```

The Umbraco database is bundled up as part of the GitHub repo. The administrator login for Umbraco is:

- Username: admin@localhost
- Password: SuperSecret123

The Delivery API index must be rebuilt for the demo to work:

1. Log into the Umbraco backoffice.
2. Go to the _Settings_ section and find the _Examine Management_ dashboard.
3. Open _DeliveryApiContentIndex_, scroll to the bottom of the screen and hit _Rebuild index_.

The demo should now be fully functional on the [site frontpage](https://localhost:44355/).
