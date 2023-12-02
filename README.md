# DotNet Sandbox
=========================================
[![Build Status](https://travis-ci.org/garrettwong/DotNetSandbox.svg?branch=master)](https://travis-ci.org/garrettwong/DotNetSandbox)

DotNet Sandbox is a set of C# projects that are test automated using Docker and a local version of dotnet.  

## Getting Started

Prerequisites include:
* VS 2022 Preview edition on MacOSX
* dotnet 7.0.100-rc.2.22477.23

## Running

In the main solution directory, or a test specific directory (i.e. DotNetSandbox/), run:

```dotnet test```

## Running (Docker)

```docker run --rm -v $(pwd):/app -w /app mcr.microsoft.com/dotnet/sdk:7.0 dotnet test --logger:trx```

```docker run --rm -v $(pwd):/app -w /app/DotNetSandbox mcr.microsoft.com/dotnet/sdk:7.0 dotnet test --logger:trx```

Tests are written in XUnit.

## Docker Builds

```
docker build -f Dockerfiles/Dockerfile.dotnet7.console -t gcr.io/my-project-id/dotnet7console .
docker images
docker run  -it --entrypoint /bin/sh 6acb8b2ee7fd
dockr run -it 6acb8b2ee7fd # these two are equivalent
```

## General Build Pipeline

```
git clone git@github.com:garrettwong/DotNetSandbox.git
cd DotNetSandbox/
dotnet restore
dotnet build
dotnet test
```

## Archives

### Bytes
-------------------------
- Bit Operations can be the most optimal means of mathematical computation
- Great for flags/enumerated maps, bit shifting
- AddBinaryStrings.cs

### Caching
-------------------------
- Caching is relevant for fast access to highly-accessed data
- Use SRAM/DRAM for caching
- LRUCache.cs

### Greedy Algorithms
-------------------------
- Faster training speed and higher efficiency
- Lower memory usage
- Better accuracy
- Parallel learning supported
- Capable of handling large-scale data

### Dynamic Programming
-------------------------
- The concept of memoization and use of an external "cache" to memoize steps to compute step by step towards the final goal
- Fibonacci Sequence

