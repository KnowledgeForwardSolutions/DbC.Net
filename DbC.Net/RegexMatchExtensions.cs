namespace DbC.Net;

/// <summary>
///   Extension methods that implement String RegexMatch requirement.
/// </summary>
public static class RegexMatchExtensions
{
   private const String _requirementName = RequirementNames.RegexMatch;

   /// <summary>
   ///   String RegexMatch postcondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> matches the supplied regular expression and 
   ///   throw an exception if it does not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="regexText">
   ///   The regular expression to match.
   /// </param>
   /// <param name="regexOptions">
   ///   Optional.  Options used when creating a <see cref="Regex"/> from the
   ///   <paramref name="regexText"/>. Defaults to 
   ///   <see cref="RegexOptions.None"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {Value} must match the regular expression: {Regex}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.PostconditionFailedExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="value"/> is <see langword="null"/>.
   ///   - or -
   ///   <paramref name="regexText"/> is <see langword="null"/>.
   /// </exception>
   /// <exception cref="ArgumentException">
   ///   <paramref name="regexText"/> is <see cref="String.Empty"/> or all
   ///   whitespace characters.
   /// </exception>
   public static String EnsuresRegexMatch(
      this String value,
      String regexText,
      RegexOptions regexOptions = RegexOptions.None,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!)
   {
      _ = regexText ?? throw new ArgumentNullException(nameof(regexText), Messages.RegexTextIsEmpty);
      if (String.IsNullOrWhiteSpace(regexText))
      {
         throw new ArgumentException(Messages.RegexTextIsEmpty, nameof(regexText));
      }

      var regex = new Regex(regexText, regexOptions);
      CheckRegexMatch(
         value ?? throw new ArgumentNullException(nameof(value), Messages.RegexInputIsNull),
         regex,
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   /// <summary>
   ///   String RegexMatch postcondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> matches the supplied regular expression and 
   ///   throw an exception if it does not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="regex">
   ///   The regular expression to match.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {Value} must match the regular expression: {Regex}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.PostconditionFailedExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="value"/> is <see langword="null"/>.
   ///   - or -
   ///   <paramref name="regex"/> is <see langword="null"/>.
   /// </exception>
   public static String EnsuresRegexMatch(
      this String value,
      Regex regex,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!)
   {

      CheckRegexMatch(
         value ?? throw new ArgumentNullException(nameof(value), Messages.RegexInputIsNull),
         regex ?? throw new ArgumentNullException(nameof(regex), Messages.RegexIsNull),
         RequirementType.Postcondition,
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   /// <summary>
   ///   String RegexMatch precondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> matches the supplied regular expression and 
   ///   throw an exception if it does not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="regexText">
   ///   The regular expression to match.
   /// </param>
   /// <param name="regexOptions">
   ///   Optional.  Options used when creating a <see cref="Regex"/> from the
   ///   <paramref name="regexText"/>. Defaults to 
   ///   <see cref="RegexOptions.None"/>.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {Value} must match the regular expression: {Regex}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.ArgumentExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="value"/> is <see langword="null"/>.
   ///   - or -
   ///   <paramref name="regexText"/> is <see langword="null"/>.
   /// </exception>
   /// <exception cref="ArgumentException">
   ///   <paramref name="regexText"/> is <see cref="String.Empty"/> or all
   ///   whitespace characters.
   /// </exception>
   public static String RequiresRegexMatch(
      this String value,
      String regexText,
      RegexOptions regexOptions = RegexOptions.None,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!)
   {
      _ = regexText ?? throw new ArgumentNullException(nameof(regexText), Messages.RegexTextIsEmpty);
      if (String.IsNullOrWhiteSpace(regexText))
      {
         throw new ArgumentException(Messages.RegexTextIsEmpty, nameof(regexText));
      }

      var regex = new Regex(regexText, regexOptions);
      CheckRegexMatch(
         value ?? throw new ArgumentNullException(nameof(value), Messages.RegexInputIsNull),
         regex,
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   /// <summary>
   ///   String RegexMatch precondition. Confirm that the <see cref="String"/>
   ///   <paramref name="value"/> matches the supplied regular expression and 
   ///   throw an exception if it does not.
   /// </summary>
   /// <param name="value">
   ///   The value to check.
   /// </param>
   /// <param name="regex">
   ///   The regular expression to match.
   /// </param>
   /// <param name="messageTemplate">
   ///   Optional. The message template to use if an exception is thrown.
   ///   Defaults to "{RequirementType} {RequirementName} failed: {Value} must match the regular expression: {Regex}".
   /// </param>
   /// <param name="exceptionFactory">
   ///   Optional. The <see cref="IExceptionFactory"/> used to create the
   ///   exception that is thrown if the <paramref name="value"/> is 
   ///   <see langword="null"/>. Defaults to 
   ///   <see cref="StandardExceptionFactories.ArgumentExceptionFactory"/>.
   /// </param>
   /// <param name="valueExpression">
   ///   Optional. Defaults to the caller expression for
   ///   <paramref name="value"/>. 
   /// </param>
   /// <returns>
   ///   The tested <paramref name="value"/> is returned unaltered to support 
   ///   chaining requirements.
   /// </returns>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="value"/> is <see langword="null"/>.
   ///   - or -
   ///   <paramref name="regex"/> is <see langword="null"/>.
   /// </exception>
   public static String RequiresRegexMatch(
      this String value,
      Regex regex,
      String? messageTemplate = null,
      IExceptionFactory? exceptionFactory = null,
      [CallerArgumentExpression(nameof(value))] String valueExpression = null!)
   {

      CheckRegexMatch(
         value ?? throw new ArgumentNullException(nameof(value), Messages.RegexInputIsNull),
         regex ?? throw new ArgumentNullException(nameof(regex), Messages.RegexIsNull),
         RequirementType.Precondition,
         messageTemplate,
         exceptionFactory,
         valueExpression);

      return value;
   }

   private static void CheckRegexMatch(
      String value,
      Regex regex,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression)
   {
      if (!regex.IsMatch(value))
      {
         messageTemplate ??= MessageTemplates.RegexMatchTemplate;
         exceptionFactory ??= StandardExceptionFactories.ResolveArgumentExceptionFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithItem(DataNames.Regex, regex.ToString())
            .WithItem(DataNames.RegexOptions, regex.Options)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }
}
