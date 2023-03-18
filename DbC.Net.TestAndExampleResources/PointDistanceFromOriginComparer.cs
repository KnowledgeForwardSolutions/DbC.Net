namespace DbC.Net.TestAndExampleResources;

public sealed class PointDistanceFromOriginComparer : Comparer<Point>
{
   public override Int32 Compare(Point a, Point b)
   {
      var aDistance = Math.Sqrt(a.X * a.X + a.Y * a.Y);
      var bDistance = Math.Sqrt(b.X * b.X + b.Y * b.Y);

      return aDistance.CompareTo(bDistance);
   }
}
