using Newtonsoft.Json.Linq;

namespace DbC.Net.Tests.Unit.Masking;

public class CharacterMaskerTests
{
   #region Constructor Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [InlineData('*')]
   [InlineData('\u0130')]  // Uppercase dotted I character
   public void CharacterMasker_Constructor_ShouldCreateNewMasker_WhenMaskCharacterIsValid(Char maskCharacter)
   {
      // Act.
      var sut = new CharacterMasker { MaskCharacter = maskCharacter };

      // Assert.
      sut.Should().NotBeNull();
      sut.MaskCharacter.Should().Be(maskCharacter);
   }

   [Fact]
   public void CharacterMasker_Constructor_ShouldThrowArgumentOutOfRangeException_WhenMaskCharacterIsNull()
   {
      // Arrange.
      var value = '\0';
      var act = () => _ = new CharacterMasker { MaskCharacter = value };

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(nameof(value))
         .And.Message.Should().StartWith(Messages.MaskCharacterIsNull);
   }

   #endregion

   #region MaskValue Method Tests
   // ==========================================================================
   // ==========================================================================

   public static TheoryData<Object> NullValueData => new TheoryData<Object>
   {
      { (String)null! },
      { (Int32?)null! },
      { (Exception)null! },
   };

   [Theory]
   [MemberData(nameof(NullValueData))]
   public void CharacterMasker_MaskValue_ShouldReturnEmptyString_WhenValueIsNull(Object value)
   {
      // Arrange.
      var sut = new CharacterMasker { MaskCharacter = '*' };

      // Act.
      var maskedValue = sut.MaskValue(value);

      // Assert.
      maskedValue.Should().Be(String.Empty);
   }

   [Fact]
   public void CharacterMasker_MaskValue_ShouldReturnEmptyString_WhenValueIsEmptyString()
   {
      // Arrange.
      var sut = new CharacterMasker { MaskCharacter = '*' };
      var value = String.Empty;

      // Act.
      var maskedValue = sut.MaskValue(value);

      // Assert.
      maskedValue.Should().Be(String.Empty);
   }

   public static TheoryData<Object, Int32> NonNullValueData => new TheoryData<Object, Int32>
   {
      { "I'm a strong, STR0NG P@$$word!42", 32 },
      { 42, 2 },
      { 99.9, 4 },
      { 100.0, 3 },
      { Guid.Parse("e2b935dc-9573-4a8a-b758-aa255c70d4ae"), 36 },
   };

   [Theory]
   [MemberData(nameof(NonNullValueData))]
   public void CharacterMasker_MaskValue_ShouldReturnMaskedValueOfExpectedLength_WhenValueIsNotNull(
      Object value,
      Int32 expectedLength)
   {
      // Arrange.
      var maskCharacter = '_';
      var sut = new CharacterMasker { MaskCharacter = maskCharacter };
      var expectedResult = new String(maskCharacter, expectedLength);

      // Act.
      var maskedValue = sut.MaskValue(value);

      // Assert.
      maskedValue.Should().Be(expectedResult);
   }

   #endregion
}
