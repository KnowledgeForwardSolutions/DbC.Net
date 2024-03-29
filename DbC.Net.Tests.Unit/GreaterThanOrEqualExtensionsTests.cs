﻿// Ignore Spelling: sv

namespace DbC.Net.Tests.Unit;

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters

public class GreaterThanOrEqualExtensionsTests
{
   private const Int32 _dataCount = 6;
   private const Int32 _stringDataCount = 7;

   #region EnsuresGreaterThanOrEqual (IComparable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldReturnOriginalValue_WhenValueIsAboveLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var lowerBound = data.MinValue;

      // Act.
      var result = value.EnsuresGreaterThanOrEqual(lowerBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var lowerBound = data.MaxValue;

      // Act.
      var result = value.EnsuresGreaterThanOrEqual(lowerBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterOrEqualThanIComparable_ShouldReturnOriginalValue_WhenReferenceValueIsNotNullAndLowerBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      T lowerBound = default!;

      // Act.
      var result = value.EnsuresGreaterThanOrEqual(lowerBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterOrEqualThanIComparable_ShouldReturnOriginalValue_WhenReferenceValueIsNullAndLowerBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = default!;

      // Act.
      var result = value.EnsuresGreaterThanOrEqual(lowerBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldThrow_WhenValueIsBelowLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldThrow_WhenReferenceValueIsNullAndLowerBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var data = new Int32Data();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound);

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThanOrEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var data = new PointStructData();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound);
      var expectedMessage = $"Postcondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new HalfData();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, messageTemplate);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new UInt128Data();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var lowerBound = "ABC";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region EnsuresGreaterThanOrEqual (IComparer) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldReturnOriginalValue_WhenValueIsAboveLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var lowerBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.EnsuresGreaterThanOrEqual(lowerBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.EnsuresGreaterThanOrEqual(lowerBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldReturnOriginalValue_WhenReferenceValueIsNotNullAndLowerBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      T lowerBound = default!;
      var comparer = Comparer<T>.Default;

      // Act.
      var result = value.EnsuresGreaterThanOrEqual(lowerBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldReturnOriginalValue_WhenReferenceValueIsNullAndLowerBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = default!;
      var comparer = Comparer<T>.Default;

      // Act.
      var result = value.EnsuresGreaterThanOrEqual(lowerBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldThrow_WhenValueIsBelowLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparer);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldThrow_WhenReferenceValueIsNullAndLowerBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      var lowerBound = data.ReverseMaxValue;
      var comparer = Comparer<T>.Default;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparer);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var data = new DateTimeData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparer);

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThanOrEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldThrowPostconditionFailedExceptionExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var data = new BoxRecordData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparer);
      var expectedMessage = $"Postcondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new ByteData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparer, messageTemplate);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new DoubleData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = "ABC";
      var lowerBound = "def";
      var comparer = StringComparer.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterOrEqualThanIComparer_ShouldThrowArgumentNullException_WhenComparerIsNull()
   {
      // Arrange.
      var data = new TimeOnlyData();
      var value = data.ReverseMaxValue;
      var lowerBound = data.ReverseMinValue;
      IComparer<TimeOnly> comparer = null!;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparer);
      var expectedMessage = Messages.ComparerIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(comparer))
         .WithMessage(expectedMessage + "*");
   }

   #endregion

   #region EnsuresGreaterThanOrEqual (String) Tests
   // ==========================================================================
   // ==========================================================================

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseAE, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseAE, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseAE, StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualString_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresGreaterThanOrEqual(lowerBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData(StringData.UpperCaseDottedI, StringData.LowerCaseI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseI, StringComparison.CurrentCultureIgnoreCase)] // I without dot sorts before I with dot in tr-TR culture
   [InlineData(StringData.UpperCaseA, StringData.LowerCaseA, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseA, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseDottedI, StringData.UpperCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseAE, StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualString_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndCurrentCultureIs_trTR(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresGreaterThanOrEqual(lowerBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.SwedishSweden)]
   [Theory]
   [InlineData(StringData.UpperCaseOWithDiaeresis, StringData.LowerCaseOWithDiaeresis, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseA, StringData.LowerCaseA, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseA, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseDiphthongAE, StringData.UpperCaseDiphthongAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseDiphthongAE, StringData.UpperCaseAE, StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualString_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndCurrentCultureIs_svSE(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresGreaterThanOrEqual(lowerBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.UpperCaseAE, StringData.UpperCaseAE, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseSlashedO, StringData.LowerCaseSlashedO, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseSlashedO, StringData.UpperCaseSlashedO, StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualString_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresGreaterThanOrEqual(lowerBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualString_ShouldReturnOriginalValue_WhenValueAndLowerBoundAreDefaultAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String lowerBound = default!;

      // Act.
      var result = value.EnsuresGreaterThanOrEqual(lowerBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.DanishDenmark)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualString_ShouldReturnOriginalValue_WhenValueAndLowerBoundAreDefaultAndCurrentCultureIs_daDK(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String lowerBound = default!;

      // Act.
      var result = value.EnsuresGreaterThanOrEqual(lowerBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData(StringData.LowerCaseDotlessI, StringData.UpperCaseI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseDotlessI, StringData.LowerCaseI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseZ, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseSlashedO, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseI, StringData.LowerCaseDotlessI, StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualString_ShouldThrow_WhenValueIsBelowLowerBoundAndCurrentCultureIs_trTR(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparisonType);

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
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualString_ShouldThrow_WhenValueIsDefaultAndLowerBoundIsNotAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      var lowerBound = "asdf";
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [UseCulture(CultureData.SwedishSweden)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualString_ShouldThrow_WhenValueIsDefaultAndLowerBoundIsNotAndCurrentCultureIs_svSE(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      var lowerBound = "asdf";
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualString_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = StringData.UpperCaseA;
      var lowerBound = StringData.UpperCaseZ;
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparisonType);

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_stringDataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThanOrEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualString_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseA;
      var lowerBound = StringData.LowerCaseZ;
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparisonType);
      var expectedMessage = $"Postcondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualString_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseH;
      var lowerBound = StringData.LowerCaseJ;
      var comparisonType = StringComparison.InvariantCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparisonType, messageTemplate);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualString_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseJ;
      var lowerBound = StringData.LowerCaseZ;
      var comparisonType = StringComparison.InvariantCultureIgnoreCase;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualString_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseA;
      var lowerBound = StringData.UpperCaseZ;
      var comparisonType = StringComparison.CurrentCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresGreaterThanOrEqual (IComparable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldReturnOriginalValue_WhenValueIsAboveLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var lowerBound = data.MinValue;

      // Act.
      var result = value.RequiresGreaterThanOrEqual(lowerBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var lowerBound = data.MaxValue;

      // Act.
      var result = value.RequiresGreaterThanOrEqual(lowerBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanOrEqualExtensions_RequiresGreaterOrEqualThanIComparable_ShouldReturnOriginalValue_WhenReferenceValueIsNotNullAndLowerBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      T lowerBound = default!;

      // Act.
      var result = value.RequiresGreaterThanOrEqual(lowerBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanOrEqualExtensions_RequiresGreaterOrEqualThanIComparable_ShouldReturnOriginalValue_WhenReferenceValueIsNullAndLowerBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = default!;

      // Act.
      var result = value.RequiresGreaterThanOrEqual(lowerBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldThrow_WhenValueIsBelowLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldThrow_WhenReferenceValueIsNullAndLowerBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var data = new Int32Data();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound);

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThanOrEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndAndAllDefaultsAreUsed()
   {
      // Arrange.
      var data = new PointStructData();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new HalfData();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new UInt128Data();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var lowerBound = "ABC";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresGreaterThanOrEqual (IComparer) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldReturnOriginalValue_WhenValueIsAboveLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var lowerBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.RequiresGreaterThanOrEqual(lowerBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.RequiresGreaterThanOrEqual(lowerBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldReturnOriginalValue_WhenReferenceValueIsNotNullAndLowerBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      T lowerBound = default!;
      var comparer = Comparer<T>.Default;

      // Act.
      var result = value.RequiresGreaterThanOrEqual(lowerBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldReturnOriginalValue_WhenReferenceValueIsNullAndLowerBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = default!;
      var comparer = Comparer<T>.Default;

      // Act.
      var result = value.RequiresGreaterThanOrEqual(lowerBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldThrow_WhenValueIsBelowLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparer);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldThrow_WhenReferenceValueIsNullAndLowerBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      var lowerBound = data.ReverseMaxValue;
      var comparer = Comparer<T>.Default;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparer);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var data = new DateTimeData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparer);

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThanOrEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var data = new BoxRecordData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparer);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new ByteData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparer, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new DoubleData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = "ABC";
      var lowerBound = "def";
      var comparer = StringComparer.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterOrEqualThanIComparer_ShouldThrowArgumentNullException_WhenComparerIsNull()
   {
      // Arrange.
      var data = new TimeOnlyData();
      var value = data.ReverseMaxValue;
      var lowerBound = data.ReverseMinValue;
      IComparer<TimeOnly> comparer = null!;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparer);
      var expectedMessage = Messages.ComparerIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(comparer))
         .WithMessage(expectedMessage + "*");
   }

   #endregion

   #region RequiresGreaterThanOrEqual (String) Tests
   // ==========================================================================
   // ==========================================================================

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseAE, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseAE, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseAE, StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualString_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresGreaterThanOrEqual(lowerBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData(StringData.UpperCaseDottedI, StringData.LowerCaseI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseI, StringComparison.CurrentCultureIgnoreCase)] // I without dot sorts before I with dot in tr-TR culture
   [InlineData(StringData.UpperCaseA, StringData.LowerCaseA, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseA, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseDottedI, StringData.UpperCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseAE, StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualString_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndCurrentCultureIs_trTR(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresGreaterThanOrEqual(lowerBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.SwedishSweden)]
   [Theory]
   [InlineData(StringData.UpperCaseOWithDiaeresis, StringData.LowerCaseOWithDiaeresis, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseA, StringData.LowerCaseA, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseA, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseDiphthongAE, StringData.UpperCaseDiphthongAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseDiphthongAE, StringData.UpperCaseAE, StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualString_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndCurrentCultureIs_svSE(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresGreaterThanOrEqual(lowerBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.UpperCaseAE, StringData.UpperCaseAE, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseSlashedO, StringData.LowerCaseSlashedO, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseSlashedO, StringData.UpperCaseSlashedO, StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualString_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresGreaterThanOrEqual(lowerBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualString_ShouldReturnOriginalValue_WhenValueAndLowerBoundAreDefaultAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String lowerBound = default!;

      // Act.
      var result = value.RequiresGreaterThanOrEqual(lowerBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.DanishDenmark)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualString_ShouldReturnOriginalValue_WhenValueAndLowerBoundAreDefaultAndCurrentCultureIs_daDK(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String lowerBound = default!;

      // Act.
      var result = value.RequiresGreaterThanOrEqual(lowerBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData(StringData.LowerCaseDotlessI, StringData.UpperCaseI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseDotlessI, StringData.LowerCaseI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseZ, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseSlashedO, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseI, StringData.LowerCaseDotlessI, StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualString_ShouldThrow_WhenValueIsBelowLowerBoundAndCurrentCultureIs_trTR(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualString_ShouldThrow_WhenValueIsDefaultAndLowerBoundIsNotAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      var lowerBound = "asdf";
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>();
   }

   [UseCulture(CultureData.SwedishSweden)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualString_ShouldThrow_WhenValueIsDefaultAndLowerBoundIsNotAndCurrentCultureIs_svSE(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      var lowerBound = "asdf";
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualString_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = StringData.UpperCaseA;
      var lowerBound = StringData.UpperCaseZ;
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparisonType);

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_stringDataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThanOrEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualString_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseA;
      var lowerBound = StringData.LowerCaseZ;
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparisonType);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualString_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseH;
      var lowerBound = StringData.LowerCaseJ;
      var comparisonType = StringComparison.InvariantCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparisonType, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualString_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseJ;
      var lowerBound = StringData.LowerCaseZ;
      var comparisonType = StringComparison.InvariantCultureIgnoreCase;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualString_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseA;
      var lowerBound = StringData.UpperCaseZ;
      var comparisonType = StringComparison.CurrentCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
