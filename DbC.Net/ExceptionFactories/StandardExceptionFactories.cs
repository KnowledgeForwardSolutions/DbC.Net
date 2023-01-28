namespace DbC.Net.ExceptionFactories;

public class StandardExceptionFactories
{
   private static readonly IReadOnlyCollection<String> _valueOnlyKeys = 
      new List<String> { DataNames.Value };

   private static readonly Lazy<ArgumentExceptionFactory> _argumentExceptionFactory =
      new(() => new ArgumentExceptionFactory());

   private static readonly Lazy<ArgumentNullExceptionFactory> _argumentNullExceptionFactory =
      new(() => new ArgumentNullExceptionFactory());

   private static readonly Lazy<ArgumentOutOfRangeExceptionFactory> _argumentOutOfRangeExceptionFactory =
      new(() => new ArgumentOutOfRangeExceptionFactory());

   private static readonly Lazy<ArgumentExceptionFactory> _secureArgumentExceptionFactory =
      new(() => new ArgumentExceptionFactory(_valueOnlyKeys, StandardTransforms.AsteriskMaskTransform));

   private static readonly Lazy<ArgumentOutOfRangeExceptionFactory> _secureArgumentOutOfRangeExceptionFactory =
      new(() => new ArgumentOutOfRangeExceptionFactory(_valueOnlyKeys, StandardTransforms.AsteriskMaskTransform));

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
}
