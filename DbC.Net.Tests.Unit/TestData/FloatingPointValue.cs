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
      ReverseComparer<T> reverseComparer)
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
      ReverseComparer = reverseComparer;
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

   public ReverseComparer<T> ReverseComparer { get; }
}
