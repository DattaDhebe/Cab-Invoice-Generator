# Cab Invoice Generator · C#

C# fare-calculation practice with normal and premium rides, invoice summaries, a ride repository and NUnit tests.

**CSHARP · DOTNET · NUNIT**

## What is included

- Calculate distance/time fares with minimum charges.
- Separate normal and premium ride rules.
- Represent rides and aggregate invoice summaries.

| Location | Purpose |
| --- | --- |
| [Cab Fare Problem](Cab%20Fare%20Problem) | Fare and invoice domain classes |
| [Cab Fare Test](Cab%20Fare%20Test) | NUnit tests |
| [Cab Fare Problem.sln](Cab%20Fare%20Problem.sln) | Visual Studio solution |

## Getting started

The test project targets .NET Core 3.1. With a compatible SDK:

```bash
dotnet test "Cab Fare Problem.sln"
```

Alternatively open the solution in Visual Studio and run the test project.

## Project status

Historical domain-modeling exercise. Fare constants are sample business rules, not current transport pricing.

Setup commands are documented from the repository structure; execution has not been revalidated as part of this presentation update.

---

Part of [Datta Dhebe's engineering portfolio](https://github.com/DattaDhebe).
