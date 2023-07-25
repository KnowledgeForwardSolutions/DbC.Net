namespace DbC.Net.Tests.Unit;

public class StartsWithExtensionsTests
{
   private const Int32 _dataCount = 7;

   #region EnsuresStarts Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StartsWithExtensions_EnsuresStartsWith_ShouldNotThrow_WhenValueStartsWithTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QW";
      var act = () => _ = value.EnsuresStartsWith(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void StartsWithExtensions_EnsuresStartsWith_ShouldNotThrow_WhenValueIsNotEmptyAndTargetIsEmptyAndComparisonIsDefault()
   {
      // Arrange.
      var value = "asdf";
      var target = String.Empty;
      var act = () => _ = value.EnsuresStartsWith(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void StartsWithExtensions_EnsuresStartsWith_ShouldNotThrow_WhenValueIsEmptyAndTargetIsEmptyAndComparisonIsDefault()
   {
      // Arrange.
      var value = String.Empty;
      var target = String.Empty;
      var act = () => _ = value.EnsuresStartsWith(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void StartsWithExtensions_EnsuresStartsWith_ShouldNotThrow_WhenValueEqualsTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QWERTY";
      var act = () => _ = value.EnsuresStartsWith(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void StartsWithExtensions_EnsuresStartsWith_ShouldReturnOriginalValue_WhenRequirementIsPassedAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QW";

      // Act.
      var result = value.EnsuresStartsWith(target);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.CurrentCulture)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "jkl", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.InvariantCulture)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.Ordinal)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void StartsWithExtensions_EnsuresStartsWith_ShouldNotThrow_WhenValueStartsWithTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresStartsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   // Note: tr-TR culture considers "i" and upper case dotted "I" as equal when
   // case is ignored. Same for "I" and lowercase dot-less "i".
   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.CurrentCulture)]
   [InlineData("IJKLMNOPQRSTUVWXYZ", StringData.LowerCaseDotlessI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.InvariantCulture)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.Ordinal)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void StartsWithExtensions_EnsuresStartsWith_ShouldNotThrow_WhenValueStartsWithTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresStartsWith(target, comparisonType);

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
   public void StartsWithExtensions_EnsuresStartsWith_ShouldNotThrow_WhenValueIsNotEmptyAndTargetIsEmptyAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = "asdf";
      var target = String.Empty;
      var act = () => _ = value.EnsuresStartsWith(target, comparisonType);

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
   public void StartsWithExtensions_EnsuresStartsWith_ShouldNotThrow_WhenValueIsEmptyAndTargetIsEmptyAndCurrentCultureIs_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = String.Empty;
      var target = String.Empty;
      var act = () => _ = value.EnsuresStartsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.CurrentCulture)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "jkl", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.InvariantCulture)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.Ordinal)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void StartsWithExtensions_EnsuresStartsWith_ShouldReturnOriginalValue_WhenRequirementIsPassedAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresStartsWith(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Fact]
   public void StartsWithExtensions_EnsuresStartsWith_ShouldNotThrow_WhenValueEqualsTargetAndComparisonIsSupplied()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QWERTY";
      var comparisonType = StringComparison.CurrentCulture;
      var act = () => _ = value.EnsuresStartsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Fact]
   public void StartsWithExtensions_EnsuresStartsWith_ShouldNotThrow_WhenValueStartsWithTargetAndComparisonIsSupplied()
   {
      // Arrange.
      var value = "IBCDEF";
      var target = StringData.LowerCaseDotlessI;
      var comparisonType = StringComparison.CurrentCultureIgnoreCase;
      var act = () => _ = value.EnsuresStartsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void StartsWithExtensions_EnsuresStartsWith_ShouldThrow_WhenValueIsNotNullAndDoesNotStartWithTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.EnsuresStartsWith(target);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Theory]
   [InlineData("!@#$%")]
   [InlineData("")]
   public void StartsWithExtensions_EnsuresStartsWith_ShouldThrow_WhenValueNullAndTargetIsNotNullAndComparisonIsDefault(String target)
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresStartsWith(target);

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
   public void StartsWithExtensions_EnsuresStartsWith_ShouldThrow_WhenValueIsNotNullAndDoesNotStartWithTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresStartsWith(target, comparisonType);

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
   public void StartsWithExtensions_EnsuresStartsWith_ShouldThrow_WhenValueIsNotNullAndDoesNotStartWithTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresStartsWith(target, comparisonType);

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
   public void StartsWithExtensions_EnsuresStartsWith_ShouldThrow_WhenValueIsNullAndTargetIsNotNullAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = null!;
      var target = "QWERTY";
      var act = () => _ = value.EnsuresStartsWith(target, comparisonType);

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
   public void StartsWithExtensions_EnsuresStartsWith_ShouldThrow_WhenValueIsNullAndTargetIsNotNullAndCurrentCultureIs_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = null!;
      var target = "QWERTY";
      var act = () => _ = value.EnsuresStartsWith(target, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Theory]
   [InlineData("not null string")]
   [InlineData(null)]
   public void StartsWithExtensions_EnsuresStartsWith_ShouldThrowArgumentNullException_WhenTargetIsNullAndComparisonIsDefault(String value)
   {
      // Arrange.
      String target = null!;
      var act = () => _ = value.EnsuresStartsWith(target);
      var expectedMessage = Messages.TargetSubstringIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(target))
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void StartsWithExtensions_EnsuresStartsWith_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailedAndComparisonIsDefault()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.EnsuresStartsWith(target);

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.StartsWith);
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
   public void StartsWithExtensions_EnsuresStartsWith_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.EnsuresStartsWith(target, comparisonType);

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.StartsWith);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void StartsWithExtension_EnsuresStartsWith_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.EnsuresStartsWith(target);
      var expectedMessage = $"Postcondition StartsWith failed: {nameof(value)} must start with the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void StartsWithExtension_EnsuresStartsWith_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeIsSuppliedAndAllOtherDefaultsAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.InvariantCulture;
      var act = () => _ = value.EnsuresStartsWith(target, comparisonType);
      var expectedMessage = $"Postcondition StartsWith failed: {nameof(value)} must start with the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void StartsWithExtension_EnsuresStartsWith_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresStartsWith(target, messageTemplate: messageTemplate);
      var expectedMessage = $"Requirement StartsWith failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void StartsWithExtension_EnsuresStartsWith_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomMessageTemplateAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresStartsWith(target, comparisonType, messageTemplate);
      var expectedMessage = $"Requirement StartsWith failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void StartsWithExtension_EnsuresStartsWith_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.EnsuresStartsWith(target, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition StartsWith failed: {nameof(value)} must start with the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void StartsWithExtension_EnsuresStartsWith_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.EnsuresStartsWith(target, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition StartsWith failed: {nameof(value)} must start with the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void StartsWithExtension_EnsuresStartsWith_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresStartsWith(target, messageTemplate: messageTemplate, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement StartsWith failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void StartsWithExtension_EnsuresStartsWith_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomMessageTemplateAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.Ordinal;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresStartsWith(target, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement StartsWith failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresStarts Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StartsWithExtensions_RequiresStartsWith_ShouldNotThrow_WhenValueStartsWithTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QW";
      var act = () => _ = value.RequiresStartsWith(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void StartsWithExtensions_RequiresStartsWith_ShouldNotThrow_WhenValueIsNotEmptyAndTargetIsEmptyAndComparisonIsDefault()
   {
      // Arrange.
      var value = "asdf";
      var target = String.Empty;
      var act = () => _ = value.RequiresStartsWith(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void StartsWithExtensions_RequiresStartsWith_ShouldNotThrow_WhenValueIsEmptyAndTargetIsEmptyAndComparisonIsDefault()
   {
      // Arrange.
      var value = String.Empty;
      var target = String.Empty;
      var act = () => _ = value.RequiresStartsWith(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void StartsWithExtensions_RequiresStartsWith_ShouldNotThrow_WhenValueEqualsTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QWERTY";
      var act = () => _ = value.RequiresStartsWith(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void StartsWithExtensions_RequiresStartsWith_ShouldReturnOriginalValue_WhenRequirementIsPassedAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QW";

      // Act.
      var result = value.RequiresStartsWith(target);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.CurrentCulture)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "jkl", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.InvariantCulture)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.Ordinal)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void StartsWithExtensions_RequiresStartsWith_ShouldNotThrow_WhenValueStartsWithTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresStartsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   // Note: tr-TR culture considers "i" and upper case dotted "I" as equal when
   // case is ignored. Same for "I" and lowercase dot-less "i".
   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.CurrentCulture)]
   [InlineData("IJKLMNOPQRSTUVWXYZ", StringData.LowerCaseDotlessI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.InvariantCulture)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.Ordinal)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void StartsWithExtensions_RequiresStartsWith_ShouldNotThrow_WhenValueStartsWithTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresStartsWith(target, comparisonType);

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
   public void StartsWithExtensions_RequiresStartsWith_ShouldNotThrow_WhenValueIsNotEmptyAndTargetIsEmptyAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = "asdf";
      var target = String.Empty;
      var act = () => _ = value.RequiresStartsWith(target, comparisonType);

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
   public void StartsWithExtensions_RequiresStartsWith_ShouldNotThrow_WhenValueIsEmptyAndTargetIsEmptyAndCurrentCultureIs_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = String.Empty;
      var target = String.Empty;
      var act = () => _ = value.RequiresStartsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.CurrentCulture)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "jkl", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.InvariantCulture)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "JKL", StringComparison.Ordinal)]
   [InlineData("JKLMNOPQRSTUVWXYZ", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void StartsWithExtensions_RequiresStartsWith_ShouldReturnOriginalValue_WhenRequirementIsPassedAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresStartsWith(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Fact]
   public void StartsWithExtensions_RequiresStartsWith_ShouldNotThrow_WhenValueEqualsTargetAndComparisonIsSupplied()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QWERTY";
      var comparisonType = StringComparison.CurrentCulture;
      var act = () => _ = value.RequiresStartsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Fact]
   public void StartsWithExtensions_RequiresStartsWith_ShouldNotThrow_WhenValueStartsWithTargetAndComparisonIsSupplied()
   {
      // Arrange.
      var value = "IBCDEF";
      var target = StringData.LowerCaseDotlessI;
      var comparisonType = StringComparison.CurrentCultureIgnoreCase;
      var act = () => _ = value.RequiresStartsWith(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void StartsWithExtensions_RequiresStartsWith_ShouldThrow_WhenValueIsNotNullAndDoesNotStartWithTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.RequiresStartsWith(target);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Theory]
   [InlineData("!@#$%")]
   [InlineData("")]
   public void StartsWithExtensions_RequiresStartsWith_ShouldThrow_WhenValueNullAndTargetIsNotNullAndComparisonIsDefault(String target)
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresStartsWith(target);

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
   public void StartsWithExtensions_RequiresStartsWith_ShouldThrow_WhenValueIsNotNullAndDoesNotStartWithTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresStartsWith(target, comparisonType);

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
   public void StartsWithExtensions_RequiresStartsWith_ShouldThrow_WhenValueIsNotNullAndDoesNotStartWithTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresStartsWith(target, comparisonType);

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
   public void StartsWithExtensions_RequiresStartsWith_ShouldThrow_WhenValueIsNullAndTargetIsNotNullAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = null!;
      var target = "QWERTY";
      var act = () => _ = value.RequiresStartsWith(target, comparisonType);

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
   public void StartsWithExtensions_RequiresStartsWith_ShouldThrow_WhenValueIsNullAndTargetIsNotNullAndCurrentCultureIs_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = null!;
      var target = "QWERTY";
      var act = () => _ = value.RequiresStartsWith(target, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Theory]
   [InlineData("not null string")]
   [InlineData(null)]
   public void StartsWithExtensions_RequiresStartsWith_ShouldThrowArgumentNullException_WhenTargetIsNullAndComparisonIsDefault(String value)
   {
      // Arrange.
      String target = null!;
      var act = () => _ = value.RequiresStartsWith(target);
      var expectedMessage = Messages.TargetSubstringIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(target))
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void StartsWithExtensions_RequiresStartsWith_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailedAndComparisonIsDefault()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.RequiresStartsWith(target);

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.StartsWith);
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
   public void StartsWithExtensions_RequiresStartsWith_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.RequiresStartsWith(target, comparisonType);

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.StartsWith);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void StartsWithExtension_RequiresStartsWith_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.RequiresStartsWith(target);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition StartsWith failed: {nameof(value)} must start with the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void StartsWithExtension_RequiresStartsWith_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeIsSuppliedAndAllOtherDefaultsAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.InvariantCulture;
      var act = () => _ = value.RequiresStartsWith(target, comparisonType);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition StartsWith failed: {nameof(value)} must start with the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void StartsWithExtension_RequiresStartsWith_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresStartsWith(target, messageTemplate: messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement StartsWith failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void StartsWithExtension_RequiresStartsWith_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomMessageTemplateAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresStartsWith(target, comparisonType, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement StartsWith failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void StartsWithExtension_RequiresStartsWith_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.RequiresStartsWith(target, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition StartsWith failed: {nameof(value)} must start with the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void StartsWithExtension_RequiresStartsWith_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.RequiresStartsWith(target, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition StartsWith failed: {nameof(value)} must start with the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void StartsWithExtension_RequiresStartsWith_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresStartsWith(target, messageTemplate: messageTemplate, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement StartsWith failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void StartsWithExtension_RequiresStartsWith_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomMessageTemplateAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.Ordinal;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresStartsWith(target, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement StartsWith failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
