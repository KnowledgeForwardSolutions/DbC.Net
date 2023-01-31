namespace DbC.Net.Tests.Unit.TestData;

public sealed class CustomExceptionExceptionFactory : ExceptionFactoryBase
{
   public CustomExceptionExceptionFactory() : base() { }

   public CustomExceptionExceptionFactory(IReadOnlyCollection<String> keys, IValueTransform transform)
      : base(keys, transform) { }

   public CustomExceptionExceptionFactory(IReadOnlyDictionary<String, IValueTransform> transforms) : base(transforms) { }

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
