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
