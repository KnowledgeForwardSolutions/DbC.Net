namespace DbC.Net.FloatingPoint;

public interface IApproximateEqualityComparer<T> where T : IFloatingPoint<T>
{
   /// <summary>
   ///   Determines if the difference between <paramref name="x"/> and 
   ///   <paramref name="y"/> is small enough for the values to be considered 
   ///   equal floating point values.
   /// </summary>
   /// <param name="x">
   ///   The left side value of the equality check.
   /// </param>
   /// <param name="y">
   ///   The right side value of the equality check.
   /// </param>
   /// <param name="epsilon">
   ///   The error margin to use when comparing the values for equality.
   /// </param>
   /// <returns>
   ///   <see langword="true"/> if the difference between <paramref name="x"/> 
   ///   and <paramref name="y"/> is small enough for the values to be 
   ///   considered equal floating point values; otherwise 
   ///   <see langword="false"/>.
   /// </returns>
   Boolean ApproximatelyEquals(T x, T y, T epsilon);
}
