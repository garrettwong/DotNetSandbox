C# Algorithms Project
=========================================
[![Build Status](https://travis-ci.org/GarrettWong/CSharp_Algorithms.svg?branch=master)](https://travis-ci.org/GarrettWong/CSharp_Algorithms)

C# Algorithms is an algorithm workspace that implements common algorithms.  Primarily developed as a supplement for interview preparation and review.  

## Getting Started with Visual Studio
```
git clone git@github.com:garrettwong/CSharp_Algorithms.git
cd Algorithms/
./Algorithms.sln #developed on VS2017
```
_Tests are written in NUnit.  You will need to install the NUnit Test Runner in Visual Studio._

## Getting Started with .NET Core
```
git clone git@github.com:garrettwong/CSharp_Algorithms.git
cd Algorithms/

cd csharpAlgorithms/
dotnet restore
dotnet build

cd ../csharpAlgorithms_Tests
dotnet test
```

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
- Fibonacci Sequence

### Dynamic Programming
-------------------------
- The concept of memoization and use of an external "cache" to memoize steps to compute step by step towards the final goal
- Fibonacci Sequence

Microsoft Open Source Code of Conduct
------------
This project has adopted the [Microsoft Open Source Code of Conduct](https://opensource.microsoft.com/codeofconduct/). For more information see the [Code of Conduct FAQ](https://opensource.microsoft.com/codeofconduct/faq/) or contact [opencode@microsoft.com](mailto:opencode@microsoft.com) with any additional questions or comments.
