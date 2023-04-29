namespace DbC.Net.Tests.Unit.TestData;

public abstract class EquatableValue<T> : IEquatableTestData<T> where T : IEquatable<T>
{
    public EquatableValue(
       T equalValue,
       T notEqualValue,
       IComparer<T> comparer,
       ReverseComparer<T> reverseComparer)
   {
      EqualValue = equalValue;
      NotEqualValue = notEqualValue;
      NonDefaultNotEqualValue = notEqualValue;
      Comparer = comparer;
      ReverseComparer = reverseComparer;
   }

   public virtual T EqualValue { get; }

   public virtual T NotEqualValue { get; }

   /// <summary>
   ///   Special case for <see cref="Boolean"/> when performing equality tests against default.
   /// </summary>
   public virtual T NonDefaultNotEqualValue { get; }

   public IComparer<T> Comparer { get; }

   public ReverseComparer<T> ReverseComparer { get; }
}
