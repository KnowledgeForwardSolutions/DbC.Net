namespace DbC.Net.Tests.Unit;

public class RegexMatchExtensionsTests
{
   private const Int32 _dataCount = 6;

   private const String AdjacentRepeatedWordRegex = @"\b(?<word>\w+)\s+(\k<word>)\b";
   private const String EmailAddressRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
   private const String IpAddressRegex = @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

   #region EnsuresRegexMatch Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData("abc@xyz.com", EmailAddressRegex, RegexOptions.None)]
   [InlineData("192.168.1.1", IpAddressRegex, RegexOptions.None)]
   [InlineData("One one two", AdjacentRepeatedWordRegex, RegexOptions.IgnoreCase)]
   public void RegexMatchExtensions_EnsuresRegexMatch_ShouldNotThrow_WhenRegexIsMatched(
      String value,
      String regexText,
      RegexOptions options)
   {
      // Arrange.
      var regex = new Regex(regexText, options);
      var act = () => _ = value.EnsuresRegexMatch(regex);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [InlineData("abc@xyz.com", EmailAddressRegex, RegexOptions.None)]
   [InlineData("192.168.1.1", IpAddressRegex, RegexOptions.None)]
   [InlineData("One one two", AdjacentRepeatedWordRegex, RegexOptions.IgnoreCase)]
   public void RegexMatchExtensions_EnsuresRegexMatch_ShouldReturnOriginalValue_WhenRegexIsMatched(
      String value,
      String regexText,
      RegexOptions options)
   {
      // Act.
      var regex = new Regex(regexText, options);
      var result = value.EnsuresRegexMatch(regex);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [InlineData("One one two")]
   [InlineData("")]
   public void RegexMatchExtensions_EnsuresRegexMatch_ShouldThrow_WhenRegexIsNotMatched(String value)
   {
      // Arrange.
      var regexText = AdjacentRepeatedWordRegex;
      var regex = new Regex(regexText);
      var act = () => _ = value.EnsuresRegexMatch(regex);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatch_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = "a@b";
      var regexText = EmailAddressRegex;
      var regex = new Regex(regexText);
      var act = () => _ = value.EnsuresRegexMatch(regex);

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.RegexMatch);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Regex].Should().Be(regexText);
      ex.Data[DataNames.RegexOptions].Should().Be(RegexOptions.None);
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatch_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "a@b";
      var regexText = EmailAddressRegex;
      var regex = new Regex(regexText);
      var act = () => _ = value.EnsuresRegexMatch(regex);
      var expectedMessage = $"Postcondition RegexMatch failed: value must match the regular expression: {regexText}";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatch_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "One two three";
      var regexText = AdjacentRepeatedWordRegex;
      var options = RegexOptions.IgnoreCase;
      var regex = new Regex(regexText, options);
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresRegexMatch(regex, messageTemplate);
      var expectedMessage = $"Requirement RegexMatch failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatch_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "a@b";
      var regexText = EmailAddressRegex;
      var regex = new Regex(regexText);
      var exceptionFactory = TestExceptionFactories.CustomExceptionFactory;
      var act = () => _ = value.EnsuresRegexMatch(regex, exceptionFactory: exceptionFactory);
      var expectedMessage = $"Postcondition RegexMatch failed: value must match the regular expression: {regexText}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatch_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "One two three";
      var regexText = AdjacentRepeatedWordRegex;
      var options = RegexOptions.IgnoreCase;
      var regex = new Regex(regexText, options);
      var messageTemplate = "Requirement {RequirementName} failed";
      var exceptionFactory = TestExceptionFactories.CustomExceptionFactory;
      var act = () => _ = value.EnsuresRegexMatch(regex, messageTemplate, exceptionFactory);
      var expectedMessage = $"Requirement RegexMatch failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatch_ShouldThrowArgumentNullException_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var regexText = IpAddressRegex;
      var regex = new Regex(regexText);
      var act = () => _ = value.EnsuresRegexMatch(regex);
      var expectedMessage = Messages.RegexInputIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(value))
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatch_ShouldThrowArgumentNullException_WhenRegexIsNull()
   {
      // Arrange.
      var value = "asdf";
      Regex regex = null!;
      var act = () => _ = value.EnsuresRegexMatch(regex);
      var expectedMessage = Messages.RegexIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(regex))
         .WithMessage(expectedMessage + "*");
   }

   #endregion

   #region RequiresRegexMatch Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData("abc@xyz.com", EmailAddressRegex, RegexOptions.None)]
   [InlineData("192.168.1.1", IpAddressRegex, RegexOptions.None)]
   [InlineData("One one two", AdjacentRepeatedWordRegex, RegexOptions.IgnoreCase)]
   public void RegexMatchExtensions_RequiresRegexMatch_ShouldNotThrow_WhenRegexIsMatched(
      String value,
      String regexText,
      RegexOptions options)
   {
      // Arrange.
      var regex = new Regex(regexText, options);
      var act = () => _ = value.RequiresRegexMatch(regex);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [InlineData("abc@xyz.com", EmailAddressRegex, RegexOptions.None)]
   [InlineData("192.168.1.1", IpAddressRegex, RegexOptions.None)]
   [InlineData("One one two", AdjacentRepeatedWordRegex, RegexOptions.IgnoreCase)]
   public void RegexMatchExtensions_RequiresRegexMatch_ShouldReturnOriginalValue_WhenRegexIsMatched(
      String value,
      String regexText,
      RegexOptions options)
   {
      // Act.
      var regex = new Regex(regexText, options);
      var result = value.RequiresRegexMatch(regex);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [InlineData("One one two")]
   [InlineData("")]
   public void RegexMatchExtensions_RequiresRegexMatch_ShouldThrow_WhenRegexIsNotMatched(String value)
   {
      // Arrange.
      var regexText = AdjacentRepeatedWordRegex;
      var regex = new Regex(regexText);
      var act = () => _ = value.RequiresRegexMatch(regex);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatch_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = "a@b";
      var regexText = EmailAddressRegex;
      var regex = new Regex(regexText);
      var act = () => _ = value.RequiresRegexMatch(regex);

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.RegexMatch);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Regex].Should().Be(regexText);
      ex.Data[DataNames.RegexOptions].Should().Be(RegexOptions.None);
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatch_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "a@b";
      var regexText = EmailAddressRegex;
      var regex = new Regex(regexText);
      var act = () => _ = value.RequiresRegexMatch(regex);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition RegexMatch failed: value must match the regular expression: {regexText}";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatch_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "One two three";
      var regexText = AdjacentRepeatedWordRegex;
      var options = RegexOptions.IgnoreCase;
      var regex = new Regex(regexText, options);
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresRegexMatch(regex, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement RegexMatch failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatch_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "a@b";
      var regexText = EmailAddressRegex;
      var regex = new Regex(regexText);
      var exceptionFactory = TestExceptionFactories.CustomExceptionFactory;
      var act = () => _ = value.RequiresRegexMatch(regex, exceptionFactory: exceptionFactory);
      var expectedMessage = $"Precondition RegexMatch failed: value must match the regular expression: {regexText}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatch_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "One two three";
      var regexText = AdjacentRepeatedWordRegex;
      var options = RegexOptions.IgnoreCase;
      var regex = new Regex(regexText, options);
      var messageTemplate = "Requirement {RequirementName} failed";
      var exceptionFactory = TestExceptionFactories.CustomExceptionFactory;
      var act = () => _ = value.RequiresRegexMatch(regex, messageTemplate, exceptionFactory);
      var expectedMessage = $"Requirement RegexMatch failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatch_ShouldThrowArgumentNullException_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var regexText = IpAddressRegex;
      var regex = new Regex(regexText);
      var act = () => _ = value.RequiresRegexMatch(regex);
      var expectedMessage = Messages.RegexInputIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(value))
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatch_ShouldThrowArgumentNullException_WhenRegexIsNull()
   {
      // Arrange.
      var value = "asdf";
      Regex regex = null!;
      var act = () => _ = value.RequiresRegexMatch(regex);
      var expectedMessage = Messages.RegexIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(regex))
         .WithMessage(expectedMessage + "*");
   }

   #endregion
}
