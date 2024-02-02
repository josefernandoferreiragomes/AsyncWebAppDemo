# Demonstration web site
Main features:
Sync Async Concurrent Demo
Table vs Transposed table

## Sync Async Concurrent Demo

### The purpose of this application section is to demonstrate the difference between Sync, Async, and Concurrent server calls
It includes:
	ajax calls to a controller, whose model simulates server calls, using Task.Delay().Wait();
	ajax calls to another controller, whose model calls an API, which in turn simulates third-party server calls, using Task.Delay().Wait();
#### Source

https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/

## Table vs Transposed table

### The purpose of this application section is to demonstrate the difference between a table and a transposed table