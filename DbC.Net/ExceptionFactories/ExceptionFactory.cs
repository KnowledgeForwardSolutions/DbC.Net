namespace DbC.Net.ExceptionFactories;

/// <summary>
///   Abstract base class for DbC.Net exception factories.
/// </summary>
public abstract class ExceptionFactory : IExceptionFactory
{
   /// <inheritdoc/>
   public abstract Exception CreateException(
      String messageTemplate, 
      Dictionary<String, Object> data, 
      Exception? innerException = null);

   /// <inheritdoc/>
   public virtual String CreateMessage(
      String messageTemplate, 
      Dictionary<String, Object> data)
   {
      _ = messageTemplate ?? throw new ArgumentNullException(nameof(messageTemplate), Messages.MessageTemplateIsEmpty);
      if (String.IsNullOrWhiteSpace(messageTemplate))
      {
         throw new ArgumentException(Messages.MessageTemplateIsEmpty, nameof(messageTemplate));
      }
      _ = data ?? throw new ArgumentNullException(nameof(data), Messages.DataDictionaryIsNull);

      var message = messageTemplate;
      foreach(var item in data)
      {
         message = message.Replace($"{{{item.Key}}}", item.Value.ToString());
      }

      return message;
   }
}
