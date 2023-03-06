namespace DbC.Net.FloatingPoint;

/// <summary>
///   Floating point approximate equality comparer that uses the relative error
///   approach for type <see cref="Half"/>.
/// </summary>
public sealed class HalfRelativeErrorComparer : BaseRelativeErrorComparer<Half>
{
   // 10 = # of significand bits for half precision.
   public HalfRelativeErrorComparer()
      : base((Half)((Int16)1 << 10) * Half.Epsilon) { }
}
