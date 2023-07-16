namespace DbC.Net.Tests.Unit;

public class MaxLengthExtensionsTests
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

   #region EnsuresMaxLength Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldNotThrow_WhenNonNullNonEmptyValueHasLengthLessThanMaxLength(String value)
   {
      // Arrange.
      var maxLength = 11;
      var act = () => _ = value.EnsuresMaxLength(maxLength);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldNotThrow_WhenNonNullNonEmptyValueHasLengthEqualToMaxLength(String value)
   {
      // Arrange.
      var maxLength = 10;
      var act = () => _ = value.EnsuresMaxLength(maxLength);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldNotThrow_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var maxLength = 10;
      var act = () => _ = value.EnsuresMaxLength(maxLength);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldNotThrow_WhenValueIsEmpty()
   {
      // Arrange.
      var value = String.Empty;
      var maxLength = 10;
      var act = () => _ = value.EnsuresMaxLength(maxLength);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [InlineData(null)]
   [InlineData("")]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldNotThrow_WhenValueIsNullOrEmptyAndMaxLengthIsZero(String value)
   {
      // Arrange.
      var maxLength = 0;
      var act = () => _ = value.EnsuresMaxLength(maxLength);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldThrow_WhenValueHasLengthGreaterThanMaxLength(String value)
   {
      // Arrange.
      var maxLength = 9;
      var act = () => _ = value.EnsuresMaxLength(maxLength);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldReturnOriginalValue_WhenNonNullNonEmptyValueHasLengthLessThanMaxLength(String value)
   {
      // Arrange.
      var maxLength = 11;

      // Act.
      var result = value.EnsuresMaxLength(maxLength);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldReturnOriginalValue_WhenNonNullNonEmptyValueHasLengthEqualToMaxLength(String value)
   {
      // Arrange.
      var maxLength = 10;

      // Act.
      var result = value.EnsuresMaxLength(maxLength);

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldReturnOriginalValue_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var maxLength = 10;

      // Act.
      var result = value.EnsuresMaxLength(maxLength);

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldReturnOriginalValue_WhenValueIsEmpty()
   {
      // Arrange.
      var value = String.Empty;
      var maxLength = 10;

      // Act.
      var result = value.EnsuresMaxLength(maxLength);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [InlineData(null)]
   [InlineData("")]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldReturnOriginalValue_WhenValueIsNullOrEmptyAndMaxLengthIsZero(String value)
   {
      // Arrange.
      var maxLength = 0;

      // Act.
      var result = value.EnsuresMaxLength(maxLength);

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldThrowArgumentOutOfRangeException_WhenMaxLengthIsNegative()
   {
      // Arrange.
      var value = "asdf";
      var maxLength = -1;
      var expectedMessage = Messages.MaxLengthIsNegative;
      var act = () => _ = value.EnsuresMaxLength(maxLength);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(nameof(maxLength))
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(maxLength);
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = "abcdefghijklmnopqrstuvwxyz";
      var maxLength = 10;
      var act = () => _ = value.EnsuresMaxLength(maxLength);

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.MaxLength);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.MaxLength].Should().Be(maxLength);
      ex.Data[DataNames.MaxLengthExpression].Should().Be(nameof(maxLength));
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "abc";
      var maxLength = 1;
      var act = () => _ = value.EnsuresMaxLength(maxLength);
      var expectedMessage = $"Postcondition MaxLength failed: {nameof(value)} must have a maximum length of {maxLength}";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "a";
      var maxLength = 0;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresMaxLength(maxLength, messageTemplate);
      var expectedMessage = $"Requirement MaxLength failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "abc";
      var maxLength = 1;
      var act = () => _ = value.EnsuresMaxLength(maxLength, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition MaxLength failed: {nameof(value)} must have a maximum length of {maxLength}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "abc";
      var maxLength = 1;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresMaxLength(maxLength, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement MaxLength failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresMaxLength Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldNotThrow_WhenNonNullNonEmptyValueHasLengthLessThanMaxLength(String value)
   {
      // Arrange.
      var maxLength = 11;
      var act = () => _ = value.RequiresMaxLength(maxLength);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldNotThrow_WhenNonNullNonEmptyValueHasLengthEqualToMaxLength(String value)
   {
      // Arrange.
      var maxLength = 10;
      var act = () => _ = value.RequiresMaxLength(maxLength);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldNotThrow_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var maxLength = 10;
      var act = () => _ = value.RequiresMaxLength(maxLength);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldNotThrow_WhenValueIsEmpty()
   {
      // Arrange.
      var value = String.Empty;
      var maxLength = 10;
      var act = () => _ = value.RequiresMaxLength(maxLength);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [InlineData(null)]
   [InlineData("")]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldNotThrow_WhenValueIsNullOrEmptyAndMaxLengthIsZero(String value)
   {
      // Arrange.
      var maxLength = 0;
      var act = () => _ = value.RequiresMaxLength(maxLength);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldThrow_WhenValueHasLengthGreaterThanMaxLength(String value)
   {
      // Arrange.
      var maxLength = 9;
      var act = () => _ = value.RequiresMaxLength(maxLength);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldReturnOriginalValue_WhenNonNullNonEmptyValueHasLengthLessThanMaxLength(String value)
   {
      // Arrange.
      var maxLength = 11;

      // Act.
      var result = value.RequiresMaxLength(maxLength);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [MemberData(nameof(TenCharacterStrings))]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldReturnOriginalValue_WhenNonNullNonEmptyValueHasLengthEqualToMaxLength(String value)
   {
      // Arrange.
      var maxLength = 10;

      // Act.
      var result = value.RequiresMaxLength(maxLength);

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldReturnOriginalValue_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var maxLength = 10;

      // Act.
      var result = value.RequiresMaxLength(maxLength);

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldReturnOriginalValue_WhenValueIsEmpty()
   {
      // Arrange.
      var value = String.Empty;
      var maxLength = 10;

      // Act.
      var result = value.RequiresMaxLength(maxLength);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [InlineData(null)]
   [InlineData("")]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldReturnOriginalValue_WhenValueIsNullOrEmptyAndMaxLengthIsZero(String value)
   {
      // Arrange.
      var maxLength = 0;

      // Act.
      var result = value.RequiresMaxLength(maxLength);

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldThrowArgumentOutOfRangeException_WhenMaxLengthIsNegative()
   {
      // Arrange.
      var value = "asdf";
      var maxLength = -1;
      var expectedMessage = Messages.MaxLengthIsNegative;
      var act = () => _ = value.RequiresMaxLength(maxLength);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(nameof(maxLength))
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(maxLength);
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = "abcdefghijklmnopqrstuvwxyz";
      var maxLength = 10;
      var act = () => _ = value.RequiresMaxLength(maxLength);

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.MaxLength);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.MaxLength].Should().Be(maxLength);
      ex.Data[DataNames.MaxLengthExpression].Should().Be(nameof(maxLength));
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "abc";
      var maxLength = 1;
      var act = () => _ = value.RequiresMaxLength(maxLength);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition MaxLength failed: {nameof(value)} must have a maximum length of {maxLength}";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "a";
      var maxLength = 0;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresMaxLength(maxLength, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement MaxLength failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "abc";
      var maxLength = 1;
      var act = () => _ = value.RequiresMaxLength(maxLength, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition MaxLength failed: {nameof(value)} must have a maximum length of {maxLength}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "abc";
      var maxLength = 1;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresMaxLength(maxLength, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement MaxLength failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
