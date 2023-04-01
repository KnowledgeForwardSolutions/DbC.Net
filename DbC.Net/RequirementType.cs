namespace DbC.Net;

/// <summary>
///   The type of requirement being checked. Either a precondition or a
///   postcondition.
/// </summary>
public enum RequirementType
{
   /// <summary>
   ///   A requirement that must be satisfied before executing a block of code.
   /// </summary>
   Precondition,

   /// <summary>
   ///   A requirement that must be satisfied when exiting a block of code.
   /// </summary>
   Postcondition
}

/// <summary>
///   Additional methods for type <see cref="RequirementType"/>.
/// </summary>
public static class RequirementTypeExtensions
{
   /// <summary>
   ///   Check if <paramref name="requirementType"/> is a defined member of the
   ///   <see cref="RequirementType"/> enumeration.
   /// </summary>
   /// <param name="requirementType">
   ///   The value to check.
   /// </param>
   /// <returns>
   ///   <see langword="true"/> if <paramref name="requirementType"/> is a
   ///   defined member of the <see cref="RequirementType"/> enumeration; 
   ///   otherwise <see langword="false"/>.
   /// </returns>
   public static Boolean IsDefined(this RequirementType requirementType)
      => requirementType == RequirementType.Precondition
         || requirementType == RequirementType.Postcondition;
}
