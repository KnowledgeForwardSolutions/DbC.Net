namespace DbC.Net.Exceptions;

public class StandardExceptionFactories
{
    private static readonly IReadOnlyCollection<string> _valueOnlyKeys =
       new List<string> { DataNames.Value };

    private static readonly Lazy<IExceptionFactory> _argumentExceptionFactory =
       new(() => new ArgumentExceptionFactory());

    private static readonly Lazy<IExceptionFactory> _argumentNullExceptionFactory =
       new(() => new ArgumentNullExceptionFactory());

    private static readonly Lazy<IExceptionFactory> _argumentOutOfRangeExceptionFactory =
       new(() => new ArgumentOutOfRangeExceptionFactory());

    private static readonly Lazy<IExceptionFactory> _formatExceptionFactory =
       new(() => new FormatExceptionFactory());

    private static readonly Lazy<IExceptionFactory> _invalidOperationExceptionFactory =
       new(() => new InvalidOperationExceptionFactory());

    private static readonly Lazy<IExceptionFactory> _notSupportedExceptionFactory =
       new(() => new NotSupportedExceptionFactory());

    private static readonly Lazy<IExceptionFactory> _postconditionFailedExceptionFactory =
       new(() => new PostconditionFailedExceptionFactory());

    private static readonly Lazy<IExceptionFactory> _secureArgumentExceptionFactory =
       new(() => new ArgumentExceptionFactory(_valueOnlyKeys, StandardTransforms.AsteriskMaskTransform));

    private static readonly Lazy<IExceptionFactory> _secureArgumentOutOfRangeExceptionFactory =
       new(() => new ArgumentOutOfRangeExceptionFactory(_valueOnlyKeys, StandardTransforms.AsteriskMaskTransform));

    private static readonly Lazy<IExceptionFactory> _secureInvalidOperationExceptionFactory =
       new(() => new InvalidOperationExceptionFactory(_valueOnlyKeys, StandardTransforms.AsteriskMaskTransform));

    private static readonly Lazy<IExceptionFactory> _secureNotSupportedExceptionFactory =
       new(() => new NotSupportedExceptionFactory(_valueOnlyKeys, StandardTransforms.AsteriskMaskTransform));

    private static readonly Lazy<IExceptionFactory> _securePostconditionFailedExceptionFactory =
       new(() => new PostconditionFailedExceptionFactory(_valueOnlyKeys, StandardTransforms.AsteriskMaskTransform));

    /// <summary>
    ///   Exception factory for creating <see cref="ArgumentException"/>s where
    ///   no value transforms are applied before creating the exception message
    ///   or the exception Data dictionary is populated.
    /// </summary>
    public static IExceptionFactory ArgumentExceptionFactory => _argumentExceptionFactory.Value;

    /// <summary>
    ///   Exception factory for creating <see cref="ArgumentNullException"/>s where
    ///   no value transforms are applied before creating the exception message
    ///   or the exception Data dictionary is populated.
    /// </summary>
    public static IExceptionFactory ArgumentNullExceptionFactory => _argumentNullExceptionFactory.Value;

    /// <summary>
    ///   Exception factory for creating <see cref="ArgumentOutOfRangeException"/>s where
    ///   no value transforms are applied before creating the exception message
    ///   or the exception Data dictionary is populated.
    /// </summary>
    public static IExceptionFactory ArgumentOutOfRangeExceptionFactory => _argumentOutOfRangeExceptionFactory.Value;

    /// <summary>
    ///   Exception factory for creating <see cref="FormatException"/>s where
    ///   no value transforms are applied before creating the exception message
    ///   or the exception Data dictionary is populated.
    /// </summary>
    public static IExceptionFactory FormatExceptionFactory => _formatExceptionFactory.Value;

    /// <summary>
    ///   Exception factory for creating <see cref="InvalidOperationException"/>s where
    ///   no value transforms are applied before creating the exception message
    ///   or the exception Data dictionary is populated.
    /// </summary>
    public static IExceptionFactory InvalidOperationExceptionFactory => _invalidOperationExceptionFactory.Value;

    /// <summary>
    ///   Exception factory for creating <see cref="NotSupportedException"/>s where
    ///   no value transforms are applied before creating the exception message
    ///   or the exception Data dictionary is populated.
    /// </summary>
    public static IExceptionFactory NotSupportedExceptionFactory => _notSupportedExceptionFactory.Value;

    /// <summary>
    ///   Exception factory for creating <see cref="PostconditionFailedException"/>s where
    ///   no value transforms are applied before creating the exception message
    ///   or the exception Data dictionary is populated.
    /// </summary>
    public static IExceptionFactory PostconditionFailedExceptionFactory => _postconditionFailedExceptionFactory.Value;

    /// <summary>
    ///   Exception factory for creating <see cref="ArgumentException"/>s where  
    ///   the Value data dictionary entry is masked with all asterisk characters 
    ///   ('*') before being included in the exception message or added to the 
    ///   exception Data dictionary.
    /// </summary>
    public static IExceptionFactory SecureArgumentExceptionFactory => _secureArgumentExceptionFactory.Value;

    /// <summary>
    ///   Exception factory for creating <see cref="ArgumentOutOfRangeException"/>s where  
    ///   the Value data dictionary entry is masked with all asterisk characters 
    ///   ('*') before being included in the exception message or added to the 
    ///   exception Data dictionary.
    /// </summary>
    public static IExceptionFactory SecureArgumentOutOfRangeExceptionFactory => _secureArgumentOutOfRangeExceptionFactory.Value;

    /// <summary>
    ///   Exception factory for creating <see cref="InvalidOperationException"/>s where  
    ///   the Value data dictionary entry is masked with all asterisk characters 
    ///   ('*') before being included in the exception message or added to the 
    ///   exception Data dictionary.
    /// </summary>
    public static IExceptionFactory SecureInvalidOperationExceptionFactory => _secureInvalidOperationExceptionFactory.Value;

    /// <summary>
    ///   Exception factory for creating <see cref="NotSupportedException"/>s where
    ///   the Value data dictionary entry is masked with all asterisk characters 
    ///   ('*') before being included in the exception message or added to the 
    ///   exception Data dictionary.
    /// </summary>
    public static IExceptionFactory SecureNotSupportedExceptionFactory => _secureNotSupportedExceptionFactory.Value;

    /// <summary>
    ///   Exception factory for creating <see cref="PostconditionFailedException"/>s where
    ///   the Value data dictionary entry is masked with all asterisk characters 
    ///   ('*') before being included in the exception message or added to the 
    ///   exception Data dictionary.
    /// </summary>
    public static IExceptionFactory SecurePostconditionFailedExceptionFactory => _securePostconditionFailedExceptionFactory.Value;
}
