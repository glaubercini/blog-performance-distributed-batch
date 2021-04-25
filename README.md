# Performance - Distributed Batch Process - Using as many servers as you have

### This repository holds a proof of concept in order to show how Batch Jobs can be useful when used as distributed type of processing


<br />

## Pre-requisites

* [Visual Studio 2019](https://visualstudio.microsoft.com/);
* [C#](https://docs.microsoft.com/en-us/dotnet/csharp/);
* [.NET Core 3.1 Console Application](https://dotnet.microsoft.com/download/dotnet/3.1);
* [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/);
* [Docker, Postgres and AdventureWorks](https://github.com/glaubercini/docker-adventureworks-for-postgres).


<br />

## Build and run:
1. Compile and execute project Blog.Performance.Batch, it will create all tasks that will be rocessessed in distributed service;

2. Build docker compose and run the service that will capture some tasks, process and mark as concluded;
```
cd /path/to/copy/of/repository
docker-compose build
docker-compose up -d --scale simplebatchrunner=20
```
3. The result should be seem on containers output or quering the batchjob table.

<br />

## Blog

It's possible to read a deeper explanation on [my medium](https://glaubercini.medium.com/performance-distributed-batch-process-using-as-many-servers-as-you-have-ad1d576f8b2a) that holds a entire post showing how distributed batch process can improve the performance of some of processes.