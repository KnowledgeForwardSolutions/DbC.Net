namespace DbC.Net.ExceptionFactories;

/// <summary>
///   A factory object used to create exceptions thrown when a DbC.Net Requires...
///   or Ensures... method fails.
/// </summary>
public interface IExceptionFactory
{
   /// <summary>
   ///   Create an exception using the supplied <paramref name="messageTemplate"/>
   ///   and the details to include in the exception's <see cref="Exception.Data"/>
   ///   dictionary.
   /// </summary>
   /// <param name="messageTemplate">
   ///   Template to create the new exception message.
   /// </param>
   /// <param name="data">
   ///   Details to include in the new exception's <see cref="Exception.Data"/>
   ///   dictionary.
   /// </param>
   /// <param name="innerException">
   ///   Optional. The exception that is the cause of the current exception, or 
   ///   <see langword="null"/> if no inner exception is specified.
   /// </param>
   /// <returns>
   ///   A new <see cref="Exception"/> object.
   /// </returns>
   /// <exception cref="ArgumentException">
   ///   <paramref name="messageTemplate"/> is <see cref="String.Empty"/> or all
   ///   whitespace characters.
   /// </exception>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="messageTemplate"/> is <see langword="null"/>.
   ///   - or -
   ///   <paramref name="data"/> is <see langword="null"/>.
   /// </exception>
   Exception CreateException(
      String messageTemplate, 
      Dictionary<String, Object> data,
      Exception? innerException = null);

   /// <summary>
   ///   Create an exception message by populating the 
   ///   <paramref name="messageTemplate"/> with values from the exception
   ///   details <paramref name="data"/> collection.
   /// </summary>
   /// <param name="messageTemplate">
   ///   Template to create the new exception message.
   /// </param>
   /// <param name="data">
   ///   Details to include in the new exception's <see cref="Exception.Data"/>
   ///   dictionary.
   /// </param>
   /// <returns>
   ///   An exception message.
   /// </returns>
   /// <exception cref="ArgumentException">
   ///   <paramref name="messageTemplate"/> is <see cref="String.Empty"/> or all
   ///   whitespace characters.
   /// </exception>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="messageTemplate"/> is <see langword="null"/>.
   ///   - or -
   ///   <paramref name="data"/> is <see langword="null"/>.
   /// </exception>
   String CreateMessage(String messageTemplate, Dictionary<String, Object> data);
}
