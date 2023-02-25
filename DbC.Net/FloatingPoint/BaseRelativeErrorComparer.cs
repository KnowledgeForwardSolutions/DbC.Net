namespace DbC.Net.FloatingPoint;

/// <summary>
///   Abstract base class for floating point approximate equality comparers that
///   use the relative error approach described in https://floating-point-gui.de/errors/comparison/
/// </summary>
public abstract class BaseRelativeErrorComparer<T> : IApproximateEqualityComparer<T>
   where T : IFloatingPointIeee754<T>, IMinMaxValue<T>
{
   private readonly T _minNormal;

   /// <summary>
   ///   Initialize a new <see cref="BaseRelativeErrorComparer{T}"/>.
   /// </summary>
   /// <param name="minNormal">
   ///   The smallest normal value of <typeparamref name="T"/>. A normal value 
   ///   has a 1 before the binary point (i.e. 1.significand bits × 2^exp)
   ///   <para/>
   ///   Java has constants for normal (Float.MIN_NORMAL) while C# does not.
   ///   See https://stackoverflow.com/questions/3874627/floating-point-comparison-functions-for-c-sharp
   ///   for description of how to calculate the normal value in C#.
   /// </param>
   public BaseRelativeErrorComparer(T minNormal) => _minNormal = minNormal;

   /// <inheritdoc/>
   public Boolean ApproximatelyEquals(T x, T y, T epsilon)
   {
      var absX = T.Abs(x);
      var absY = T.Abs(y);
      var diff = T.Abs(x - y);

      if (x == y)
      {
         // Shortcut, handles infinities
         return true;
      }
      else if (T.IsZero(x) || T.IsZero(y) || absX + absY < _minNormal)
      {
         // a or b is zero, or both are extremely close to it.
         // relative error is less meaningful here
         return diff < (epsilon * _minNormal);
      }

      // use relative error
      return diff / T.Min(absX + absY, T.MaxValue) < epsilon;
   }
}
