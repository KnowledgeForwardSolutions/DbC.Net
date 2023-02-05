﻿namespace DbC.Net.Tests.Unit.TestResources;

/// <summary>
///   Simple <see cref="IComparer{T}"/> implementation that reverses the result
///   of the normal comparison.
/// </summary>
public class ReverseComparer<T> : IComparer<T>, IEqualityComparer<T>
{
   public Int32 Compare(T? x, T? y) => Comparer<T>.Default.Compare(x, y) * -1;

   public Boolean Equals(T? x, T? y) => !EqualityComparer<T>.Default.Equals(x, y);

   public Int32 GetHashCode([DisallowNull] T obj) => throw new NotImplementedException();
}
