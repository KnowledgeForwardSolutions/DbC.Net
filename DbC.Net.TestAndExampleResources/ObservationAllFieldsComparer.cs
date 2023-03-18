namespace DbC.Net.TestAndExampleResources;

public sealed class ObservationAllFieldsComparer : IEqualityComparer<Observation>, IComparer<Observation>
{
   public Int32 Compare(Observation? x, Observation? y)
   {
      if (x is null)
      {
         return y is null ? 0 : -1;
      }

      return x.CompareTo(y);
   }

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

      return x.ObservationId == y.ObservationId
         && x.ObservationTimestamp == y.ObservationTimestamp
         && x.ObservationType == y.ObservationType
         && x.Value == y.Value
         && x.Units == y.Units;
   }

   public Int32 GetHashCode([DisallowNull] Observation obj)
      => HashCode.Combine(obj.ObservationId, obj.ObservationTimestamp, obj.ObservationType, obj.Value, obj.Units);
}