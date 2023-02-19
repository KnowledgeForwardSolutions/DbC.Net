namespace DbC.Net.Tests.Unit.TestData;

public abstract class EquatableValue<T> where T : IEquatable<T>
{
    public EquatableValue(
       T equalValue,
       T notEqualValue,
       ReverseComparer<T> reverseComparer)
   {
      EqualValue = equalValue;
      NotEqualValue = notEqualValue;
      NonDefaultNotEqualValue = notEqualValue;
      ReverseComparer = reverseComparer;
   }

   public virtual T EqualValue { get; }

   public virtual T NotEqualValue { get; }

   /// <summary>
   ///   Special case for <see cref="Boolean"/> when performing equality tests against default.
   /// </summary>
   public virtual T NonDefaultNotEqualValue { get; }

   public ReverseComparer<T> ReverseComparer { get; }
}
