namespace DbC.Net.TestAndExampleResources;

public static class BoxComparers
{
   public static readonly BoxAllFieldsComparer AllFieldsComparer = new();

   public static readonly BoxDimensionsComparer DimensionsComparer = new();

   public static readonly BoxVolumeComparer VolumeComparer = new();
}
