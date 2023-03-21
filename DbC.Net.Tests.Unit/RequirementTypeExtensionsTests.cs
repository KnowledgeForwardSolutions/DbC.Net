namespace DbC.Net.Tests.Unit;

public class RequirementTypeExtensionsTests
{
   #region IsDefined Method Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData(RequirementType.Precondition)]
   [InlineData(RequirementType.Postcondition)]
   public void RequirementTypeExtensions_IsDefined_ShouldReturnTrue_WhenValueIsDefined(RequirementType requirementType)
      => requirementType.IsDefined().Should().BeTrue();

   [Fact]
   public void RequirementTypeExtensions_IsDefined_ShouldReturnFalse_WhenValueIsNotDefined()
   {
      // Arrange
      var requirementType = (RequirementType)99;

      // Act/assert.
      requirementType.IsDefined().Should().BeFalse();
   }

   #endregion
}
