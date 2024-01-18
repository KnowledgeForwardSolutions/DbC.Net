namespace DbC.Net.Tests.Unit;

#pragma warning disable xUnit1012 // Null should only be used for nullable parameters
public class ContainsExtensionsTests
{
   private const Int32 _dataCount = 7;

   #region EnsuresContains Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ContainsExtensions_EnsuresContains_ShouldNotThrow_WhenValueContainsTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "WE";
      var act = () => _ = value.EnsuresContains(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_EnsuresContains_ShouldNotThrow_WhenValueIsNotEmptyAndTargetIsEmptyAndComparisonIsDefault()
   {
      // Arrange.
      var value = "asdf";
      var target = String.Empty;
      var act = () => _ = value.EnsuresContains(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_EnsuresContains_ShouldNotThrow_WhenValueIsEmptyAndTargetIsEmptyAndComparisonIsDefault()
   {
      // Arrange.
      var value = String.Empty;
      var target = String.Empty;
      var act = () => _ = value.EnsuresContains(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_EnsuresContains_ShouldNotThrow_WhenValueEqualsTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QWERTY";
      var act = () => _ = value.EnsuresContains(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_EnsuresContains_ShouldNotThrow_WhenValueStartsWithTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QW";
      var act = () => _ = value.EnsuresContains(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_EnsuresContains_ShouldNotThrow_WhenValueEndsWithTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "TY";
      var act = () => _ = value.EnsuresContains(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_EnsuresContains_ShouldNotThrow_WhenValueContainsMultipleTargetSubstringsAndComparisonIsDefault()
   {
      // Arrange.
      var value = "asdfQWERTYasdf";
      var target = "sd";
      var act = () => _ = value.EnsuresContains(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_EnsuresContains_ShouldReturnOriginalValue_WhenRequirementIsPassedAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "WE";

      // Act.
      var result = value.EnsuresContains(target);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void ContainsExtensions_EnsuresContains_ShouldNotThrow_WhenValueContainsTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresContains(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   // Note: tr-TR culture considers "i" and upper case dotted "I" as equal when
   // case is ignored. Same for "I" and lowercase dot-less "i".
   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", StringData.LowerCaseDotlessI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void ContainsExtensions_EnsuresContains_ShouldNotThrow_WhenValueContainsTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresContains(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   // Note: th-TH culture considers "a" and "a-" as equal.
   [UseCulture(CultureData.ThaiThailand)]
   [Theory]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "A-", StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "a-", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void ContainsExtensions_EnsuresContains_ShouldNotThrow_WhenValueContainsTargetAndCurrentCultureIs_thTH(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresContains(target, comparisonType);

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
   public void ContainsExtensions_EnsuresContains_ShouldNotThrow_WhenValueIsNotEmptyAndTargetIsEmptyAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = "asdf";
      var target = String.Empty;
      var act = () => _ = value.EnsuresContains(target, comparisonType);

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
   public void ContainsExtensions_EnsuresContains_ShouldNotThrow_WhenValueIsEmptyAndTargetIsEmptyAndCurrentCultureIs_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = String.Empty;
      var target = String.Empty;
      var act = () => _ = value.EnsuresContains(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void ContainsExtensions_EnsuresContains_ShouldReturnOriginalValue_WhenRequirementIsPassedAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresContains(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Fact]
   public void ContainsExtensions_EnsuresContains_ShouldNotThrow_WhenValueEqualsTargetAndComparisonIsSupplied()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QWERTY";
      var comparisonType = StringComparison.CurrentCulture;
      var act = () => _ = value.EnsuresContains(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.ThaiThailand)]
   [Fact]
   public void ContainsExtensions_EnsuresContains_ShouldNotThrow_WhenValueStartsWithTargetAndComparisonIsSupplied()
   {
      // Arrange.
      var value = "ABCDEF";
      var target = "A-";
      var comparisonType = StringComparison.CurrentCultureIgnoreCase;
      var act = () => _ = value.EnsuresContains(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_EnsuresContains_ShouldNotThrow_WhenValueEndsWithTargetAndComparisonIsSupplied()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "TY";
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.EnsuresContains(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Fact]
   public void ContainsExtensions_EnsuresContains_ShouldNotThrow_WhenValueContainsMultipleTargetSubstringsAndComparisonIsSupplied()
   {
      // Arrange.
      var value = "GHIJK12345GHIK";
      var target = StringData.LowerCaseDotlessI;
      var comparisonType = StringComparison.CurrentCultureIgnoreCase;
      var act = () => _ = value.EnsuresContains(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_EnsuresContains_ShouldThrow_WhenValueIsNotNullAndDoesNotContainTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.EnsuresContains(target);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Theory]
   [InlineData("!@#$%")]
   [InlineData("")]
   public void ContainsExtensions_EnsuresContains_ShouldThrow_WhenValueNullAndTargetIsNotNullAndComparisonIsDefault(String target)
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresContains(target);

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
   public void ContainsExtensions_EnsuresContains_ShouldThrow_WhenValueIsNotNullAndDoesNotContainTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresContains(target, comparisonType);

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
   public void ContainsExtensions_EnsuresContains_ShouldThrow_WhenValueIsNotNullAndDoesNotContainTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresContains(target, comparisonType);

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
   public void ContainsExtensions_EnsuresContains_ShouldThrow_WhenValueIsNullAndTargetIsNotNullAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = null!;
      var target = "QWERTY";
      var act = () => _ = value.EnsuresContains(target, comparisonType);

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
   public void ContainsExtensions_EnsuresContains_ShouldThrow_WhenValueIsNullAndTargetIsNotNullAndCurrentCultureIs_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = null!;
      var target = "QWERTY";
      var act = () => _ = value.EnsuresContains(target, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Theory]
   [InlineData("not null string")]
   [InlineData(null)]
   public void ContainsExtensions_EnsuresContains_ShouldThrowArgumentNullException_WhenTargetIsNullAndComparisonIsDefault(String value)
   {
      // Arrange.
      String target = null!;
      var act = () => _ = value.EnsuresContains(target);
      var expectedMessage = Messages.TargetSubstringIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(target))
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void ContainsExtensions_EnsuresContains_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailedAndComparisonIsDefault()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.EnsuresContains(target);

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.Contains);
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
   public void ContainsExtensions_EnsuresContains_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.EnsuresContains(target, comparisonType);

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.Contains);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void ContainsExtension_EnsuresContains_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.EnsuresContains(target);
      var expectedMessage = $"Postcondition Contains failed: {nameof(value)} must contain the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void ContainsExtension_EnsuresContains_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeIsSuppliedAndAllOtherDefaultsAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.InvariantCulture;
      var act = () => _ = value.EnsuresContains(target, comparisonType);
      var expectedMessage = $"Postcondition Contains failed: {nameof(value)} must contain the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void ContainsExtension_EnsuresContains_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresContains(target, messageTemplate: messageTemplate);
      var expectedMessage = $"Requirement Contains failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void ContainsExtension_EnsuresContains_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomMessageTemplateAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresContains(target, comparisonType, messageTemplate);
      var expectedMessage = $"Requirement Contains failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void ContainsExtension_EnsuresContains_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.EnsuresContains(target, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition Contains failed: {nameof(value)} must contain the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void ContainsExtension_EnsuresContains_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.EnsuresContains(target, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition Contains failed: {nameof(value)} must contain the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void ContainsExtension_EnsuresContains_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresContains(target, messageTemplate: messageTemplate, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement Contains failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void ContainsExtension_EnsuresContains_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomMessageTemplateAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.Ordinal;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresContains(target, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement Contains failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresContains Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ContainsExtensions_RequiresContains_ShouldNotThrow_WhenValueContainsTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "WE";
      var act = () => _ = value.RequiresContains(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_RequiresContains_ShouldNotThrow_WhenValueIsNotEmptyAndTargetIsEmptyAndComparisonIsDefault()
   {
      // Arrange.
      var value = "asdf";
      var target = String.Empty;
      var act = () => _ = value.RequiresContains(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_RequiresContains_ShouldNotThrow_WhenValueIsEmptyAndTargetIsEmptyAndComparisonIsDefault()
   {
      // Arrange.
      var value = String.Empty;
      var target = String.Empty;
      var act = () => _ = value.RequiresContains(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_RequiresContains_ShouldNotThrow_WhenValueEqualsTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QWERTY";
      var act = () => _ = value.RequiresContains(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_RequiresContains_ShouldNotThrow_WhenValueStartsWithTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QW";
      var act = () => _ = value.RequiresContains(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_RequiresContains_ShouldNotThrow_WhenValueEndsWithTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "TY";
      var act = () => _ = value.RequiresContains(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_RequiresContains_ShouldNotThrow_WhenValueContainsMultipleTargetSubstringsAndComparisonIsDefault()
   {
      // Arrange.
      var value = "asdfQWERTYasdf";
      var target = "sd";
      var act = () => _ = value.RequiresContains(target);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_RequiresContains_ShouldReturnOriginalValue_WhenRequirementIsPassedAndComparisonIsDefault()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "WE";

      // Act.
      var result = value.RequiresContains(target);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void ContainsExtensions_RequiresContains_ShouldNotThrow_WhenValueContainsTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresContains(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   // Note: tr-TR culture considers "i" and upper case dotted "I" as equal when
   // case is ignored. Same for "I" and lowercase dot-less "i".
   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", StringData.LowerCaseDotlessI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void ContainsExtensions_RequiresContains_ShouldNotThrow_WhenValueContainsTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresContains(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   // Note: th-TH culture considers "a" and "a-" as equal.
   [UseCulture(CultureData.ThaiThailand)]
   [Theory]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "A-", StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "a-", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void ContainsExtensions_RequiresContains_ShouldNotThrow_WhenValueContainsTargetAndCurrentCultureIs_thTH(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresContains(target, comparisonType);

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
   public void ContainsExtensions_RequiresContains_ShouldNotThrow_WhenValueIsNotEmptyAndTargetIsEmptyAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = "asdf";
      var target = String.Empty;
      var act = () => _ = value.RequiresContains(target, comparisonType);

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
   public void ContainsExtensions_RequiresContains_ShouldNotThrow_WhenValueIsEmptyAndTargetIsEmptyAndCurrentCultureIs_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = String.Empty;
      var target = String.Empty;
      var act = () => _ = value.RequiresContains(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.CurrentCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.CurrentCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.InvariantCulture)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.InvariantCultureIgnoreCase)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "JKL", StringComparison.Ordinal)]
   [InlineData("ABCDEFGHIJKLMNOPQRSTUVWXYZ", "jkl", StringComparison.OrdinalIgnoreCase)]
   public void ContainsExtensions_RequiresContains_ShouldReturnOriginalValue_WhenRequirementIsPassedAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresContains(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Fact]
   public void ContainsExtensions_RequiresContains_ShouldNotThrow_WhenValueEqualsTargetAndComparisonIsSupplied()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "QWERTY";
      var comparisonType = StringComparison.CurrentCulture;
      var act = () => _ = value.RequiresContains(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.ThaiThailand)]
   [Fact]
   public void ContainsExtensions_RequiresContains_ShouldNotThrow_WhenValueStartsWithTargetAndComparisonIsSupplied()
   {
      // Arrange.
      var value = "ABCDEF";
      var target = "A-";
      var comparisonType = StringComparison.CurrentCultureIgnoreCase;
      var act = () => _ = value.RequiresContains(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_RequiresContains_ShouldNotThrow_WhenValueEndsWithTargetAndComparisonIsSupplied()
   {
      // Arrange.
      var value = "QWERTY";
      var target = "TY";
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.RequiresContains(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Fact]
   public void ContainsExtensions_RequiresContains_ShouldNotThrow_WhenValueContainsMultipleTargetSubstringsAndComparisonIsSupplied()
   {
      // Arrange.
      var value = "GHIJK12345GHIK";
      var target = StringData.LowerCaseDotlessI;
      var comparisonType = StringComparison.CurrentCultureIgnoreCase;
      var act = () => _ = value.RequiresContains(target, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ContainsExtensions_RequiresContains_ShouldThrow_WhenValueIsNotNullAndDoesNotContainTargetAndComparisonIsDefault()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.RequiresContains(target);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Theory]
   [InlineData("!@#$%")]
   [InlineData("")]
   public void ContainsExtensions_RequiresContains_ShouldThrow_WhenValueNullAndTargetIsNotNullAndComparisonIsDefault(String target)
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresContains(target);

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
   public void ContainsExtensions_RequiresContains_ShouldThrow_WhenValueIsNotNullAndDoesNotContainTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresContains(target, comparisonType);

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
   public void ContainsExtensions_RequiresContains_ShouldThrow_WhenValueIsNotNullAndDoesNotContainTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresContains(target, comparisonType);

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
   public void ContainsExtensions_RequiresContains_ShouldThrow_WhenValueIsNullAndTargetIsNotNullAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = null!;
      var target = "QWERTY";
      var act = () => _ = value.RequiresContains(target, comparisonType);

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
   public void ContainsExtensions_RequiresContains_ShouldThrow_WhenValueIsNullAndTargetIsNotNullAndCurrentCultureIs_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = null!;
      var target = "QWERTY";
      var act = () => _ = value.RequiresContains(target, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Theory]
   [InlineData("not null string")]
   [InlineData(null)]
   public void ContainsExtensions_RequiresContains_ShouldThrowArgumentNullException_WhenTargetIsNullAndComparisonIsDefault(String value)
   {
      // Arrange.
      String target = null!;
      var act = () => _ = value.RequiresContains(target);
      var expectedMessage = Messages.TargetSubstringIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(target))
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void ContainsExtensions_RequiresContains_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailedAndComparisonIsDefault()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.RequiresContains(target);

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.Contains);
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
   public void ContainsExtensions_RequiresContains_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed_thTH(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.RequiresContains(target, comparisonType);

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.Contains);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void ContainsExtension_RequiresContains_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.RequiresContains(target);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition Contains failed: {nameof(value)} must contain the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void ContainsExtension_RequiresContains_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeIsSuppliedAndAllOtherDefaultsAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.InvariantCulture;
      var act = () => _ = value.RequiresContains(target, comparisonType);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition Contains failed: {nameof(value)} must contain the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void ContainsExtension_RequiresContains_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresContains(target, messageTemplate: messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement Contains failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void ContainsExtension_RequiresContains_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomMessageTemplateAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresContains(target, comparisonType, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement Contains failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void ContainsExtension_RequiresContains_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var act = () => _ = value.RequiresContains(target, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition Contains failed: {nameof(value)} must contain the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void ContainsExtension_RequiresContains_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.RequiresContains(target, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition Contains failed: {nameof(value)} must contain the substring \"{target}\"";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void ContainsExtension_RequiresContains_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresContains(target, messageTemplate: messageTemplate, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement Contains failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void ContainsExtension_RequiresContains_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndComparisonTypeAndCustomMessageTemplateAndCustomExceptionFactoryAreUsed()
   {
      // Arrange.
      var value = "This is a test";
      var target = "only";
      var comparisonType = StringComparison.Ordinal;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresContains(target, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement Contains failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
