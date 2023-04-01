namespace DbC.Net.Exceptions;

/// <summary>
///   Exception factory for creating <see cref="FormatException"/>s.
/// </summary>
public sealed class FormatExceptionFactory : ExceptionFactoryBase
{
    /// <summary>
    ///   Initialize a new <see cref="FormatExceptionFactory"/> with no value
    ///   transforms.
    /// </summary>
    public FormatExceptionFactory() : base() { }

    /// <summary>
    ///   Initialize a new <see cref="FormatExceptionFactory"/> with the 
    ///   <paramref name="transform"/> to use for the specified data dictionary
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
    public FormatExceptionFactory(IReadOnlyCollection<string> keys, IValueTransform transform)
       : base(keys, transform) { }

    /// <summary>
    ///   Initialize a new <see cref="FormatExceptionFactory"/> with the 
    ///   specified value <paramref name="transforms"/>.
    /// </summary>
    /// <param name="transforms">
    ///   Dictionary of value transforms to apply to data dictionary entries.
    /// </param>
    public FormatExceptionFactory(IReadOnlyDictionary<string, IValueTransform> transforms) : base(transforms) { }

    /// <inheritdoc/>
    public override FormatException CreateException(
       IReadOnlyDictionary<string, object> data,
       string messageTemplate)
    {
        ValidateDataDictionary(data);
        ValidateMessageTemplate(messageTemplate);

        var transformedData = ApplyTransforms(data);
        var message = CreateMessage(messageTemplate, transformedData);

        return new FormatException(message)
           .PopulateExceptionData(transformedData);
    }
}
