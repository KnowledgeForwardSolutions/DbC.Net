namespace DbC.Net.Tests.Unit.TestData;

public abstract class FloatingPointValue<T> : IComparableTestData<T> where T : IFloatingPoint<T>
{
   public FloatingPointValue(
      T value,
      T withinToleranceDelta,
      T outOfToleranceDelta,
      T fixedEpsilon,
      IApproximateEqualityComparer<T> fixedErrorComparer,
      T relativeEpsilon,
      IApproximateEqualityComparer<T> relativeErrorComparer,
      T maxValue,
      T minValue,
      IComparer<T> comparer,
      ReverseComparer<T> reverseComparer,
      T lowerBound,
      T upperBound,
      T belowLowerBoundValue,
      T withinBoundsValue,
      T aboveUpperBoundValue)
   {
      Value = value;
      WithinToleranceDelta = withinToleranceDelta;
      OutOfToleranceDelta = outOfToleranceDelta;
      FixedEpsilon = fixedEpsilon;
      FixedErrorComparer = fixedErrorComparer;
      RelativeEpsilon = relativeEpsilon;
      RelativeErrorComparer = relativeErrorComparer;
      MaxValue = maxValue;
      MinValue = minValue;
      Comparer = comparer;
      ReverseComparer = reverseComparer;
      ReverseMaxValue = minValue;
      ReverseMinValue = maxValue;

      LowerBound = lowerBound;
      UpperBound = upperBound;
      BelowLowerBoundValue = belowLowerBoundValue;
      WithinBoundsValue = withinBoundsValue;
      AboveUpperBoundValue = aboveUpperBoundValue;
      ReverseLowerBound = upperBound;
      ReverseUpperBound = lowerBound;
      ReverseBelowLowerBoundValue = aboveUpperBoundValue;
      ReverseAboveUpperBoundValue = belowLowerBoundValue;
   }

   public virtual T Value { get; }

   public virtual T WithinToleranceDelta { get; }

   public virtual T OutOfToleranceDelta { get; }

   public virtual T FixedEpsilon { get; }

   public virtual T RelativeEpsilon { get; }

   public virtual IApproximateEqualityComparer<T> FixedErrorComparer { get; } = default!;

   public virtual IApproximateEqualityComparer<T> RelativeErrorComparer { get; } = default!;

   public T MaxValue { get; }

   public T MinValue { get; }

   public IComparer<T> Comparer { get; }

   public ReverseComparer<T> ReverseComparer { get; }

   public T ReverseMaxValue { get; }

   public T ReverseMinValue { get; }

   public T LowerBound { get; }

   public T UpperBound { get; }

   public T BelowLowerBoundValue { get; }

   public T WithinBoundsValue { get; }

   public T AboveUpperBoundValue { get; }

   public virtual T ReverseLowerBound { get; }

   public virtual T ReverseUpperBound { get; }

   public virtual T ReverseBelowLowerBoundValue { get; }

   public virtual T ReverseAboveUpperBoundValue { get; }
}
