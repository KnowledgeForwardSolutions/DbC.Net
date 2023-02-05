namespace DbC.Net.Tests.Unit.TestResources;

public sealed record PointRecord(Int32 X, Int32 Y) : IComparable<PointRecord>
{
    public Int32 CompareTo(PointRecord? other) => throw new NotImplementedException();
}
