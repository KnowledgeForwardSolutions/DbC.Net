namespace DbC.Net.Tests.Unit;

public class RegexMatchExtensionsTests
{
   private const Int32 _dataCount = 6;

   private const String AdjacentRepeatedWordRegex = @"\b(?<word>\w+)\s+(\k<word>)\b";
   private const String EmailAddressRegex = @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$";
   private const String IpAddressRegex = @"^(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$";

   #region EnsuresRegexMatch (String Overload) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData("abc@xyz.com", EmailAddressRegex)]
   [InlineData("192.168.1.1", IpAddressRegex)]
   public void RegexMatchExtensions_EnsuresRegexMatchStringOverload_ShouldNotThrow_WhenRegexIsMatchedAndOptionsAreDefault(
      String value,
      String regexText)
   {
      // Arrange.
      var act = () => _ = value.EnsuresRegexMatch(regexText);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [InlineData("abc@xyz.com", EmailAddressRegex)]
   [InlineData("192.168.1.1", IpAddressRegex)]
   public void RegexMatchExtensions_EnsuresRegexMatchStringOverload_ShouldReturnOriginalValue_WhenRegexIsMatchedAndOptionsAreDefault(
      String value,
      String regexText)
   {
      // Act.
      var result = value.EnsuresRegexMatch(regexText);

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatchStringOverload_ShouldNotThrow_WhenRegexIsMatchedAndOptionsAreSpecified()
   {
      // Arrange.
      var value = "One one two";
      var regexText = AdjacentRepeatedWordRegex;
      var options = RegexOptions.IgnoreCase;
      var act = () => _ = value.EnsuresRegexMatch(regexText, options);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatchStringOverload_ShouldReturnOriginalValue_WhenRegexIsMatchedAndOptionsAreSpecified()
   {
      // Arrange.
      var value = "One one two";
      var regexText = AdjacentRepeatedWordRegex;
      var options = RegexOptions.IgnoreCase;

      // Act
      var result = value.EnsuresRegexMatch(regexText, options);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [InlineData("One one two")]
   [InlineData("")]
   public void RegexMatchExtensions_EnsuresRegexMatchStringOverload_ShouldThrow_WhenRegexIsNotMatchedAndOptionsAreDefault(String value)
   {
      // Arrange.
      var regexText = AdjacentRepeatedWordRegex;
      var act = () => _ = value.EnsuresRegexMatch(regexText);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Theory]
   [InlineData("19216811")]
   [InlineData("")]
   public void RegexMatchExtensions_EnsuresRegexMatchStringOverload_ShouldThrow_WhenRegexIsNotMatchedAndOptionsAreSpecified(String value)
   {
      // Arrange.
      var regexText = IpAddressRegex;
      var options = RegexOptions.IgnoreCase;
      var act = () => _ = value.EnsuresRegexMatch(regexText, options);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatchStringOverload_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailedAndOptionsAreDefault()
   {
      // Arrange.
      var value = "a@b";
      var regexText = EmailAddressRegex;
      var act = () => _ = value.EnsuresRegexMatch(regexText);

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
   public void RegexMatchExtensions_EnsuresRegexMatchStringOverload_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailedAndOptionsAreSpecified()
   {
      // Arrange.
      var value = "123456789";
      var regexText = IpAddressRegex;
      var options = RegexOptions.IgnoreCase;
      var act = () => _ = value.EnsuresRegexMatch(regexText, options);

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.RegexMatch);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Regex].Should().Be(regexText);
      ex.Data[DataNames.RegexOptions].Should().Be(options);
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatchStringOverload_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "a@b";
      var regexText = EmailAddressRegex;
      var act = () => _ = value.EnsuresRegexMatch(regexText);
      var expectedMessage = $"Postcondition RegexMatch failed: value must match the regular expression: {regexText}";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatchStringOverload_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "One two three";
      var regexText = AdjacentRepeatedWordRegex;
      var options = RegexOptions.IgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresRegexMatch(regexText, options, messageTemplate);
      var expectedMessage = $"Requirement RegexMatch failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatchStringOverload_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "a@b";
      var regexText = EmailAddressRegex;
      var exceptionFactory = TestExceptionFactories.CustomExceptionFactory;
      var act = () => _ = value.EnsuresRegexMatch(regexText, exceptionFactory: exceptionFactory);
      var expectedMessage = $"Postcondition RegexMatch failed: value must match the regular expression: {regexText}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatchStringOverload_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "One two three";
      var regexText = AdjacentRepeatedWordRegex;
      var options = RegexOptions.IgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var exceptionFactory = TestExceptionFactories.CustomExceptionFactory;
      var act = () => _ = value.EnsuresRegexMatch(regexText, options, messageTemplate, exceptionFactory);
      var expectedMessage = $"Requirement RegexMatch failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatchStringOverload_ShouldThrowArgumentNullException_WhenValueIsNullAndOptionsAreDefault()
   {
      // Arrange.
      String value = null!;
      var regexText = IpAddressRegex;
      var act = () => _ = value.EnsuresRegexMatch(regexText);
      var expectedMessage = Messages.RegexInputIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(value))
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatchStringOverload_ShouldThrowArgumentNullException_WhenValueIsNullAndOptionsAreSpecified()
   {
      // Arrange.
      String value = null!;
      var regexText = IpAddressRegex;
      var options = RegexOptions.IgnoreCase;
      var act = () => _ = value.EnsuresRegexMatch(regexText, options);
      var expectedMessage = Messages.RegexInputIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(value))
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void RegexMatchExtensions_EnsuresRegexMatchStringOverload_ShouldThrowArgumentNullException_WhenRegexTextIsNull()
   {
      // Arrange.
      var value = "asdf";
      String regexText = null!;
      var act = () => _ = value.EnsuresRegexMatch(regexText);
      var expectedMessage = Messages.RegexTextIsEmpty;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(regexText))
         .WithMessage(expectedMessage + "*");
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void RegexMatchExtensions_EnsuresRegexMatchStringOverload_ShouldThrowArgumentNullException_WhenRegexTextIsEmpty(String regexText)
   {
      // Arrange.
      var value = "asdf";
      var act = () => _ = value.EnsuresRegexMatch(regexText);
      var expectedMessage = Messages.RegexTextIsEmpty;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(nameof(regexText))
         .WithMessage(expectedMessage + "*");
   }

   #endregion

   #region RequiresRegexMatch (String Overload) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData("abc@xyz.com", EmailAddressRegex)]
   [InlineData("192.168.1.1", IpAddressRegex)]
   public void RegexMatchExtensions_RequiresRegexMatchStringOverload_ShouldNotThrow_WhenRegexIsMatchedAndOptionsAreDefault(
      String value,
      String regexText)
   {
      // Arrange.
      var act = () => _ = value.RequiresRegexMatch(regexText);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [InlineData("abc@xyz.com", EmailAddressRegex)]
   [InlineData("192.168.1.1", IpAddressRegex)]
   public void RegexMatchExtensions_RequiresRegexMatchStringOverload_ShouldReturnOriginalValue_WhenRegexIsMatchedAndOptionsAreDefault(
      String value,
      String regexText)
   {
      // Act.
      var result = value.RequiresRegexMatch(regexText);

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatchStringOverload_ShouldNotThrow_WhenRegexIsMatchedAndOptionsAreSpecified()
   {
      // Arrange.
      var value = "One one two";
      var regexText = AdjacentRepeatedWordRegex;
      var options = RegexOptions.IgnoreCase;
      var act = () => _ = value.RequiresRegexMatch(regexText, options);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatchStringOverload_ShouldReturnOriginalValue_WhenRegexIsMatchedAndOptionsAreSpecified()
   {
      // Arrange.
      var value = "One one two";
      var regexText = AdjacentRepeatedWordRegex;
      var options = RegexOptions.IgnoreCase;

      // Act
      var result = value.RequiresRegexMatch(regexText, options);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [InlineData("One one two")]
   [InlineData("")]
   public void RegexMatchExtensions_RequiresRegexMatchStringOverload_ShouldThrow_WhenRegexIsNotMatchedAndOptionsAreDefault(String value)
   {
      // Arrange.
      var regexText = AdjacentRepeatedWordRegex;
      var act = () => _ = value.RequiresRegexMatch(regexText);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Theory]
   [InlineData("19216811")]
   [InlineData("")]
   public void RegexMatchExtensions_RequiresRegexMatchStringOverload_ShouldThrow_WhenRegexIsNotMatchedAndOptionsAreSpecified(String value)
   {
      // Arrange.
      var regexText = IpAddressRegex;
      var options = RegexOptions.IgnoreCase;
      var act = () => _ = value.RequiresRegexMatch(regexText, options);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatchStringOverload_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailedAndOptionsAreDefault()
   {
      // Arrange.
      var value = "a@b";
      var regexText = EmailAddressRegex;
      var act = () => _ = value.RequiresRegexMatch(regexText);

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
   public void RegexMatchExtensions_RequiresRegexMatchStringOverload_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailedAndOptionsAreSpecified()
   {
      // Arrange.
      var value = "123456789";
      var regexText = IpAddressRegex;
      var options = RegexOptions.IgnoreCase;
      var act = () => _ = value.RequiresRegexMatch(regexText, options);

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.RegexMatch);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Regex].Should().Be(regexText);
      ex.Data[DataNames.RegexOptions].Should().Be(options);
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatchStringOverload_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "a@b";
      var regexText = EmailAddressRegex;
      var act = () => _ = value.RequiresRegexMatch(regexText);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition RegexMatch failed: value must match the regular expression: {regexText}";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatchStringOverload_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "One two three";
      var regexText = AdjacentRepeatedWordRegex;
      var options = RegexOptions.IgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresRegexMatch(regexText, options, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement RegexMatch failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatchStringOverload_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "a@b";
      var regexText = EmailAddressRegex;
      var exceptionFactory = TestExceptionFactories.CustomExceptionFactory;
      var act = () => _ = value.RequiresRegexMatch(regexText, exceptionFactory: exceptionFactory);
      var expectedMessage = $"Precondition RegexMatch failed: value must match the regular expression: {regexText}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatchStringOverload_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "One two three";
      var regexText = AdjacentRepeatedWordRegex;
      var options = RegexOptions.IgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var exceptionFactory = TestExceptionFactories.CustomExceptionFactory;
      var act = () => _ = value.RequiresRegexMatch(regexText, options, messageTemplate, exceptionFactory);
      var expectedMessage = $"Requirement RegexMatch failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatchStringOverload_ShouldThrowArgumentNullException_WhenValueIsNullAndOptionsAreDefault()
   {
      // Arrange.
      String value = null!; 
      var regexText = IpAddressRegex;
      var act = () => _ = value.RequiresRegexMatch(regexText);
      var expectedMessage = Messages.RegexInputIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(value))
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatchStringOverload_ShouldThrowArgumentNullException_WhenValueIsNullAndOptionsAreSpecified()
   {
      // Arrange.
      String value = null!;
      var regexText = IpAddressRegex;
      var options = RegexOptions.IgnoreCase;
      var act = () => _ = value.RequiresRegexMatch(regexText, options);
      var expectedMessage = Messages.RegexInputIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(value))
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void RegexMatchExtensions_RequiresRegexMatchStringOverload_ShouldThrowArgumentNullException_WhenRegexTextIsNull()
   {
      // Arrange.
      var value = "asdf";
      String regexText = null!;
      var act = () => _ = value.RequiresRegexMatch(regexText);
      var expectedMessage = Messages.RegexTextIsEmpty;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(regexText))
         .WithMessage(expectedMessage + "*");
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void RegexMatchExtensions_RequiresRegexMatchStringOverload_ShouldThrowArgumentNullException_WhenRegexTextIsEmpty(String regexText)
   {
      // Arrange.
      var value = "asdf";
      var act = () => _ = value.RequiresRegexMatch(regexText);
      var expectedMessage = Messages.RegexTextIsEmpty;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(nameof(regexText))
         .WithMessage(expectedMessage + "*");
   }

   #endregion
}
