namespace DbC.Net.TestAndExampleResources;

public sealed class CustomExceptionFactory : ExceptionFactoryBase
{
   public CustomExceptionFactory() : base() { }

   public CustomExceptionFactory(IReadOnlyCollection<string> keys, IValueTransform transform)
      : base(keys, transform) { }

   public CustomExceptionFactory(IReadOnlyDictionary<string, IValueTransform> transforms) : base(transforms) { }

   /// <inheritdoc/>
   public override CustomException CreateException(
      IReadOnlyDictionary<string, object> data,
      string messageTemplate)
   {
      ValidateDataDictionary(data);
      ValidateMessageTemplate(messageTemplate);

      var transformedData = ApplyTransforms(data);
      var message = CreateMessage(messageTemplate, transformedData);

      return new CustomException(message)
         .PopulateExceptionData(transformedData);
   }
}
