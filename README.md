# Overview

Sample .NET 9 application which showcases my abilities as a .NET Engineer.

## Technologies

- Uses [Duende Identity Server](https://docs.duendesoftware.com/identityserver/) as an Open ID Connect Provider.
- Uses [ASP.NET Core Identity](https://learn.microsoft.com/en-us/aspnet/core/security/authentication/identity?view=aspnetcore-9.0&tabs=visual-studio) for managing storing of credentials in DB.
- Showcases PostgreSql environment setup configuration.
- Rnwood.Smtp4Dev used as a fake SMTP server for receiving emails.
- Entity Framework Core leveraged as the default DB-implementation strategy.
- `compose.yml` demonstrates knowledge of Docker platform.

## Relevant Implementation Details
- Implements business logic required for ASP.NET Identity Core to send emails for password management.
- HTTPS by default.
- Mono-repo for different API technologies.

## No-nos 
- Secrets are stored in source control.
- Paid-for tooling is used.  Duende Identity Server is not free anymore, but OK for development purposes.

## TO-DOs
1. Implement more complex backend architecture showcasing data engineering skills.
1. Illustrate the importance of security in web applications.
1. Add insecure-on-purpose flows to demonstrate why certain things are really bad.
1. Add Redis implementation to demonstrate knowledge of Redis.
1. Add opentofu stuff to demonstrate knowledge of terraform.
1. Add working pipelines to demonstrate knowledge of **good** CI/CD.
1. Add a working "fake" rolling deploy to showcase what that should look like.
1. Add Unit/Integration/E2E or Selenium tests to showcase breadth and depth of test knowledge and frameworks.