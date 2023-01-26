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
   protected readonly IValueMasker _valueMasker;
   protected readonly IReadOnlySet<String> _sensitiveValues;

   /// <summary>
   ///   Initialize a new <see cref="MaskedExceptionFactory"/>.
   /// </summary>
   /// <param name="valueMasker">
   ///   The <see cref="IValueMasker"/> used to mask sensitive values.
   /// </param>
   /// <param name="sensitiveValues">
   ///   Collection of keys for values that are considered sensitive and that
   ///   should be masked.
   /// </param>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="valueMasker"/> is <see langword="null"/>.
   ///   - or -
   ///   <paramref name="sensitiveValues"/> is <see langword="null"/>.
   /// </exception>
   public MaskedExceptionFactory(
      IValueMasker valueMasker,
      IReadOnlyCollection<String> sensitiveValues)
   {
      _valueMasker = valueMasker 
         ?? throw new ArgumentNullException(nameof(valueMasker), Messages.ValueMaskerIsNull);
      _ = sensitiveValues 
         ?? throw new ArgumentNullException(nameof(sensitiveValues), Messages.SensitiveValuesListIsNull);
      _sensitiveValues = sensitiveValues.ToHashSet();
   }

   /// <summary>
   ///   Prepare the data to include in an exception by masking sensitive values.
   /// </summary>
   /// <param name="data">
   ///   Details to include in the new exception's <see cref="Exception.Data"/>
   ///   dictionary.
   /// </param>
   /// <returns>
   ///   A new data dictionary, with sensitive values replaced by masked strings.
   /// </returns>
   public virtual Dictionary<String, Object> MaskSensitiveValues(
      Dictionary<String, Object> data)
   {
      ValidateDataDictionary(data);

      var maskedData = new Dictionary<String, Object>();
      foreach(var kvp in data)
      {
         maskedData[kvp.Key] = _sensitiveValues.Contains(kvp.Key)
            ? _valueMasker.MaskValue(kvp.Value)
            : kvp.Value;
      }
      return maskedData;
   }
}
