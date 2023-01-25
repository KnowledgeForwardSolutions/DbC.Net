namespace DbC.Net.ExceptionFactories;

/// <summary>
///   Exception factory for creating <see cref="ArgumentException"/>s.
/// </summary>
public sealed class ArgumentExceptionFactory : ExceptionFactory
{
   private static readonly Lazy<ArgumentExceptionFactory> _lazy =
      new(() => new ArgumentExceptionFactory());

   private ArgumentExceptionFactory() { }

   /// <summary>
   ///   The single instance of <see cref="ArgumentExceptionFactory"/>.
   /// </summary>
   public static ArgumentExceptionFactory Instance => _lazy.Value;

   /// <inheritdoc/>
   public override ArgumentException CreateException(
      String messageTemplate,
      Dictionary<String, Object> data)
   {
      ValidateMessageTemplate(messageTemplate);
      ValidateDataDictionary(data);

      var message = CreateMessage(messageTemplate, data);
      var paramName = GetParamName(data);

      return new ArgumentException(message, paramName as String)
         .PopulateExceptionData(data);
   }
}
