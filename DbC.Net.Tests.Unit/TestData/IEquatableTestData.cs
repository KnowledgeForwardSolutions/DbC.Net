namespace DbC.Net.Tests.Unit.TestData;

public interface IEquatableTestData<T> where T : IEquatable<T>
{
   T EqualValue { get; }

   T NotEqualValue { get; }

   T NonDefaultNotEqualValue { get; }

   ReverseComparer<T> ReverseComparer { get; }
}
