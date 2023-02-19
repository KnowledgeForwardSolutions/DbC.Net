namespace DbC.Net.Tests.Unit.TestData;

public class BooleanData : ComparableValue<Boolean>
{
   public BooleanData() : base(true, false, new ReverseComparer<Boolean>(), false, true) { }

    public override Boolean NonDefaultNotEqualValue => true;
}