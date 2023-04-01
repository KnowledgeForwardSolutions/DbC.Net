namespace DbC.Net.Exceptions;

/// <summary>
///   Exception factory for creating <see cref="ArgumentNullException"/>s.
/// </summary>
public sealed class ArgumentNullExceptionFactory : ExceptionFactoryBase
{
    /// <summary>
    ///   Initialize a new <see cref="ArgumentNullExceptionFactory"/> with no 
    ///   value transforms.
    /// </summary>
    public ArgumentNullExceptionFactory() : base() { }

    /// <summary>
    ///   Initialize a new <see cref="ArgumentNullExceptionFactory"/> with the 
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
    public ArgumentNullExceptionFactory(IReadOnlyCollection<string> keys, IValueTransform transform)
       : base(keys, transform) { }

    /// <summary>
    ///   Initialize a new <see cref="ArgumentNullExceptionFactory"/> with the 
    ///   specified value <paramref name="transforms"/>.
    /// </summary>
    /// <param name="transforms">
    ///   Dictionary of value transforms to apply to data dictionary entries.
    /// </param>
    public ArgumentNullExceptionFactory(IReadOnlyDictionary<string, IValueTransform> transforms) : base(transforms) { }

    /// <inheritdoc/>
    public override ArgumentNullException CreateException(
       IReadOnlyDictionary<string, object> data,
       string messageTemplate)
    {
        ValidateDataDictionary(data);
        ValidateMessageTemplate(messageTemplate);

        var paramName = GetParamName(data);
        var transformedData = ApplyTransforms(data);
        var message = CreateMessage(messageTemplate, transformedData);

        return new ArgumentNullException(paramName, message)
           .PopulateExceptionData(transformedData);
    }
}
