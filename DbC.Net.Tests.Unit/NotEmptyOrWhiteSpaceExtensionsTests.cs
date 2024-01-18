namespace DbC.Net.Tests.Unit;

#pragma warning disable xUnit1012 // Null should only be used for nullable parameters
public class NotEmptyOrWhiteSpaceExtensionsTests
{
   private const Int32 _dataCount = 4;

   #region EnsuresNotEmptyOrWhiteSpace Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData(null)]
   [InlineData("asdf")]
   public void NotEmptyOrWhiteSpaceExtensions_EnsuresNotEmptyOrWhiteSpace_ShouldNotThrow_WhenValueIsNotEmptyOrWhiteSpace(String value)
   {
      // Arrange.
      var act = () => _ = value.EnsuresNotEmptyOrWhiteSpace();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotEmptyOrWhiteSpaceExtensions_EnsuresNotEmptyOrWhiteSpace_ShouldThrow_WhenValueIsEmptyOrWhiteSpace(String value)
   {
      // Arrange.
      var act = () => _ = value.EnsuresNotEmptyOrWhiteSpace();

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotEmptyOrWhiteSpaceExtensions_EnsuresNotEmptyOrWhiteSpace_ShouldThrowWithExpectedDataDictionary_WhenValueIsEmptyOrWhiteSpace(String value)
   {
      // Arrange.
      var act = () => _ = value.EnsuresNotEmptyOrWhiteSpace();

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotEmptyOrWhiteSpace);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotEmptyOrWhiteSpaceExtensions_EnsuresNotEmptyOrWhiteSpace_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsEmptyOrWhiteSpaceAndAllDefaultsAreUsed(String value)
   {
      // Arrange.
      var act = () => _ = value.EnsuresNotEmptyOrWhiteSpace();
      var expectedMessage = $"Postcondition NotEmptyOrWhiteSpace failed: value may not be String.Empty or all whitespace characters";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotEmptyOrWhiteSpaceExtensions_EnsuresNotEmptyOrWhiteSpace_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsEmptyOrWhiteSpaceAndCustomMessageTemplateIsUsed(String value)
   {
      // Arrange.
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotEmptyOrWhiteSpace(messageTemplate);
      var expectedMessage = $"Requirement NotEmptyOrWhiteSpace failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotEmptyOrWhiteSpaceExtensions_EnsuresNotEmptyOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsEmptyOrWhiteSpaceAndCustomExceptionFactoryIsUsed(String value)
   {
      // Arrange.
      var act = () => _ = value.EnsuresNotEmptyOrWhiteSpace(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition NotEmptyOrWhiteSpace failed: value may not be String.Empty or all whitespace characters";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotEmptyOrWhiteSpaceExtensions_EnsuresNotEmptyOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsEmptyOrWhiteSpaceAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed(String value)
   {
      // Arrange.
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotEmptyOrWhiteSpace(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotEmptyOrWhiteSpace failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresNotEmptyOrWhiteSpace Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData(null)]
   [InlineData("asdf")]
   public void NotEmptyOrWhiteSpaceExtensions_RequiresNotEmptyOrWhiteSpace_ShouldNotThrow_WhenValueIsNotEmptyOrWhiteSpace(String value)
   {
      // Arrange.
      var act = () => _ = value.RequiresNotEmptyOrWhiteSpace();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotEmptyOrWhiteSpaceExtensions_RequiresNotEmptyOrWhiteSpace_ShouldThrow_WhenValueIsEmptyOrWhiteSpace(String value)
   {
      // Arrange.
      var act = () => _ = value.RequiresNotEmptyOrWhiteSpace();

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotEmptyOrWhiteSpaceExtensions_RequiresNotEmptyOrWhiteSpace_ShouldThrowWithExpectedDataDictionary_WhenValueIsEmptyOrWhiteSpace(String value)
   {
      // Arrange.
      var act = () => _ = value.RequiresNotEmptyOrWhiteSpace();

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotEmptyOrWhiteSpace);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotEmptyOrWhiteSpaceExtensions_RequiresNotEmptyOrWhiteSpace_ShouldThrowArgumentExceptionWithExpectedMessage_WhenValueIsEmptyOrWhiteSpaceAndAllDefaultsAreUsed(String value)
   {
      // Arrange.
      var act = () => _ = value.RequiresNotEmptyOrWhiteSpace();
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition NotEmptyOrWhiteSpace failed: value may not be String.Empty or all whitespace characters";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotEmptyOrWhiteSpaceExtensions_RequiresNotEmptyOrWhiteSpace_ShouldThrowArgumentExceptionWithExpectedMessage_WhenValueIsEmptyOrWhiteSpaceAndCustomMessageTemplateIsUsed(String value)
   {
      // Arrange.
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotEmptyOrWhiteSpace(messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement NotEmptyOrWhiteSpace failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotEmptyOrWhiteSpaceExtensions_RequiresNotEmptyOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsEmptyOrWhiteSpaceAndCustomExceptionFactoryIsUsed(String value)
   {
      // Arrange.
      var act = () => _ = value.RequiresNotEmptyOrWhiteSpace(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition NotEmptyOrWhiteSpace failed: value may not be String.Empty or all whitespace characters";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotEmptyOrWhiteSpaceExtensions_RequiresNotEmptyOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsEmptyOrWhiteSpaceAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed(String value)
   {
      // Arrange.
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotEmptyOrWhiteSpace(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotEmptyOrWhiteSpace failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
