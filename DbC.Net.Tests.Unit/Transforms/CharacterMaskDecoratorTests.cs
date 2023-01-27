namespace DbC.Net.Tests.Unit.Transforms;

public class CharacterMaskDecoratorTests
{
   private static readonly IValueTransform _baseTransform = StandardTransforms.NullTransform;
   private const Char _maskCharacter = '*';

   #region Constructor Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void CharacterMaskDecorator_Constructor_ShouldCreateObject_WhenAllValuesSupplied()
   {
      // Act.
      var sut = new CharacterMaskDecorator(_baseTransform, _maskCharacter);

      // Assert.
      sut.Should().NotBeNull();
   }

   [Fact]
   public void CharacterMaskDecorator_Constructor_ShouldThrowArgumentNullException_WhenBaseTransformIsNull()
   {
      // Arrange.
      IValueTransform baseTransform = null!;
      var act = () => _ = new CharacterMaskDecorator(baseTransform, _maskCharacter);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(baseTransform))
         .And.Message.Should().StartWith(Messages.BaseTransformIsNull);
   }

   [Fact]
   public void CharacterMaskDecorator_Constructor_ShouldThrowArgumentOutOfRangeException_WhenMaskCharacterIsNull()
   {
      // Arrange.
      var maskCharacter = '\0';
      var act = () => _ = new CharacterMaskDecorator(_baseTransform, maskCharacter);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(nameof(maskCharacter))
         .And.Message.Should().StartWith(Messages.MaskCharacterIsNull);
   }

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
   public void CharacterMaskDecorator_TransformValue_ShouldReturnEmptyString_WhenValueIsNull(Object value)
   {
      // Arrange.
      var sut = new CharacterMaskDecorator(_baseTransform, _maskCharacter);

      // Act.
      var transformedValue = sut.TransformValue(value);

      // Assert.
      transformedValue.Should().Be(String.Empty);
   }

   public static TheoryData<Object, Int32> NonNullValueData => new()
   {
      { "I'm a strong, STR0NG P@$$word!42", 32 },
      { 42, 2 },
      { 99.9, 4 },
      { 100.0, 3 },
      { Guid.Parse("e2b935dc-9573-4a8a-b758-aa255c70d4ae"), 36 },
   };

   [Theory]
   [MemberData(nameof(NonNullValueData))]
   public void CharacterMaskDecorator_MaskValue_ShouldReturnMaskedStringOfExpectedLength_WhenValueIsNotNull(
      Object value,
      Int32 expectedLength)
   {
      // Arrange.
      var maskCharacter = '_';
      var sut = new CharacterMaskDecorator(_baseTransform, maskCharacter);
      var expectedResult = new String(maskCharacter, expectedLength);

      // Act.
      var transformedValue = sut.TransformValue(value);

      // Assert.
      transformedValue.Should().Be(expectedResult);
   }

   #endregion
}
