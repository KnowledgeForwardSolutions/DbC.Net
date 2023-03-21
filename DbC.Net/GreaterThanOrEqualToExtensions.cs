namespace DbC.Net;

/// <summary>
///   Extension methods that implement GreaterThanOrEqualTo requirement for 
///   types that implement <see cref="IComparable{T}"/> or that use 
///   <see cref="IComparer{T}"/>.
/// </summary>
public static class GreaterThanOrEqualToExtensions
{
   private const String _requirementName = RequirementNames.GreaterThanOrEqualTo;


   private static void CheckGreaterThanOrEqualTo<T>(
      T value,
      T lowerBound,
      RequirementType requirementType,
      String? messageTemplate,
      IExceptionFactory? exceptionFactory,
      String valueExpression,
      String lowerBoundExpression) where T : IComparable<T>
   {
      if (value is null || value!.CompareTo(lowerBound) <= 0)
      {
         messageTemplate ??= MessageTemplates.GreaterThanOrEqualToTemplate;
         exceptionFactory ??= GetExceptionFactory(requirementType);
         var data = ExceptionDataBuilder.Create()
            .WithRequirement(requirementType, _requirementName)
            .WithValue(value!, valueExpression)
            .WithLowerBound(lowerBound, lowerBoundExpression)
            .Build();

         throw exceptionFactory.CreateException(data, messageTemplate);
      }
   }

   private static IExceptionFactory GetExceptionFactory(RequirementType requirementType)
      => requirementType == RequirementType.Precondition
         ? StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory
         : StandardExceptionFactories.PostconditionFailedExceptionFactory;
}
