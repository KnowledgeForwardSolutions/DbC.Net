namespace DbC.Net.TestAndExampleResources;

public record Box(Int32 Height, Int32 Width, Int32 Length, String Color) : IComparable<Box>
{
   public Int32 Volume => Height * Width * Length;

   public Int32 CompareTo(Box? other)
   {
      // Compare to null will always evaluate as greater than, per MSDN documentation for IComparable<T>.CompareTo(T)
      if (other == null) return 1;

      var result = Height.CompareTo(other!.Height);
      if (result != 0) return result;

      result = Width.CompareTo(other!.Width);
      if (result != 0) return result;

      result = Length.CompareTo(other!.Length);
      return result != 0 
         ? result 
         : Color.CompareTo(other!.Color);
   }
}
