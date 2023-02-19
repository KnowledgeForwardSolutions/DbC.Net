namespace DbC.Net.Tests.Unit.TestData;

public class SingleData : ComparableValue<Single>
{
   public SingleData() : base(
      Single.Pi,
      Single.Tau,
      new ReverseComparer<Single>(),
      Single.MinValue,
      Single.MaxValue)
   { }
}