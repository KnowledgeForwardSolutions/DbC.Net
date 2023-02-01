namespace DbC.Net.Examples;
public sealed class CustomExceptionFactory : ExceptionFactoryBase
{
   public CustomExceptionFactory() : base() { }

   public CustomExceptionFactory(IReadOnlyCollection<String> keys, IValueTransform transform)
      : base(keys, transform) { }

   public CustomExceptionFactory(IReadOnlyDictionary<String, IValueTransform> transforms) : base(transforms) { }

   /// <inheritdoc/>
   public override CustomException CreateException(
      IReadOnlyDictionary<String, Object> data,
      String messageTemplate)
   {
      ValidateDataDictionary(data);
      ValidateMessageTemplate(messageTemplate);

      var transformedData = ApplyTransforms(data);
      var message = CreateMessage(messageTemplate, transformedData);

      return new CustomException(message)
         .PopulateExceptionData(transformedData);
   }
}
