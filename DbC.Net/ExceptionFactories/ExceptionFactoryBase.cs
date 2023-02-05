namespace DbC.Net.ExceptionFactories;

/// <summary>
///   Abstract base class for DbC.Net exception factories.
/// </summary>
public abstract class ExceptionFactoryBase : IExceptionFactory
{
   private const String _ensuresPrefix = "Ensures";
   private const String _requiresPrefix = "Requires";

   private readonly Dictionary<String, IValueTransform> _transforms = new();

   /// <summary>
   ///   Initialize a new <see cref="ExceptionFactoryBase"/> object with all
   ///   defaults.
   /// </summary>
   public ExceptionFactoryBase() { }

   /// <summary>
   ///   Initialize a new <see cref="ExceptionFactoryBase"/> with the 
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
   public ExceptionFactoryBase(IReadOnlyCollection<String> keys, IValueTransform transform)
   {
      _ = keys ?? throw new ArgumentNullException(nameof(keys), Messages.TransformKeysCollectonIsNull);
      _ = transform ?? throw new ArgumentNullException(nameof(transform), Messages.ValueTransformIsNull);

      foreach(var key in keys)
      {
         _transforms[key] = transform;
      }
   }

   /// <summary>
   ///   Initialize a new <see cref="ExceptionFactoryBase"/> with the specified
   ///   value <paramref name="transforms"/>.
   /// </summary>
   /// <param name="transforms">
   ///   Dictionary of value transforms to apply to data dictionary entries.
   /// </param>
   public ExceptionFactoryBase(IReadOnlyDictionary<String, IValueTransform> transforms)
   {
      _ = transforms ?? throw new ArgumentNullException(nameof(transforms), Messages.TransformsDictionaryIsNull);

      foreach(var kvp in transforms)
      {
         _transforms[kvp.Key] = kvp.Value;
      }
   }

   /// <summary>
   ///   Apply value transformations to the data dictionary. 
   /// </summary>
   /// <param name="data">
   ///   Details to include in the new exception's <see cref="Exception.Data"/>
   ///   dictionary.
   /// </param>
   /// <returns>
   ///   A new data dictionary, containing values the transformed data values.
   /// </returns>
   public IReadOnlyDictionary<String, Object> ApplyTransforms(IReadOnlyDictionary<String, Object> data)
   {
      var transformed = new Dictionary<String, Object>();
      foreach(var kvp in data)
      {
         transformed[kvp.Key] = _transforms.TryGetValue(kvp.Key, out var transform)
            ? transform.TransformValue(kvp.Value)
            : kvp.Value;
      }

      return transformed;
   }

   /// <inheritdoc/>
   public abstract Exception CreateException(
      IReadOnlyDictionary<String, Object> data,
      String messageTemplate);

   /// <summary>
   ///   Create an exception message by populating the 
   ///   <paramref name="messageTemplate"/> with values from the exception
   ///   details <paramref name="data"/> collection.
   /// </summary>
   /// <param name="messageTemplate">
   ///   Template to create the new exception message.
   /// </param>
   /// <param name="data">
   ///   Details to include in the new exception's <see cref="Exception.Data"/>
   ///   dictionary.
   /// </param>
   /// <returns>
   ///   An exception message.
   /// </returns>
   /// <exception cref="ArgumentException">
   ///   <paramref name="messageTemplate"/> is <see cref="String.Empty"/> or all
   ///   whitespace characters.
   /// </exception>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="messageTemplate"/> is <see langword="null"/>.
   ///   - or -
   ///   <paramref name="data"/> is <see langword="null"/>.
   /// </exception>
   public virtual String CreateMessage(
      String messageTemplate,
      IReadOnlyDictionary<String, Object> data)
   {
      ValidateMessageTemplate(messageTemplate);
      ValidateDataDictionary(data);

      var message = messageTemplate;
      foreach(var item in data)
      {
         message = message.Replace($"{{{item.Key}}}", item.Value?.ToString());
      }

      return message;
   }

   /// <summary>
   ///   Get the parameter name value from the value expression in supplied 
   ///   <paramref name="data"/> dictionary.
   /// </summary>
   /// <param name="data">
   ///   Details to include in the new exception's <see cref="Exception.Data"/>
   ///   dictionary.
   /// </param>
   /// <returns>
   ///   The parameter name, or <see cref="String.Empty"/> if not available.
   /// </returns>
   /// <remarks>
   ///   The entry in the <paramref name="data"/> dictionary with the 
   ///   <see cref="DataNames.ValueExpression"/> is a string containing the 
   ///   full expression passed to the Requires... or Ensures... method. Because
   ///   Requires... and Ensures... methods can be chained together, it is
   ///   possible that the value expression will contain preceding methods in
   ///   the call chain. This method strips off any extra data and only returns
   ///   the original value. 
   ///   <para/>
   ///   i.e. x.RequiresNotNull().RequiresGreaterThanZero() => x
   /// </remarks>
   // TODO: Note that the current implementation is not entirely bullet-proof. For
   // TODO: example, a value expression of "thisValueRequiresMoreThought.EnsuresNotNull()"
   // TODO: would return "thisValue".
   public virtual String GetParamName(IReadOnlyDictionary<String, Object> data)
   {
      ValidateDataDictionary(data);

      var paramName = String.Empty;
      if (data.TryGetValue(DataNames.ValueExpression, out var valueExpression))
      {
         paramName = valueExpression as String;
         var requiresIndex = paramName!.IndexOf(_requiresPrefix);
         var ensuresIndex = paramName.IndexOf(_ensuresPrefix);
         var offset = -1;
         if (requiresIndex > -1 && ensuresIndex == -1)
         {
            offset = requiresIndex;
         }
         else if (requiresIndex == -1 && ensuresIndex > -1)
         {
            offset = ensuresIndex;
         }
         else if (requiresIndex > -1 && ensuresIndex > -1)
         {
            offset = Math.Min(requiresIndex, ensuresIndex);
         }

         if (offset > -1)
         {
            paramName = paramName[..offset].TrimEnd();
         }
         if (paramName.EndsWith('.'))
         {
            paramName = paramName[..^1].TrimEnd();
         }
      }

      return paramName;
   }

   /// <summary>
   ///   Confirm that the <paramref name="data"/> dictionary is not 
   ///   <see langword="null"/>.
   /// </summary>
   /// <param name="data">
   ///   Details to include in the new exception's <see cref="Exception.Data"/>
   ///   dictionary.
   /// </param>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="data"/> is <see langword="null"/>.
   /// </exception>
   public static void ValidateDataDictionary(IReadOnlyDictionary<String, Object> data)
      => _ = data ?? throw new ArgumentNullException(nameof(data), Messages.DataDictionaryIsNull);

   /// <summary>
   ///   Confirm that the <paramref name="messageTemplate"/> is not 
   ///   <see langword="null"/>, <see cref="String.Empty"/> or all whitespace 
   ///   characters.
   /// </summary>
   /// <param name="messageTemplate">
   ///   Template to create the new exception message.
   /// </param>
   /// </param>
   /// <exception cref="ArgumentException">
   ///   <paramref name="messageTemplate"/> is <see cref="String.Empty"/> or all
   ///   whitespace characters.
   /// </exception>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="messageTemplate"/> is <see langword="null"/>.
   /// </exception>
   public static void ValidateMessageTemplate(String messageTemplate)
   {
      _ = messageTemplate ?? throw new ArgumentNullException(nameof(messageTemplate), Messages.MessageTemplateIsEmpty);
      if (String.IsNullOrWhiteSpace(messageTemplate))
      {
         throw new ArgumentException(Messages.MessageTemplateIsEmpty, nameof(messageTemplate));
      }
   }
}
