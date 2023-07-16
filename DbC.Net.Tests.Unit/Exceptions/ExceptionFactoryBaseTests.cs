namespace DbC.Net.Tests.Unit.Exceptions;

public class ExceptionFactoryTests
{
    // Non-abstract class to test ExceptionFactoryBase.CreateMessage method.
    private class ExampleExceptionFactory : ExceptionFactoryBase
    {
        public ExampleExceptionFactory() { }

        public ExampleExceptionFactory(IReadOnlyCollection<string> keys, IValueTransform transform)
           : base(keys, transform) { }

        public ExampleExceptionFactory(IReadOnlyDictionary<string, IValueTransform> transforms)
           : base(transforms) { }

        public override Exception CreateException(
           IReadOnlyDictionary<string, object> data,
           string messageTemplate)
           => throw new NotImplementedException();
    }

    private readonly IReadOnlyCollection<string> _keys = new List<string> { DataNames.Value, DataNames.ValueExpression };
    private readonly IValueTransform _transform = StandardTransforms.AsteriskMaskTransform;
    private readonly IReadOnlyDictionary<string, IValueTransform> _transforms = new Dictionary<string, IValueTransform>()
   {
      { DataNames.Value, StandardTransforms.DigitAsteriskMaskTransform },
      { DataNames.ValueExpression, StandardTransforms.AsteriskMaskTransform }
   };

    private readonly Dictionary<string, object> _data = new() {
      { DataNames.RequirementType, RequirementType.Precondition },
      { DataNames.RequirementName, RequirementNames.Equal },
      { DataNames.Value, 42 },
      { DataNames.ValueExpression, "theAnswerToTheUltimateQuestionOfLifeTheUniverseAndEverything" } };

    #region Constructor Tests
    // ==========================================================================
    // ==========================================================================

    [Fact]
    public void ExceptionFactoryBase_ParameterlessConstructor_ShouldCreateObject()
    {
        // Act.
        var sut = new ExampleExceptionFactory();

        // Assert.
        sut.Should().NotBeNull();
    }

    [Fact]
    public void ExceptionFactoryBase_CollectionAndValueTransformConstructor_ShouldCreateObject_WhenAllValuesSupplied()
    {
        // Act.
        var sut = new ExampleExceptionFactory(_keys, _transform);

        // Assert.
        sut.Should().NotBeNull();
    }

    [Fact]
    public void ExceptionFactoryBase_CollectionAndValueTransformConstructor_ShouldThrowArgumentNullException_WhenKeysCollectionIsNull()
    {
        // Arrange.
        IReadOnlyCollection<string> keys = null!;
        var act = () => _ = new ExampleExceptionFactory(keys, _transform);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(keys))
           .And.Message.Should().StartWith(Messages.TransformKeysCollectonIsNull);
    }

    [Fact]
    public void ExceptionFactoryBase_CollectionAndValueTransformConstructor_ShouldThrowArgumentNullException_WhenTransformIsNull()
    {
        // Arrange.
        IValueTransform transform = null!;
        var act = () => _ = new ExampleExceptionFactory(_keys, transform);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(transform))
           .And.Message.Should().StartWith(Messages.ValueTransformIsNull);
    }

    [Fact]
    public void ExceptionFactoryBase_TransformDictionaryConstructor_ShouldCreateObject_WhenAllValuesSupplied()
    {
        // Act.
        var sut = new ExampleExceptionFactory(_transforms);

        // Assert.
        sut.Should().NotBeNull();
    }

    [Fact]
    public void ExceptionFactoryBase_TransformDictionaryConstructor_ShouldThrowArgumentNullException_WhenTransformDictionaryIsNull()
    {
        // Arrange.
        IReadOnlyDictionary<string, IValueTransform> transforms = null!;
        var act = () => _ = new ExampleExceptionFactory(transforms);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(transforms))
           .And.Message.Should().StartWith(Messages.TransformsDictionaryIsNull);
    }

    #endregion

    #region ApplyTransforms Method Tests
    // ==========================================================================
    // ==========================================================================

    [Fact]
    public void ExceptionFactoryBase_ApplyTransforms_ShouldReturnOriginalValues_WhenNoTransformsDefined()
    {
        // Arrange.
        var sut = new ExampleExceptionFactory();

        // Act.
        var transformed = sut.ApplyTransforms(_data);

        // Assert.
        transformed.Should().NotBeSameAs(_data);
        transformed.Should().BeEquivalentTo(_data);
    }

    [Fact]
    public void ExceptionFactoryBase_ApplyTransforms_ShouldReturnOriginalValues_WhenNoTransformKeysMatch()
    {
        // Arrange.
        IReadOnlyCollection<string> keys = new List<string> { DataNames.Regex };
        var sut = new ExampleExceptionFactory(keys, _transform);

        // Act.
        var transformed = sut.ApplyTransforms(_data);

        // Assert.
        transformed.Should().NotBeSameAs(_data);
        transformed.Should().BeEquivalentTo(_data);
    }

    [Fact]
    public void ExceptionFactoryBase_ApplyTransforms_ShouldReturnExpectedResult_WhenTransformKeysMatchAndOneTransformIsDefined()
    {
        // Arrange.
        var sut = new ExampleExceptionFactory(_keys, _transform);

        IReadOnlyDictionary<string, object> data = new Dictionary<string, object> {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, RequirementNames.Equal },
         { DataNames.Value, "111-222-3333" },
         { DataNames.ValueExpression, "accountNumber" } };

        // Act.
        var transformed = sut.ApplyTransforms(data);

        // Assert.
        transformed.Should().NotBeSameAs(data);
        transformed[DataNames.RequirementType].Should().Be(data[DataNames.RequirementType]);
        transformed[DataNames.RequirementName].Should().Be(data[DataNames.RequirementName]);
        transformed[DataNames.Value].Should().Be("************");
        transformed[DataNames.ValueExpression].Should().Be("*************");
    }

    [Fact]
    public void ExceptionFactoryBase_ApplyTransforms_ShouldReturnExpectedResult_WhenTransformKeysMatchAndMultipleTransformsAreDefined()
    {
        // Arrange.
        var sut = new ExampleExceptionFactory(_transforms);

        IReadOnlyDictionary<string, object> data = new Dictionary<string, object> {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, RequirementNames.Equal },
         { DataNames.Value, "111-222-3333" },
         { DataNames.ValueExpression, "accountNumber" } };

        // Act.
        var transformed = sut.ApplyTransforms(data);

        // Assert.
        transformed.Should().NotBeSameAs(data);
        transformed[DataNames.RequirementType].Should().Be(data[DataNames.RequirementType]);
        transformed[DataNames.RequirementName].Should().Be(data[DataNames.RequirementName]);
        transformed[DataNames.Value].Should().Be("***-***-****");
        transformed[DataNames.ValueExpression].Should().Be("*************");
    }

    #endregion

    #region CreateMessage Method Tests
    // ==========================================================================
    // ==========================================================================

    [Fact]
    public void ExceptionFactoryBase_CreateMessage_ShouldReturnUnchangedMessageTemplate_WhenTemplateContainsNoPlaceholders()
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
    public void ExceptionFactoryBase_CreateMessage_ShouldReturnUnchangedMessageTemplate_WhenDataDictionaryIsEmpty()
    {
        // Arrange.
        var messageTemplate = "{RequirementType} {RequirementName} failed: {Value} is incorrect";
        var data = new Dictionary<string, object>();

        var sut = new ExampleExceptionFactory();

        // Act.
        var message = sut.CreateMessage(messageTemplate, data);

        // Assert.
        message.Should().Be(messageTemplate);
    }

    [Fact]
    public void ExceptionFactoryBase_CreateMessage_ShouldReturnUnchangedMessageTemplate_WhenNoPlaceholdersMatchItemsInDataDictionary()
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
    public void ExceptionFactoryBase_CreateMessage_ShouldNotReplacePlaceholder_WhenItemKeyIsPartialButNotExactMatchForPlaceholder()
    {
        // Arrange. Note item key "Value" is a substring of placeholder {ValueExpression}. Should not match.
        var messageTemplate = "{RequirementType} {RequirementName} failed: {ValueExpression} is incorrect";
        var data = new Dictionary<string, object> {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, RequirementNames.Equal },
         { DataNames.Value, 42 } };

        var sut = new ExampleExceptionFactory();

        var expectedMessage = "Precondition Equal failed: {ValueExpression} is incorrect";

        // Act.
        var message = sut.CreateMessage(messageTemplate, data);

        // Assert.
        message.Should().Be(expectedMessage);
    }

    [Fact]
    public void ExceptionFactoryBase_CreateMessage_ShouldNotReplacePlaceholder_WhenPlaceholderIsPartialButNotExactMatchForItemKey()
    {
        // Arrange. Note item key "Value" is a substring of placeholder {ValueExpression}. Should not match.
        var messageTemplate = "{RequirementType} {RequirementName} failed: {Value} is incorrect";
        var data = new Dictionary<string, object> {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, RequirementNames.Equal },
         { DataNames.ValueExpression, "theAnswerToTheUltimateQuestionOfLifeTheUniverseAndEverything" } };

        var sut = new ExampleExceptionFactory();

        var expectedMessage = "Precondition Equal failed: {Value} is incorrect";

        // Act.
        var message = sut.CreateMessage(messageTemplate, data);

        // Assert.
        message.Should().Be(expectedMessage);
    }

    [Fact]
    public void ExceptionFactoryBase_CreateMessage_ShouldReturnExpectedMessage_WhenTemplatePlaceholdersAreMatched()
    {
        // Arrange.
        var messageTemplate = "{RequirementType} {RequirementName} failed: {Value} is incorrect";

        var sut = new ExampleExceptionFactory();

        var expectedMessage = "Precondition Equal failed: 42 is incorrect";

        // Act.
        var message = sut.CreateMessage(messageTemplate, _data);

        // Assert.
        message.Should().Be(expectedMessage);
    }

    [Fact]
    public void ExceptionFactoryBase_CreateMessage_ShouldReturnExpectedMessage_WhenTemplatePlaceholderIsRepeatedAndMatched()
    {
        // Arrange.
        var messageTemplate = "{RequirementType} {RequirementName} failed: {Value} is incorrect. Don't use {Value}. Use something else";

        var sut = new ExampleExceptionFactory();

        var expectedMessage = "Precondition Equal failed: 42 is incorrect. Don't use 42. Use something else";

        // Act.
        var message = sut.CreateMessage(messageTemplate, _data);

        // Assert.
        message.Should().Be(expectedMessage);
    }

    [Fact]
    public void ExceptionFactoryBase_CreateMessage_ShouldReturnExpectedMessage_WhenItemValuesAreNull()
    {
        // Arrange.
        var messageTemplate = "{RequirementType} {RequirementName} failed: '{Value}' is incorrect. Don't use '{Value}'. Use something else";
        var data = new Dictionary<string, object>() {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, RequirementNames.Equal },
         { DataNames.Value, default(string)! },
         { DataNames.ValueExpression, "theAnswerToTheUltimateQuestionOfLifeTheUniverseAndEverything" } };

        var sut = new ExampleExceptionFactory();

        var expectedMessage = "Precondition Equal failed: '' is incorrect. Don't use ''. Use something else";

        // Act.
        var message = sut.CreateMessage(messageTemplate, data);

        // Assert.
        message.Should().Be(expectedMessage);
    }

    [Theory]
    [InlineData("")]
    [InlineData("\t")]
    public void ExceptionFactoryBase_CreateMessage_ShouldThrowArgumentException_WhenMessageTemplateIsEmpty(string messageTemplate)
    {
        // Arrange. 
        var sut = new ExampleExceptionFactory();
        var act = () => _ = sut.CreateMessage(messageTemplate, _data);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentException>()
           .WithParameterName(nameof(messageTemplate))
           .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
    }

    [Fact]
    public void ExceptionFactoryBase_CreateMessage_ShouldThrowArgumentNullException_WhenMessageTemplateIsNull()
    {
        // Arrange. 
        string messageTemplate = null!;
        var sut = new ExampleExceptionFactory();
        var act = () => _ = sut.CreateMessage(messageTemplate, _data);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(messageTemplate))
           .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
    }

    [Fact]
    public void ExceptionFactoryBase_CreateMessage_ShouldThrowArgumentNullException_WhenDataIsNull()
    {
        // Arrange. 
        var messageTemplate = "{RequirementName} failed: {Value} is incorrect";
        Dictionary<string, object> data = null!;

        var sut = new ExampleExceptionFactory();
        var act = () => _ = sut.CreateMessage(messageTemplate, data);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(data))
           .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
    }

    #endregion

    #region ValidateDataDictionary Method Tests
    // ==========================================================================
    // ==========================================================================

    [Fact]
    public void ExceptionFactoryBase_ValidateDataDictionary_ShouldThrowArgumentNullException_WhenDataIsNull()
    {
        // Arrange.
        Dictionary<string, object> data = null!;

        var act = () => ExceptionFactoryBase.ValidateDataDictionary(data);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(data))
           .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
    }

    [Fact]
    public void ExceptionFactoryBase_ValidateDataDictionary_ShouldNotThrow_WhenDataIsNotNull()
    {
        // Arrange.
        var act = () => ExceptionFactoryBase.ValidateDataDictionary(_data);

        // Act/assert.
        act.Should().NotThrow();
    }

    #endregion

    #region GetParamName Method Tests
    // ==========================================================================
    // ==========================================================================

    [Fact]
    public void ExceptionFactoryBase_GetParamName_ShouldReturnStringEmpty_WhenValueExpressionIsNotSupplied()
    {
        // Arrange.
        var data = new Dictionary<string, object> {
         { DataNames.Value, 42 } };
        var sut = new ExampleExceptionFactory();

        // Act.
        var paramName = sut.GetParamName(data);

        // Assert.
        paramName.Should().Be(string.Empty);
    }

    public static TheoryData<string> ValidValueExpressionData => new TheoryData<string>
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
    public void ExceptionFactoryBase_GetParamName_ShouldReturnExpectedParamName_WhenValueExpressionIsSupplied(string valueExpression)
    {
        // Arrange.
        var data = new Dictionary<string, object> {
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
    public void ExceptionFactoryBase_ValidateMessageTemplate_ShouldThrowArgumentNullException_WhenMessageTemplateIsNull()
    {
        // Arrange.
        string messageTemplate = null!;

        var act = () => ExceptionFactoryBase.ValidateMessageTemplate(messageTemplate);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(messageTemplate))
           .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
    }

    [Theory]
    [InlineData("")]
    [InlineData("\t")]
    public void ExceptionFactoryBase_ValidateMessageTemplate_ShouldThrowArgumentNullException_WhenMessageTemplateIsEmpty(string messageTemplate)
    {
        // Arrange.
        var act = () => ExceptionFactoryBase.ValidateMessageTemplate(messageTemplate);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentException>()
           .WithParameterName(nameof(messageTemplate))
           .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
    }

    [Fact]
    public void ExceptionFactoryBase_ValidateMessageTemplate_ShouldNotThrow_WhenMessageTemplateIsNotEmpty()
    {
        // Arrange.
        var messageTemplate = "non-empty template";
        var act = () => ExceptionFactoryBase.ValidateMessageTemplate(messageTemplate);

        // Act/assert.
        act.Should().NotThrow();
    }

    #endregion
}
