namespace DbC.Net.Exceptions;
/// <summary>
///   Utility builder class for creating the collection of key/value pairs 
///   for an exception's Data dictionary
/// </summary>
public class ExceptionDataBuilder
{
   private Dictionary<String, Object> _data = new();

   private ExceptionDataBuilder() { }

   /// <summary>
   ///   Finalize the creation of exception data and return completed dictionary.
   /// </summary>
   /// <returns>
   ///   A <see cref="Dictionary{String, Object}"/> containing all of the items
   ///   added via With... methods prior to invoking the Build method.
   /// </returns>
   /// <remarks>
   ///   The Build method also sets the internal collection to 
   ///   <see langword="null"/> so the builder can not continue to be used after 
   ///   the exception data dictionary is created.
   /// </remarks>
   /// <exception cref="InvalidOperationException">
   ///   The Build method was previously invoked and can not be invoked again.
   /// </exception>
   public Dictionary<String, Object> Build()
   {
      var result = _data ?? throw new InvalidOperationException(Messages.ExceptionDataAlreadyBuilt);
      _data = null!;

      return result;
   }

   /// <summary>
   ///   Create a new <see cref="ExceptionDataBuilder"/> object.
   /// </summary>
   /// <returns>
   ///   A new <see cref="ExceptionDataBuilder"/> object.
   /// </returns>
   public static ExceptionDataBuilder Create() => new();

   /// <summary>
   ///   Add epsilon information (for floating point comparisons) to the 
   ///   exception data dictionary.
   /// </summary>
   /// <param name="epsilon">
   ///   The epsilon value.
   /// </param>
   /// <param name="epsilonExpression">
   ///   The epsilon parameter expression in the calling method.
   /// </param>
   /// <returns>
   ///   A reference to this <see cref="ExceptionDataBuilder"/> object to 
   ///   support method chaining.
   /// </returns>
   /// <exception cref="ArgumentException">
   ///   <paramref name="epsilonExpression"/> is <see cref="String.Empty"/>.
   /// </exception>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="epsilonExpression"/> is <see langword="null"/>.
   /// </exception>
   public ExceptionDataBuilder WithEpsilon(Object epsilon, String epsilonExpression)
   {
      ArgumentException.ThrowIfNullOrEmpty(epsilonExpression, nameof(epsilonExpression));

      _data[DataNames.Epsilon] = epsilon;
      _data[DataNames.EpsilonExpression] = epsilonExpression;

      return this;
   }

   /// <summary>
   ///   Add information for the specified item <paramref name="name"/> to the
   ///   exception data dictionary.
   /// </summary>
   /// <param name="name">
   ///   The name of the item to add.
   /// </param>
   /// <param name="value">
   ///   The item value.
   /// </param>
   /// <returns>
   ///   A reference to this <see cref="ExceptionDataBuilder"/> object to 
   ///   support method chaining.
   /// </returns>
   /// <exception cref="ArgumentException">
   ///   <paramref name="name"/> is <see cref="String.Empty"/>.
   /// </exception>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="name"/> is <see langword="null"/>.
   /// </exception>
   public ExceptionDataBuilder WithItem(String name, Object value)
   {
      ArgumentException.ThrowIfNullOrEmpty(name, nameof(name));

      _data[name] = value;

      return this;
   }

   /// <summary>
   ///   Add lower bound information to the exception data dictionary.
   /// </summary>
   /// <param name="lowerBound">
   ///   The lower bound value.
   /// </param>
   /// <param name="lowerBoundExpression">
   ///   The lower bound parameter expression in the calling method.
   /// </param>
   /// <returns>
   ///   A reference to this <see cref="ExceptionDataBuilder"/> object to 
   ///   support method chaining.
   /// </returns>
   /// <exception cref="ArgumentException">
   ///   <paramref name="lowerBoundExpression"/> is <see cref="String.Empty"/>.
   /// </exception>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="lowerBoundExpression"/> is <see langword="null"/>.
   /// </exception>
   public ExceptionDataBuilder WithLowerBound(Object lowerBound, String lowerBoundExpression)
   {
      ArgumentException.ThrowIfNullOrEmpty(lowerBoundExpression, nameof(lowerBoundExpression));

      _data[DataNames.LowerBound] = lowerBound;
      _data[DataNames.LowerBoundExpression] = lowerBoundExpression;

      return this;
   }

   /// <summary>
   ///   Add requirement information to the exception data dictionary.
   /// </summary>
   /// <param name="requirementType">
   ///   The type of the failed requirement: Precondition or PostCondition.
   /// </param>
   /// <param name="requirementName">
   ///   The name of the failed requirement.
   /// </param>
   /// <returns>
   ///   A reference to this <see cref="ExceptionDataBuilder"/> object to 
   ///   support method chaining.
   /// </returns>
   /// <exception cref="ArgumentOutOfRangeException">
   ///   <paramref name="requirementType"/> is not a defined member of the
   ///   <see cref="RequirementType"/> enumeration.
   /// </exception>
   /// <exception cref="ArgumentException">
   ///   <paramref name="requirementName"/> is <see cref="String.Empty"/>.
   /// </exception>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="requirementName"/> is <see langword="null"/>.
   /// </exception>
   public ExceptionDataBuilder WithRequirement(
      RequirementType requirementType,
      String requirementName)
   {
      if (!requirementType.IsDefined())
      {
         throw new ArgumentOutOfRangeException(
            nameof(requirementType),
            requirementType,
            Messages.RequirementTypeIsNotDefined);
      }
      ArgumentException.ThrowIfNullOrEmpty(requirementName, nameof(requirementName));

      _data[DataNames.RequirementType] = requirementType;
      _data[DataNames.RequirementName] = requirementName;

      return this;
   }

   /// <summary>
   ///   Add target information to the exception data dictionary.
   /// </summary>
   /// <param name="target">
   ///   The target value.
   /// </param>
   /// <param name="targetExpression">
   ///   The target parameter expression in the calling method.
   /// </param>
   /// <returns>
   ///   A reference to this <see cref="ExceptionDataBuilder"/> object to 
   ///   support method chaining.
   /// </returns>
   /// <exception cref="ArgumentException">
   ///   <paramref name="targetExpression"/> is <see cref="String.Empty"/>.
   /// </exception>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="targetExpression"/> is <see langword="null"/>.
   /// </exception>
   public ExceptionDataBuilder WithTarget(Object target, String targetExpression)
   {
      ArgumentException.ThrowIfNullOrEmpty(targetExpression, nameof(targetExpression));

      _data[DataNames.Target] = target;
      _data[DataNames.TargetExpression] = targetExpression;

      return this;
   }

   /// <summary>
   ///   Add lower bound information to the exception data dictionary.
   /// </summary>
   /// <param name="upperBound">
   ///   The upper bound value.
   /// </param>
   /// <param name="upperBoundExpression">
   ///   The upper bound parameter expression in the calling method.
   /// </param>
   /// <returns>
   ///   A reference to this <see cref="ExceptionDataBuilder"/> object to 
   ///   support method chaining.
   /// </returns>
   /// <exception cref="ArgumentException">
   ///   <paramref name="upperBoundExpression"/> is <see cref="String.Empty"/>.
   /// </exception>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="upperBoundExpression"/> is <see langword="null"/>.
   /// </exception>
   public ExceptionDataBuilder WithUpperBound(Object upperBound, String upperBoundExpression)
   {
      ArgumentException.ThrowIfNullOrEmpty(upperBoundExpression, nameof(upperBoundExpression));

      _data[DataNames.UpperBound] = upperBound;
      _data[DataNames.UpperBoundExpression] = upperBoundExpression;

      return this;
   }

   /// <summary>
   ///   Add value information to the exception data dictionary.
   /// </summary>
   /// <param name="value">
   ///   The value being checked.
   /// </param>
   /// <param name="valueExpression">
   ///   The value parameter expression in the calling method.
   /// </param>
   /// <returns>
   ///   A reference to this <see cref="ExceptionDataBuilder"/> object to 
   ///   support method chaining.
   /// </returns>
   /// <exception cref="ArgumentException">
   ///   <paramref name="valueExpression"/> is <see cref="String.Empty"/>.
   /// </exception>
   /// <exception cref="ArgumentNullException">
   ///   <paramref name="valueExpression"/> is <see langword="null"/>.
   /// </exception>
   public ExceptionDataBuilder WithValue(Object value, String valueExpression)
   {
      ArgumentException.ThrowIfNullOrEmpty(valueExpression, nameof(valueExpression));

      _data[DataNames.Value] = value;
      _data[DataNames.ValueExpression] = valueExpression;

      return this;
   }
}
