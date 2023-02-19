namespace DbC.Net.TestAndExampleResources;

public sealed class Observation : IEquatable<Observation>, IComparable<Observation>
{
   public Guid ObservationId { get; init; }

   public DateTime ObservationTimestamp { get; init; }

   public String ObservationType { get; init; } = default!;

   public Double Value { get; init; }

   public String Units { get; init; } = default!;

   public Boolean Equals(Observation? other)
   {
      if (ReferenceEquals(this, other))
      {
         return true;
      }
      else if (other is null)
      {
         return false;
      }

      return ValueEquality(this, other);
   }

   public override Boolean Equals(Object? obj)
   {
      if (obj is null)
      {
         return false;
      }
      else if (obj.GetType() != typeof(Observation))
      {
         return false;
      }

      return ValueEquality(this, (Observation)obj);
   }

   public override Int32 GetHashCode()
      => HashCode.Combine(ObservationId, ObservationTimestamp, ObservationType, Value, Units);

   private static Boolean ValueEquality(Observation left, Observation right)
      => left.ObservationId == right.ObservationId
         && left.ObservationTimestamp == right.ObservationTimestamp
         && left.ObservationType == right.ObservationType
         && left.Value == right.Value
         && left.Units == right.Units;

    public Int32 CompareTo(Observation? other) => throw new NotImplementedException();
}
