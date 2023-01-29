namespace DbC.Net.Tests.Unit.ExceptionFactories;

public class FormatExceptionFactoryTests
{
   private readonly IReadOnlyCollection<String> _keys = new List<String> { DataNames.Value };
   private readonly IValueTransform _transform = StandardTransforms.AsteriskMaskTransform;
   private readonly IReadOnlyDictionary<String, IValueTransform> _transforms = new Dictionary<String, IValueTransform>()
   {
      { DataNames.Value, StandardTransforms.DigitAsteriskMaskTransform },
      { DataNames.ValueExpression, StandardTransforms.AsteriskMaskTransform }
   };

   private const String _messageTemplate = "{RequirementType} {RequirementName} failed: value (\"{Value}\") is not a valid three part name";

   private readonly Dictionary<String, Object> _data = new() {
      { DataNames.RequirementType, RequirementType.Precondition },
      { DataNames.RequirementName, "True" },
      { DataNames.Value, "a.b" },
      { DataNames.ValueExpression, "threePartName" } };

   #region Constructor Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void FormatExceptionFactory_ParameterlessConstructor_ShouldCreateObject()
   {
      // Act.
      var sut = new FormatExceptionFactory();

      // Assert.
      sut.Should().NotBeNull();
   }

   [Fact]
   public void FormatExceptionFactory_CollectionAndValueTransformConstructor_ShouldCreateObject_WhenAllValuesSupplied()
   {
      // Act.
      var sut = new FormatExceptionFactory(_keys, _transform);

      // Assert.
      sut.Should().NotBeNull();
   }

   [Fact]
   public void FormatExceptionFactory_CollectionAndValueTransformConstructor_ShouldThrowArgumentNullException_WhenKeysCollectionIsNull()
   {
      // Arrange.
      IReadOnlyCollection<String> keys = null!;
      var act = () => _ = new FormatExceptionFactory(keys, _transform);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(keys))
         .And.Message.Should().StartWith(Messages.TransformKeysCollectonIsNull);
   }

   [Fact]
   public void FormatExceptionFactory_CollectionAndValueTransformConstructor_ShouldThrowArgumentNullException_WhenTransformIsNull()
   {
      // Arrange.
      IValueTransform transform = null!;
      var act = () => _ = new FormatExceptionFactory(_keys, transform);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(transform))
         .And.Message.Should().StartWith(Messages.ValueTransformIsNull);
   }

   [Fact]
   public void FormatExceptionFactory_TransformDictionaryConstructor_ShouldCreateObject_WhenAllValuesSupplied()
   {
      // Act.
      var sut = new FormatExceptionFactory(_transforms);

      // Assert.
      sut.Should().NotBeNull();
   }

   [Fact]
   public void FormatExceptionFactory_TransformDictionaryConstructor_ShouldThrowArgumentNullException_WhenTransformDictionaryIsNull()
   {
      // Arrange.
      IReadOnlyDictionary<String, IValueTransform> transforms = null!;
      var act = () => _ = new FormatExceptionFactory(transforms);

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
   public void FormatExceptionFactory_CreateException_ShouldCreateExceptionOfExpectedType()
   {
      // Arrange.
      var sut = new FormatExceptionFactory();

      // Act.
      var ex = sut.CreateException(_data, _messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<FormatException>();
   }

   [Fact]
   public void FormatExceptionFactory_CreateException_ShouldCreateExceptionWithOriginalDataValues_WhenNoValueTransformsAreSpecified()
   {
      // Arrange.
      var sut = new FormatExceptionFactory();

      // Act.
      var ex = sut.CreateException(_data, _messageTemplate);

      // Assert.
      ex.Should().NotBeNull();

      ex.Data.Count.Should().Be(_data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(_data[DataNames.Value]);
      ex.Data[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
   }

   [Fact]
   public void FormatExceptionFactory_CreateException_ShouldCreateExceptionWithTransformedDataValues_WhenValueTransformsAreSpecified()
   {
      // Arrange.
      var sut = new FormatExceptionFactory(_keys, _transform);
      var expectedValue = "***";

      // Act.
      var ex = sut.CreateException(_data, _messageTemplate);

      // Assert.
      ex.Should().NotBeNull();

      ex.Data.Count.Should().Be(_data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(expectedValue);
      ex.Data[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
   }

   [Fact]
   public void FormatExceptionFactory_CreateException_ShouldCreateExceptionWithExpectedMessage_WhenNoValueTransformsAreSpecified()
   {
      // Arrange.
      var sut = new FormatExceptionFactory();
      var expectedMessage = "Precondition True failed: value (\"a.b\") is not a valid three part name";

      // Act.
      var ex = sut.CreateException(_data, _messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void FormatExceptionFactory_CreateException_ShouldCreateExceptionWithExpectedMessage_WhenValueTransformsAreSpecified()
   {
      // Arrange.
      var sut = new FormatExceptionFactory(_keys, _transform);
      var expectedMessage = "Precondition True failed: value (\"***\") is not a valid three part name";

      // Act.
      var ex = sut.CreateException(_data, _messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void FormatExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenDataDictionaryIsNull()
   {
      // Arrange.
      Dictionary<String, Object> data = null!;
      var sut = new FormatExceptionFactory();
      var act = () => _ = sut.CreateException(data, _messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(data))
         .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void FormatExceptionFactory_CreateException_ShouldThrowArgumentException_WhenMessageTemplateIsEmpty(String messageTemplate)
   {
      // Arrange.
      var sut = new FormatExceptionFactory();
      var act = () => _ = sut.CreateException(_data, messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void FormatExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenMessageTemplateIsNull()
   {
      // Arrange.
      String messageTemplate = null!;
      var sut = new FormatExceptionFactory();
      var act = () => _ = sut.CreateException(_data, messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   #endregion
}
