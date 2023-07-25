namespace DbC.Net.Tests.Unit;

public class EndsWithExtensionsTests
{
   private const Int32 _dataCount = 7;

   #region EnsuresEndsWith Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldNotThrow_WhenValueEndsWithTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "TY";
      var act = () => _ = value.EnsuresEndsWith(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldNotThrow_WhenValueIsNotEmptyAndTargetIsEmptyAndComparisonIsDefault()
   {
      // Arrange.
      var value = "asdf";
      var target = String.Empty;
      var act = () => _ = value.EnsuresEndsWith(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldNotThrow_WhenValueIsEmptyAndTargetIsEmptyAndComparisonIsDefault()
   {
      // Arrange.
      var value = String.Empty;
      var target = String.Empty;
      var act = () => _ = value.EnsuresEndsWith(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldNotThrow_WhenValueEqualsTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QWERTY";
      var act = () => _ = value.EnsuresEndsWith(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldReturnOriginalValue_WhenRequirementIsPassedAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "TY";

      // Act.
      var result = value.EnsuresEndsWith(target);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHIJKL", "jkl", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKL", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKL", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldNotThrow_WhenValueEndsWithTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   // Note: tr-TR culture considers "i" and upper case dotted "I" as equal when
   // case is ignored. Same for "I" and lowercase dot-less "i".
   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHI", StringData.LowerCaseDotlessI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKL", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKL", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldNotThrow_WhenValueEndsWithTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldNotThrow_WhenValueIsNotEmptyAndTargetIsEmptyAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = "asdf";
      var target = String.Empty;
      var act = () => _ = value.EnsuresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.ThaiThailand)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldNotThrow_WhenValueIsEmptyAndTargetIsEmptyAndCurrentCultureIs_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = String.Empty;
      var target = String.Empty;
      var act = () => _ = value.EnsuresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHIJKL", "jkl", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKL", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKL", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldReturnOriginalValue_WhenRequirementIsPassedAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresEndsWith(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Fact]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldNotThrow_WhenValueEqualsTargetAndComparisonIsSupplied()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QWERTY";
      var comparisonType = StringComparison.CurrentCulture;
      var act = () => _ = value.EnsuresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Fact]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldNotThrow_WhenValueEndsWithTargetAndComparisonIsSupplied()
   {
      // Arrange.
      var value = "ABCDEFGHI";
      var target = StringData.LowerCaseDotlessI;
      var comparisonType = StringComparison.CurrentCultureIgnoreCase;
      var act = () => _ = value.EnsuresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldThrow_WhenValueIsNotNullAndDoesNotEndWithTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.EnsuresEndsWith(target);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Theory]
   [InlineData("!@#$%")]
   [InlineData("")]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldThrow_WhenValueNullAndTargetIsNotNullAndComparisonIsDefault(String target)
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresEndsWith(target);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "adz", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "adz", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "adz", StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldThrow_WhenValueIsNotNullAndDoesNotEndWithTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   // Note: tr-TR culture considers "i" and upper case dotted "I" as equal when
   // case is ignored. Same for "I" and lowercase dot-less "i".
   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", StringData.LowerCaseDotlessI, StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "adz", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "adz", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "adz", StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldThrow_WhenValueIsNotNullAndDoesNotEndWithTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldThrow_WhenValueIsNullAndTargetIsNotNullAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = null!;
      var target = "QWERTY";
      var act = () => _ = value.EnsuresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [UseCulture(CultureData.ThaiThailand)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldThrow_WhenValueIsNullAndTargetIsNotNullAndCurrentCultureIs_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = null!;
      var target = "QWERTY";
      var act = () => _ = value.EnsuresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Theory]
   [InlineData("not null string")]
   [InlineData(null)]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldThrowArgumentNullException_WhenTargetIsNullAndComparisonIsDefault(String value)
   {
      // Arrange.
      String target = null!;
      var act = () => _ = value.EnsuresEndsWith(target);
      var expectedMessage = Messages.TargetSubstringIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(target))
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailedAndComparisonIsDefault()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.EnsuresEndsWith(target);

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.EndsWith);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
      ex.Data[DataNames.StringComparison].Should().Be(StringComparison.Ordinal);
   }

   [UseCulture(CultureData.ThaiThailand)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_EnsuresEndsWith_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.EnsuresEndsWith(target, comparisonType);

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.EndsWith);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void EndsWithExtension_EnsuresEndsWith_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.EnsuresEndsWith(target);
      var expectedMessage = $"Postcondition EndsWith failed: {nameof(value)} must end with the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void EndsWithExtension_EnsuresEndsWith_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeIsSuppliedAndAllOtherDefaultsAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.InvariantCulture;
      var act = () => _ = value.EnsuresEndsWith(target, comparisonType);
      var expectedMessage = $"Postcondition EndsWith failed: {nameof(value)} must end with the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void EndsWithExtension_EnsuresEndsWith_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresEndsWith(target, messageTemplate: messageTemplate);
      var expectedMessage = $"Requirement EndsWith failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void EndsWithExtension_EnsuresEndsWith_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomMessageTemplateAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresEndsWith(target, comparisonType, messageTemplate);
      var expectedMessage = $"Requirement EndsWith failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void EndsWithExtension_EnsuresEndsWith_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.EnsuresEndsWith(target, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition EndsWith failed: {nameof(value)} must end with the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void EndsWithExtension_EnsuresEndsWith_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.EnsuresEndsWith(target, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition EndsWith failed: {nameof(value)} must end with the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void EndsWithExtension_EnsuresEndsWith_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresEndsWith(target, messageTemplate: messageTemplate, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement EndsWith failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void EndsWithExtension_EnsuresEndsWith_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomMessageTemplateAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.Ordinal;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresEndsWith(target, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement EndsWith failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresEndsWith Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void EndsWithExtensions_RequiresEndsWith_ShouldNotThrow_WhenValueEndsWithTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "TY";
      var act = () => _ = value.RequiresEndsWith(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void EndsWithExtensions_RequiresEndsWith_ShouldNotThrow_WhenValueIsNotEmptyAndTargetIsEmptyAndComparisonIsDefault()
   {
      // Arrange.
      var value = "asdf";
      var target = String.Empty;
      var act = () => _ = value.RequiresEndsWith(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void EndsWithExtensions_RequiresEndsWith_ShouldNotThrow_WhenValueIsEmptyAndTargetIsEmptyAndComparisonIsDefault()
   {
      // Arrange.
      var value = String.Empty;
      var target = String.Empty;
      var act = () => _ = value.RequiresEndsWith(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void EndsWithExtensions_RequiresEndsWith_ShouldNotThrow_WhenValueEqualsTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QWERTY";
      var act = () => _ = value.RequiresEndsWith(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void EndsWithExtensions_RequiresEndsWith_ShouldReturnOriginalValue_WhenRequirementIsPassedAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "TY";

      // Act.
      var result = value.RequiresEndsWith(target);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHIJKL", "jkl", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKL", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKL", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_RequiresEndsWith_ShouldNotThrow_WhenValueEndsWithTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   // Note: tr-TR culture considers "i" and upper case dotted "I" as equal when
   // case is ignored. Same for "I" and lowercase dot-less "i".
   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHI", StringData.LowerCaseDotlessI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKL", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKL", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_RequiresEndsWith_ShouldNotThrow_WhenValueEndsWithTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_RequiresEndsWith_ShouldNotThrow_WhenValueIsNotEmptyAndTargetIsEmptyAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = "asdf";
      var target = String.Empty;
      var act = () => _ = value.RequiresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.ThaiThailand)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_RequiresEndsWith_ShouldNotThrow_WhenValueIsEmptyAndTargetIsEmptyAndCurrentCultureIs_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = String.Empty;
      var target = String.Empty;
      var act = () => _ = value.RequiresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHIJKL", "jkl", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKL", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKL", "JKL", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKL", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_RequiresEndsWith_ShouldReturnOriginalValue_WhenRequirementIsPassedAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresEndsWith(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Fact]
   public void EndsWithExtensions_RequiresEndsWith_ShouldNotThrow_WhenValueEqualsTargetAndComparisonIsSupplied()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QWERTY";
      var comparisonType = StringComparison.CurrentCulture;
      var act = () => _ = value.RequiresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Fact]
   public void EndsWithExtensions_RequiresEndsWith_ShouldNotThrow_WhenValueEndsWithTargetAndComparisonIsSupplied()
   {
      // Arrange.
      var value = "ABCDEFGHI";
      var target = StringData.LowerCaseDotlessI;
      var comparisonType = StringComparison.CurrentCultureIgnoreCase;
      var act = () => _ = value.RequiresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void EndsWithExtensions_RequiresEndsWith_ShouldThrow_WhenValueIsNotNullAndDoesNotEndWithTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.RequiresEndsWith(target);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Theory]
   [InlineData("!@#$%")]
   [InlineData("")]
   public void EndsWithExtensions_RequiresEndsWith_ShouldThrow_WhenValueNullAndTargetIsNotNullAndComparisonIsDefault(String target)
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresEndsWith(target);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "adz", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "adz", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "adz", StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_RequiresEndsWith_ShouldThrow_WhenValueIsNotNullAndDoesNotEndWithTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   // Note: tr-TR culture considers "i" and upper case dotted "I" as equal when
   // case is ignored. Same for "I" and lowercase dot-less "i".
   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", StringData.LowerCaseDotlessI, StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "adz", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "adz", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "adz", StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_RequiresEndsWith_ShouldThrow_WhenValueIsNotNullAndDoesNotEndWithTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_RequiresEndsWith_ShouldThrow_WhenValueIsNullAndTargetIsNotNullAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = null!;
      var target = "QWERTY";
      var act = () => _ = value.RequiresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [UseCulture(CultureData.ThaiThailand)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_RequiresEndsWith_ShouldThrow_WhenValueIsNullAndTargetIsNotNullAndCurrentCultureIs_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = null!;
      var target = "QWERTY";
      var act = () => _ = value.RequiresEndsWith(target, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Theory]
   [InlineData("not null string")]
   [InlineData(null)]
   public void EndsWithExtensions_RequiresEndsWith_ShouldThrowArgumentNullException_WhenTargetIsNullAndComparisonIsDefault(String value)
   {
      // Arrange.
      String target = null!;
      var act = () => _ = value.RequiresEndsWith(target);
      var expectedMessage = Messages.TargetSubstringIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(target))
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void EndsWithExtensions_RequiresEndsWith_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailedAndComparisonIsDefault()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.RequiresEndsWith(target);

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.EndsWith);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
      ex.Data[DataNames.StringComparison].Should().Be(StringComparison.Ordinal);
   }

   [UseCulture(CultureData.ThaiThailand)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void EndsWithExtensions_RequiresEndsWith_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.RequiresEndsWith(target, comparisonType);

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.EndsWith);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void EndsWithExtension_RequiresEndsWith_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.RequiresEndsWith(target);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition EndsWith failed: {nameof(value)} must end with the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void EndsWithExtension_RequiresEndsWith_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeIsSuppliedAndAllOtherDefaultsAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.InvariantCulture;
      var act = () => _ = value.RequiresEndsWith(target, comparisonType);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition EndsWith failed: {nameof(value)} must end with the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void EndsWithExtension_RequiresEndsWith_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresEndsWith(target, messageTemplate: messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement EndsWith failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void EndsWithExtension_RequiresEndsWith_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomMessageTemplateAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresEndsWith(target, comparisonType, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement EndsWith failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void EndsWithExtension_RequiresEndsWith_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.RequiresEndsWith(target, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition EndsWith failed: {nameof(value)} must end with the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void EndsWithExtension_RequiresEndsWith_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.RequiresEndsWith(target, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition EndsWith failed: {nameof(value)} must end with the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void EndsWithExtension_RequiresEndsWith_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresEndsWith(target, messageTemplate: messageTemplate, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement EndsWith failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void EndsWithExtension_RequiresEndsWith_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomMessageTemplateAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.Ordinal;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresEndsWith(target, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement EndsWith failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
