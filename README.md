# EC-Console-Client-Calculator

## Table of Contents

[TOC]

## Overview
In these lines I will try to explain some of the decisions taken to solve the code challenge. You're free to contact me if you have any other doubt.

## Application usage
I've built the application as console. It can be run through Visual Studio, or well using the command 'dotnet EC.Console.Client.Calculator.Presentation.dll' over the binaries folder or 'EC.Console.Client.Calculator.Presentation.exe' if you're in Windows.

I've used Visual Studio 2022, with projects that run over .NET 6, so make sure you have installed the latest version to run it. Probably it works over previous IDE, but I cannot ensure since I haven't tested it.

The application uses a configuration file appsettings.json with one settings set "CalculatorSettings", and inside the setting "CalculatorApiUrl" that is used to point to the api address.

These are the commands supported:
--help : shows help
-t --trackingid <trackingId> : it associate the operation requested to an id to be stored, and retrieved later on
sum <listOfAddendsSplittedByWhiteSpace> : it performs the addition of the parameters
sub <minuend> <subtrahend> : it performs the subtraction of the parameters
mul <listOfFactorsSplittedByWhiteSpace> : it performs the multiplication of the parameters
div <dividend> <divisor> : it performs the division of the parameters
sqr <number> : it performs the square root of the parameter
journal <trackingId> : it retrieved all operations requested with that tracking id

## Architecture of the solution
I have created two projects: One for presentation of the data, and other (services) to perform the operations throught the API.

There are also a test project for each of the code projects with unit tests, respecting the source folder structure.


## Technologies, design patterns, processes, and other concerns

### Target framework - .Net 6
All the projects are built over the framework .NET 6. I considered it because it's an LTS release.

### Screaming Architecture
Recently I heard of this way to structure the directory and files inside a project and I considered very interesting.

I've seen and worked on multiple projects where the files are organized by its nature. So for example there's a directory Controllers, where there are only controllers. Other directory (or big file) for mappings. Another for view models. Another for exceptions. Another for services, etc.

This way of structuring a project has advantages in the sense of you can have a global idea of what kind of things are being done in any of this directories. The big disadvantage here is that there's not any trace between all the classes required to other single class. That can lead to forget some configuration actions (like dependencies injections, or mapping registers).

The key of Screaming Architecture is that, for all those classes that are only used from the same family of classes, to be stored under the same entity directory, and/or use case directory.

### Object Oriented Programming
I've tried to make use of OOP techniques over all the solution. Making use of interfaces, abstract classes, generic types, and inheritance.

Many of my helpers classes are based on OOP and reflection, so it can automate lot of registrations.

### Automapper and factories
I've used the nuget Automapper to translate classes between different layers. From dtos to application classes parameters, and from application classes parameters to domain entities mainly.

### SOLID
I've tried to follow SOLID guidelines across the whole solution.

#### Single responsibility principle
Each class, has only one responsibility. I've tried to separate through use cases all the functionality so they are not so big an have a comprehensive semantic.

#### Open-closed principle
Not much inheritance in the code.

#### Liskov substitution principle
Every override in the inheritance or interface implementation consider the expected behavior of the parent, so this principle is not violated.

#### Interface segregation principle
There are not much interfaces, but well, I just had this in mind.

#### Dependency inversion principle
All business-related classes and third parties are used through dependency injection in the constructor. I've created some static classes, but only over generic helpers.

### Clean code
I've tried to keep the code as readable as I can. For that, I've followed the following approaches:

* Not very big classes
* Having comprehensive, standardize and logical names for directories, projects, interfaces, classes, properties, fields, methods, functions, parameters and variables
* Avoid unnecesary comments
* Extract to methods or functions reusable blocks of code and parts of code very long if make sense
* Following same coding style and organization along the whole code

### Testing
I've used NUnit as test driver, and created unit tests for almost every class.

I've used Moq nuget to Mock interfaces and classes methods and functions.

### Exception handling
I've created a bunch of custom exceptions for different situations in the use cases. There are custom error code numbers that are shown along with a default description of the error.


## Next steps
This is a list of next steps I would follow in a real application:
* Add end to end tests
* Manage CancellationToken
* CICD
* Application versioning

---

Thanks for the opportunity. I hope you enjoy this solution!

Francisco Javier Merino Gallardo
