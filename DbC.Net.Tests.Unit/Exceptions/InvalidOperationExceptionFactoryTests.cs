namespace DbC.Net.Tests.Unit.Exceptions;

public class InvalidOperationExceptionFactoryTests
{
    private readonly IReadOnlyCollection<string> _keys = new List<string> { DataNames.Value };
    private readonly IValueTransform _transform = StandardTransforms.AsteriskMaskTransform;
    private readonly IReadOnlyDictionary<string, IValueTransform> _transforms = new Dictionary<string, IValueTransform>()
   {
      { DataNames.Value, StandardTransforms.DigitAsteriskMaskTransform },
      { DataNames.ValueExpression, StandardTransforms.AsteriskMaskTransform }
   };

    private const string _messageTemplate = "{RequirementType} {RequirementName} failed: value (\"{Value}\") is not a word that starts with 'M'";

    private readonly Dictionary<string, object> _data = new() {
      { DataNames.RequirementType, RequirementType.Precondition },
      { DataNames.RequirementName, "RegexMatch" },
      { DataNames.Value, "asdf" },
      { DataNames.ValueExpression, "apiResponse" },
      { DataNames.Regex, @"\b[M]\w+" } };

    #region Constructor Tests
    // ==========================================================================
    // ==========================================================================

    [Fact]
    public void InvalidOperationExceptionFactory_ParameterlessConstructor_ShouldCreateObject()
    {
        // Act.
        var sut = new InvalidOperationExceptionFactory();

        // Assert.
        sut.Should().NotBeNull();
    }

    [Fact]
    public void InvalidOperationExceptionFactory_CollectionAndValueTransformConstructor_ShouldCreateObject_WhenAllValuesSupplied()
    {
        // Act.
        var sut = new InvalidOperationExceptionFactory(_keys, _transform);

        // Assert.
        sut.Should().NotBeNull();
    }

    [Fact]
    public void InvalidOperationExceptionFactory_CollectionAndValueTransformConstructor_ShouldThrowArgumentNullException_WhenKeysCollectionIsNull()
    {
        // Arrange.
        IReadOnlyCollection<string> keys = null!;
        var act = () => _ = new InvalidOperationExceptionFactory(keys, _transform);

        // Act/assert.
        act.Should().Throw<ArgumentNullException>()
           .WithParameterName(nameof(keys))
           .And.Message.Should().StartWith(Messages.TransformKeysCollectonIsNull);
    }

    [Fact]
    public void InvalidOperationExceptionFactory_CollectionAndValueTransformConstructor_ShouldThrowArgumentNullException_WhenTransformIsNull()
    {
        // Arrange.
        IValueTransform transform = null!;
        var act = () => _ = new InvalidOperationExceptionFactory(_keys, transform);

        // Act/assert.
        act.Should().Throw<ArgumentNullException>()
           .WithParameterName(nameof(transform))
           .And.Message.Should().StartWith(Messages.ValueTransformIsNull);
    }

    [Fact]
    public void InvalidOperationExceptionFactory_TransformDictionaryConstructor_ShouldCreateObject_WhenAllValuesSupplied()
    {
        // Act.
        var sut = new InvalidOperationExceptionFactory(_transforms);

        // Assert.
        sut.Should().NotBeNull();
    }

    [Fact]
    public void InvalidOperationExceptionFactory_TransformDictionaryConstructor_ShouldThrowArgumentNullException_WhenTransformDictionaryIsNull()
    {
        // Arrange.
        IReadOnlyDictionary<string, IValueTransform> transforms = null!;
        var act = () => _ = new InvalidOperationExceptionFactory(transforms);

        // Act/assert.
        act.Should().Throw<ArgumentNullException>()
           .WithParameterName(nameof(transforms))
           .And.Message.Should().StartWith(Messages.TransformsDictionaryIsNull);
    }

    #endregion

    #region CreateException Method Tests
    // ==========================================================================
    // ==========================================================================

    [Fact]
    public void InvalidOperationExceptionFactory_CreateException_ShouldCreateExceptionOfExpectedType()
    {
        // Arrange.
        var sut = new InvalidOperationExceptionFactory();

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();
        ex.Should().BeOfType<InvalidOperationException>();
    }

    [Fact]
    public void InvalidOperationExceptionFactory_CreateException_ShouldCreateExceptionWithOriginalDataValues_WhenNoValueTransformsAreSpecified()
    {
        // Arrange.
        var sut = new InvalidOperationExceptionFactory();

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();

        ex.Data.Count.Should().Be(_data.Count);
        ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
        ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
        ex.Data[DataNames.Value].Should().Be(_data[DataNames.Value]);
        ex.Data[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
        ex.Data[DataNames.Regex].Should().Be(_data[DataNames.Regex]);
    }

    [Fact]
    public void InvalidOperationExceptionFactory_CreateException_ShouldCreateExceptionWithTransformedDataValues_WhenValueTransformsAreSpecified()
    {
        // Arrange.
        var sut = new InvalidOperationExceptionFactory(_keys, _transform);
        var expectedValue = "****";

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();

        ex.Data.Count.Should().Be(_data.Count);
        ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
        ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
        ex.Data[DataNames.Value].Should().Be(expectedValue);
        ex.Data[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
        ex.Data[DataNames.Regex].Should().Be(_data[DataNames.Regex]);
    }

    [Fact]
    public void InvalidOperationExceptionFactory_CreateException_ShouldCreateExceptionWithExpectedMessage_WhenNoValueTransformsAreSpecified()
    {
        // Arrange.
        var sut = new InvalidOperationExceptionFactory();
        var expectedMessage = "Precondition RegexMatch failed: value (\"asdf\") is not a word that starts with 'M'";

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();
        ex.Message.Should().StartWith(expectedMessage);
    }

    [Fact]
    public void InvalidOperationExceptionFactory_CreateException_ShouldCreateExceptionWithExpectedMessage_WhenValueTransformsAreSpecified()
    {
        // Arrange.
        var sut = new InvalidOperationExceptionFactory(_keys, _transform);
        var expectedMessage = "Precondition RegexMatch failed: value (\"****\") is not a word that starts with 'M'";

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();
        ex.Message.Should().StartWith(expectedMessage);
    }

    [Fact]
    public void InvalidOperationExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenDataDictionaryIsNull()
    {
        // Arrange.
        Dictionary<string, object> data = null!;
        var sut = new InvalidOperationExceptionFactory();
        var act = () => _ = sut.CreateException(data, _messageTemplate);

        // Act/assert.
        act.Should().Throw<ArgumentNullException>()
           .WithParameterName(nameof(data))
           .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
    }

    [Theory]
    [InlineData("")]
    [InlineData("\t")]
    public void InvalidOperationExceptionFactory_CreateException_ShouldThrowInvalidOperationException_WhenMessageTemplateIsEmpty(string messageTemplate)
    {
        // Arrange.
        var sut = new InvalidOperationExceptionFactory();
        var act = () => _ = sut.CreateException(_data, messageTemplate);

        // Act/assert.
        act.Should().Throw<ArgumentException>()
           .WithParameterName(nameof(messageTemplate))
           .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
    }

    [Fact]
    public void InvalidOperationExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenMessageTemplateIsNull()
    {
        // Arrange.
        string messageTemplate = null!;
        var sut = new InvalidOperationExceptionFactory();
        var act = () => _ = sut.CreateException(_data, messageTemplate);

        // Act/assert.
        act.Should().Throw<ArgumentNullException>()
           .WithParameterName(nameof(messageTemplate))
           .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
    }

    #endregion
}
