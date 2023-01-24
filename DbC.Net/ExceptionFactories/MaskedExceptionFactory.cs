namespace DbC.Net.ExceptionFactories;

/// <summary>
///   Abstract base class for DbC.Net exception factories that mask sensitive
///   data.
/// </summary>
/// <remarks>
///   Use an exception factory derived from <see cref="MaskedExceptionFactory"/>
///   to prevent sensitive values from being exposed to those who should not see
///   it (for example, by writing an exception to a log).
/// </remarks>
public abstract class MaskedExceptionFactory : ExceptionFactory
{
   /// <summary>
   ///   Mask sensitive data by replacing with a string consisting of all
   ///   asterisk characters.
   /// </summary>
   /// <param name="data">
   ///   Details to include in the new exception's <see cref="Exception.Data"/>
   ///   dictionary.
   /// </param>
   /// <param name="itemKeys">
   ///   Array if keys for items to mask. If empty, then the item keys
   ///   <see cref="DataNames.Value"/> and 
   ///   <see cref="DataNames.ValueExpression"/> are masked.
   /// </param>
   public virtual void MaskSensitiveValues(
      Dictionary<String, Object> data,
      params String[] itemKeys)
      => throw new NotImplementedException();
}
