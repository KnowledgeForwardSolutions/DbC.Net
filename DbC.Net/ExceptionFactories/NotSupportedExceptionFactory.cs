namespace DbC.Net.ExceptionFactories;

/// <summary>
///   Exception factory for creating <see cref="NotSupportedException"/>s.
/// </summary>
public sealed class NotSupportedExceptionFactory : ExceptionFactory
{
   private static readonly Lazy<NotSupportedExceptionFactory> _lazy =
      new(() => new NotSupportedExceptionFactory());

   private NotSupportedExceptionFactory() { }

   /// <summary>
   ///   The single instance of <see cref="NotSupportedExceptionFactory"/>.
   /// </summary>
   public static NotSupportedExceptionFactory Instance => _lazy.Value;

   /// <inheritdoc/>
   public override NotSupportedException CreateException(
      String messageTemplate,
      Dictionary<String, Object> data)
   {
      ValidateMessageTemplate(messageTemplate);
      ValidateDataDictionary(data);

      var message = CreateMessage(messageTemplate, data);

      return new NotSupportedException(message)
         .PopulateExceptionData(data);
   }
}
