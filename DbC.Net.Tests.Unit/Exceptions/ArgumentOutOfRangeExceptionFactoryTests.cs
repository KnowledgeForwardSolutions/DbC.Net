﻿namespace DbC.Net.Tests.Unit.Exceptions;

public class ArgumentOutOfRangeExceptionFactoryTests
{
    private readonly IReadOnlyCollection<string> _keys = new List<string> { DataNames.Value };
    private readonly IValueTransform _transform = StandardTransforms.DigitAsteriskMaskTransform;
    private readonly IReadOnlyDictionary<string, IValueTransform> _transforms = new Dictionary<string, IValueTransform>()
   {
      { DataNames.Value, StandardTransforms.DigitAsteriskMaskTransform },
      { DataNames.ValueExpression, StandardTransforms.AsteriskMaskTransform }
   };

    private const string _messageTemplate = "{RequirementType} {RequirementName} failed: value ({Value}) is not greater than {LowerBound}";

    private readonly IReadOnlyDictionary<string, object> _data = new Dictionary<string, object>() {
      { DataNames.RequirementType, RequirementType.Precondition },
      { DataNames.RequirementName, "GreaterThan" },
      { DataNames.Value, 99.9 },
      { DataNames.ValueExpression, "sum" },
      { DataNames.LowerBound, 100.0 },
      { DataNames.LowerBoundExpression, "lowerBound" } };

    #region Constructor Tests
    // ==========================================================================
    // ==========================================================================

    [Fact]
    public void ArgumentOutOfRangeExceptionFactory_ParameterlessConstructor_ShouldCreateObject()
    {
        // Act.
        var sut = new ArgumentOutOfRangeExceptionFactory();

        // Assert.
        sut.Should().NotBeNull();
    }

    [Fact]
    public void ArgumentOutOfRangeExceptionFactory_CollectionAndValueTransformConstructor_ShouldCreateObject_WhenAllValuesSupplied()
    {
        // Act.
        var sut = new ArgumentOutOfRangeExceptionFactory(_keys, _transform);

        // Assert.
        sut.Should().NotBeNull();
    }

    [Fact]
    public void ArgumentOutOfRangeExceptionFactory_CollectionAndValueTransformConstructor_ShouldThrowArgumentNullException_WhenKeysCollectionIsNull()
    {
        // Arrange.
        IReadOnlyCollection<string> keys = null!;
        var act = () => _ = new ArgumentOutOfRangeExceptionFactory(keys, _transform);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(keys))
           .And.Message.Should().StartWith(Messages.TransformKeysCollectonIsNull);
    }

    [Fact]
    public void ArgumentOutOfRangeExceptionFactory_CollectionAndValueTransformConstructor_ShouldThrowArgumentNullException_WhenTransformIsNull()
    {
        // Arrange.
        IValueTransform transform = null!;
        var act = () => _ = new ArgumentOutOfRangeExceptionFactory(_keys, transform);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(transform))
           .And.Message.Should().StartWith(Messages.ValueTransformIsNull);
    }

    [Fact]
    public void ArgumentOutOfRangeExceptionFactory_TransformDictionaryConstructor_ShouldCreateObject_WhenAllValuesSupplied()
    {
        // Act.
        var sut = new ArgumentOutOfRangeExceptionFactory(_transforms);

        // Assert.
        sut.Should().NotBeNull();
    }

    [Fact]
    public void ArgumentOutOfRangeExceptionFactory_TransformDictionaryConstructor_ShouldThrowArgumentNullException_WhenTransformDictionaryIsNull()
    {
        // Arrange.
        IReadOnlyDictionary<string, IValueTransform> transforms = null!;
        var act = () => _ = new ArgumentOutOfRangeExceptionFactory(transforms);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(transforms))
           .And.Message.Should().StartWith(Messages.TransformsDictionaryIsNull);
    }

    #endregion

    #region CreateException Method Tests
    // ==========================================================================
    // ==========================================================================

    [Fact]
    public void ArgumentOutOfRangeExceptionFactory_CreateException_ShouldCreateExceptionOfExpectedType()
    {
        // Arrange.
        var sut = new ArgumentOutOfRangeExceptionFactory();

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();
        ex.Should().BeOfType<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void ArgumentOutOfRangeExceptionFactory_CreateException_ShouldCreateExceptionWithOriginalDataValues_WhenNoValueTransformsAreSpecified()
    {
        // Arrange.
        var sut = new ArgumentOutOfRangeExceptionFactory();

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();

        ex.Data.Count.Should().Be(_data.Count);
        ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
        ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
        ex.Data[DataNames.Value].Should().Be(_data[DataNames.Value]);
        ex.Data[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
        ex.Data[DataNames.LowerBound].Should().Be(_data[DataNames.LowerBound]);
        ex.Data[DataNames.LowerBoundExpression].Should().Be(_data[DataNames.LowerBoundExpression]);
    }

    [Fact]
    public void ArgumentOutOfRangeExceptionFactory_CreateException_ShouldCreateExceptionWithTransformedDataValues_WhenValueTransformsAreSpecified()
    {
        // Arrange.
        var sut = new ArgumentOutOfRangeExceptionFactory(_keys, _transform);
        var expectedValue = "**.*";

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();

        ex.Data.Count.Should().Be(_data.Count);
        ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
        ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
        ex.Data[DataNames.Value].Should().Be(expectedValue);
        ex.Data[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
        ex.Data[DataNames.LowerBound].Should().Be(_data[DataNames.LowerBound]);
        ex.Data[DataNames.LowerBoundExpression].Should().Be(_data[DataNames.LowerBoundExpression]);
    }

    [Fact]
    public void ArgumentOutOfRangeExceptionFactory_CreateException_ShouldCreateExceptionWithExpectedMessage_WhenNoValueTransformsAreSpecified()
    {
        // Arrange.
        var sut = new ArgumentOutOfRangeExceptionFactory();
        var expectedMessage = "Precondition GreaterThan failed: value (99.9) is not greater than 100";

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();
        ex.Message.Should().StartWith(expectedMessage);
    }

    [Fact]
    public void ArgumentOutOfRangeExceptionFactory_CreateException_ShouldCreateExceptionWithExpectedMessage_WhenValueTransformsAreSpecified()
    {
        // Arrange.
        var sut = new ArgumentOutOfRangeExceptionFactory(_keys, _transform);
        var expectedMessage = "Precondition GreaterThan failed: value (**.*) is not greater than 100";

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();
        ex.Message.Should().StartWith(expectedMessage);
    }

    [Fact]
    public void ArgumentOutOfRangeExceptionFactory_CreateException_ShouldCreateExceptionWithExpectedParamName_WhenNoValueTransformsAreSpecified()
    {
        // Arrange.
        var sut = new ArgumentOutOfRangeExceptionFactory();
        var expectedParamName = "sum";

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();
        ex.ParamName.Should().Be(expectedParamName);
    }

    [Fact]
    public void ArgumentOutOfRangeExceptionFactory_CreateException_ShouldCreateExceptionWithExpectedActualValue_WhenNoValueTransformsAreSpecified()
    {
        // Arrange.
        var sut = new ArgumentOutOfRangeExceptionFactory();
        var expectedActualValue = 99.9;

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();
        ex.ActualValue.Should().Be(expectedActualValue);
    }

    [Fact]
    public void ArgumentOutOfRangeExceptionFactory_CreateException_ShouldCreateExceptionWithExpectedActualValue_WhenValueTransformsAreSpecified()
    {
        // Arrange.
        var sut = new ArgumentOutOfRangeExceptionFactory(_keys, _transform);
        var expectedActualValue = "**.*";

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();
        ex.ActualValue.Should().Be(expectedActualValue);
    }

    [Fact]
    public void ArgumentOutOfRangeExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenDataDictionaryIsNull()
    {
        // Arrange.
        Dictionary<string, object> data = null!;
        var sut = new ArgumentOutOfRangeExceptionFactory();
        var act = () => _ = sut.CreateException(data, _messageTemplate);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(data))
           .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
    }

    [Theory]
    [InlineData("")]
    [InlineData("\t")]
    public void ArgumentOutOfRangeExceptionFactory_CreateException_ShouldThrowArgumentException_WhenMessageTemplateIsEmpty(string messageTemplate)
    {
        // Arrange.
        var sut = new ArgumentOutOfRangeExceptionFactory();
        var act = () => _ = sut.CreateException(_data, messageTemplate);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentException>()
           .WithParameterName(nameof(messageTemplate))
           .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
    }

    [Fact]
    public void ArgumentOutOfRangeExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenMessageTemplateIsNull()
    {
        // Arrange.
        string messageTemplate = null!;
        var sut = new ArgumentOutOfRangeExceptionFactory();
        var act = () => _ = sut.CreateException(_data, messageTemplate);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(messageTemplate))
           .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
    }

    #endregion
}
