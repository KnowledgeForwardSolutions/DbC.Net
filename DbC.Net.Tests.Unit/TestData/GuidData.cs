﻿namespace DbC.Net.Tests.Unit.TestData;

public class GuidData : ComparableValue<Guid>
{
   public GuidData() : base(
      new Guid("44444444-4444-4444-4444-444444444444"),
      new Guid("88888888-8888-8888-8888-888888888888"),
      new ReverseComparer<Guid>(),
      new Guid("11111111-1111-1111-1111-111111111111"),
      new Guid("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"))
   { }
}

