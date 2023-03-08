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

   public Int32 CompareTo(Observation? other)
   {
      // Compare to null will always evaluate as greater than, per MSDN documentation for IComparable<T>.CompareTo(T)
      if (other == null) return 1;

      // This is a contrived example that simply compares all fields of an object.
      // Otherwise, you'd want to consider if Id equality means that the objects
      // are truly equal.
      var result = ObservationId.CompareTo(other.ObservationId);
      if (result != 0) return result;

      result = ObservationTimestamp.CompareTo(other.ObservationTimestamp);
      if (result != 0) return result;

      result = ObservationType.CompareTo(other.ObservationType);
      if (result != 0) return result;

      result = Value.CompareTo(other.Value);
      return result == 0
         ? result
         : Units.CompareTo(other.Units);
   }
}
