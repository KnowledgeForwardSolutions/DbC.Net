namespace DbC.Net.Tests.Unit.TestData;

public abstract class ComparableValue<T> : EquatableValue<T>, IComparableTestData<T>
   where T : IEquatable<T>, IComparable<T>
{
   public ComparableValue(
      T equalValue,
      T notEqualValue,
      ReverseComparer<T> reverseComparer,
      T minValue,
      T maxValue,
      T lowerBound,
      T upperBound,
      T belowLowerBoundValue,
      T withinBoundsValue,
      T aboveUpperBoundValue) : base(equalValue, notEqualValue, reverseComparer)
   {
      MinValue = minValue;
      MaxValue = maxValue;
      ReverseMaxValue = minValue;
      ReverseMinValue = maxValue;

      LowerBound = lowerBound;
      UpperBound = upperBound;
      BelowLowerBoundValue = belowLowerBoundValue;
      WithinBoundsValue = withinBoundsValue;
      AboveUpperBoundValue = aboveUpperBoundValue;
   }

   public T MaxValue { get; }

   public T MinValue { get; }

   public T ReverseMaxValue { get; }

   public T ReverseMinValue { get; }

   public virtual T LowerBound { get; }

   public virtual T UpperBound { get; }

   public virtual T BelowLowerBoundValue { get; }

   public virtual T WithinBoundsValue { get; }

   public virtual T AboveUpperBoundValue { get; }
}
