namespace DbC.Net.ExceptionFactories;

/// <summary>
///   Exception factory for creating <see cref="InvalidOperationException"/>s.
/// </summary>
public sealed class InvalidOperationExceptionFactory : ExceptionFactory
{
   private static readonly Lazy<InvalidOperationExceptionFactory> _lazy =
      new(() => new InvalidOperationExceptionFactory());

   private InvalidOperationExceptionFactory() { }

   /// <summary>
   ///   The single instance of <see cref="InvalidOperationExceptionFactory"/>.
   /// </summary>
   public static InvalidOperationExceptionFactory Instance => _lazy.Value;

   /// <inheritdoc/>
   public override InvalidOperationException CreateException(
      String messageTemplate,
      Dictionary<String, Object> data)
   {
      ValidateMessageTemplate(messageTemplate);
      ValidateDataDictionary(data);

      var message = CreateMessage(messageTemplate, data);

      return new InvalidOperationException(message)
         .PopulateExceptionData(data);
   }
}
