namespace DbC.Net.ExceptionFactories;

public static class ExceptionExtensions
{
   /// <summary>
   ///   Given a dictionary of String/Object key value pairs, populate the Data
   ///   property of the supplied exception.
   /// </summary>
   /// <returns>
   ///   The updated exception to support method chaining.
   /// </returns>
   /// <param name="ex">
   ///   The exception to update.
   /// </param>
   /// <param name="data">
   ///   Additional data to include in the exception.
   /// </param>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="ex"/> is <see langword="null"/>.
   ///   - or -
   ///   <paramref name="data"/> is <see langword="null"/>.
   /// </exception>
   public static T PopulateExceptionData<T>(
      this T ex,
      Dictionary<String, Object> data) where T : Exception
   {
      _ = ex ?? throw new ArgumentNullException(nameof(ex), Messages.ExceptionIsNull);
      _ = data ?? throw new ArgumentNullException(nameof(data), Messages.DataDictionaryIsNull);

      foreach (var item in data)
      {
         ex.Data[item.Key] = item.Value;
      }

      return ex;
   }
}
