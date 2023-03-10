namespace DbC.Net.Tests.Unit.TestData;

public abstract class ComparableValue<T> : EquatableValue<T>
   where T : IEquatable<T>, IComparable<T>
{
   public ComparableValue(
      T equalValue,
      T notEqualValue,
      ReverseComparer<T> reverseComparer,
      T minValue,
      T maxValue) : base(equalValue, notEqualValue, reverseComparer)
   {
      MinValue = minValue;
      MaxValue = maxValue;
   }

   public T MaxValue { get; }

   public T MinValue { get; }
}
