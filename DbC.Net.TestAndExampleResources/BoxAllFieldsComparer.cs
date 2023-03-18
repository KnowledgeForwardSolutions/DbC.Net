namespace DbC.Net.TestAndExampleResources;

public sealed class BoxAllFieldsComparer : IEqualityComparer<Box>, IComparer<Box>
{
   public Int32 Compare(Box? x, Box? y)
   {
      if (x is null)
      {
         return y is null ? 0 : -1;
      }

      return x.CompareTo(y);
   }

   public Boolean Equals(Box? x, Box? y)
   {
      if (ReferenceEquals(x, y))
      {
         return true;
      }
      else if (x is null || y is null)
      {
         return false;
      }

      return x.Height == y.Height && x.Width == y.Width && x.Length == y.Length && x.Color == y.Color;
   }

   public Int32 GetHashCode([DisallowNull] Box obj)
      => HashCode.Combine(obj.Height, obj.Width, obj.Length, obj.Color);
}
