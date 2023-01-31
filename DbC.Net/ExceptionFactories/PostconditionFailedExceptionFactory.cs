namespace DbC.Net.ExceptionFactories;

/// <summary>
///   Exception factory for creating <see cref="PostconditionFailedException"/>s.
/// </summary>
public sealed class PostconditionFailedExceptionFactory : ExceptionFactoryBase
{
   /// <summary>
   ///   Initialize a new <see cref="PostconditionFailedExceptionFactory"/> with 
   ///   no value transforms.
   /// </summary>
   public PostconditionFailedExceptionFactory() : base() { }

   /// <summary>
   ///   Initialize a new <see cref="PostconditionFailedExceptionFactory"/> with 
   ///   the <paramref name="transform"/> to use for the specified data dictionary
   ///   <paramref name="keys"/>.
   /// </summary>
   /// <param name="keys">
   ///   Keys that identify data dictionary entries that should be transformed
   ///   when creating exceptions.
   /// </param>
   /// <param name="transform">
   ///   The <see cref="IValueTransform"/> to use for the specified data 
   ///   dictionary <paramref name="keys"/>.
   /// </param>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="keys"/> is <see langword="null"/>.
   ///   - or -
   ///   <paramref name="transform"/> is <see langword="null"/>.
   /// </exception>
   public PostconditionFailedExceptionFactory(IReadOnlyCollection<String> keys, IValueTransform transform)
      : base(keys, transform) { }

   /// <summary>
   ///   Initialize a new <see cref="PostconditionFailedExceptionFactory"/> with 
   ///   the specified value <paramref name="transforms"/>.
   /// </summary>
   /// <param name="transforms">
   ///   Dictionary of value transforms to apply to data dictionary entries.
   /// </param>
   public PostconditionFailedExceptionFactory(IReadOnlyDictionary<String, IValueTransform> transforms) : base(transforms) { }

   /// <inheritdoc/>
   public override PostconditionFailedException CreateException(
      IReadOnlyDictionary<String, Object> data,
      String messageTemplate)
   {
      ValidateDataDictionary(data);
      ValidateMessageTemplate(messageTemplate);

      var transformedData = ApplyTransforms(data);
      var message = CreateMessage(messageTemplate, transformedData);

      return new PostconditionFailedException(message)
         .PopulateExceptionData(transformedData);
   }
}