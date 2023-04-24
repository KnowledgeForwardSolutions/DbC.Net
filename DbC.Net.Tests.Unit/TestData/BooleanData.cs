﻿namespace DbC.Net.Tests.Unit.TestData;

public class BooleanData : ComparableValue<Boolean>
{
   public BooleanData() : base(
      true, 
      false, 
      new ReverseComparer<Boolean>(), 
      false, 
      true,
      false,
      false,
      false,
      false,
      false) { }

   public override Boolean NonDefaultNotEqualValue => true;

   public override Boolean LowerBound => throw new NotImplementedException();

   public override Boolean UpperBound => throw new NotImplementedException();

   public override Boolean BelowLowerBoundValue => throw new NotImplementedException();

   public override Boolean WithinBoundsValue => throw new NotImplementedException();

   public override Boolean AboveUpperBoundValue => throw new NotImplementedException();
}