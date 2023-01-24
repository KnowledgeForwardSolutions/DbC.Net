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
   public override Exception CreateException(
      String messageTemplate, 
      Dictionary<String, Object> data, 
      Exception? innerException = null)
   {
      _ = messageTemplate ?? throw new ArgumentNullException(nameof(messageTemplate), Messages.MessageTemplateIsEmpty);
      if (String.IsNullOrWhiteSpace(messageTemplate))
      {
         throw new ArgumentException(Messages.MessageTemplateIsEmpty, nameof(messageTemplate));
      }
      _ = data ?? throw new ArgumentNullException(nameof(data), Messages.DataDictionaryIsNull);

      var message = CreateMessage(messageTemplate, data);

      return new ArgumentNullException(message, innerException)
         .PopulateExceptionData(data);
   }
}
