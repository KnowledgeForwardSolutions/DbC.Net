﻿namespace DbC.Net.ExceptionFactories;

/// <summary>
///   Exception factory for creating <see cref="FormatException"/>s.
/// </summary>
public sealed class FormatExceptionFactory : ExceptionFactory
{
   private static readonly Lazy<FormatExceptionFactory> _lazy =
      new(() => new FormatExceptionFactory());

   private FormatExceptionFactory() { }

   /// <summary>
   ///   The single instance of <see cref="FormatExceptionFactory"/>.
   /// </summary>
   public static FormatExceptionFactory Instance => _lazy.Value;

   /// <inheritdoc/>
   public override FormatException CreateException(
      String messageTemplate,
      Dictionary<String, Object> data)
   {
      ValidateMessageTemplate(messageTemplate);
      ValidateDataDictionary(data);

      var message = CreateMessage(messageTemplate, data);

      return new FormatException(message)
         .PopulateExceptionData(data);
   }
}