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
  - [ApproximatelyEqual Benchmarks](#approximatelyequal-benchmarks)
  - [GreaterThan Benchmarks](#greaterthan-benchmarks)
  - [GreaterThanOrEqual Benchmarks](#greaterthanorequal-benchmarks)

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

### ApproximatelyEqual Benchmarks

| Method                     | Value Type | Comparer                  | Message Template | Exception Factory |     Mean |     Error |    StdDev | Allocated |
|--------------------------- |:-----------|:-------------------------:|:----------------:|:-----------------:|---------:|----------:|----------:|----------:|
| RequiresApproximatelyEqual | Double     | Fixed Epsilon Comparer    |                  |                   | 4.991 ns | 0.0467 ns | 0.0414 ns |         - |
| RequiresApproximatelyEqual | Double     | Fixed Epsilon Comparer    | X                |                   | 4.841 ns | 0.0279 ns | 0.0233 ns |         - |
| RequiresApproximatelyEqual | Double     | Fixed Epsilon Comparer    |                  | X                 | 5.344 ns | 0.1348 ns | 0.1753 ns |         - |
| RequiresApproximatelyEqual | Double     | Fixed Epsilon Comparer    | X                | X                 | 5.283 ns | 0.0700 ns | 0.0546 ns |         - |
| RequiresApproximatelyEqual | Double     | Relative Epsilon Comparer |                  |                   | 6.332 ns | 0.1121 ns | 0.1049 ns |         - |
| RequiresApproximatelyEqual | Double     | Relative Epsilon Comparer | X                |                   | 6.748 ns | 0.0824 ns | 0.0771 ns |         - |
| RequiresApproximatelyEqual | Double     | Relative Epsilon Comparer |                  | X                 | 7.569 ns | 0.0590 ns | 0.0493 ns |         - |
| RequiresApproximatelyEqual | Double     | Relative Epsilon Comparer | X                | X                 | 6.154 ns | 0.1515 ns | 0.2359 ns |         - |
| RequiresApproximatelyEqual | Single     | Fixed Epsilon Comparer    |                  |                   | 4.608 ns | 0.0569 ns | 0.0532 ns |         - |
| RequiresApproximatelyEqual | Single     | Fixed Epsilon Comparer    | X                |                   | 4.542 ns | 0.0672 ns | 0.0596 ns |         - |
| RequiresApproximatelyEqual | Single     | Fixed Epsilon Comparer    |                  | X                 | 5.881 ns | 0.1068 ns | 0.0999 ns |         - |
| RequiresApproximatelyEqual | Single     | Fixed Epsilon Comparer    | X                | X                 | 4.582 ns | 0.0416 ns | 0.0390 ns |         - |
| RequiresApproximatelyEqual | Single     | Relative Epsilon Comparer |                  |                   | 6.490 ns | 0.1068 ns | 0.1272 ns |         - |
| RequiresApproximatelyEqual | Single     | Relative Epsilon Comparer | X                |                   | 6.544 ns | 0.0473 ns | 0.0419 ns |         - |
| RequiresApproximatelyEqual | Single     | Relative Epsilon Comparer |                  | X                 | 6.560 ns | 0.0335 ns | 0.0280 ns |         - |
| RequiresApproximatelyEqual | Single     | Relative Epsilon Comparer | X                | X                 | 7.393 ns | 0.0984 ns | 0.0822 ns |         - |

### GreaterThan Benchmarks

| Method              | Value Type  | Comparer         | Message Template | Exception Factory |       Mean |     Error |    StdDev | Allocated |
|-------------------- |:------------|:----------------:|:----------------:|:-----------------:|-----------:|----------:|----------:|----------:|
| RequiresGreaterThan | Int32       |                  |                  |                   |  0.0033 ns | 0.0073 ns | 0.0068 ns |         - |
| RequiresGreaterThan | Int32       |                  | X                |                   |  0.0062 ns | 0.0078 ns | 0.0069 ns |         - |
| RequiresGreaterThan | Int32       |                  |                  | X                 |  1.6264 ns | 0.0053 ns | 0.0049 ns |         - |
| RequiresGreaterThan | Int32       |                  | X                | X                 |  0.0018 ns | 0.0035 ns | 0.0029 ns |         - |
| RequiresGreaterThan | Int32       | IComparer<T>     |                  |                   |  2.6291 ns | 0.0679 ns | 0.0602 ns |         - |
| RequiresGreaterThan | Int32       | IComparer<T>     | X                |                   |  2.4138 ns | 0.0686 ns | 0.0573 ns |         - |
| RequiresGreaterThan | Int32       | IComparer<T>     |                  | X                 |  2.7780 ns | 0.0334 ns | 0.0261 ns |         - |
| RequiresGreaterThan | Int32       | IComparer<T>     | X                | X                 |  2.2379 ns | 0.0337 ns | 0.0315 ns |         - |
| RequiresGreaterThan | String      |                  |                  |                   | 41.4850 ns | 0.3105 ns | 0.2905 ns |         - |
| RequiresGreaterThan | String      |                  | X                |                   | 40.9680 ns | 0.3176 ns | 0.2815 ns |         - |
| RequiresGreaterThan | String      |                  |                  | X                 | 40.3530 ns | 0.5610 ns | 0.5248 ns |         - |
| RequiresGreaterThan | String      |                  | X                | X                 | 42.0430 ns | 0.2408 ns | 0.2134 ns |         - |
| RequiresGreaterThan | String      | IComparer<T>     |                  |                   |  6.7720 ns | 0.0450 ns | 0.0375 ns |         - |
| RequiresGreaterThan | String      | IComparer<T>     | X                |                   |  6.0890 ns | 0.0450 ns | 0.0399 ns |         - |
| RequiresGreaterThan | String      | IComparer<T>     |                  | X                 |  6.8730 ns | 0.0791 ns | 0.0740 ns |         - |
| RequiresGreaterThan | String      | IComparer<T>     | X                | X                 |  7.2860 ns | 0.0827 ns | 0.0773 ns |         - |
| RequiresGreaterThan | String      | StringComparison |                  |                   |  5.6310 ns | 0.0349 ns | 0.0310 ns |         - |
| RequiresGreaterThan | String      | StringComparison | X                |                   |  5.5750 ns | 0.0338 ns | 0.0299 ns |         - |
| RequiresGreaterThan | String      | StringComparison |                  | X                 |  5.5400 ns | 0.0337 ns | 0.0315 ns |         - |
| RequiresGreaterThan | String      | StringComparison | X                | X                 |  6.1180 ns | 0.0340 ns | 0.0318 ns |         - |
| RequiresGreaterThan | Record      |                  |                  |                   |  4.9939 ns | 0.1279 ns | 0.1953 ns |         - |
| RequiresGreaterThan | Record      |                  | X                |                   |  4.6437 ns | 0.0168 ns | 0.0157 ns |         - |
| RequiresGreaterThan | Record      |                  |                  | X                 |  4.7160 ns | 0.0850 ns | 0.0795 ns |         - |
| RequiresGreaterThan | Record      |                  | X                | X                 |  4.7240 ns | 0.0867 ns | 0.0768 ns |         - |
| RequiresGreaterThan | Record      | IComparer<T>     |                  |                   |  6.0640 ns | 0.0488 ns | 0.0432 ns |         - |
| RequiresGreaterThan | Record      | IComparer<T>     | X                |                   |  5.9618 ns | 0.0149 ns | 0.0116 ns |         - |
| RequiresGreaterThan | Record      | IComparer<T>     |                  | X                 |  5.6564 ns | 0.0399 ns | 0.0333 ns |         - |
| RequiresGreaterThan | Record      | IComparer<T>     | X                | X                 |  5.8100 ns | 0.0190 ns | 0.0159 ns |         - |
| RequiresGreaterThan | Class       |                  |                  |                   |  4.8347 ns | 0.0153 ns | 0.0128 ns |         - |
| RequiresGreaterThan | Class       |                  | X                |                   |  5.2207 ns | 0.1325 ns | 0.1361 ns |         - |
| RequiresGreaterThan | Class       |                  |                  | X                 |  5.0445 ns | 0.0219 ns | 0.0183 ns |         - |
| RequiresGreaterThan | Class       |                  | X                | X                 |  5.0650 ns | 0.0236 ns | 0.0221 ns |         - |
| RequiresGreaterThan | Class       | IComparer<T>     |                  |                   |  5.6963 ns | 0.0493 ns | 0.0461 ns |         - |
| RequiresGreaterThan | Class       | IComparer<T>     | X                |                   |  5.7535 ns | 0.0192 ns | 0.0170 ns |         - |
| RequiresGreaterThan | Class       | IComparer<T>     |                  | X                 |  5.9751 ns | 0.0315 ns | 0.0295 ns |         - |
| RequiresGreaterThan | Class       | IComparer<T>     | X                | X                 |  6.1536 ns | 0.0416 ns | 0.0347 ns |         - |

### GreaterThanOrEqual Benchmarks

| Method                     | Value Type  | Comparer         | Message Template | Exception Factory |       Mean |     Error |    StdDev | Allocated |
|--------------------------- |:------------|:----------------:|:----------------:|:-----------------:|-----------:|----------:|----------:|----------:|
| RequiresGreaterThanOrEqual | Int32       |                  |                  |                   |  0.0091 ns | 0.0091 ns | 0.0085 ns |         - |
| RequiresGreaterThanOrEqual | Int32       |                  | X                |                   |  0.0126 ns | 0.0142 ns | 0.0133 ns |         - |
| RequiresGreaterThanOrEqual | Int32       |                  |                  | X                 |  2.4577 ns | 0.0328 ns | 0.0256 ns |         - |
| RequiresGreaterThanOrEqual | Int32       |                  | X                | X                 |  2.7125 ns | 0.0464 ns | 0.0434 ns |         - |
| RequiresGreaterThanOrEqual | Int32       | IComparer<T>     |                  |                   |  2.8699 ns | 0.0416 ns | 0.0325 ns |         - |
| RequiresGreaterThanOrEqual | Int32       | IComparer<T>     | X                |                   |  2.2878 ns | 0.0469 ns | 0.0416 ns |         - |
| RequiresGreaterThanOrEqual | Int32       | IComparer<T>     |                  | X                 |  2.9088 ns | 0.0432 ns | 0.0361 ns |         - |
| RequiresGreaterThanOrEqual | Int32       | IComparer<T>     | X                | X                 |  2.5619 ns | 0.0434 ns | 0.0406 ns |         - |
| RequiresGreaterThanOrEqual | String      |                  |                  |                   | 42.4940 ns | 0.8842 ns | 0.9081 ns |         - |
| RequiresGreaterThanOrEqual | String      |                  | X                |                   | 43.0879 ns | 0.8943 ns | 2.1599 ns |         - |
| RequiresGreaterThanOrEqual | String      |                  |                  | X                 | 45.1511 ns | 0.7607 ns | 0.7116 ns |         - |
| RequiresGreaterThanOrEqual | String      |                  | X                | X                 | 43.1631 ns | 0.8707 ns | 0.9678 ns |         - |
| RequiresGreaterThanOrEqual | String      | IComparer<T>     |                  |                   |  7.2533 ns | 0.2058 ns | 0.6035 ns |         - |
| RequiresGreaterThanOrEqual | String      | IComparer<T>     | X                |                   |  7.2371 ns | 0.1720 ns | 0.2521 ns |         - |
| RequiresGreaterThanOrEqual | String      | IComparer<T>     |                  | X                 |  7.8608 ns | 0.1682 ns | 0.3076 ns |         - |
| RequiresGreaterThanOrEqual | String      | IComparer<T>     | X                | X                 |  7.8060 ns | 0.1448 ns | 0.1209 ns |         - |
| RequiresGreaterThanOrEqual | String      | StringComparison |                  |                   |  5.8433 ns | 0.1454 ns | 0.3162 ns |         - |
| RequiresGreaterThanOrEqual | String      | StringComparison | X                |                   |  6.1645 ns | 0.1511 ns | 0.2353 ns |         - |
| RequiresGreaterThanOrEqual | String      | StringComparison |                  | X                 |  6.8419 ns | 0.2489 ns | 0.7101 ns |         - |
| RequiresGreaterThanOrEqual | String      | StringComparison | X                | X                 |  6.0659 ns | 0.1236 ns | 0.1156 ns |         - |
| RequiresGreaterThanOrEqual | Record      |                  |                  |                   |  6.6181 ns | 0.0839 ns | 0.0785 ns |         - |
| RequiresGreaterThanOrEqual | Record      |                  | X                |                   |  7.2732 ns | 0.1591 ns | 0.1488 ns |         - |
| RequiresGreaterThanOrEqual | Record      |                  |                  | X                 |  7.1189 ns | 0.1120 ns | 0.1048 ns |         - |
| RequiresGreaterThanOrEqual | Record      |                  | X                | X                 |  7.1882 ns | 0.0420 ns | 0.0328 ns |         - |
| RequiresGreaterThanOrEqual | Record      | IComparer<T>     |                  |                   |  5.7632 ns | 0.0809 ns | 0.0756 ns |         - |
| RequiresGreaterThanOrEqual | Record      | IComparer<T>     | X                |                   |  5.6692 ns | 0.0541 ns | 0.0506 ns |         - |
| RequiresGreaterThanOrEqual | Record      | IComparer<T>     |                  | X                 |  6.1206 ns | 0.0767 ns | 0.0640 ns |         - |
| RequiresGreaterThanOrEqual | Record      | IComparer<T>     | X                | X                 |  6.3007 ns | 0.0832 ns | 0.0650 ns |         - |
| RequiresGreaterThanOrEqual | Class       |                  |                  |                   |  6.9214 ns | 0.0762 ns | 0.0713 ns |         - |
| RequiresGreaterThanOrEqual | Class       |                  | X                |                   |  7.2330 ns | 0.1152 ns | 0.1078 ns |         - |
| RequiresGreaterThanOrEqual | Class       |                  |                  | X                 |  7.1900 ns | 0.0622 ns | 0.0519 ns |         - |
| RequiresGreaterThanOrEqual | Class       |                  | X                | X                 |  7.3473 ns | 0.1689 ns | 0.1735 ns |         - |
| RequiresGreaterThanOrEqual | Class       | IComparer<T>     |                  |                   |  5.7619 ns | 0.0838 ns | 0.0784 ns |         - |
| RequiresGreaterThanOrEqual | Class       | IComparer<T>     | X                |                   |  5.9492 ns | 0.0894 ns | 0.0793 ns |         - |
| RequiresGreaterThanOrEqual | Class       | IComparer<T>     |                  | X                 |  6.1544 ns | 0.0711 ns | 0.0665 ns |         - |
| RequiresGreaterThanOrEqual | Class       | IComparer<T>     | X                | X                 |  5.7887 ns | 0.0562 ns | 0.0526 ns |         - |

