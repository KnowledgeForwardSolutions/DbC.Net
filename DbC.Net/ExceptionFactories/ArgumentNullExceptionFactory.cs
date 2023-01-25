namespace DbC.Net.ExceptionFactories;

/// <summary>
///   Exception factory for creating <see cref="ArgumentNullException"/>s.
/// </summary>
public sealed class ArgumentNullExceptionFactory : ExceptionFactory
{
   private static readonly Lazy<ArgumentNullExceptionFactory> _lazy =
      new(() => new ArgumentNullExceptionFactory());

   private ArgumentNullExceptionFactory() { }

   /// <summary>
   ///   The single instance of <see cref="ArgumentNullExceptionFactory"/>.
   /// </summary>
   public static ArgumentNullExceptionFactory Instance => _lazy.Value;

   /// <inheritdoc/>
   public override ArgumentNullException CreateException(
      String messageTemplate, 
      Dictionary<String, Object> data)
   {
      ValidateMessageTemplate(messageTemplate);
      ValidateDataDictionary(data);

      var message = CreateMessage(messageTemplate, data);
      var paramName = GetParamName(data);

      return new ArgumentNullException(paramName as String, message)
         .PopulateExceptionData(data);
   }
}
