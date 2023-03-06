namespace DbC.Net.FloatingPoint;

/// <summary>
///   Floating point approximate equality comparer that uses a fixed error.
/// </summary>
/// <remarks>
///   A fixed error, while commonly recommended, can be considered a naive 
///   approach (see https://floating-point-gui.de/errors/comparison/ for more
///   detail). Unless you are certain that a fixed error is sufficient, you 
///   should consider using a relative error approach, such as 
///   <see cref="DoubleRelativeErrorComparer"/> or implementing your own 
///   comparer that implements <see cref="IApproximateEqualityComparer{T}"/>.
/// </remarks>
public sealed class FixedErrorComparer<T> : IApproximateEqualityComparer<T> where T : IFloatingPoint<T>
{
   /// <inheritdoc/>
   public Boolean ApproximatelyEquals(T x, T y, T epsilon) => T.Abs(x - y) < epsilon;
}
