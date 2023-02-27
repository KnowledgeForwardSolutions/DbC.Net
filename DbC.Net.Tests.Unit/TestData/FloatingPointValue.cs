namespace DbC.Net.Tests.Unit.TestData;

public abstract class FloatingPointValue<T> where T : IFloatingPoint<T>
{
   public FloatingPointValue(
      T value,
      T withinToleranceDelta,
      T outOfToleranceDelta,
      T fixedEpsilon,
      IApproximateEqualityComparer<T> fixedEpsilonComparer,
      T relativeEpsilon,
      IApproximateEqualityComparer<T> relativeErrorComparer)
   {
      Value = value;
      WithinToleranceDelta = withinToleranceDelta;
      OutOfToleranceDelta = outOfToleranceDelta;
      FixedEpsilon = fixedEpsilon;
      FixedEpsilonComparer = fixedEpsilonComparer;
      RelativeEpsilon = relativeEpsilon;
      RelativeErrorComparer = relativeErrorComparer;
   }

   public virtual T Value { get; }

   public virtual T WithinToleranceDelta { get; }

   public virtual T OutOfToleranceDelta { get; }

   public virtual T FixedEpsilon { get; }

   public virtual T RelativeEpsilon { get; }

   public virtual IApproximateEqualityComparer<T> FixedEpsilonComparer { get; } = default!;

   public virtual IApproximateEqualityComparer<T> RelativeErrorComparer { get; } = default!;
}
