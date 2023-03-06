namespace DbC.Net.Tests.Unit.TestData;

public abstract class FloatingPointValue<T> where T : IFloatingPoint<T>
{
   public FloatingPointValue(
      T value,
      T withinToleranceDelta,
      T outOfToleranceDelta,
      T fixedEpsilon,
      IApproximateEqualityComparer<T> fixedErrorComparer,
      T relativeEpsilon,
      IApproximateEqualityComparer<T> relativeErrorComparer)
   {
      Value = value;
      WithinToleranceDelta = withinToleranceDelta;
      OutOfToleranceDelta = outOfToleranceDelta;
      FixedEpsilon = fixedEpsilon;
      FixedErrorComparer = fixedErrorComparer;
      RelativeEpsilon = relativeEpsilon;
      RelativeErrorComparer = relativeErrorComparer;
   }

   public virtual T Value { get; }

   public virtual T WithinToleranceDelta { get; }

   public virtual T OutOfToleranceDelta { get; }

   public virtual T FixedEpsilon { get; }

   public virtual T RelativeEpsilon { get; }

   public virtual IApproximateEqualityComparer<T> FixedErrorComparer { get; } = default!;

   public virtual IApproximateEqualityComparer<T> RelativeErrorComparer { get; } = default!;
}
