namespace DbC.Net.FloatingPoint;

/// <summary>
///   Floating point approximate equality comparer that uses the relative error
///   approach for type <see cref="Single"/>.
/// </summary>
public sealed class SingleRelativeErrorComparer : BaseRelativeErrorComparer<Single>
{
   // 23 = # of significand bits for single precision.
   public SingleRelativeErrorComparer()
      : base((1 << 23) * Single.Epsilon) { }
}
