namespace DbC.Net.Tests.Unit.TestData;

public interface IComparableTestData<T> where T : IComparable<T>
{
   T MaxValue { get; }

   T MinValue { get; }

   ReverseComparer<T> ReverseComparer { get; }
}
