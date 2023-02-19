namespace DbC.Net.TestAndExampleResources;

public record Box(Int32 Height, Int32 Width, Int32 Length, String Color) : IComparable<Box>
{
   public Int32 Volume => Height * Width * Length;

   public Int32 CompareTo(Box? other) => throw new NotImplementedException();
}
