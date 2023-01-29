namespace DbC.Net.Tests.Unit.Transforms;

public class DigitMaskDecoratorTests
{
   private static readonly IValueTransform _baseTransform = StandardTransforms.NullTransform;
   private const Char _maskCharacter = '_';

   #region Constructor Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void DigitMaskDecorator_Constructor_ShouldCreateObject_WhenAllValuesSupplied()
   {
      // Act.
      var sut = new DigitMaskDecorator(_baseTransform, _maskCharacter);

      // Assert.
      sut.Should().NotBeNull();
      sut.MaskCharacter.Should().Be(_maskCharacter);
   }

   [Fact]
   public void DigitMaskDecorator_Constructor_ShouldCreateObject_WhenAllDefaults()
   {
      // Act.
      var sut = new DigitMaskDecorator(_baseTransform);

      // Assert.
      sut.Should().NotBeNull();
      sut.MaskCharacter.Should().Be(DigitMaskDecorator.DefaultMaskCharacter);
   }

   [Fact]
   public void DigitMaskDecorator_Constructor_ShouldThrowArgumentNullException_WhenBaseTransformIsNull()
   {
      // Arrange.
      IValueTransform baseTransform = null!;
      var act = () => _ = new DigitMaskDecorator(baseTransform, _maskCharacter);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(baseTransform))
         .And.Message.Should().StartWith(Messages.BaseTransformIsNull);
   }

   [Fact]
   public void DigitMaskDecorator_Constructor_ShouldThrowArgumentOutOfRangeException_WhenMaskCharacterIsNull()
   {
      // Arrange.
      var maskCharacter = '\0';
      var act = () => _ = new DigitMaskDecorator(_baseTransform, maskCharacter);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(nameof(maskCharacter))
         .And.Message.Should().StartWith(Messages.MaskCharacterIsNull);
   }

   #endregion

   #region DefaultMaskCharacter Property Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void DigitMaskDecorator_DefaultMaskCharacter_ShouldBeAsterisk()
      => DigitMaskDecorator.DefaultMaskCharacter.Should().Be('*');

   #endregion

   #region TransformValue Method Tests
   // ==========================================================================
   // ==========================================================================

   public static TheoryData<Object> NullValueData => new()
   {
      { (String)null! },
      { (Int32?)null! },
      { (Exception)null! },
   };

   [Theory]
   [MemberData(nameof(NullValueData))]
   public void DigitMaskDecorator_TransformValue_ShouldReturnEmptyString_WhenValueIsNull(Object value)
   {
      // Arrange.
      var sut = new DigitMaskDecorator(_baseTransform, _maskCharacter);

      // Act.
      var transformedValue = sut.TransformValue(value);

      // Assert.
      transformedValue.Should().Be(String.Empty);
   }

   public static TheoryData<Object, String> NonNullValueData => new()
   {
      { "123-456-7890", "___-___-____" },
      { "1234 Ave. A", "____ Ave. A" },
      { 99.9, "__._" },
      { "password", "password" }
   };

   [Theory]
   [MemberData(nameof(NonNullValueData))]
   public void DigitMaskDecorator_MaskValue_ShouldReturnMaskedStringOfExpectedLength_WhenValueIsNotNull(
      Object value,
      String expected)
   {
      // Arrange.
      var sut = new DigitMaskDecorator(_baseTransform, _maskCharacter);

      // Act.
      var transformedValue = sut.TransformValue(value);

      // Assert.
      transformedValue.Should().Be(expected);
   }

   #endregion
}
