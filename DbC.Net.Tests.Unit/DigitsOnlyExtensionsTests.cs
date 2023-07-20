namespace DbC.Net.Tests.Unit;

public class DigitsOnlyExtensionsTests
{
   private const Int32 _dataCount = 4;

   #region EnsuresDigitsOnly Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void DigitsOnlyExtensions_EnsuresDigitsOnly_ShouldNotThrow_WhenValueContainsOnlyDigitCharacters()
   {
      // Arrange.
      var value = "1234567890";
      var act = () => _ = value.EnsuresDigitsOnly();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void DigitsOnlyExtensions_EnsuresDigitsOnly_ShouldNotThrow_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresDigitsOnly();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void DigitsOnlyExtensions_EnsuresDigitsOnly_ShouldNotThrow_WhenValueIsEmpty()
   {
      // Arrange.
      var value = String.Empty;
      var act = () => _ = value.EnsuresDigitsOnly();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [InlineData("This is a test!")]
   [InlineData("\t")]
   [InlineData(StringData.LowerCaseAPlusDiaeresisCombiningCharacter)]
   [InlineData(StringData.FractionOneTenth)]
   [InlineData(StringData.RomanNumeral12)]
   public void DigitsOnlyExtensions_EnsuresDigitsOnly_ShouldThrow_WhenValueContainsNonDigitCharacters(String value)
   {
      // Arrange.
      var act = () => _ = value.EnsuresDigitsOnly();

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void DigitsOnlyExtensions_EnsuresDigitsOnly_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = "(555) 123-4567";
      var act = () => _ = value.EnsuresDigitsOnly();

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.DigitsOnly);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void DigitsOnlyExtensions_EnsuresDigitsOnly_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "(555) 123-4567";
      var act = () => _ = value.EnsuresDigitsOnly();
      var expectedMessage = $"Postcondition DigitsOnly failed: value may only contain radix-10 digit characters";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void DigitsOnlyExtensions_EnsuresDigitsOnly_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "\t123\t";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresDigitsOnly(messageTemplate);
      var expectedMessage = $"Requirement DigitsOnly failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void NotEmptyOrWhiteSpaceExtensions_EnsuresNotEmptyOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "!@#$%^&*()_+";
      var act = () => _ = value.EnsuresDigitsOnly(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition DigitsOnly failed: value may only contain radix-10 digit characters";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void NotEmptyOrWhiteSpaceExtensions_EnsuresNotEmptyOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.DiaeresisCombiningCharacter;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresDigitsOnly(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement DigitsOnly failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   #endregion

   #region RequiresDigitsOnly Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void DigitsOnlyExtensions_RequiresDigitsOnly_ShouldNotThrow_WhenValueContainsOnlyDigitCharacters()
   {
      // Arrange.
      var value = "1234567890";
      var act = () => _ = value.RequiresDigitsOnly();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void DigitsOnlyExtensions_RequiresDigitsOnly_ShouldNotThrow_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresDigitsOnly();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void DigitsOnlyExtensions_RequiresDigitsOnly_ShouldNotThrow_WhenValueIsEmpty()
   {
      // Arrange.
      var value = String.Empty;
      var act = () => _ = value.RequiresDigitsOnly();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [InlineData("This is a test!")]
   [InlineData("\t")]
   [InlineData(StringData.LowerCaseAPlusDiaeresisCombiningCharacter)]
   [InlineData(StringData.FractionOneTenth)]
   [InlineData(StringData.RomanNumeral12)]
   public void DigitsOnlyExtensions_RequiresDigitsOnly_ShouldThrow_WhenValueContainsNonDigitCharacters(String value)
   {
      // Arrange.
      var act = () => _ = value.RequiresDigitsOnly();

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Fact]
   public void DigitsOnlyExtensions_RequiresDigitsOnly_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = "(555) 123-4567";
      var act = () => _ = value.RequiresDigitsOnly();

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.DigitsOnly);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void DigitsOnlyExtensions_RequiresDigitsOnly_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "(555) 123-4567";
      var act = () => _ = value.RequiresDigitsOnly();
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition DigitsOnly failed: value may only contain radix-10 digit characters";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void DigitsOnlyExtensions_RequiresDigitsOnly_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "\t123\t";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresDigitsOnly(messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement DigitsOnly failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void NotEmptyOrWhiteSpaceExtensions_RequiresNotEmptyOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "!@#$%^&*()_+";
      var act = () => _ = value.RequiresDigitsOnly(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition DigitsOnly failed: value may only contain radix-10 digit characters";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void NotEmptyOrWhiteSpaceExtensions_RequiresNotEmptyOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.DiaeresisCombiningCharacter;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresDigitsOnly(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement DigitsOnly failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   #endregion
}
