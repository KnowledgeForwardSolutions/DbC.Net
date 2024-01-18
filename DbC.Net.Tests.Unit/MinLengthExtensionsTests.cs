namespace DbC.Net.Tests.Unit;

#pragma warning disable xUnit1012 // Null should only be used for nullable parameters
public class MinLengthExtensionsTests
{
   private const Int32 _dataCount = 6;

   public static TheoryData<String> TenCharacterStrings => new()
   {
      { "abcdefghij" },
      {
         StringData.LowerCaseAWithDiaeresis + StringData.LowerCaseAWithOverring +
         StringData.LowerCaseDiphthongAE + StringData.LowerCaseDotlessI +
         StringData.LowerCaseEszett + StringData.LowerCaseOWithDiaeresis +
         StringData.UpperCaseSlashedO + StringData.UpperCaseOWithDiaeresis +
         StringData.UpperCaseDottedI + StringData.UpperCaseAWithOverring
      }
   };

   #region EnsuresMinLength Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MinLengthExtensions_EnsuresMinLength_ShouldNotThrow_WhenNonNullNonEmptyValueHasLengthGreaterThanMinLength(String value)
   {
      // Arrange.
      var minLength = 9;
      var act = () => _ = value.EnsuresMinLength(minLength);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MinLengthExtensions_EnsuresMinLength_ShouldNotThrow_WhenNonNullNonEmptyValueHasLengthEqualToMinLength(String value)
   {
      // Arrange.
      var minLength = 10;
      var act = () => _ = value.EnsuresMinLength(minLength);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [InlineData(null)]
   [InlineData("")]
   public void MinLengthExtensions_EnsuresMinLength_ShouldNotThrow_WhenValueIsNullOrEmptyAndMinLengthIsZero(String value)
   {
      // Arrange.
      var minLength = 0;
      var act = () => _ = value.EnsuresMinLength(minLength);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MinLengthExtensions_EnsuresMinLength_ShouldThrow_WhenValueHasLengthGreaterThanMinLength(String value)
   {
      // Arrange.
      var minLength = 11;
      var act = () => _ = value.EnsuresMinLength(minLength);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void MinLengthExtensions_EnsuresMinLength_ShouldThrow_WhenValueIsNullAndMinLengthIsGreaterThanZero()
   {
      // Arrange.
      String value = null!;
      var maxLength = 10;
      var act = () => _ = value.EnsuresMinLength(maxLength);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void MinLengthExtensions_EnsuresMinLength_ShouldThrow_WhenValueIsEmptyAndMinLengthIsGreaterThanZero()
   {
      // Arrange.
      var value = String.Empty;
      var maxLength = 10;
      var act = () => _ = value.EnsuresMinLength(maxLength);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MinLengthExtensions_EnsuresMinLength_ShouldReturnOriginalValue_WhenNonNullNonEmptyValueHasLengthGreaterThanMinLength(String value)
   {
      // Arrange.
      var minLength = 9;

      // Assert.
      var result = _ = value.EnsuresMinLength(minLength);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MinLengthExtensions_EnsuresMinLength_ShouldReturnOriginalValue_WhenNonNullNonEmptyValueHasLengthEqualToMinLength(String value)
   {
      // Arrange.
      var minLength = 10;

      // Assert.
      var result = _ = value.EnsuresMinLength(minLength);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [InlineData(null)]
   [InlineData("")]
   public void MinLengthExtensions_EnsuresMinLength_ShouldReturnOriginalValue_WhenValueIsNullOrEmptyAndMinLengthIsZero(String value)
   {
      // Arrange.
      var minLength = 0;

      // Assert.
      var result = _ = value.EnsuresMinLength(minLength);

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void MinLengthExtensions_EnsuresMinLength_ShouldThrowArgumentOutOfRangeException_WhenMinLengthIsNegative()
   {
      // Arrange.
      var value = "asdf";
      var minLength = -1;
      var expectedMessage = Messages.MinLengthIsNegative;
      var act = () => _ = value.EnsuresMinLength(minLength);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(nameof(minLength))
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(minLength);
   }

   [Fact]
   public void MinLengthExtensions_EnsuresMinLength_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = "abc";
      var minLength = 10;
      var act = () => _ = value.EnsuresMinLength(minLength);

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.MinLength);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.MinLength].Should().Be(minLength);
      ex.Data[DataNames.MinLengthExpression].Should().Be(nameof(minLength));
   }

   [Fact]
   public void MinLengthExtensions_EnsuresMinLength_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "abc";
      var minLength = 10;
      var act = () => _ = value.EnsuresMinLength(minLength);
      var expectedMessage = $"Postcondition MinLength failed: {nameof(value)} must have a minimum length of {minLength}";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void MinLengthExtensions_EnsuresMinLength_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "abc";
      var minLength = 10;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresMinLength(minLength, messageTemplate);
      var expectedMessage = $"Requirement MinLength failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void MinLengthExtensions_EnsuresMinLength_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "abc";
      var minLength = 10;
      var act = () => _ = value.EnsuresMinLength(minLength, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition MinLength failed: {nameof(value)} must have a minimum length of {minLength}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void MinLengthExtensions_EnsuresMinLength_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "abc";
      var minLength = 10;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresMinLength(minLength, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement MinLength failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresMinLength Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MinLengthExtensions_RequiresMinLength_ShouldNotThrow_WhenNonNullNonEmptyValueHasLengthGreaterThanMinLength(String value)
   {
      // Arrange.
      var minLength = 9;
      var act = () => _ = value.RequiresMinLength(minLength);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MinLengthExtensions_RequiresMinLength_ShouldNotThrow_WhenNonNullNonEmptyValueHasLengthEqualToMinLength(String value)
   {
      // Arrange.
      var minLength = 10;
      var act = () => _ = value.RequiresMinLength(minLength);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [InlineData(null)]
   [InlineData("")]
   public void MinLengthExtensions_RequiresMinLength_ShouldNotThrow_WhenValueIsNullOrEmptyAndMinLengthIsZero(String value)
   {
      // Arrange.
      var minLength = 0;
      var act = () => _ = value.RequiresMinLength(minLength);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MinLengthExtensions_RequiresMinLength_ShouldThrow_WhenValueHasLengthGreaterThanMinLength(String value)
   {
      // Arrange.
      var minLength = 11;
      var act = () => _ = value.RequiresMinLength(minLength);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Fact]
   public void MinLengthExtensions_RequiresMinLength_ShouldThrow_WhenValueIsNullAndMinLengthIsGreaterThanZero()
   {
      // Arrange.
      String value = null!;
      var maxLength = 10;
      var act = () => _ = value.RequiresMinLength(maxLength);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Fact]
   public void MinLengthExtensions_RequiresMinLength_ShouldThrow_WhenValueIsEmptyAndMinLengthIsGreaterThanZero()
   {
      // Arrange.
      var value = String.Empty;
      var maxLength = 10;
      var act = () => _ = value.RequiresMinLength(maxLength);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MinLengthExtensions_RequiresMinLength_ShouldReturnOriginalValue_WhenNonNullNonEmptyValueHasLengthGreaterThanMinLength(String value)
   {
      // Arrange.
      var minLength = 9;

      // Assert.
      var result = _ = value.RequiresMinLength(minLength);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MinLengthExtensions_RequiresMinLength_ShouldReturnOriginalValue_WhenNonNullNonEmptyValueHasLengthEqualToMinLength(String value)
   {
      // Arrange.
      var minLength = 10;

      // Assert.
      var result = _ = value.RequiresMinLength(minLength);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [InlineData(null)]
   [InlineData("")]
   public void MinLengthExtensions_RequiresMinLength_ShouldReturnOriginalValue_WhenValueIsNullOrEmptyAndMinLengthIsZero(String value)
   {
      // Arrange.
      var minLength = 0;

      // Assert.
      var result = _ = value.RequiresMinLength(minLength);

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void MinLengthExtensions_RequiresMinLength_ShouldThrowArgumentOutOfRangeException_WhenMinLengthIsNegative()
   {
      // Arrange.
      var value = "asdf";
      var minLength = -1;
      var expectedMessage = Messages.MinLengthIsNegative;
      var act = () => _ = value.RequiresMinLength(minLength);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(nameof(minLength))
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(minLength);
   }

   [Fact]
   public void MinLengthExtensions_RequiresMinLength_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = "abc";
      var minLength = 10;
      var act = () => _ = value.RequiresMinLength(minLength);

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.MinLength);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.MinLength].Should().Be(minLength);
      ex.Data[DataNames.MinLengthExpression].Should().Be(nameof(minLength));
   }

   [Fact]
   public void MinLengthExtensions_RequiresMinLength_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "abc";
      var minLength = 10;
      var act = () => _ = value.RequiresMinLength(minLength);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition MinLength failed: {nameof(value)} must have a minimum length of {minLength}";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MinLengthExtensions_RequiresMinLength_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "abc";
      var minLength = 10;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresMinLength(minLength, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement MinLength failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MinLengthExtensions_RequiresMinLength_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "abc";
      var minLength = 10;
      var act = () => _ = value.RequiresMinLength(minLength, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition MinLength failed: {nameof(value)} must have a minimum length of {minLength}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void MinLengthExtensions_RequiresMinLength_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "abc";
      var minLength = 10;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresMinLength(minLength, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement MinLength failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
