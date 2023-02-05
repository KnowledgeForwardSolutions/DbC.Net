namespace DbC.Net.Tests.Unit.TestResources;

public sealed class PointClass : IEquatable<PointClass>, IComparable<PointClass>
{
   public int X { get; set; }

   public int Y { get; set; }

    public Int32 CompareTo(PointClass? other) => throw new NotImplementedException();

    public Boolean Equals(PointClass? other)
      => other is not null
         && Equals(this.X, other.X)
         && Equals(this.Y, other.Y);
}
