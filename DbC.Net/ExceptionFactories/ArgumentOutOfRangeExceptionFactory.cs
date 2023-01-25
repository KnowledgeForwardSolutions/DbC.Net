namespace DbC.Net.ExceptionFactories;

/// <summary>
///   Exception factory for creating <see cref="ArgumentOutOfRangeException"/>s.
/// </summary>
public sealed class ArgumentOutOfRangeExceptionFactory : ExceptionFactory
{
   private static readonly Lazy<ArgumentOutOfRangeExceptionFactory> _lazy =
      new(() => new ArgumentOutOfRangeExceptionFactory());

   private ArgumentOutOfRangeExceptionFactory() { }

   /// <summary>
   ///   The single instance of <see cref="ArgumentOutOfRangeExceptionFactory"/>.
   /// </summary>
   public static ArgumentOutOfRangeExceptionFactory Instance => _lazy.Value;

   /// <inheritdoc/>
   public override ArgumentOutOfRangeException CreateException(
      String messageTemplate,
      Dictionary<String, Object> data)
   {
      ValidateMessageTemplate(messageTemplate);
      ValidateDataDictionary(data);

      var message = CreateMessage(messageTemplate, data);
      var paramName = GetParamName(data);
      data.TryGetValue(DataNames.Value, out var actualValue);

      return new ArgumentOutOfRangeException(paramName, actualValue, message)
         .PopulateExceptionData(data);
   }
}
