namespace DbC.Net.TestAndExampleResources;

public sealed class BoxVolumeComparer : IEqualityComparer<Box>
{
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

      return x.Volume == y.Volume;
   }

   public Int32 GetHashCode([DisallowNull] Box obj)
      => obj.Volume.GetHashCode();
}
