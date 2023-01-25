namespace DbC.Net.Tests.Unit.ExceptionFactories;

public class ExceptionFactoryTests
{
   // Non-abstract class to test ExceptionFactory.CreateMessage method.
   private class ExampleExceptionFactory : ExceptionFactory
   {
      public override Exception CreateException(
         String messageTemplate, 
         Dictionary<String, Object> data) 
         => throw new NotImplementedException();
   }

   private readonly Dictionary<String, Object> _data = new() {
      { DataNames.RequirementType, RequirementType.Precondition },
      { DataNames.RequirementName, "Equals" },
      { DataNames.Value, 42 },
      { DataNames.ValueExpression, "theAnswerToTheUltimateQuestionOfLifeTheUniverseAndEverything" } };

   #region CreateMessage Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ExceptionFactory_CreateMessage_ShouldReturnUnchangedMessageTemplate_WhenTemplateContainsNoPlaceholders()
   {
      // Arrange.
      var messageTemplate = "Example exception message";

      var sut = new ExampleExceptionFactory();

      // Act.
      var message = sut.CreateMessage(messageTemplate, _data);

      // Assert.
      message.Should().Be(messageTemplate);
   }

   [Fact]
   public void ExceptionFactory_CreateMessage_ShouldReturnUnchangedMessageTemplate_WhenDataDictionaryIsEmpty()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: {Value} is incorrect";
      var data = new Dictionary<String, Object>();

      var sut = new ExampleExceptionFactory();

      // Act.
      var message = sut.CreateMessage(messageTemplate, data);

      // Assert.
      message.Should().Be(messageTemplate);
   }

   [Fact]
   public void ExceptionFactory_CreateMessage_ShouldReturnUnchangedMessageTemplate_WhenNoPlaceholdersMatchItemsInDataDictionary()
   {
      // Arrange.
      var messageTemplate = "{TheTest} failed: {TheAnswer} is incorrect";

      var sut = new ExampleExceptionFactory();

      // Act.
      var message = sut.CreateMessage(messageTemplate, _data);

      // Assert.
      message.Should().Be(messageTemplate);
   }

   [Fact]
   public void ExceptionFactory_CreateMessage_ShouldNotReplacePlaceholder_WhenItemKeyIsPartialButNotExactMatchForPlaceholder()
   {
      // Arrange. Note item key "Value" is a substring of placeholder {ValueExpression}. Should not match.
      var messageTemplate = "{RequirementType} {RequirementName} failed: {ValueExpression} is incorrect";
      var data = new Dictionary<String, Object> {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, "Equals" },
         { DataNames.Value, 42 } };

   var sut = new ExampleExceptionFactory();

      var expectedMessage = "Precondition Equals failed: {ValueExpression} is incorrect";

      // Act.
      var message = sut.CreateMessage(messageTemplate, data);

      // Assert.
      message.Should().Be(expectedMessage);
   }

   [Fact]
   public void ExceptionFactory_CreateMessage_ShouldNotReplacePlaceholder_WhenPlaceholderIsPartialButNotExactMatchForItemKey()
   {
      // Arrange. Note item key "Value" is a substring of placeholder {ValueExpression}. Should not match.
      var messageTemplate = "{RequirementType} {RequirementName} failed: {Value} is incorrect";
      var data = new Dictionary<String, Object> {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, "Equals" },
         { DataNames.ValueExpression, "theAnswerToTheUltimateQuestionOfLifeTheUniverseAndEverything" } };

      var sut = new ExampleExceptionFactory();

      var expectedMessage = "Precondition Equals failed: {Value} is incorrect";

      // Act.
      var message = sut.CreateMessage(messageTemplate, data);

      // Assert.
      message.Should().Be(expectedMessage);
   }

   [Fact]
   public void ExceptionFactory_CreateMessage_ShouldReturnExpectedMessageTemplate_WhenTemplatePlaceholdersAreMatched()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: {Value} is incorrect";

      var sut = new ExampleExceptionFactory();

      var expectedMessage = "Precondition Equals failed: 42 is incorrect";

      // Act.
      var message = sut.CreateMessage(messageTemplate, _data);

      // Assert.
      message.Should().Be(expectedMessage);
   }

   [Fact]
   public void ExceptionFactory_CreateMessage_ShouldReturnExpectedMessageTemplate_WhenTemplatePlaceholderIsRepeatedAndMatched()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: {Value} is incorrect. Don't use {Value}. Use something else";

      var sut = new ExampleExceptionFactory();

      var expectedMessage = "Precondition Equals failed: 42 is incorrect. Don't use 42. Use something else";

      // Act.
      var message = sut.CreateMessage(messageTemplate, _data);

      // Assert.
      message.Should().Be(expectedMessage);
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void ExceptionFactory_CreateMessage_ShouldThrowArgumentException_WhenMessageTemplateIsEmpty(String messageTemplate)
   {
      // Arrange. 
      var sut = new ExampleExceptionFactory();
      var act = () => _ = sut.CreateMessage(messageTemplate, _data);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void ExceptionFactory_CreateMessage_ShouldThrowArgumentNullException_WhenMessageTemplateIsNull()
   {
      // Arrange. 
      String messageTemplate = null!;
      var sut = new ExampleExceptionFactory();
      var act = () => _ = sut.CreateMessage(messageTemplate, _data);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void ExceptionFactory_CreateMessage_ShouldThrowArgumentNullException_WhenDataIsNull()
   {
      // Arrange. 
      var messageTemplate = "{RequirementName} failed: {Value} is incorrect";
      Dictionary<String, Object> data = null!;

      var sut = new ExampleExceptionFactory();
      var act = () => _ = sut.CreateMessage(messageTemplate, data);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(data))
         .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
   }

   #endregion

   #region ValidateDataDictionary Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ExceptionFactory_ValidateDataDictionary_ShouldThrowArgumentNullException_WhenDataIsNull()
   {
      // Arrange.
      Dictionary<String, Object> data = null!;

      var act = () => ExceptionFactory.ValidateDataDictionary(data);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(data))
         .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
   }

   [Fact]
   public void ExceptionFactory_ValidateDataDictionary_ShouldNotThrow_WhenDataIsNotNull()
   {
      // Arrange.
      var act = () => ExceptionFactory.ValidateDataDictionary(_data);

      // Act/assert.
      act.Should().NotThrow();
   }

   #endregion

   #region GetParamName Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ExceptionFactory_GetParamName_ShouldReturnStringEmpty_WhenValueExpressionIsNotSupplied()
   {
      // Arrange.
      var data = new Dictionary<String, Object> {
         { DataNames.Value, 42 } };
      var sut = new ExampleExceptionFactory();

      // Act.
      var paramName = sut.GetParamName(data);

      // Assert.
      paramName.Should().Be(String.Empty);
   }

   public static TheoryData<String> ValidValueExpressionData => new TheoryData<String>
   {
      { "value" },
      { "value.RequiresNotNull()" },
      { "value.EnsuresNotNull()" },
      { "value.RequiresNotNull().RequiresGreaterThanZero()" },
      { "value.EnsuresNotNull().EnsuresGreaterThanZero()" },
      { "value.RequiresNotNull().EnsuresGreaterThanZero()" },
      { "value.EnsuresNotNull().RequiresGreaterThanZero()" },
      { "value .RequiresNotNull() .RequiresGreaterThanZero()" },
      { "value .EnsuresNotNull() .EnsuresGreaterThanZero()" },
      { "value .RequiresNotNull() .EnsuresGreaterThanZero()" },
      { "value .EnsuresNotNull() .RequiresGreaterThanZero()" },
      { @"value 
            .RequiresNotNull()
            .RequiresGreaterThanZero()" },
      { @"value 
            .EnsuresNotNull()
            .EnsuresGreaterThanZero()" },
      { @"value 
            .RequiresNotNull()
            .EnsuresGreaterThanZero()" },
      { @"value 
            .EnsuresNotNull()
            .RequiresGreaterThanZero()" },
      { @"value. 
            RequiresNotNull().
            RequiresGreaterThanZero()" },
      { @"value. 
            EnsuresNotNull().
            EnsuresGreaterThanZero()" },
      { @"value. 
            RequiresNotNull().
            EnsuresGreaterThanZero()" },
      { @"value. 
            EnsuresNotNull().
            RequiresGreaterThanZero()" },
   };

   [Theory]
   [MemberData(nameof(ValidValueExpressionData))]
   public void ExceptionFactory_GetParamName_ShouldReturnExpectedParamName_WhenValueExpressionIsSupplied(String valueExpression)
   {
      // Arrange.
      var data = new Dictionary<String, Object> {
         { DataNames.Value, 42 },
         { DataNames.ValueExpression, valueExpression } };
      var sut = new ExampleExceptionFactory();

      var expectedParamName = "value";

      // Act.
      var paramName = sut.GetParamName(data);

      // Assert.
      paramName.Should().Be(expectedParamName);
   }

   #endregion

   #region ValidateMessageTemplate Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ExceptionFactory_ValidateMessageTemplate_ShouldThrowArgumentNullException_WhenMessageTemplateIsNull()
   {
      // Arrange.
      String messageTemplate = null!;

      var act = () => ExceptionFactory.ValidateMessageTemplate(messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void ExceptionFactory_ValidateMessageTemplate_ShouldThrowArgumentNullException_WhenMessageTemplateIsEmpty(String messageTemplate)
   {
      // Arrange.
      var act = () => ExceptionFactory.ValidateMessageTemplate(messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void ExceptionFactory_ValidateMessageTemplate_ShouldNotThrow_WhenMessageTemplateIsNotEmpty()
   {
      // Arrange.
      var messageTemplate = "non-empty template";
      var act = () => ExceptionFactory.ValidateMessageTemplate(messageTemplate);

      // Act/assert.
      act.Should().NotThrow();
   }

   #endregion
}
