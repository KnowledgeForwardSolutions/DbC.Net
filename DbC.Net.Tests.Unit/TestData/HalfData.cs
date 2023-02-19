using System;

namespace DbC.Net.Tests.Unit.TestData;

public class HalfData : ComparableValue<Half>
{
   public HalfData() : base(
      Half.Pi,
      Half.Tau,
      new ReverseComparer<Half>(),
      Half.MinValue,
      Half.MaxValue)
   { }
}

