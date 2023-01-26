namespace DbC.Net.Tests.Unit.ExceptionFactories;

public class MaskedExceptionFactoryTests
{
   // Non-abstract class to test MaskedExceptionFactory constructor and MaskSensitiveValues method.
   private class ExampleMaskedExceptionFactory : MaskedExceptionFactory
   {
      public ExampleMaskedExceptionFactory(
         IValueMasker valueMasker,
         IReadOnlyCollection<String> sensitiveValues) : base(valueMasker, sensitiveValues) { }

      public override Exception CreateException(
         String messageTemplate,
         Dictionary<String, Object> data)
         => throw new NotImplementedException();
   }

   private readonly Dictionary<String, Object> _data = new() {
      { DataNames.RequirementType, RequirementType.Precondition },
      { DataNames.RequirementName, "MinLength" },
      { DataNames.Value, "password" },
      { DataNames.ValueExpression, "userPassword" },
      { DataNames.MinLength, 12 },
      { DataNames.MinLengthExpression, "12" } };

   private readonly IValueMasker _valueMasker = new CharacterMasker { MaskCharacter = '*' };
   private readonly List<String> _sensitiveValues = new() { DataNames.Value };

   #region Constructor Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void MaskedExceptionFactory_Constructor_ShouldCreateObject_WhenAllValuesSupplied()
   {
      // Act.
      var sut = new ExampleMaskedExceptionFactory(_valueMasker, _sensitiveValues);

      // Assert.
      sut.Should().NotBeNull();
   }

   [Fact]
   public void MaskedExceptionFactory_Constructor_ShouldCreateObject_WhenSensitiveValuesIsEmpty()
   {
      // Arrange.
      IReadOnlyCollection<String> sensitiveValues = new List<String>();
      // Act.
      var sut = new ExampleMaskedExceptionFactory(_valueMasker, sensitiveValues);

      // Assert.
      sut.Should().NotBeNull();
   }

   [Fact]
   public void MaskedExceptionFactory_Constructor_ShouldCreateObject_WhenSensitiveValuesContainsDuplicateValues()
   {
      // Arrange.
      IReadOnlyCollection<String> sensitiveValues = new List<String>
      {
         DataNames.Value,
         DataNames.Target,
         DataNames.Value
      };
      // Act.
      var sut = new ExampleMaskedExceptionFactory(_valueMasker, sensitiveValues);

      // Assert.
      sut.Should().NotBeNull();
   }

   [Fact]
   public void MaskedExceptionFactory_Constructor_ShouldThrowArgumentNullException_WhenValueMaskerIsNull()
   {
      // Arrange.
      IValueMasker valueMasker = null!;
      var act = () => _ = new ExampleMaskedExceptionFactory(valueMasker, _sensitiveValues);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(valueMasker))
         .And.Message.Should().StartWith(Messages.ValueMaskerIsNull);
   }

   [Fact]
   public void MaskedExceptionFactory_Constructor_ShouldThrowArgumentNullException_WhenSensitiveValuesIsNull()
   {
      // Arrange.
      IReadOnlyCollection<String> sensitiveValues = null!;
      var act = () => _ = new ExampleMaskedExceptionFactory(_valueMasker, sensitiveValues);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(sensitiveValues))
         .And.Message.Should().StartWith(Messages.SensitiveValuesListIsNull);
   }

   #endregion

   #region MaskSensitiveValues Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void MaskedExceptionFactory_MaskSensitiveValues_ShouldReturnExpectedResult_WhenDataDictionaryContainsSensitiveValues()
   {
      // Arrange.
      var sut = new ExampleMaskedExceptionFactory(_valueMasker, _sensitiveValues);
      var expectedMaskedPassword = new String('*', 8);

      // Act.
      var maskedData = sut.MaskSensitiveValues(_data);

      // Assert.
      maskedData.Should().NotBeNull();
      maskedData.Should().NotBeSameAs(_data);
      maskedData.Count.Should().Be(_data.Count);
      maskedData[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
      maskedData[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
      maskedData[DataNames.Value].Should().Be(expectedMaskedPassword);
      maskedData[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
      maskedData[DataNames.MinLength].Should().Be(_data[DataNames.MinLength]);
      maskedData[DataNames.MinLengthExpression].Should().Be(_data[DataNames.MinLengthExpression]);
   }

   [Fact]
   public void MaskedExceptionFactory_MaskSensitiveValues_ShouldReturnExpectedResult_WhenDataDictionaryDoesNotContainsSensitiveValues()
   {
      // Arrange.
      IReadOnlyCollection<String> sensitiveValues = new List<String>{ DataNames.Limit };
      var sut = new ExampleMaskedExceptionFactory(_valueMasker, sensitiveValues);

      // Act.
      var maskedData = sut.MaskSensitiveValues(_data);

      // Assert.
      maskedData.Should().NotBeNull();
      maskedData.Should().NotBeSameAs(_data);
      maskedData.Count.Should().Be(_data.Count);
      maskedData[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
      maskedData[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
      maskedData[DataNames.Value].Should().Be(_data[DataNames.Value]);
      maskedData[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
      maskedData[DataNames.MinLength].Should().Be(_data[DataNames.MinLength]);
      maskedData[DataNames.MinLengthExpression].Should().Be(_data[DataNames.MinLengthExpression]);
   }

   [Fact]
   public void MaskedExceptionFactory_MaskSensitiveValues_ShouldReturnExpectedResult_WhenSensitiveValuesListIsEmpty()
   {
      // Arrange.
      IReadOnlyCollection<String> sensitiveValues = new List<String>();
      var sut = new ExampleMaskedExceptionFactory(_valueMasker, sensitiveValues);

      // Act.
      var maskedData = sut.MaskSensitiveValues(_data);

      // Assert.
      maskedData.Should().NotBeNull();
      maskedData.Should().NotBeSameAs(_data);
      maskedData.Count.Should().Be(_data.Count);
      maskedData[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
      maskedData[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
      maskedData[DataNames.Value].Should().Be(_data[DataNames.Value]);
      maskedData[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
      maskedData[DataNames.MinLength].Should().Be(_data[DataNames.MinLength]);
      maskedData[DataNames.MinLengthExpression].Should().Be(_data[DataNames.MinLengthExpression]);
   }

   [Fact]
   public void MaskedExceptionFactory_MaskSensitiveValues_ShouldReturnExpectedResult_WhenSensitiveValuesContainsDuplicateValues()
   {
      // Arrange.
      IReadOnlyCollection<String> sensitiveValues = new List<String>
      {
         DataNames.Value,
         DataNames.Target,
         DataNames.Value
      };
      var sut = new ExampleMaskedExceptionFactory(_valueMasker, sensitiveValues);
      var expectedMaskedPassword = new String('*', 8);

      // Act.
      var maskedData = sut.MaskSensitiveValues(_data);

      // Assert.
      maskedData.Should().NotBeNull();
      maskedData.Should().NotBeSameAs(_data);
      maskedData.Count.Should().Be(_data.Count);
      maskedData[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
      maskedData[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
      maskedData[DataNames.Value].Should().Be(expectedMaskedPassword);
      maskedData[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
      maskedData[DataNames.MinLength].Should().Be(_data[DataNames.MinLength]);
      maskedData[DataNames.MinLengthExpression].Should().Be(_data[DataNames.MinLengthExpression]);
   }

   [Fact]
   public void MaskedExceptionFactory_MaskSensitiveValues_ShouldReturnExpectedResult_WhenDataDictionaryIsEmpty()
   {
      // Arrange.
      var sut = new ExampleMaskedExceptionFactory(_valueMasker, _sensitiveValues);
      var data = new Dictionary<String, object>();

      // Act.
      var maskedData = sut.MaskSensitiveValues(data);

      // Assert.
      maskedData.Should().NotBeNull();
      maskedData.Should().NotBeSameAs(_data);
      maskedData.Count.Should().Be(0);
   }

   [Fact]
   public void MaskedExceptionFactory_MaskSensitiveValues_ShouldThrowArgumentNullException_WhenDataDictionaryIsNull()
   {
      // Arrange.
      var sut = new ExampleMaskedExceptionFactory(_valueMasker, _sensitiveValues);
      Dictionary<String, Object> data = null!;
      var act = () => _ = sut.MaskSensitiveValues(data);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(data))
         .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
   }

   #endregion
}
