using System.Globalization;

namespace DbC.Net.Tests.Unit.TestData;

public class ObservationClassData : ComparableValue<Observation>
{
   public ObservationClassData() : base(
      new Observation { 
         ObservationId = new Guid("f77d70bc-6eea-45f4-96e5-5bbb02f7ee08"),
         ObservationTimestamp = new DateTime(2022, 11, 22, 9, 37, 46, 789),
         ObservationType = ObservationType.Temperature,
         Value = 6.278,
         Units = Units.DegreesCelsius },
      new Observation
      {
         ObservationId = new Guid("33c8d30b-18f7-48f9-82dd-e58ab8c2d819"),
         ObservationTimestamp = new DateTime(2022, 12, 14, 10, 47, 21, 123),
         ObservationType = ObservationType.Temperature,
         Value = 3.056,
         Units = Units.DegreesCelsius
      },
      new ReverseComparer<Observation>(),
      new Observation
      {
         ObservationId = new Guid("11111111-1111-1111-1111-111111111111"),
         ObservationTimestamp = new DateTime(1970, 1, 1, 1, 1, 1, 1),
         ObservationType = ObservationType.Mass,
         Value = 0.1,
         Units = Units.Gram
      },
      new Observation
      {
         ObservationId = new Guid("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"),
         ObservationTimestamp = new DateTime(2099, 12, 31, 23, 59, 59, 999),
         ObservationType = ObservationType.Mass,
         Value = 99.9,
         Units = Units.Kilogram
      })
   { }
}
