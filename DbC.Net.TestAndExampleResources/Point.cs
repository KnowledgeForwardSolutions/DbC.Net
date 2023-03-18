namespace DbC.Net.TestAndExampleResources;

public struct Point : IEquatable<Point>, IComparable<Point>
{
   public Int32 X { get; set; }

   public Int32 Y { get; set; }

   public Int32 CompareTo(Point other)
   {
      var result = X.CompareTo(other.X);
      return result != 0
         ? result
         : Y.CompareTo(other.Y);
   }

   public override Boolean Equals([NotNullWhen(true)] Object? obj)
   {
      if (obj is null)
      {
         return false;
      }
      else if (obj.GetType() != typeof(Point))
      {
         return false;
      }

      return Equals((Point)obj);
   }

   public Boolean Equals(Point other) => this.X == other.X && this.Y == other.Y;
    
   public override Int32 GetHashCode() 
      => HashCode.Combine(X, Y);

   public static bool operator ==(Point left, Point right) => left.Equals(right);

   public static bool operator !=(Point left, Point right) => !(left == right);
}
