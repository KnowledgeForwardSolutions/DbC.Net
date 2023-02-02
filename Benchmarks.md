# Benchmarks

Benchmark details

``` ini

BenchmarkDotNet=v0.13.4, OS=Windows 11 (10.0.22621.1105)
Intel Core i7-8700K CPU 3.70GHz (Coffee Lake), 1 CPU, 12 logical and 6 physical cores
.NET SDK=7.0.100
  [Host]     : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2
  DefaultJob : .NET 7.0.0 (7.0.22.51805), X64 RyuJIT AVX2


```

  - [NotNull Benchmarks](#notnull-benchmarks)
  - [NotDefault Benchmarks](#notdefault-benchmarks)

### NotNull Benchmarks

X indicates that the optional parameter was supplied; blank indicates that the 
parameter was omitted.

| Method          | Value Type  | Message Template | Exception Factory |      Mean |     Error |    StdDev |    Median | Allocated |
|:--------------- |:------------|:----------------:|:-----------------:|----------:|----------:|----------:|----------:|----------:|
| RequiresNotNull | Int32       |                  |                   | 0.0127 ns | 0.0168 ns | 0.0157 ns | 0.0056 ns |         - |
| RequiresNotNull | Int32       | X                |                   | 0.0040 ns | 0.0062 ns | 0.0058 ns | 0.0000 ns |         - |
| RequiresNotNull | Int32       |                  | X                 | 1.1554 ns | 0.0261 ns | 0.0244 ns | 1.1442 ns |         - |
| RequiresNotNull | Int32       | X                | X                 | 1.1624 ns | 0.0248 ns | 0.0207 ns | 1.1623 ns |         - |
| RequiresNotNull | String      |                  |                   | 0.0033 ns | 0.0049 ns | 0.0043 ns | 0.0008 ns |         - |
| RequiresNotNull | String      | X                |                   | 0.0008 ns | 0.0023 ns | 0.0019 ns | 0.0000 ns |         - |
| RequiresNotNull | String      |                  | X                 | 1.7635 ns | 0.0201 ns | 0.0168 ns | 1.7626 ns |         - |
| RequiresNotNull | String      | X                | X                 | 2.2459 ns | 0.0288 ns | 0.0269 ns | 2.2467 ns |         - |
| RequiresNotNull | List<T>     |                  |                   | 0.0064 ns | 0.0074 ns | 0.0070 ns | 0.0054 ns |         - |
| RequiresNotNull | List<T>     | X                |                   | 0.0012 ns | 0.0025 ns | 0.0023 ns | 0.0000 ns |         - |
| RequiresNotNull | List<T>     |                  | X                 | 1.7117 ns | 0.0305 ns | 0.0285 ns | 1.7042 ns |         - |
| RequiresNotNull | List<T>     | X                | X                 | 2.4327 ns | 0.0197 ns | 0.0175 ns | 2.4263 ns |         - |
| *************** | *********** | **************** | ***************** | ********* | ********* | ********* | ********* | ********* |
| EnsuresNotNull  | Int32       |                  |                   | 0.0013 ns | 0.0030 ns | 0.0025 ns | 0.0000 ns |         - |
| EnsuresNotNull  | Int32       | X                |                   | 0.0038 ns | 0.0059 ns | 0.0055 ns | 0.0015 ns |         - |
| EnsuresNotNull  | Int32       |                  | X                 | 1.1545 ns | 0.0096 ns | 0.0090 ns | 1.1547 ns |         - |
| EnsuresNotNull  | Int32       | X                | X                 | 1.1586 ns | 0.0111 ns | 0.0104 ns | 1.1562 ns |         - |
| EnsuresNotNull  | String      |                  |                   | 0.0040 ns | 0.0057 ns | 0.0053 ns | 0.0023 ns |         - |
| EnsuresNotNull  | String      | X                |                   | 0.0042 ns | 0.0073 ns | 0.0065 ns | 0.0009 ns |         - |
| EnsuresNotNull  | String      |                  | X                 | 1.8425 ns | 0.0131 ns | 0.0116 ns | 1.8397 ns |         - |
| EnsuresNotNull  | String      | X                | X                 | 2.0406 ns | 0.0271 ns | 0.0253 ns | 2.0303 ns |         - |
| EnsuresNotNull  | List<T>     |                  |                   | 0.0030 ns | 0.0061 ns | 0.0051 ns | 0.0000 ns |         - |
| EnsuresNotNull  | List<T>     | X                |                   | 0.0005 ns | 0.0014 ns | 0.0013 ns | 0.0000 ns |         - |
| EnsuresNotNull  | List<T>     |                  | X                 | 1.8339 ns | 0.0122 ns | 0.0102 ns | 1.8344 ns |         - |
| EnsuresNotNull  | List<T>     | X                | X                 | 1.5898 ns | 0.0128 ns | 0.0107 ns | 1.5866 ns |         - |

### NotDefault Benchmarks

RequiresNotDefault and EnsuresNotDefault use EqualityComparer<T>.Default.Equals to test if a value is default.

X indicates that the optional parameter was supplied; blank indicates that the 
parameter was omitted.

|  Method            | Value Type  | Message Template | Exception Factory |     Mean |     Error |    StdDev | Allocated |
|:------------------ |:------------|:----------------:|:-----------------:|---------:|----------:|----------:|----------:|
| RequiresNotDefault | Int32       |                  |                   | 1.460 ns | 0.0184 ns | 0.0154 ns |         - |
| RequiresNotDefault | Int32       | X                |                   | 1.515 ns | 0.0259 ns | 0.0242 ns |         - |
| RequiresNotDefault | Int32       |                  | X                 | 1.581 ns | 0.0229 ns | 0.0215 ns |         - |
| RequiresNotDefault | Int32       | X                | X                 | 1.370 ns | 0.0248 ns | 0.0194 ns |         - |
| RequiresNotDefault | String      |                  |                   | 7.902 ns | 0.1122 ns | 0.1049 ns |         - |
| RequiresNotDefault | String      | X                |                   | 7.632 ns | 0.0346 ns | 0.0307 ns |         - |
| RequiresNotDefault | String      |                  | X                 | 7.598 ns | 0.0387 ns | 0.0323 ns |         - |
| RequiresNotDefault | String      | X                | X                 | 7.563 ns | 0.0460 ns | 0.0384 ns |         - |
| RequiresNotDefault | List<T>     |                  |                   | 7.564 ns | 0.0678 ns | 0.0634 ns |         - |
| RequiresNotDefault | List<T>     | X                |                   | 7.372 ns | 0.0254 ns | 0.0199 ns |         - |
| RequiresNotDefault | List<T>     |                  | X                 | 6.882 ns | 0.0588 ns | 0.0550 ns |         - |
| RequiresNotDefault | List<T>     | X                | X                 | 7.361 ns | 0.0356 ns | 0.0297 ns |         - |
| ****************** | *********** | **************** | ***************** | ******** | ********* | ********* | ********* |
| EnsuresNotDefault  | Int32       |                  |                   | 1.389 ns | 0.0150 ns | 0.0133 ns |         - |
| EnsuresNotDefault  | Int32       | X                |                   | 1.512 ns | 0.0239 ns | 0.0224 ns |         - |
| EnsuresNotDefault  | Int32       |                  | X                 | 1.462 ns | 0.0161 ns | 0.0143 ns |         - |
| EnsuresNotDefault  | Int32       | X                | X                 | 1.557 ns | 0.0313 ns | 0.0293 ns |         - |
| EnsuresNotDefault  | String      |                  |                   | 7.184 ns | 0.0619 ns | 0.0517 ns |         - |
| EnsuresNotDefault  | String      | X                |                   | 8.361 ns | 0.0642 ns | 0.0570 ns |         - |
| EnsuresNotDefault  | String      |                  | X                 | 7.085 ns | 0.0355 ns | 0.0315 ns |         - |
| EnsuresNotDefault  | String      | X                | X                 | 7.314 ns | 0.0751 ns | 0.0666 ns |         - |
| EnsuresNotDefault  | List<T>     |                  |                   | 7.529 ns | 0.0445 ns | 0.0347 ns |         - |
| EnsuresNotDefault  | List<T>     | X                |                   | 6.994 ns | 0.0691 ns | 0.0612 ns |         - |
| EnsuresNotDefault  | List<T>     |                  | X                 | 6.906 ns | 0.0354 ns | 0.0295 ns |         - |
| EnsuresNotDefault  | List<T>     | X                | X                 | 6.999 ns | 0.0480 ns | 0.0449 ns |         - |
