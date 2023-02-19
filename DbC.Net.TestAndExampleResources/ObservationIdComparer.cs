namespace DbC.Net.TestAndExampleResources;

public sealed class ObservationIdComparer : IEqualityComparer<Observation>
{
   public Boolean Equals(Observation? x, Observation? y)
   {
      if (ReferenceEquals(x, y))
      {
         return true;
      }
      else if (x is null || y is null)
      {
         return false;
      }

      return x.ObservationId == y.ObservationId;
   }

   public Int32 GetHashCode([DisallowNull] Observation obj) => obj.ObservationId.GetHashCode();
}
