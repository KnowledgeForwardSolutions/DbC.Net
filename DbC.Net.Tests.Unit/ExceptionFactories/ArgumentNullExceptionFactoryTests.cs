namespace DbC.Net.Tests.Unit.ExceptionFactories;

public class ArgumentNullExceptionFactoryTests
{
   private readonly IReadOnlyCollection<String> _keys = new List<String> { DataNames.ValueExpression };
   private readonly IValueTransform _transform = StandardTransforms.AsteriskMaskTransform;
   private readonly IReadOnlyDictionary<String, IValueTransform> _transforms = new Dictionary<String, IValueTransform>()
   {
      { DataNames.Value, StandardTransforms.DigitAsteriskMaskTransform },
      { DataNames.ValueExpression, StandardTransforms.AsteriskMaskTransform }
   };

   private const String _messageTemplate = "{RequirementType} {RequirementName} failed: {ValueExpression} may not be null";

   private readonly IReadOnlyDictionary<String, Object> _data = new Dictionary<String, Object> {
      { DataNames.RequirementType, RequirementType.Precondition },
      { DataNames.RequirementName, "NotNull" },
      { DataNames.ValueExpression, "x" } };

   #region Constructor Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ArgumentNullExceptionFactory_ParameterlessConstructor_ShouldCreateObject()
   {
      // Act.
      var sut = new ArgumentNullExceptionFactory();

      // Assert.
      sut.Should().NotBeNull();
   }

   [Fact]
   public void ArgumentNullExceptionFactory_CollectionAndValueTransformConstructor_ShouldCreateObject_WhenAllValuesSupplied()
   {
      // Act.
      var sut = new ArgumentNullExceptionFactory(_keys, _transform);

      // Assert.
      sut.Should().NotBeNull();
   }

   [Fact]
   public void ArgumentNullExceptionFactory_CollectionAndValueTransformConstructor_ShouldThrowArgumentNullException_WhenKeysCollectionIsNull()
   {
      // Arrange.
      IReadOnlyCollection<String> keys = null!;
      var act = () => _ = new ArgumentNullExceptionFactory(keys, _transform);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(keys))
         .And.Message.Should().StartWith(Messages.TransformKeysCollectonIsNull);
   }

   [Fact]
   public void ArgumentNullExceptionFactory_CollectionAndValueTransformConstructor_ShouldThrowArgumentNullException_WhenTransformIsNull()
   {
      // Arrange.
      IValueTransform transform = null!;
      var act = () => _ = new ArgumentNullExceptionFactory(_keys, transform);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(transform))
         .And.Message.Should().StartWith(Messages.ValueTransformIsNull);
   }

   [Fact]
   public void ArgumentNullExceptionFactory_TransformDictionaryConstructor_ShouldCreateObject_WhenAllValuesSupplied()
   {
      // Act.
      var sut = new ArgumentNullExceptionFactory(_transforms);

      // Assert.
      sut.Should().NotBeNull();
   }

   [Fact]
   public void ArgumentNullExceptionFactory_TransformDictionaryConstructor_ShouldThrowArgumentNullException_WhenTransformDictionaryIsNull()
   {
      // Arrange.
      IReadOnlyDictionary<String, IValueTransform> transforms = null!;
      var act = () => _ = new ArgumentNullExceptionFactory(transforms);

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
   public void ArgumentNullExceptionFactory_CreateException_ShouldCreateExceptionOfExpectedType()
   {
      // Arrange.
      var sut = new ArgumentNullExceptionFactory();

      // Act.
      var ex = sut.CreateException(_data, _messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<ArgumentNullException>();
   }

   [Fact]
   public void ArgumentNullExceptionFactory_CreateException_ShouldCreateExceptionWithOriginalDataValues_WhenNoValueTransformsAreSpecified()
   {
      // Arrange.
      var sut = new ArgumentNullExceptionFactory();

      // Act.
      var ex = sut.CreateException(_data, _messageTemplate);

      // Assert.
      ex.Should().NotBeNull();

      ex.Data.Count.Should().Be(_data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
      ex.Data[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
   }

   [Fact]
   public void ArgumentNullExceptionFactory_CreateException_ShouldCreateExceptionWithTransformedDataValues_WhenValueTransformsAreSpecified()
   {
      // Arrange.
      var sut = new ArgumentNullExceptionFactory(_keys, _transform);
      var expectedValueExpression = "*";

      // Act.
      var ex = sut.CreateException(_data, _messageTemplate);

      // Assert.
      ex.Should().NotBeNull();

      ex.Data.Count.Should().Be(_data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
      ex.Data[DataNames.ValueExpression].Should().Be(expectedValueExpression);
   }

   [Fact]
   public void ArgumentNullExceptionFactory_CreateException_ShouldCreateExceptionWithExpectedMessage_WhenNoValueTransformsAreSpecified()
   {
      // Arrange.
      var sut = new ArgumentNullExceptionFactory();
      var expectedMessage = "Precondition NotNull failed: x may not be null";

      // Act.
      var ex = sut.CreateException(_data, _messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void ArgumentNullExceptionFactory_CreateException_ShouldCreateExceptionWithExpectedMessage_WhenValueTransformsAreSpecified()
   {
      // Arrange.
      var sut = new ArgumentNullExceptionFactory(_keys, _transform);
      var expectedMessage = "Precondition NotNull failed: * may not be null";

      // Act.
      var ex = sut.CreateException(_data, _messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void ArgumentNullExceptionFactory_CreateException_ShouldCreateExceptionWithExpectedParamName_WhenNoValueTransformsAreSpecified()
   {
      // Arrange.
      var sut = new ArgumentNullExceptionFactory();
      var expectedParamName = "x";

      // Act.
      var ex = sut.CreateException(_data, _messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.ParamName.Should().Be(expectedParamName);
   }

   [Fact]
   public void ArgumentNullExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenDataDictionaryIsNull()
   {
      // Arrange.
      Dictionary<String, Object> data = null!;
      var sut = new ArgumentNullExceptionFactory();
      var act = () => _ = sut.CreateException(data, _messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(data))
         .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void ArgumentNullExceptionFactory_CreateException_ShouldThrowArgumentException_WhenMessageTemplateIsEmpty(String messageTemplate)
   {
      // Arrange.
      var sut = new ArgumentNullExceptionFactory();
      var act = () => _ = sut.CreateException(_data, messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void ArgumentNullExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenMessageTemplateIsNull()
   {
      // Arrange.
      String messageTemplate = null!;
      var sut = new ArgumentNullExceptionFactory();
      var act = () => _ = sut.CreateException(_data, messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   #endregion
}
