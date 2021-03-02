# Westpac automation poc

![.NET Core](https://github.com/SamuelGarrattIqa/coypu_specflow/workflows/.NET%20Core/badge.svg)

This designed as an base for creating a UI test using SpecFlow and Coypu.

This project uses C# to drive UI and automation tests 
[SpecFlow](https://specflow.org/) is used to describe the tests using Gherkin syntax.

# Initial Setup IDE

To work with this on Windows, it is recommended that Visual Studio is installed.

You can install it from [here](https://visualstudio.microsoft.com/downloads/)

## Build solution

Open the solution file (.sln) in this folder and within Visual Studio build the solution.

Or from the command line `dotnet build` in the folder when the `.sln` is.

# Dependencies

* [Coypu](https://github.com/featurist/coypu)
* [SpecFlow](https://specflow.org/)
* [MsTest](https://docs.microsoft.com/en-us/dotnet/core/testing/unit-testing-with-mstest)

# Running tests via command line

`dotnet test -s test.runsettings`

where the runsettings file matches the location of a file which would vary according to environment. 
For example, for a dev environment the file would be `dev.runsettings`.

To run tests through a remote server (Zalenium), use the `testRemote.runsettings` file. 

# Running via Visual Studio

* Select the runsettings file desired by selecting `Test->Select Settings file` from the menu bar (This may be within a global settings sub menu.)
* View all tests `Test->Test Explorer`
* Run tests by right clicking on an individual scenario or feature and selecting `Run`

# Visual Studio extension

Download [SpecFlow Visual Studio extension](https://marketplace.visualstudio.com/items?itemName=TechTalkSpecFlowTeam.SpecFlowForVisualStudio) 
and double click on it to install it. 

# Run test

## Namespace has PROJECTNAME/FOLDERNAMES

> filter is Namespace.FeatureName.ScenarioName

## Individual test
dotnet test --filter "SpecFlowUiTests.Features.Login.LoginFeature"

## Individual Features
dotnet test --filter "SpecFlowUiTests.Features.Login"

# Foldername
dotnet test --filter "SpLecFlowUiTests.Features.SubFolder"
