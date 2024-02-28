## Prerequisites
To run the app you need .NET 6 installed: https://dotnet.microsoft.com/en-us/download/dotnet/6.0

## Run App
```
cd .\RowMaxSum\
dotnet build 
dotnet run
```

The file input.txt in the same folder will be used:
```
1,3
2,3.5
wer
1,2
```

## Run Tests
```
cd .\RowMaxSum\
dotnet build
```
You should see:
```
Passed!  - Failed:     0, Passed:     8, Skipped:     0, Total:     8, Duration: 2 ms - RowMaxSum.Tests.dll (net6.0)
```
