﻿namespace DbC.Net.Tests.Unit.Exceptions;

public class ArgumentExceptionFactoryTests
{
    private readonly IReadOnlyCollection<string> _keys = new List<string> { DataNames.Value };
    private readonly IValueTransform _transform = StandardTransforms.AsteriskMaskTransform;
    private readonly IReadOnlyDictionary<string, IValueTransform> _transforms = new Dictionary<string, IValueTransform>()
   {
      { DataNames.Value, StandardTransforms.DigitAsteriskMaskTransform },
      { DataNames.ValueExpression, StandardTransforms.AsteriskMaskTransform }
   };

    private const string _messageTemplate = "{RequirementType} {RequirementName} failed: value (\"{Value}\") does not meet minimum length of {MinLength}";

    private readonly IReadOnlyDictionary<string, object> _data = new Dictionary<string, object> {
      { DataNames.RequirementType, RequirementType.Precondition },
      { DataNames.RequirementName, "MinLength" },
      { DataNames.Value, "Ab" },
      { DataNames.ValueExpression, "firstName.EnsuresNotNull()" },
      { DataNames.MinLength, 5 },
      { DataNames.MinLengthExpression, "5" } };

    #region Constructor Tests
    // ==========================================================================
    // ==========================================================================

    [Fact]
    public void ArgumentExceptionFactory_ParameterlessConstructor_ShouldCreateObject()
    {
        // Act.
        var sut = new ArgumentExceptionFactory();

        // Assert.
        sut.Should().NotBeNull();
    }

    [Fact]
    public void ArgumentExceptionFactory_CollectionAndValueTransformConstructor_ShouldCreateObject_WhenAllValuesSupplied()
    {
        // Act.
        var sut = new ArgumentExceptionFactory(_keys, _transform);

        // Assert.
        sut.Should().NotBeNull();
    }

    [Fact]
    public void ArgumentExceptionFactory_CollectionAndValueTransformConstructor_ShouldThrowArgumentNullException_WhenKeysCollectionIsNull()
    {
        // Arrange.
        IReadOnlyCollection<string> keys = null!;
        var act = () => _ = new ArgumentExceptionFactory(keys, _transform);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(keys))
           .And.Message.Should().StartWith(Messages.TransformKeysCollectonIsNull);
    }

    [Fact]
    public void ArgumentExceptionFactory_CollectionAndValueTransformConstructor_ShouldThrowArgumentNullException_WhenTransformIsNull()
    {
        // Arrange.
        IValueTransform transform = null!;
        var act = () => _ = new ArgumentExceptionFactory(_keys, transform);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(transform))
           .And.Message.Should().StartWith(Messages.ValueTransformIsNull);
    }

    [Fact]
    public void ArgumentExceptionFactory_TransformDictionaryConstructor_ShouldCreateObject_WhenAllValuesSupplied()
    {
        // Act.
        var sut = new ArgumentExceptionFactory(_transforms);

        // Assert.
        sut.Should().NotBeNull();
    }

    [Fact]
    public void ArgumentExceptionFactory_TransformDictionaryConstructor_ShouldThrowArgumentNullException_WhenTransformDictionaryIsNull()
    {
        // Arrange.
        IReadOnlyDictionary<string, IValueTransform> transforms = null!;
        var act = () => _ = new ArgumentExceptionFactory(transforms);

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
    public void ArgumentExceptionFactory_CreateException_ShouldCreateExceptionOfExpectedType()
    {
        // Arrange.
        var sut = new ArgumentExceptionFactory();

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();
        ex.Should().BeOfType<ArgumentException>();
    }

    [Fact]
    public void ArgumentExceptionFactory_CreateException_ShouldCreateExceptionWithOriginalDataValues_WhenNoValueTransformsAreSpecified()
    {
        // Arrange.
        var sut = new ArgumentExceptionFactory();

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();

        ex.Data.Count.Should().Be(_data.Count);
        ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
        ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
        ex.Data[DataNames.Value].Should().Be(_data[DataNames.Value]);
        ex.Data[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
        ex.Data[DataNames.MinLength].Should().Be(_data[DataNames.MinLength]);
        ex.Data[DataNames.MinLengthExpression].Should().Be(_data[DataNames.MinLengthExpression]);
    }

    [Fact]
    public void ArgumentExceptionFactory_CreateException_ShouldCreateExceptionWithTransformedDataValues_WhenValueTransformsAreSpecified()
    {
        // Arrange.
        var sut = new ArgumentExceptionFactory(_keys, _transform);
        var expectedValue = "**";

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();

        ex.Data.Count.Should().Be(_data.Count);
        ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
        ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
        ex.Data[DataNames.Value].Should().Be(expectedValue);
        ex.Data[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
        ex.Data[DataNames.MinLength].Should().Be(_data[DataNames.MinLength]);
        ex.Data[DataNames.MinLengthExpression].Should().Be(_data[DataNames.MinLengthExpression]);
    }

    [Fact]
    public void ArgumentExceptionFactory_CreateException_ShouldCreateExceptionWithExpectedMessage_WhenNoValueTransformsAreSpecified()
    {
        // Arrange.
        var sut = new ArgumentExceptionFactory();
        var expectedMessage = "Precondition MinLength failed: value (\"Ab\") does not meet minimum length of 5";

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();
        ex.Message.Should().StartWith(expectedMessage);
    }

    [Fact]
    public void ArgumentExceptionFactory_CreateException_ShouldCreateExceptionWithExpectedMessage_WhenValueTransformsAreSpecified()
    {
        // Arrange.
        var sut = new ArgumentExceptionFactory(_keys, _transform);
        var expectedMessage = "Precondition MinLength failed: value (\"**\") does not meet minimum length of 5";

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();
        ex.Message.Should().StartWith(expectedMessage);
    }

    [Fact]
    public void ArgumentExceptionFactory_CreateException_ShouldCreateExceptionWithExpectedParamName_WhenNoValueTransformsAreSpecified()
    {
        // Arrange.
        var sut = new ArgumentExceptionFactory();
        var expectedParamName = "firstName";

        // Act.
        var ex = sut.CreateException(_data, _messageTemplate);

        // Assert.
        ex.Should().NotBeNull();
        ex.ParamName.Should().Be(expectedParamName);
    }

    [Fact]
    public void ArgumentExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenDataDictionaryIsNull()
    {
        // Arrange.
        Dictionary<string, object> data = null!;
        var sut = new ArgumentExceptionFactory();
        var act = () => _ = sut.CreateException(data, _messageTemplate);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(data))
           .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
    }

    [Theory]
    [InlineData("")]
    [InlineData("\t")]
    public void ArgumentExceptionFactory_CreateException_ShouldThrowArgumentException_WhenMessageTemplateIsEmpty(string messageTemplate)
    {
        // Arrange.
        var sut = new ArgumentExceptionFactory();
        var act = () => _ = sut.CreateException(_data, messageTemplate);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentException>()
           .WithParameterName(nameof(messageTemplate))
           .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
    }

    [Fact]
    public void ArgumentExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenMessageTemplateIsNull()
    {
        // Arrange.
        string messageTemplate = null!;
        var sut = new ArgumentExceptionFactory();
        var act = () => _ = sut.CreateException(_data, messageTemplate);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(messageTemplate))
           .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
    }

    #endregion
}
