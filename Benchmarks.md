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
  - [LessThan Benchmarks](#lessthan-benchmarks)
  - [LessThanOrEqual Benchmarks](#lessthanorequal-benchmarks)
  - [Between Benchmarks](#between-benchmarks)
  - [GreaterThanZero Benchmarks](#greaterthanzero-benchmarks)
  - [GreaterThanOrEqualToZero Benchmarks](#greaterthanorequaltozero-benchmarks)
  - [LessThanZero Benchmarks](#lessthanzero-benchmarks)
  - [LessThanOrEqualToZero Benchmarks](#lessthanorequaltozero-benchmarks)

  - [MaxLength Benchmarks](#maxlength-benchmarks)
  - [MinLength Benchmarks](#minlength-benchmarks)
  - [NotNullOrEmpty Benchmarks](#notnullorempty-benchmarks)
  - [NotNullOrWhiteSpace Benchmarks](#notnullorwhitespace-benchmarks)
  - [NotEmptyOrWhiteSpace Benchmarks](#notemptyorwhitespace-benchmarks)
  - [AlphaNumericOnly Benchmarks](#alphanumericonly-benchmarks)

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

### LessThan Benchmarks

| Method           | Value Type  | Comparer         | Message Template | Exception Factory |       Mean |     Error |    StdDev | Allocated |
|----------------- |:------------|:----------------:|:----------------:|:-----------------:|-----------:|----------:|----------:|----------:|
| RequiresLessThan | Int32       |                  |                  |                   |  0.0049 ns | 0.0086 ns | 0.0076 ns |         - |
| RequiresLessThan | Int32       |                  | X                |                   |  0.0063 ns | 0.0096 ns | 0.0085 ns |         - |
| RequiresLessThan | Int32       |                  |                  | X                 |  2.2213 ns | 0.0309 ns | 0.0274 ns |         - |
| RequiresLessThan | Int32       |                  | X                | X                 |  2.0005 ns | 0.0209 ns | 0.0185 ns |         - |
| RequiresLessThan | Int32       | IComparer<T>     |                  |                   |  2.7763 ns | 0.0169 ns | 0.0141 ns |         - |
| RequiresLessThan | Int32       | IComparer<T>     | X                |                   |  2.3148 ns | 0.0290 ns | 0.0272 ns |         - |
| RequiresLessThan | Int32       | IComparer<T>     |                  | X                 |  3.0788 ns | 0.0880 ns | 0.0903 ns |         - |
| RequiresLessThan | Int32       | IComparer<T>     | X                | X                 |  2.9196 ns | 0.0886 ns | 0.2139 ns |         - |
| RequiresLessThan | String      |                  |                  |                   | 41.9424 ns | 0.6503 ns | 0.6083 ns |         - |
| RequiresLessThan | String      |                  | X                |                   | 52.3400 ns | 1.0718 ns | 3.0054 ns |         - |
| RequiresLessThan | String      |                  |                  | X                 | 42.3073 ns | 0.6900 ns | 0.6117 ns |         - |
| RequiresLessThan | String      |                  | X                | X                 | 43.9661 ns | 0.9066 ns | 2.0278 ns |         - |
| RequiresLessThan | String      | IComparer<T>     |                  |                   |  7.4133 ns | 0.1780 ns | 0.3164 ns |         - |
| RequiresLessThan | String      | IComparer<T>     | X                |                   |  7.2638 ns | 0.1605 ns | 0.1784 ns |         - |
| RequiresLessThan | String      | IComparer<T>     |                  | X                 |  8.3081 ns | 0.2083 ns | 0.5874 ns |         - |
| RequiresLessThan | String      | IComparer<T>     | X                | X                 |  7.7006 ns | 0.0727 ns | 0.0644 ns |         - |
| RequiresLessThan | String      | StringComparison |                  |                   |  5.5466 ns | 0.0423 ns | 0.0375 ns |         - |
| RequiresLessThan | String      | StringComparison | X                |                   |  5.8392 ns | 0.0410 ns | 0.0364 ns |         - |
| RequiresLessThan | String      | StringComparison |                  | X                 |  6.1740 ns | 0.0831 ns | 0.0777 ns |         - |
| RequiresLessThan | String      | StringComparison | X                | X                 |  5.9900 ns | 0.0700 ns | 0.0585 ns |         - |
| RequiresLessThan | Record      |                  |                  |                   |  6.4274 ns | 0.0426 ns | 0.0378 ns |         - |
| RequiresLessThan | Record      |                  | X                |                   |  7.3372 ns | 0.1296 ns | 0.1212 ns |         - |
| RequiresLessThan | Record      |                  |                  | X                 |  7.2741 ns | 0.0362 ns | 0.0321 ns |         - |
| RequiresLessThan | Record      |                  | X                | X                 |  7.3785 ns | 0.0390 ns | 0.0346 ns |         - |
| RequiresLessThan | Record      | IComparer<T>     |                  |                   |  5.4820 ns | 0.0430 ns | 0.0402 ns |         - |
| RequiresLessThan | Record      | IComparer<T>     | X                |                   |  5.6602 ns | 0.0528 ns | 0.0494 ns |         - |
| RequiresLessThan | Record      | IComparer<T>     |                  | X                 |  5.9396 ns | 0.0528 ns | 0.0468 ns |         - |
| RequiresLessThan | Record      | IComparer<T>     | X                | X                 |  5.9010 ns | 0.0215 ns | 0.0180 ns |         - |
| RequiresLessThan | Class       |                  |                  |                   |  6.5335 ns | 0.0429 ns | 0.0381 ns |         - |
| RequiresLessThan | Class       |                  | X                |                   |  7.2292 ns | 0.0746 ns | 0.0662 ns |         - |
| RequiresLessThan | Class       |                  |                  | X                 |  7.2350 ns | 0.0362 ns | 0.0339 ns |         - |
| RequiresLessThan | Class       |                  | X                | X                 |  7.1378 ns | 0.0292 ns | 0.0259 ns |         - |
| RequiresLessThan | Class       | IComparer<T>     |                  |                   |  5.6671 ns | 0.0455 ns | 0.0403 ns |         - |
| RequiresLessThan | Class       | IComparer<T>     | X                |                   |  5.6437 ns | 0.0316 ns | 0.0280 ns |         - |
| RequiresLessThan | Class       | IComparer<T>     |                  | X                 |  5.7431 ns | 0.0508 ns | 0.0475 ns |         - |
| RequiresLessThan | Class       | IComparer<T>     | X                | X                 |  5.6304 ns | 0.0434 ns | 0.0406 ns |         - |

### LessThanOrEqual Benchmarks

| Method                  | Value Type  | Comparer         | Message Template | Exception Factory |       Mean |     Error |    StdDev | Allocated |
|------------------------ |:------------|:----------------:|:----------------:|:-----------------:|-----------:|----------:|----------:|----------:|
| RequiresLessThanOrEqual | Int32       |                  |                  |                   |  0.0032 ns | 0.0038 ns | 0.0032 ns |         - |
| RequiresLessThanOrEqual | Int32       |                  | X                |                   |  0.0046 ns | 0.0060 ns | 0.0056 ns |         - |
| RequiresLessThanOrEqual | Int32       |                  |                  | X                 |  2.2491 ns | 0.0251 ns | 0.0235 ns |         - |
| RequiresLessThanOrEqual | Int32       |                  | X                | X                 |  1.9912 ns | 0.0129 ns | 0.0121 ns |         - |
| RequiresLessThanOrEqual | Int32       | IComparer<T>     |                  |                   |  2.7751 ns | 0.0231 ns | 0.0216 ns |         - |
| RequiresLessThanOrEqual | Int32       | IComparer<T>     | X                |                   |  2.2859 ns | 0.0153 ns | 0.0135 ns |         - |
| RequiresLessThanOrEqual | Int32       | IComparer<T>     |                  | X                 |  3.0145 ns | 0.0532 ns | 0.0444 ns |         - |
| RequiresLessThanOrEqual | Int32       | IComparer<T>     | X                | X                 |  2.7113 ns | 0.0612 ns | 0.0752 ns |         - |
| RequiresLessThanOrEqual | String      |                  |                  |                   | 40.2086 ns | 0.8267 ns | 1.1316 ns |         - |
| RequiresLessThanOrEqual | String      |                  | X                |                   | 41.6270 ns | 0.7159 ns | 0.6346 ns |         - |
| RequiresLessThanOrEqual | String      |                  |                  | X                 | 43.7436 ns | 0.8791 ns | 0.8633 ns |         - |
| RequiresLessThanOrEqual | String      |                  | X                | X                 | 42.5799 ns | 0.6806 ns | 0.6367 ns |         - |
| RequiresLessThanOrEqual | String      | IComparer<T>     |                  |                   |  7.1765 ns | 0.1537 ns | 0.1888 ns |         - |
| RequiresLessThanOrEqual | String      | IComparer<T>     | X                |                   |  7.2017 ns | 0.1673 ns | 0.1790 ns |         - |
| RequiresLessThanOrEqual | String      | IComparer<T>     |                  | X                 |  8.2092 ns | 0.1942 ns | 0.3024 ns |         - |
| RequiresLessThanOrEqual | String      | IComparer<T>     | X                | X                 |  7.8686 ns | 0.1794 ns | 0.1762 ns |         - |
| RequiresLessThanOrEqual | String      | StringComparison |                  |                   |  5.5717 ns | 0.0273 ns | 0.0228 ns |         - |
| RequiresLessThanOrEqual | String      | StringComparison | X                |                   |  6.0956 ns | 0.1475 ns | 0.1755 ns |         - |
| RequiresLessThanOrEqual | String      | StringComparison |                  | X                 |  6.3769 ns | 0.1430 ns | 0.1267 ns |         - |
| RequiresLessThanOrEqual | String      | StringComparison | X                | X                 |  5.9994 ns | 0.0777 ns | 0.0727 ns |         - |
| RequiresLessThanOrEqual | Record      |                  |                  |                   |  6.5428 ns | 0.1601 ns | 0.1644 ns |         - |
| RequiresLessThanOrEqual | Record      |                  | X                |                   |  7.2435 ns | 0.0858 ns | 0.0670 ns |         - |
| RequiresLessThanOrEqual | Record      |                  |                  | X                 |  7.2417 ns | 0.1708 ns | 0.2557 ns |         - |
| RequiresLessThanOrEqual | Record      |                  | X                | X                 |  7.2571 ns | 0.1708 ns | 0.1598 ns |         - |
| RequiresLessThanOrEqual | Record      | IComparer<T>     |                  |                   |  5.5694 ns | 0.0846 ns | 0.0750 ns |         - |
| RequiresLessThanOrEqual | Record      | IComparer<T>     | X                |                   |  5.6697 ns | 0.1401 ns | 0.1376 ns |         - |
| RequiresLessThanOrEqual | Record      | IComparer<T>     |                  | X                 |  5.8552 ns | 0.0326 ns | 0.0272 ns |         - |
| RequiresLessThanOrEqual | Record      | IComparer<T>     | X                | X                 |  5.9280 ns | 0.0484 ns | 0.0429 ns |         - |
| RequiresLessThanOrEqual | Class       |                  |                  |                   |  6.4110 ns | 0.0327 ns | 0.0290 ns |         - |
| RequiresLessThanOrEqual | Class       |                  | X                |                   |  6.8122 ns | 0.0495 ns | 0.0439 ns |         - |
| RequiresLessThanOrEqual | Class       |                  |                  | X                 |  6.7991 ns | 0.0440 ns | 0.0412 ns |         - |
| RequiresLessThanOrEqual | Class       |                  | X                | X                 |  6.9434 ns | 0.0571 ns | 0.0534 ns |         - |
| RequiresLessThanOrEqual | Class       | IComparer<T>     |                  |                   |  5.5902 ns | 0.0259 ns | 0.0230 ns |         - |
| RequiresLessThanOrEqual | Class       | IComparer<T>     | X                |                   |  5.6048 ns | 0.0365 ns | 0.0342 ns |         - |
| RequiresLessThanOrEqual | Class       | IComparer<T>     |                  | X                 |  5.7207 ns | 0.0546 ns | 0.0511 ns |         - |
| RequiresLessThanOrEqual | Class       | IComparer<T>     | X                | X                 |  5.5950 ns | 0.0395 ns | 0.0350 ns |         - |

### Between Benchmarks

| Method          | Value Type  | Comparer         | Message Template | Exception Factory |       Mean |     Error |    StdDev | Allocated |
|---------------- |:------------|:----------------:|:----------------:|:-----------------:|-----------:|----------:|----------:|----------:|
| RequiresBetween | Int32       |                  |                  |                   |   2.491 ns | 0.0443 ns | 0.0392 ns |         - |
| RequiresBetween | Int32       |                  | X                |                   |   2.467 ns | 0.0346 ns | 0.0307 ns |         - |
| RequiresBetween | Int32       |                  |                  | X                 |   3.918 ns | 0.0432 ns | 0.0383 ns |         - |
| RequiresBetween | Int32       |                  | X                | X                 |   2.472 ns | 0.0280 ns | 0.0219 ns |         - |
| RequiresBetween | Int32       | IComparer<T>     |                  |                   |   3.272 ns | 0.0427 ns | 0.0379 ns |         - |
| RequiresBetween | Int32       | IComparer<T>     | X                |                   |   3.266 ns | 0.0212 ns | 0.0177 ns |         - |
| RequiresBetween | Int32       | IComparer<T>     |                  | X                 |   3.069 ns | 0.0661 ns | 0.0586 ns |         - |
| RequiresBetween | Int32       | IComparer<T>     | X                | X                 |   3.055 ns | 0.0454 ns | 0.0425 ns |         - |
| RequiresBetween | String      |                  |                  |                   | 128.068 ns | 1.4173 ns | 1.2564 ns |         - |
| RequiresBetween | String      |                  | X                |                   | 121.275 ns | 1.8087 ns | 1.6918 ns |         - |
| RequiresBetween | String      |                  |                  | X                 | 124.305 ns | 2.2006 ns | 1.9508 ns |         - |
| RequiresBetween | String      |                  | X                | X                 | 124.494 ns | 0.9860 ns | 0.8741 ns |         - |
| RequiresBetween | String      | IComparer<T>     |                  |                   |  17.865 ns | 0.3836 ns | 0.3940 ns |         - |
| RequiresBetween | String      | IComparer<T>     | X                |                   |  18.473 ns | 0.3983 ns | 0.5037 ns |         - |
| RequiresBetween | String      | IComparer<T>     |                  | X                 |  18.568 ns | 0.3336 ns | 0.3276 ns |         - |
| RequiresBetween | String      | IComparer<T>     | X                | X                 |  18.770 ns | 0.3832 ns | 0.5496 ns |         - |
| RequiresBetween | String      | StringComparison |                  |                   |  16.232 ns | 0.2028 ns | 0.1897 ns |         - |
| RequiresBetween | String      | StringComparison | X                |                   |  16.067 ns | 0.2067 ns | 0.1933 ns |         - |
| RequiresBetween | String      | StringComparison |                  | X                 |  16.931 ns | 0.3585 ns | 0.3521 ns |         - |
| RequiresBetween | String      | StringComparison | X                | X                 |  16.729 ns | 0.3632 ns | 0.3033 ns |         - |
| RequiresBetween | Record      |                  |                  |                   |  17.307 ns | 0.3741 ns | 0.5600 ns |         - |
| RequiresBetween | Record      |                  | X                |                   |  18.629 ns | 0.3954 ns | 0.6038 ns |         - |
| RequiresBetween | Record      |                  |                  | X                 |  18.928 ns | 0.4022 ns | 0.4131 ns |         - |
| RequiresBetween | Record      |                  | X                | X                 |  18.108 ns | 0.3135 ns | 0.2932 ns |         - |
| RequiresBetween | Record      | IComparer<T>     |                  |                   |  14.815 ns | 0.1416 ns | 0.1255 ns |         - |
| RequiresBetween | Record      | IComparer<T>     | X                |                   |  13.376 ns | 0.2883 ns | 0.2697 ns |         - |
| RequiresBetween | Record      | IComparer<T>     |                  | X                 |  13.866 ns | 0.1943 ns | 0.1622 ns |         - |
| RequiresBetween | Record      | IComparer<T>     | X                | X                 |  13.559 ns | 0.2487 ns | 0.2204 ns |         - |
| RequiresBetween | Class       |                  |                  |                   |  17.053 ns | 0.2911 ns | 0.3465 ns |         - |
| RequiresBetween | Class       |                  | X                |                   |  17.399 ns | 0.3774 ns | 0.4194 ns |         - |
| RequiresBetween | Class       |                  |                  | X                 |  17.603 ns | 0.3686 ns | 0.3620 ns |         - |
| RequiresBetween | Class       |                  | X                | X                 |  17.180 ns | 0.3736 ns | 0.3119 ns |         - |
| RequiresBetween | Class       | IComparer<T>     |                  |                   |  14.042 ns | 0.2933 ns | 0.4206 ns |         - |
| RequiresBetween | Class       | IComparer<T>     | X                |                   |  13.202 ns | 0.1368 ns | 0.1213 ns |         - |
| RequiresBetween | Class       | IComparer<T>     |                  | X                 |  13.560 ns | 0.2960 ns | 0.5106 ns |         - |
| RequiresBetween | Class       | IComparer<T>     | X                | X                 |  13.211 ns | 0.1913 ns | 0.1696 ns |         - |

### GreaterThanZero Benchmarks

| Method                  | Value Type  | Message Template | Exception Factory |      Mean |     Error |    StdDev | Allocated |
|:----------------------- |:------------|:----------------:|:-----------------:|----------:|----------:|----------:|----------:|
| RequiresGreaterThanZero | Int32       |                  |                   | 0.2333 ns | 0.0194 ns | 0.0181 ns |         - |
| RequiresGreaterThanZero | Int32       | X                |                   | 0.4801 ns | 0.0157 ns | 0.0140 ns |         - |
| RequiresGreaterThanZero | Int32       |                  | X                 | 2.1925 ns | 0.0659 ns | 0.0617 ns |         - |
| RequiresGreaterThanZero | Int32       | X                | X                 | 1.7096 ns | 0.0329 ns | 0.0308 ns |         - |
| RequiresGreaterThanZero | Double      |                  |                   | 0.6312 ns | 0.0198 ns | 0.0185 ns |         - |
| RequiresGreaterThanZero | Double      | X                |                   | 0.9438 ns | 0.0115 ns | 0.0102 ns |         - |
| RequiresGreaterThanZero | Double      |                  | X                 | 2.0147 ns | 0.0189 ns | 0.0177 ns |         - |
| RequiresGreaterThanZero | Double      | X                | X                 | 2.0258 ns | 0.0251 ns | 0.0235 ns |         - |
| RequiresGreaterThanZero | Decimal     |                  |                   | 2.4109 ns | 0.0531 ns | 0.0471 ns |         - |
| RequiresGreaterThanZero | Decimal     | X                |                   | 2.1276 ns | 0.0199 ns | 0.0177 ns |         - |
| RequiresGreaterThanZero | Decimal     |                  | X                 | 3.9250 ns | 0.0179 ns | 0.0158 ns |         - |
| RequiresGreaterThanZero | Decimal     | X                | X                 | 3.9672 ns | 0.0404 ns | 0.0359 ns |         - |

### GreaterThanOrEqualToZero Benchmarks

| Method                           | Value Type  | Message Template | Exception Factory |      Mean |     Error |    StdDev | Allocated |
|:-------------------------------- |:------------|:----------------:|:-----------------:|----------:|----------:|----------:|----------:|
| RequiresGreaterThanOrEqualToZero | Int32       |                  |                   | 0.2676 ns | 0.0204 ns | 0.0191 ns |         - |
| RequiresGreaterThanOrEqualToZero | Int32       | X                |                   | 0.5805 ns | 0.0294 ns | 0.0275 ns |         - |
| RequiresGreaterThanOrEqualToZero | Int32       |                  | X                 | 2.3188 ns | 0.0755 ns | 0.0706 ns |         - |
| RequiresGreaterThanOrEqualToZero | Int32       | X                | X                 | 1.8308 ns | 0.0334 ns | 0.0312 ns |         - |
| RequiresGreaterThanOrEqualToZero | Double      |                  |                   | 0.6458 ns | 0.0175 ns | 0.0156 ns |         - |
| RequiresGreaterThanOrEqualToZero | Double      | X                |                   | 0.6677 ns | 0.0153 ns | 0.0143 ns |         - |
| RequiresGreaterThanOrEqualToZero | Double      |                  | X                 | 1.9825 ns | 0.0244 ns | 0.0216 ns |         - |
| RequiresGreaterThanOrEqualToZero | Double      | X                | X                 | 2.0095 ns | 0.0128 ns | 0.0107 ns |         - |
| RequiresGreaterThanOrEqualToZero | Decimal     |                  |                   | 2.3769 ns | 0.0642 ns | 0.0600 ns |         - |
| RequiresGreaterThanOrEqualToZero | Decimal     | X                |                   | 2.2519 ns | 0.0247 ns | 0.0219 ns |         - |
| RequiresGreaterThanOrEqualToZero | Decimal     |                  | X                 | 4.1155 ns | 0.0505 ns | 0.0472 ns |         - |
| RequiresGreaterThanOrEqualToZero | Decimal     | X                | X                 | 3.9699 ns | 0.0422 ns | 0.0374 ns |         - |

### LessThanZero Benchmarks

| Method           | Value Type  | Message Template | Exception Factory |      Mean |     Error |    StdDev | Allocated |
|:---------------- |:------------|:----------------:|:-----------------:|----------:|----------:|----------:|----------:|
| RequiresThanZero | Int32       |                  |                   | 0.2510 ns | 0.0234 ns | 0.0208 ns |         - |
| RequiresThanZero | Int32       | X                |                   | 0.4442 ns | 0.0105 ns | 0.0082 ns |         - |
| RequiresThanZero | Int32       |                  | X                 | 2.1038 ns | 0.0333 ns | 0.0311 ns |         - |
| RequiresThanZero | Int32       | X                | X                 | 1.6793 ns | 0.0328 ns | 0.0291 ns |         - |
| RequiresThanZero | Double      |                  |                   | 0.9623 ns | 0.0478 ns | 0.0491 ns |         - |
| RequiresThanZero | Double      | X                |                   | 0.6556 ns | 0.0275 ns | 0.0258 ns |         - |
| RequiresThanZero | Double      |                  | X                 | 1.8240 ns | 0.0408 ns | 0.0382 ns |         - |
| RequiresThanZero | Double      | X                | X                 | 2.2645 ns | 0.0341 ns | 0.0319 ns |         - |
| RequiresThanZero | Decimal     |                  |                   | 2.3017 ns | 0.0361 ns | 0.0320 ns |         - |
| RequiresThanZero | Decimal     | X                |                   | 2.2129 ns | 0.0400 ns | 0.0374 ns |         - |
| RequiresThanZero | Decimal     |                  | X                 | 4.3049 ns | 0.0358 ns | 0.0335 ns |         - |
| RequiresThanZero | Decimal     | X                | X                 | 4.1347 ns | 0.0837 ns | 0.0783 ns |         - |

### LessThanOrEqualToZero Benchmarks

| Method                        | Value Type  | Message Template | Exception Factory |      Mean |     Error |    StdDev | Allocated |
|:----------------------------- |:------------|:----------------:|:-----------------:|----------:|----------:|----------:|----------:|
| RequiresLessThanOrEqualToZero | Int32       |                  |                   | 0.2472 ns | 0.0207 ns | 0.0194 ns |         - |
| RequiresLessThanOrEqualToZero | Int32       | X                |                   | 0.4837 ns | 0.0373 ns | 0.0349 ns |         - |
| RequiresLessThanOrEqualToZero | Int32       |                  | X                 | 2.2319 ns | 0.0515 ns | 0.0430 ns |         - |
| RequiresLessThanOrEqualToZero | Int32       | X                | X                 | 1.7007 ns | 0.0369 ns | 0.0328 ns |         - |
| RequiresLessThanOrEqualToZero | Double      |                  |                   | 0.9152 ns | 0.0125 ns | 0.0117 ns |         - |
| RequiresLessThanOrEqualToZero | Double      | X                |                   | 0.6585 ns | 0.0186 ns | 0.0174 ns |         - |
| RequiresLessThanOrEqualToZero | Double      |                  | X                 | 1.8286 ns | 0.0418 ns | 0.0371 ns |         - |
| RequiresLessThanOrEqualToZero | Double      | X                | X                 | 2.3557 ns | 0.0764 ns | 0.1070 ns |         - |
| RequiresLessThanOrEqualToZero | Decimal     |                  |                   | 2.5296 ns | 0.0844 ns | 0.2407 ns |         - |
| RequiresLessThanOrEqualToZero | Decimal     | X                |                   | 2.5169 ns | 0.0819 ns | 0.1434 ns |         - |
| RequiresLessThanOrEqualToZero | Decimal     |                  | X                 | 4.6693 ns | 0.1231 ns | 0.2569 ns |         - |
| RequiresLessThanOrEqualToZero | Decimal     | X                | X                 | 4.3924 ns | 0.1172 ns | 0.2852 ns |         - |

### MaxLength Benchmarks

| Method            | String content              | Message Template | Exception Factory |      Mean |     Error |    StdDev | Allocated |
|:----------------- |:----------------------------|:----------------:|:-----------------:|----------:|----------:|----------:|----------:|
| RequiresMaxLength | Non-empty string            |                  |                   | 0.0070 ns | 0.0112 ns | 0.0105 ns |         - |
| RequiresMaxLength | Non-empty string            | X                |                   | 0.0280 ns | 0.0280 ns | 0.0262 ns |         - |
| RequiresMaxLength | Non-empty string            |                  | X                 | 2.6625 ns | 0.0476 ns | 0.0445 ns |         - |
| RequiresMaxLength | Non-empty string            | X                | X                 | 2.5481 ns | 0.0178 ns | 0.0158 ns |         - |
| RequiresMaxLength | String w/Unicode characters |                  |                   | 0.0095 ns | 0.0108 ns | 0.0101 ns |         - |
| RequiresMaxLength | String w/Unicode characters | X                |                   | 0.0078 ns | 0.0077 ns | 0.0064 ns |         - |
| RequiresMaxLength | String w/Unicode characters |                  | X                 | 2.8855 ns | 0.0447 ns | 0.0396 ns |         - |
| RequiresMaxLength | String w/Unicode characters | X                | X                 | 2.6974 ns | 0.0271 ns | 0.0240 ns |         - |
| RequiresMaxLength | Null String                 |                  |                   | 0.0017 ns | 0.0040 ns | 0.0035 ns |         - |
| RequiresMaxLength | Null String                 | X                |                   | 0.0065 ns | 0.0116 ns | 0.0103 ns |         - |
| RequiresMaxLength | Null String                 |                  | X                 | 2.5399 ns | 0.0218 ns | 0.0182 ns |         - |
| RequiresMaxLength | Null String                 | X                | X                 | 2.4789 ns | 0.0114 ns | 0.0101 ns |         - |
| RequiresMaxLength | Empty String                |                  |                   | 0.0032 ns | 0.0044 ns | 0.0041 ns |         - |
| RequiresMaxLength | Empty String                | X                |                   | 0.0115 ns | 0.0162 ns | 0.0152 ns |         - |
| RequiresMaxLength | Empty String                |                  | X                 | 2.8678 ns | 0.0251 ns | 0.0223 ns |         - |
| RequiresMaxLength | Empty String                | X                | X                 | 2.6799 ns | 0.0155 ns | 0.0129 ns |         - |

### MinLength Benchmarks

| Method            | String content              | Message Template | Exception Factory |      Mean |     Error |    StdDev | Allocated |
|:----------------- |:----------------------------|:----------------:|:-----------------:|----------:|----------:|----------:|----------:|
| RequiresMinLength | Non-empty string            |                  |                   | 0.0003 ns | 0.0011 ns | 0.0009 ns |         - |
| RequiresMinLength | Non-empty string            | X                |                   | 0.0002 ns | 0.0009 ns | 0.0008 ns |         - |
| RequiresMinLength | Non-empty string            |                  | X                 | 2.6453 ns | 0.0178 ns | 0.0149 ns |         - |
| RequiresMinLength | Non-empty string            | X                | X                 | 2.5455 ns | 0.0158 ns | 0.0132 ns |         - |
| RequiresMinLength | String w/Unicode characters |                  |                   | 0.0033 ns | 0.0071 ns | 0.0059 ns |         - |
| RequiresMinLength | String w/Unicode characters | X                |                   | 0.0022 ns | 0.0043 ns | 0.0038 ns |         - |
| RequiresMinLength | String w/Unicode characters |                  | X                 | 2.8725 ns | 0.0290 ns | 0.0257 ns |         - |
| RequiresMinLength | String w/Unicode characters | X                | X                 | 2.7093 ns | 0.0272 ns | 0.0241 ns |         - |
| RequiresMinLength | Null String                 |                  |                   | 0.0045 ns | 0.0078 ns | 0.0073 ns |         - |
| RequiresMinLength | Null String                 | X                |                   | 0.0051 ns | 0.0062 ns | 0.0058 ns |         - |
| RequiresMinLength | Null String                 |                  | X                 | 2.5437 ns | 0.0321 ns | 0.0300 ns |         - |
| RequiresMinLength | Null String                 | X                | X                 | 2.7542 ns | 0.0762 ns | 0.0713 ns |         - |
| RequiresMinLength | Empty String                |                  |                   | 0.0001 ns | 0.0002 ns | 0.0002 ns |         - |
| RequiresMinLength | Empty String                | X                |                   | 0.0008 ns | 0.0019 ns | 0.0017 ns |         - |
| RequiresMinLength | Empty String                |                  | X                 | 2.6954 ns | 0.0259 ns | 0.0230 ns |         - |
| RequiresMinLength | Empty String                | X                | X                 | 2.6405 ns | 0.0316 ns | 0.0264 ns |         - |

### NotNullOrEmpty Benchmarks

| Method                 | Message Template | Null Exception Factory | Empty Exception Factory |      Mean |     Error |    StdDev | Allocated |
|:---------------------- |:----------------:|:----------------------:|:-----------------------:|----------:|----------:|----------:|----------:|
| RequiresNotNullOrEmpty |                  |                        |                         | 0.0016 ns | 0.0038 ns | 0.0034 ns |         - |
| RequiresNotNullOrEmpty | X                |                        |                         | 0.0074 ns | 0.0098 ns | 0.0082 ns |         - |
| RequiresNotNullOrEmpty |                  | X                      |                         | 0.0051 ns | 0.0066 ns | 0.0062 ns |         - |
| RequiresNotNullOrEmpty |                  |                        | X                       | 0.0067 ns | 0.0090 ns | 0.0084 ns |         - |
| RequiresNotNullOrEmpty |                  | X                      | X                       | 0.0060 ns | 0.0077 ns | 0.0068 ns |         - |
| RequiresNotNullOrEmpty | X                | X                      |                         | 0.0485 ns | 0.0287 ns | 0.0572 ns |         - |
| RequiresNotNullOrEmpty | X                |                        | X                       | 0.0405 ns | 0.0264 ns | 0.0528 ns |         - |
| RequiresNotNullOrEmpty | X                | X                      | X                       | 0.0393 ns | 0.0289 ns | 0.0333 ns |         - |

### NotNullOrWhiteSpace Benchmarks

| Method                      | Message Template | Null Exception Factory | Empty Exception Factory |     Mean |     Error |    StdDev | Allocated |
|:--------------------------- |:----------------:|:----------------------:|:-----------------------:|---------:|----------:|----------:|----------:|
| RequiresNotNullOrWhiteSpace |                  |                        |                         | 2.167 ns | 0.0175 ns | 0.0163 ns |         - |
| RequiresNotNullOrWhiteSpace | X                |                        |                         | 2.447 ns | 0.0215 ns | 0.0191 ns |         - |
| RequiresNotNullOrWhiteSpace |                  | X                      |                         | 1.915 ns | 0.0123 ns | 0.0096 ns |         - |
| RequiresNotNullOrWhiteSpace |                  |                        | X                       | 2.935 ns | 0.0268 ns | 0.0251 ns |         - |
| RequiresNotNullOrWhiteSpace |                  | X                      | X                       | 2.756 ns | 0.0198 ns | 0.0154 ns |         - |
| RequiresNotNullOrWhiteSpace | X                | X                      |                         | 2.215 ns | 0.0188 ns | 0.0166 ns |         - |
| RequiresNotNullOrWhiteSpace | X                |                        | X                       | 2.298 ns | 0.0470 ns | 0.0393 ns |         - |
| RequiresNotNullOrWhiteSpace | X                | X                      | X                       | 2.225 ns | 0.0223 ns | 0.0198 ns |         - |

### NotEmptyOrWhiteSpace Benchmarks

| Method            | Message Template | Exception Factory |     Mean |     Error |    StdDev | Allocated |
|:----------------- |:----------------:|:-----------------:|---------:|----------:|----------:|----------:|
| RequiresMinLength |                  |                   | 1.907 ns | 0.0316 ns | 0.0295 ns |         - |
| RequiresMinLength | X                |                   | 2.461 ns | 0.0270 ns | 0.0253 ns |         - |
| RequiresMinLength |                  | X                 | 2.981 ns | 0.0201 ns | 0.0179 ns |         - |
| RequiresMinLength | X                | X                 | 2.533 ns | 0.0230 ns | 0.0204 ns |         - |

### AlphaNumericOnly Benchmarks

| Method                   | String content      | Message Template | Exception Factory |       Mean |     Error |    StdDev | Allocated |
|:------------------------ |:--------------------|:----------------:|:-----------------:|-----------:|----------:|----------:|----------:|
| RequiresAlphaNumericOnly | Null String         |                  |                   |   1.440 ns | 0.0125 ns | 0.0098 ns |         - |
| RequiresAlphaNumericOnly | Null String         | X                |                   |   1.247 ns | 0.0245 ns | 0.0229 ns |         - |
| RequiresAlphaNumericOnly | Null String         |                  | X                 |   1.870 ns | 0.0055 ns | 0.0046 ns |         - |
| RequiresAlphaNumericOnly | Null String         | X                | X                 |   1.444 ns | 0.0095 ns | 0.0089 ns |         - |
| RequiresAlphaNumericOnly | String (Length 10)  |                  |                   |  14.056 ns | 0.0816 ns | 0.0724 ns |         - |
| RequiresAlphaNumericOnly | String (Length 10)  | X                |                   |  14.423 ns | 0.2091 ns | 0.1746 ns |         - |
| RequiresAlphaNumericOnly | String (Length 10)  |                  | X                 |  14.459 ns | 0.0728 ns | 0.0569 ns |         - |
| RequiresAlphaNumericOnly | String (Length 10)  | X                | X                 |  14.703 ns | 0.1031 ns | 0.0914 ns |         - |
| RequiresAlphaNumericOnly | String (Length 100) |                  |                   | 139.280 ns | 0.9190 ns | 0.8147 ns |         - |
| RequiresAlphaNumericOnly | String (Length 100) | X                |                   | 140.831 ns | 1.7650 ns | 1.6510 ns |         - |
| RequiresAlphaNumericOnly | String (Length 100) |                  | X                 | 138.831 ns | 0.8712 ns | 0.8149 ns |         - |
| RequiresAlphaNumericOnly | String (Length 100) | X                | X                 | 140.733 ns | 0.7224 ns | 0.6757 ns |         - |
