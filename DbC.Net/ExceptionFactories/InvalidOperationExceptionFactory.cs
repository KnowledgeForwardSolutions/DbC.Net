namespace DbC.Net.ExceptionFactories;

/// <summary>
///   Exception factory for creating <see cref="InvalidOperationException"/>s.
/// </summary>
public sealed class InvalidOperationExceptionFactory : ExceptionFactoryBase
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
      IReadOnlyDictionary<String, Object> data,
      String messageTemplate)
   {
      ValidateDataDictionary(data);
      ValidateMessageTemplate(messageTemplate);

      var message = CreateMessage(messageTemplate, data);

      return new InvalidOperationException(message)
         .PopulateExceptionData(data);
   }
}
