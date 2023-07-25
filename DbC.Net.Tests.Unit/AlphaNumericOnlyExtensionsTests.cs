namespace DbC.Net.Tests.Unit;

public class AlphaNumericOnlyExtensionsTests
{
   private const Int32 _dataCount = 4;

   #region EnsuresAlphaNumericOnly Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData("123")]
   [InlineData("asdf")]
   [InlineData("QWERTY")]
   [InlineData(StringData.UpperCaseDiphthongAE)]
   [InlineData(StringData.LowerCaseAWithOverring)]
   [InlineData("abc123XYZ")]
   [InlineData("s\u00F8ster")]  // s + lower case slashed 'o' + ster - Danish for sister
   public void AlphaNumericOnlyExtensions_EnsuresAlphaNumericOnly_ShouldNotThrow_WhenValueContainsOnlyLetterOrDigitCharacters(String value)
   {
      // Arrange.
      var act = () => _ = value.EnsuresAlphaNumericOnly();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void AlphaNumericOnlyExtensions_EnsuresAlphaNumericOnly_ShouldNotThrow_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresAlphaNumericOnly();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void AlphaNumericOnlyExtensions_EnsuresAlphaNumericOnly_ShouldNotThrow_WhenValueIsEmpty()
   {
      // Arrange.
      var value = String.Empty;
      var act = () => _ = value.EnsuresAlphaNumericOnly();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [InlineData("This is a test!")]
   [InlineData("\t")]
   [InlineData("\tASDF\t")]
   [InlineData(StringData.LowerCaseAPlusDiaeresisCombiningCharacter)]
   public void AlphaNumericOnlyExtensions_EnsuresAlphaNumericOnly_ShouldThrow_WhenValueContainsNonLetterOrNonDigitCharacters(String value)
   {
      // Arrange.
      var act = () => _ = value.EnsuresAlphaNumericOnly();

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void AlphaNumericOnlyExtensions_EnsuresAlphaNumericOnly_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = "(555) 123-4567";
      var act = () => _ = value.EnsuresAlphaNumericOnly();

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.AlphaNumericOnly);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void AlphaNumericOnlyExtensions_EnsuresAlphaNumericOnly_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "(555) 123-4567";
      var act = () => _ = value.EnsuresAlphaNumericOnly();
      var expectedMessage = $"Postcondition AlphaNumericOnly failed: value may only contain alphanumeric characters";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void AlphaNumericOnlyExtensions_EnsuresAlphaNumericOnly_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "\t123\t";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresAlphaNumericOnly(messageTemplate);
      var expectedMessage = $"Requirement AlphaNumericOnly failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void NotEmptyOrWhiteSpaceExtensions_EnsuresNotEmptyOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "!@#$%^&*()_+";
      var act = () => _ = value.EnsuresAlphaNumericOnly(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition AlphaNumericOnly failed: value may only contain alphanumeric characters";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void NotEmptyOrWhiteSpaceExtensions_EnsuresNotEmptyOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.DiaeresisCombiningCharacter;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresAlphaNumericOnly(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement AlphaNumericOnly failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresAlphaNumericOnly Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData("123")]
   [InlineData("asdf")]
   [InlineData("QWERTY")]
   [InlineData(StringData.UpperCaseDiphthongAE)]
   [InlineData(StringData.LowerCaseAWithOverring)]
   [InlineData("abc123XYZ")]
   [InlineData("s\u00F8ster")]  // s + lower case slashed 'o' + ster - Danish for sister
   public void AlphaNumericOnlyExtensions_RequiresAlphaNumericOnly_ShouldNotThrow_WhenValueContainsOnlyLetterOrDigitCharacters(String value)
   {
      // Arrange.
      var act = () => _ = value.RequiresAlphaNumericOnly();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void AlphaNumericOnlyExtensions_RequiresAlphaNumericOnly_ShouldNotThrow_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresAlphaNumericOnly();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void AlphaNumericOnlyExtensions_RequiresAlphaNumericOnly_ShouldNotThrow_WhenValueIsEmpty()
   {
      // Arrange.
      var value = String.Empty;
      var act = () => _ = value.RequiresAlphaNumericOnly();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [InlineData("This is a test!")]
   [InlineData("\t")]
   [InlineData("\tASDF\t")]
   [InlineData(StringData.LowerCaseAPlusDiaeresisCombiningCharacter)]
   public void AlphaNumericOnlyExtensions_RequiresAlphaNumericOnly_ShouldThrow_WhenValueContainsNonLetterOrNonDigitCharacters(String value)
   {
      // Arrange.
      var act = () => _ = value.RequiresAlphaNumericOnly();

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Fact]
   public void AlphaNumericOnlyExtensions_RequiresAlphaNumericOnly_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = "(555) 123-4567";
      var act = () => _ = value.RequiresAlphaNumericOnly();

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.AlphaNumericOnly);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void AlphaNumericOnlyExtensions_RequiresAlphaNumericOnly_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "(555) 123-4567";
      var act = () => _ = value.RequiresAlphaNumericOnly();
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition AlphaNumericOnly failed: value may only contain alphanumeric characters";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void AlphaNumericOnlyExtensions_RequiresAlphaNumericOnly_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "\t123\t";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresAlphaNumericOnly(messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement AlphaNumericOnly failed";

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
      var act = () => _ = value.RequiresAlphaNumericOnly(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition AlphaNumericOnly failed: value may only contain alphanumeric characters";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void NotEmptyOrWhiteSpaceExtensions_RequiresNotEmptyOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.DiaeresisCombiningCharacter;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresAlphaNumericOnly(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement AlphaNumericOnly failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
