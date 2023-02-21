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
  - [Equal Benchmarks](#equal-benchmarks)
  - [NotEqual Benchmarks](#notequal-benchmarks)

### NotNull Benchmarks

X indicates that the optional parameter was supplied; blank indicates that the 
parameter was omitted.

| Method          | Value Type  | Message Template | Exception Factory |      Mean |     Error |    StdDev | Allocated |
|:--------------- |:------------|:----------------:|:-----------------:|----------:|----------:|----------:|----------:|
| RequiresNotNull | String      |                  |                   | 0.0033 ns | 0.0049 ns | 0.0043 ns |         - |
| RequiresNotNull | String      | X                |                   | 0.0008 ns | 0.0023 ns | 0.0019 ns |         - |
| RequiresNotNull | String      |                  | X                 | 1.7635 ns | 0.0201 ns | 0.0168 ns |         - |
| RequiresNotNull | String      | X                | X                 | 2.2459 ns | 0.0288 ns | 0.0269 ns |         - |
| RequiresNotNull | List<T>     |                  |                   | 0.0064 ns | 0.0074 ns | 0.0070 ns |         - |
| RequiresNotNull | List<T>     | X                |                   | 0.0012 ns | 0.0025 ns | 0.0023 ns |         - |
| RequiresNotNull | List<T>     |                  | X                 | 1.7117 ns | 0.0305 ns | 0.0285 ns |         - |
| RequiresNotNull | List<T>     | X                | X                 | 2.4327 ns | 0.0197 ns | 0.0175 ns |         - |
| *************** | *********** | **************** | ***************** | ********* | ********* | ********* | ********* |
| EnsuresNotNull  | String      |                  |                   | 0.0040 ns | 0.0057 ns | 0.0053 ns |         - |
| EnsuresNotNull  | String      | X                |                   | 0.0042 ns | 0.0073 ns | 0.0065 ns |         - |
| EnsuresNotNull  | String      |                  | X                 | 1.8425 ns | 0.0131 ns | 0.0116 ns |         - |
| EnsuresNotNull  | String      | X                | X                 | 2.0406 ns | 0.0271 ns | 0.0253 ns |         - |
| EnsuresNotNull  | List<T>     |                  |                   | 0.0030 ns | 0.0061 ns | 0.0051 ns |         - |
| EnsuresNotNull  | List<T>     | X                |                   | 0.0005 ns | 0.0014 ns | 0.0013 ns |         - |
| EnsuresNotNull  | List<T>     |                  | X                 | 1.8339 ns | 0.0122 ns | 0.0102 ns |         - |
| EnsuresNotNull  | List<T>     | X                | X                 | 1.5898 ns | 0.0128 ns | 0.0107 ns |         - |

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

### Equal Benchmarks

|  Method       | Value Type  | Comparer             | Message Template | Exception Factory |       Mean |     Error |    StdDev | Allocated |
|:------------- |:------------|:--------------------:|:----------------:|:-----------------:|-----------:|----------:|----------:|----------:|
| RequiresEqual | Int32       |                      |                  |                   |  1.2221 ns | 0.0527 ns | 0.0704 ns |         - |
| RequiresEqual | Int32       |                      | X                |                   |  3.6139 ns | 0.0283 ns | 0.0265 ns |         - |
| RequiresEqual | Int32       |                      |                  | X                 |  3.2580 ns | 0.0156 ns | 0.0131 ns |         - |
| RequiresEqual | Int32       |                      | X                | X                 |  2.0926 ns | 0.0205 ns | 0.0191 ns |         - |
| RequiresEqual | Int32       | IEqualityComparer<T> |                  |                   |  0.0049 ns | 0.0130 ns | 0.0109 ns |         - |
| RequiresEqual | Int32       | IEqualityComparer<T> | X                |                   |  0.0039 ns | 0.0053 ns | 0.0047 ns |         - |
| RequiresEqual | Int32       | IEqualityComparer<T> |                  | X                 |  0.0025 ns | 0.0039 ns | 0.0036 ns |         - |
| RequiresEqual | Int32       | IEqualityComparer<T> | X                | X                 |  0.0091 ns | 0.0119 ns | 0.0111 ns |         - |
| RequiresEqual | String      |                      |                  |                   |  4.5864 ns | 0.0434 ns | 0.0406 ns |         - |
| RequiresEqual | String      |                      | X                |                   |  4.7503 ns | 0.0643 ns | 0.0602 ns |         - |
| RequiresEqual | String      |                      |                  | X                 |  4.6344 ns | 0.1034 ns | 0.0807 ns |         - |
| RequiresEqual | String      |                      | X                | X                 |  4.4326 ns | 0.0771 ns | 0.0721 ns |         - |
| RequiresEqual | String      | IEqualityComparer<T> |                  |                   |  1.6282 ns | 0.0271 ns | 0.0254 ns |         - |
| RequiresEqual | String      | IEqualityComparer<T> | X                |                   |  1.8676 ns | 0.0274 ns | 0.0242 ns |         - |
| RequiresEqual | String      | IEqualityComparer<T> |                  | X                 |  2.1668 ns | 0.0169 ns | 0.0150 ns |         - |
| RequiresEqual | String      | IEqualityComparer<T> | X                | X                 |  1.9697 ns | 0.0266 ns | 0.0222 ns |         - |
| RequiresEqual | String      | StringComparison     |                  |                   |  1.4707 ns | 0.0186 ns | 0.0155 ns |         - |
| RequiresEqual | String      | StringComparison     | X                |                   |  2.4579 ns | 0.0259 ns | 0.0217 ns |         - |
| RequiresEqual | String      | StringComparison     |                  | X                 |  4.0601 ns | 0.0268 ns | 0.0224 ns |         - |
| RequiresEqual | String      | StringComparison     | X                | X                 |  4.4613 ns | 0.0361 ns | 0.0338 ns |         - |
| RequiresEqual | Record      |                      |                  |                   | 14.1755 ns | 0.1201 ns | 0.1003 ns |         - |
| RequiresEqual | Record      |                      | X                |                   | 14.5214 ns | 0.2156 ns | 0.2017 ns |         - |
| RequiresEqual | Record      |                      |                  | X                 | 14.1793 ns | 0.0670 ns | 0.0626 ns |         - |
| RequiresEqual | Record      |                      | X                | X                 | 14.7373 ns | 0.0807 ns | 0.0754 ns |         - |
| RequiresEqual | Record      | IEqualityComparer<T> |                  |                   |  2.2255 ns | 0.0192 ns | 0.0180 ns |         - |
| RequiresEqual | Record      | IEqualityComparer<T> | X                |                   |  3.1703 ns | 0.0247 ns | 0.0219 ns |         - |
| RequiresEqual | Record      | IEqualityComparer<T> |                  | X                 |  5.6450 ns | 0.0411 ns | 0.0384 ns |         - |
| RequiresEqual | Record      | IEqualityComparer<T> | X                | X                 |  5.7490 ns | 0.0777 ns | 0.0727 ns |         - |
| RequiresEqual | Class       |                      |                  |                   |  8.1012 ns | 0.0730 ns | 0.0647 ns |         - |
| RequiresEqual | Class       |                      | X                |                   |  8.9902 ns | 0.0734 ns | 0.0650 ns |         - |
| RequiresEqual | Class       |                      |                  | X                 |  8.9700 ns | 0.0577 ns | 0.0482 ns |         - |
| RequiresEqual | Class       |                      | X                | X                 |  9.0753 ns | 0.1102 ns | 0.1031 ns |         - |
| RequiresEqual | Class       | IEqualityComparer<T> |                  |                   |  5.0150 ns | 0.0436 ns | 0.0408 ns |         - |
| RequiresEqual | Class       | IEqualityComparer<T> | X                |                   |  4.6248 ns | 0.0259 ns | 0.0229 ns |         - |
| RequiresEqual | Class       | IEqualityComparer<T> |                  | X                 |  8.0629 ns | 0.1107 ns | 0.1036 ns |         - |
| RequiresEqual | Class       | IEqualityComparer<T> | X                | X                 |  7.9168 ns | 0.0600 ns | 0.0501 ns |         - |

### NotEqual Benchmarks

| Method           | Value Type  | Comparer             | Message Template | Exception Factory |      Mean |     Error |    StdDev | Allocated |
|----------------- |:------------|:--------------------:|:----------------:|:-----------------:|----------:|----------:|----------:|----------:|
| RequiresNotEqual | Int32       |                      |                  |                   |  1.535 ns | 0.0274 ns | 0.0256 ns |         - |
| RequiresNotEqual | Int32       |                      | X                |                   |  2.014 ns | 0.0274 ns | 0.0256 ns |         - |
| RequiresNotEqual | Int32       |                      |                  | X                 |  3.267 ns | 0.0195 ns | 0.0183 ns |         - |
| RequiresNotEqual | Int32       |                      | X                | X                 |  2.103 ns | 0.0246 ns | 0.0205 ns |         - |
| RequiresNotEqual | Int32       | IEqualityComparer<T> |                  |                   |  1.930 ns | 0.0484 ns | 0.0404 ns |         - |
| RequiresNotEqual | Int32       | IEqualityComparer<T> | X                |                   |  1.650 ns | 0.0399 ns | 0.0373 ns |         - |
| RequiresNotEqual | Int32       | IEqualityComparer<T> |                  | X                 |  3.695 ns | 0.0998 ns | 0.1298 ns |         - |
| RequiresNotEqual | Int32       | IEqualityComparer<T> | X                | X                 |  4.174 ns | 0.0605 ns | 0.0537 ns |         - |
| RequiresNotEqual | String      |                      |                  |                   |  4.678 ns | 0.0514 ns | 0.0481 ns |         - |
| RequiresNotEqual | String      |                      | X                |                   |  5.045 ns | 0.0691 ns | 0.0612 ns |         - |
| RequiresNotEqual | String      |                      |                  | X                 |  4.932 ns | 0.0485 ns | 0.0405 ns |         - |
| RequiresNotEqual | String      |                      | X                | X                 |  4.895 ns | 0.0669 ns | 0.0593 ns |         - |
| RequiresNotEqual | String      | IEqualityComparer<T> |                  |                   |  5.177 ns | 0.0577 ns | 0.0540 ns |         - |
| RequiresNotEqual | String      | IEqualityComparer<T> | X                |                   |  5.339 ns | 0.0513 ns | 0.0480 ns |         - |
| RequiresNotEqual | String      | IEqualityComparer<T> |                  | X                 |  7.660 ns | 0.1102 ns | 0.1031 ns |         - |
| RequiresNotEqual | String      | IEqualityComparer<T> | X                | X                 |  8.530 ns | 0.1096 ns | 0.1025 ns |         - |
| RequiresNotEqual | String      | StringComparison     |                  |                   |  2.163 ns | 0.0365 ns | 0.0341 ns |         - |
| RequiresNotEqual | String      | StringComparison     | X                |                   |  1.825 ns | 0.0455 ns | 0.0426 ns |         - |
| RequiresNotEqual | String      | StringComparison     |                  | X                 |  4.696 ns | 0.0333 ns | 0.0278 ns |         - |
| RequiresNotEqual | String      | StringComparison     | X                | X                 |  4.744 ns | 0.0589 ns | 0.0551 ns |         - |
| RequiresNotEqual | Record      |                      |                  |                   | 14.131 ns | 0.2875 ns | 0.2689 ns |         - |
| RequiresNotEqual | Record      |                      | X                |                   | 14.839 ns | 0.2608 ns | 0.2439 ns |         - |
| RequiresNotEqual | Record      |                      |                  | X                 | 14.963 ns | 0.1703 ns | 0.1593 ns |         - |
| RequiresNotEqual | Record      |                      | X                | X                 | 14.403 ns | 0.1630 ns | 0.1525 ns |         - |
| RequiresNotEqual | Record      | IEqualityComparer<T> |                  |                   |  3.938 ns | 0.1002 ns | 0.0937 ns |         - |
| RequiresNotEqual | Record      | IEqualityComparer<T> | X                |                   |  4.369 ns | 0.0336 ns | 0.0314 ns |         - |
| RequiresNotEqual | Record      | IEqualityComparer<T> |                  | X                 |  6.247 ns | 0.0599 ns | 0.0560 ns |         - |
| RequiresNotEqual | Record      | IEqualityComparer<T> | X                | X                 |  6.866 ns | 0.0733 ns | 0.0612 ns |         - |
| RequiresNotEqual | Class       |                      |                  |                   |  7.170 ns | 0.0387 ns | 0.0323 ns |         - |
| RequiresNotEqual | Class       |                      | X                |                   |  8.000 ns | 0.0993 ns | 0.0880 ns |         - |
| RequiresNotEqual | Class       |                      |                  | X                 |  8.010 ns | 0.1091 ns | 0.0967 ns |         - |
| RequiresNotEqual | Class       |                      | X                | X                 |  7.085 ns | 0.0857 ns | 0.0760 ns |         - |
| RequiresNotEqual | Class       | IEqualityComparer<T> |                  |                   |  4.629 ns | 0.0545 ns | 0.0510 ns |         - |
| RequiresNotEqual | Class       | IEqualityComparer<T> | X                |                   |  4.593 ns | 0.0475 ns | 0.0444 ns |         - |
| RequiresNotEqual | Class       | IEqualityComparer<T> |                  | X                 |  6.931 ns | 0.0844 ns | 0.0789 ns |         - |
| RequiresNotEqual | Class       | IEqualityComparer<T> | X                | X                 |  6.909 ns | 0.1044 ns | 0.0977 ns |         - |