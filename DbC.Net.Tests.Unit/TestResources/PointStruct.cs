namespace DbC.Net.Tests.Unit.TestResources;

public struct PointStruct : IEquatable<PointStruct>, IComparable<PointStruct>
{
    public int X { get; set; }

    public int Y { get; set; }

    public Int32 CompareTo(PointStruct other) => throw new NotImplementedException();

    public Boolean Equals(PointStruct other) => Equals(this.X, other.X) && Equals(this.Y, other.Y);
}
