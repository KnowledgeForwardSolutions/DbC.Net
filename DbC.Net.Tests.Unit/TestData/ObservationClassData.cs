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
      },
      new Observation
      {
         ObservationId = new Guid("33333333-3333-3333-3333-333333333333"),
         ObservationTimestamp = new DateTime(1980, 3, 3, 3, 3, 3, 3),
         ObservationType = ObservationType.Concentration,
         Value = 0.3,
         Units = Units.GramsPerLiter
      },
      new Observation
      {
         ObservationId = new Guid("CCCCCCCC-CCCC-CCCC-CCCC-CCCCCCCCCCCC"),
         ObservationTimestamp = new DateTime(1990, 9, 9, 9, 9, 9, 9),
         ObservationType = ObservationType.Concentration,
         Value = 0.9,
         Units = Units.KilogramsPerMeterCubed
      },
      new Observation
      {
         ObservationId = new Guid("11111111-1111-1111-1111-111111111111"),
         ObservationTimestamp = new DateTime(1970, 1, 1, 1, 1, 1, 1),
         ObservationType = ObservationType.Concentration,
         Value = 0.1,
         Units = Units.GramsPerLiter
      },
      new Observation
      {
         ObservationId = new Guid("88888888-8888-8888-8888-888888888888"),
         ObservationTimestamp = new DateTime(1985, 8, 8, 8, 8, 8, 8),
         ObservationType = ObservationType.Concentration,
         Value = 0.6,
         Units = Units.GramsPerLiter
      },
      new Observation
      {
         ObservationId = new Guid("FFFFFFFF-FFFF-FFFF-FFFF-FFFFFFFFFFFF"),
         ObservationTimestamp = new DateTime(2099, 12, 31, 23, 59, 59, 999),
         ObservationType = ObservationType.Concentration,
         Value = 99.9,
         Units = Units.KilogramsPerMeterCubed
      })
   { }
}
