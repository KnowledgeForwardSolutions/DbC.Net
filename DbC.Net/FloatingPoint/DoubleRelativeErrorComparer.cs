namespace DbC.Net.FloatingPoint;

/// <summary>
///   Floating point approximate equality comparer that uses the relative error
///   approach for type <see cref="Double"/>.
/// </summary>
public sealed class DoubleRelativeErrorComparer : BaseRelativeErrorComparer<Double>
{
   // 52 = # of significand bits for double precision.
   public DoubleRelativeErrorComparer()
      : base((1L << 52) * Double.Epsilon) { }
}
