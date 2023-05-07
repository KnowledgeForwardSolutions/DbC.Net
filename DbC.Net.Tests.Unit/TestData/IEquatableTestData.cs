namespace DbC.Net.Tests.Unit.TestData;

public interface IEquatableTestData<T> where T : IEquatable<T>
{
   T EqualValue { get; }

   T NotEqualValue { get; }

   T NonDefaultNotEqualValue { get; }

   IComparer<T> Comparer { get; }

   ReverseComparer<T> ReverseComparer { get; }
}
