﻿namespace DbC.Net.TestAndExampleResources;

public sealed class BoxDimensionsComparer : IEqualityComparer<Box>
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

      return x.Height == y.Height && x.Width == y.Width && x.Length == y.Length;
   }

   public Int32 GetHashCode([DisallowNull] Box obj)
      => HashCode.Combine(obj.Height, obj.Width, obj.Length);
}
