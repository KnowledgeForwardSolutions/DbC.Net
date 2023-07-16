namespace DbC.Net.Tests.Unit.Transforms;

public class FixedLengthDecoratorTests
{
   private static readonly IValueTransform _baseTransform = StandardTransforms.NullTransform;
   private const Int32 _length = 12;
   private const Char _padCharacter = '_';

   #region Constructor Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void FixedLengthDecorator_Constructor_ShouldCreateObject_WhenAllValuesSupplied()
   {
      // Act.
      var sut = new FixedLengthDecorator(_baseTransform, _length, _padCharacter);

      // Assert.
      sut.Should().NotBeNull();
      sut.Length.Should().Be(_length);
      sut.PadCharacter.Should().Be(_padCharacter);
   }

   [Fact]
   public void FixedLengthDecorator_Constructor_ShouldCreateObject_WhenAllDefaultsUsed()
   {
      // Act.
      var sut = new FixedLengthDecorator(_baseTransform);

      // Assert.
      sut.Should().NotBeNull();
      sut.Length.Should().Be(FixedLengthDecorator.DefaultLength);
      sut.PadCharacter.Should().Be(FixedLengthDecorator.DefaultPadCharacter);
   }

   [Fact]
   public void FixedLengthDecorator_Constructor_ShouldThrowArgumentNullException_WhenBaseTransformIsNull()
   {
      // Arrange.
      IValueTransform baseTransform = null!;
      var act = () => _ = new FixedLengthDecorator(baseTransform, _length, _padCharacter);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(baseTransform))
         .And.Message.Should().StartWith(Messages.BaseTransformIsNull);
   }

   [Fact]
   public void FixedLengthDecorator_Constructor_ShouldThrowArgumentOutOfRangeException_WhenLengthIsLessThanOne()
   {
      // Arrange.
      var length = 0;
      var act = () => _ = new FixedLengthDecorator(_baseTransform, length, _padCharacter);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(nameof(length))
         .And.Message.Should().StartWith(Messages.LengthIsLessThanOne);
   }

   [Fact]
   public void FixedLengthDecorator_Constructor_ShouldThrowArgumentOutOfRangeException_WhenPadCharacterIsNull()
   {
      // Arrange.
      var padCharacter = '\0';
      var act = () => _ = new FixedLengthDecorator(_baseTransform, _length, padCharacter);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(nameof(padCharacter))
         .And.Message.Should().StartWith(Messages.PadCharacterIsNull);
   }

   #endregion

   #region DefaultLength Property Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void FixedLengthDecorator_DefaultLength_ShouldBeEight() 
      => FixedLengthDecorator.DefaultLength.Should().Be(8);

   #endregion

   #region DefaultPadCharacter Property Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void FixedLengthDecorator_DefaultPadCharacter_ShouldBeSpace()
      => FixedLengthDecorator.DefaultPadCharacter.Should().Be(' ');

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
   public void FixedLengthDecorator_TransformValue_ShouldReturnEmptyString_WhenValueIsNull(Object value)
   {
      // Arrange.
      var sut = new FixedLengthDecorator(_baseTransform, _length, _padCharacter);
      var expectedResult = new String(_padCharacter, _length);

      // Act.
      var transformedValue = sut.TransformValue(value);

      // Assert.
      transformedValue.Should().Be(expectedResult);
   }

   public static TheoryData<Object, String> NonNullValueData => new()
   {
      { "password", "password____" },
      { 42, "42__________" },
      { 99.9, "99.9________" },
      { 100.0, "100_________" },
      { Guid.Parse("e2b935dc-9573-4a8a-b758-aa255c70d4ae"), "e2b935dc-957" },
   };

   [Theory]
   [MemberData(nameof(NonNullValueData))]
   public void FixedLengthDecorator_MaskValue_ShouldReturnMaskedStringOfExpectedLength_WhenValueIsNotNull(
      Object value,
      String expectedResult)
   {
      // Arrange.
      var sut = new FixedLengthDecorator(_baseTransform, _length, _padCharacter);

      // Act.
      var transformedValue = sut.TransformValue(value);

      // Assert.
      transformedValue.Should().Be(expectedResult);
   }

   #endregion
}
