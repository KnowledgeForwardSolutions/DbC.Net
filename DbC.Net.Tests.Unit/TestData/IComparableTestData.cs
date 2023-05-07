namespace DbC.Net.Tests.Unit.TestData;

public interface IComparableTestData<T> where T : IComparable<T>
{
   T MaxValue { get; }

   T MinValue { get; }

   IComparer<T> Comparer { get; }

   ReverseComparer<T> ReverseComparer { get; }

   T ReverseMaxValue { get; }

   T ReverseMinValue { get; }

   T LowerBound { get; }

   T UpperBound { get; }

   T BelowLowerBoundValue { get; }

   T WithinBoundsValue { get; }

   T AboveUpperBoundValue { get; }

   T ReverseLowerBound { get; }

   T ReverseUpperBound { get; }

   T ReverseBelowLowerBoundValue { get; }

   T ReverseAboveUpperBoundValue { get; }
}
