namespace DbC.Net.Tests.Unit.TestData;

public interface IComparableTestData<T> where T : IComparable<T>
{
   T MaxValue { get; }

   T MinValue { get; }

   ReverseComparer<T> ReverseComparer { get; }

   T ReverseMaxValue { get; }

   T ReverseMinValue { get; }

   T LowerBound { get; }

   T UpperBound { get; }

   T BelowLowerBoundValue { get; }

   T WithinBoundsValue { get; }

   T AboveUpperBoundValue { get; }
}
