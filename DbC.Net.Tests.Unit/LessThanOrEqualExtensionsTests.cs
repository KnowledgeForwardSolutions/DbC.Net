// Ignore Spelling: sv

namespace DbC.Net.Tests.Unit;

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters

public class LessThanOrEqualExtensionsTests
{
   private const Int32 _dataCount = 6;
   private const Int32 _stringDataCount = 7;

   #region EnsuresLessThanOrEqual (IComparable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparable_ShouldReturnOriginalValue_WhenValueIsBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MinValue;
      var upperBound = data.MaxValue;

      // Act.
      var result = value.EnsuresLessThanOrEqual(upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparable_ShouldReturnOriginalValue_WhenValueIsEqualToUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var upperBound = data.MaxValue;

      // Act.
      var result = value.EnsuresLessThanOrEqual(upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparable_ShouldReturnOriginalValue_WhenReferenceValueIsNullAndUpperBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      var upperBound = data.MinValue;

      // Act.
      var result = value.EnsuresLessThanOrEqual(upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanOrEqualExtensions_EnsuresLessOrEqualThanIComparable_ShouldReturnOriginalValue_WhenReferenceValueIsNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T upperBound = default!;

      // Act.
      var result = value.EnsuresLessThanOrEqual(upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparable_ShouldThrow_WhenValueIsAboveUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanOrEqualExtensions_EnsuresLessOrEqualThanIComparable_ShouldThrow_WhenReferenceValueIsNotNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      T upperBound = default!;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparable_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var data = new Int32Data();
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound);

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.LessThanOrEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
   }

   [Fact]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAndAllDefaultsAreUsed()
   {
      // Arrange.
      var data = new PointStructData();
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound);
      var expectedMessage = $"Postcondition LessThanOrEqual failed: {nameof(value)} must be less than or equal to {upperBound}";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new HalfData();
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, messageTemplate);
      var expectedMessage = $"Requirement LessThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new UInt128Data();
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition LessThanOrEqual failed: {nameof(value)} must be less than or equal to {upperBound}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "ABC";
      String upperBound = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement LessThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region EnsuresLessThanOrEqual (IComparer) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparer_ShouldReturnOriginalValue_WhenValueIsBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMinValue;
      var upperBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.EnsuresLessThanOrEqual(upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparer_ShouldReturnOriginalValue_WhenValueIsEqualToUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMinValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.EnsuresLessThanOrEqual(upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparer_ShouldReturnOriginalValue_WhenReferenceValueIsNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T upperBound = default!;
      var comparer = Comparer<T>.Default;

      // Act.
      var result = value.EnsuresLessThanOrEqual(upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparer_ShouldReturnOriginalValue_WhenReferenceValueIsNullAndUpperBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      var upperBound = data.ReverseMaxValue;
      var comparer = Comparer<T>.Default;

      // Act.
      var result = value.EnsuresLessThanOrEqual(upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparer_ShouldThrow_WhenValueIsAboveUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, comparer);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparer_ShouldThrow_WhenReferenceValueIsNotNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      T upperBound = default!;
      var comparer = Comparer<T>.Default;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, comparer);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparer_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var data = new DateTimeData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, comparer);

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.LessThanOrEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
   }

   [Fact]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparer_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var data = new BoxRecordData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, comparer);
      var expectedMessage = $"Postcondition LessThanOrEqual failed: {nameof(value)} must be less than or equal to {upperBound}";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparer_ShouldThrowPostconditionFailedExceptionExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new ByteData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, comparer, messageTemplate);
      var expectedMessage = $"Requirement LessThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new DoubleData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition LessThanOrEqual failed: {nameof(value)} must be less than or equal to {upperBound}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = "def";
      var upperBound = "ABC";
      var comparer = StringComparer.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement LessThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanOrEqualExtensions_EnsuresLessOrEqualThanIComparer_ShouldThrowArgumentNullException_WhenComparerIsNull()
   {
      // Arrange.
      var data = new TimeOnlyData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      IComparer<TimeOnly> comparer = null!;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, comparer);
      var expectedMessage = Messages.ComparerIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(comparer))
         .WithMessage(expectedMessage + "*");
   }

   #endregion

   #region EnsuresLessThanOrEqual (String) Tests
   // ==========================================================================
   // ==========================================================================

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseZ, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualString_ShouldReturnOriginalValue_WhenValueIsBelowUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresLessThanOrEqual(upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData(StringData.UpperCaseI, StringData.UpperCaseDottedI, StringComparison.CurrentCulture)] // I without dot sorts before I with dot in tr-TR culture
   [InlineData(StringData.LowerCaseDotlessI, StringData.UpperCaseDottedI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseA, StringData.UpperCaseA, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseA, StringData.LowerCaseI, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseZ, StringData.UpperCaseDottedI, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualString_ShouldReturnOriginalValue_WhenValueIsBelowLowerBoundAndCurrentCultureIs_trTR(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresLessThanOrEqual(upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.SwedishSweden)]
   [Theory]
   [InlineData(StringData.LowerCaseOWithDiaeresis, StringData.UpperCaseOWithDiaeresis, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseZ, StringData.UpperCaseOWithDiaeresis, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseA, StringData.UpperCaseA, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseA, StringData.LowerCaseI, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseDiphthongAE, StringData.LowerCaseDiphthongAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseAE, StringData.UpperCaseDiphthongAE, StringComparison.OrdinalIgnoreCase)]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualString_ShouldReturnOriginalValue_WhenValueIsBelowUpperBoundAndCurrentCultureIs_svSE(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresLessThanOrEqual(upperBound, comparisonType);

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
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualString_ShouldReturnOriginalValue_WhenValueIsEqualToUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresLessThanOrEqual(upperBound, comparisonType);

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
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualString_ShouldReturnOriginalValue_WhenValueAndUpperBoundAreDefaultAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String upperBound = default!;

      // Act.
      var result = value.EnsuresLessThanOrEqual(upperBound, comparisonType);

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
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualString_ShouldReturnOriginalValue_WhenValueAndUpperBoundAreDefaultAndCurrentCultureIs_daDK(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String upperBound = default!;

      // Act.
      var result = value.EnsuresLessThanOrEqual(upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData(StringData.UpperCaseI, StringData.LowerCaseDotlessI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.LowerCaseDotlessI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseZ, StringData.LowerCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseSlashedO, StringData.UpperCaseSlashedO, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseDotlessI, StringData.UpperCaseI, StringComparison.OrdinalIgnoreCase)]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualString_ShouldThrow_WhenValueIsAboveUpperBoundAndCurrentCultureIs_trTR(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, comparisonType);

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
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualString_ShouldThrow_WhenValueIsNotDefaultAndUpperBoundIsDefaultAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = "asdf";
      String upperBound = default!;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, comparisonType);

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
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualString_ShouldThrow_WhenValueIsNotDefaultAndUpperBoundIsDefaultAndCurrentCultureIs_svSE(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = "asdf";
      String upperBound = default!;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualString_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = StringData.UpperCaseZ;
      var upperBound = StringData.UpperCaseA;
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, comparisonType);

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_stringDataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.LessThanOrEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualString_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseZ;
      var upperBound = StringData.UpperCaseA;
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, comparisonType);
      var expectedMessage = $"Postcondition LessThanOrEqual failed: {nameof(value)} must be less than or equal to {upperBound}";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualString_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseJ;
      var upperBound = StringData.UpperCaseH;
      var comparisonType = StringComparison.InvariantCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, comparisonType, messageTemplate);
      var expectedMessage = $"Requirement LessThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualString_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseZ;
      var upperBound = StringData.UpperCaseJ;
      var comparisonType = StringComparison.InvariantCultureIgnoreCase;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition LessThanOrEqual failed: {nameof(value)} must be less than or equal to {upperBound}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Fact]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualString_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseZ;
      var upperBound = StringData.LowerCaseA;
      var comparisonType = StringComparison.CurrentCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement LessThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresLessThanOrEqual (IComparable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparable_ShouldReturnOriginalValue_WhenValueIsBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MinValue;
      var upperBound = data.MaxValue;

      // Act.
      var result = value.RequiresLessThanOrEqual(upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparable_ShouldReturnOriginalValue_WhenValueIsEqualToUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var upperBound = data.MaxValue;

      // Act.
      var result = value.RequiresLessThanOrEqual(upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparable_ShouldReturnOriginalValue_WhenReferenceValueIsNullAndUpperBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      var upperBound = data.MinValue;

      // Act.
      var result = value.RequiresLessThanOrEqual(upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanOrEqualExtensions_RequiresLessOrEqualThanIComparable_ShouldReturnOriginalValue_WhenReferenceValueIsNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T upperBound = default!;

      // Act.
      var result = value.RequiresLessThanOrEqual(upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparable_ShouldThrow_WhenValueIsAboveUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanOrEqualExtensions_RequiresLessOrEqualThanIComparable_ShouldThrow_WhenReferenceValueIsNotNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      T upperBound = default!;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparable_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var data = new Int32Data();
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound);

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.LessThanOrEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
   }

   [Fact]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparable_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndAndAllDefaultsAreUsed()
   {
      // Arrange.
      var data = new PointStructData();
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition LessThanOrEqual failed: {nameof(value)} must be less than or equal to {upperBound}";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparable_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new HalfData();
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement LessThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new UInt128Data();
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition LessThanOrEqual failed: {nameof(value)} must be less than or equal to {upperBound}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "ABC";
      String upperBound = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement LessThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresLessThanOrEqual (IComparer) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparer_ShouldReturnOriginalValue_WhenValueIsBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMinValue;
      var upperBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.RequiresLessThanOrEqual(upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparer_ShouldReturnOriginalValue_WhenValueIsEqualToUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMinValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.RequiresLessThanOrEqual(upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparer_ShouldReturnOriginalValue_WhenReferenceValueIsNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T upperBound = default!;
      var comparer = Comparer<T>.Default;

      // Act.
      var result = value.RequiresLessThanOrEqual(upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparer_ShouldReturnOriginalValue_WhenReferenceValueIsNullAndUpperBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      var upperBound = data.ReverseMaxValue;
      var comparer = Comparer<T>.Default;

      // Act.
      var result = value.RequiresLessThanOrEqual(upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparer_ShouldThrow_WhenValueIsAboveUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, comparer);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparer_ShouldThrow_WhenReferenceValueIsNotNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      T upperBound = default!;
      var comparer = Comparer<T>.Default;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, comparer);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparer_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var data = new DateTimeData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, comparer);

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.LessThanOrEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
   }

   [Fact]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparer_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var data = new BoxRecordData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, comparer);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition LessThanOrEqual failed: {nameof(value)} must be less than or equal to {upperBound}";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparer_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new ByteData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, comparer, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement LessThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new DoubleData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition LessThanOrEqual failed: {nameof(value)} must be less than or equal to {upperBound}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = "def";
      var upperBound = "ABC";
      var comparer = StringComparer.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement LessThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanOrEqualExtensions_RequiresLessOrEqualThanIComparer_ShouldThrowArgumentNullException_WhenComparerIsNull()
   {
      // Arrange.
      var data = new TimeOnlyData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      IComparer<TimeOnly> comparer = null!;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, comparer);
      var expectedMessage = Messages.ComparerIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(comparer))
         .WithMessage(expectedMessage + "*");
   }

   #endregion

   #region RequiresLessThanOrEqual (String) Tests
   // ==========================================================================
   // ==========================================================================

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseZ, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualString_ShouldReturnOriginalValue_WhenValueIsBelowUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresLessThanOrEqual(upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData(StringData.UpperCaseI, StringData.UpperCaseDottedI, StringComparison.CurrentCulture)] // I without dot sorts before I with dot in tr-TR culture
   [InlineData(StringData.LowerCaseDotlessI, StringData.UpperCaseDottedI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseA, StringData.UpperCaseA, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseA, StringData.LowerCaseI, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseZ, StringData.UpperCaseDottedI, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualString_ShouldReturnOriginalValue_WhenValueIsBelowLowerBoundAndCurrentCultureIs_trTR(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresLessThanOrEqual(upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.SwedishSweden)]
   [Theory]
   [InlineData(StringData.LowerCaseOWithDiaeresis, StringData.UpperCaseOWithDiaeresis, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseZ, StringData.UpperCaseOWithDiaeresis, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseA, StringData.UpperCaseA, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseA, StringData.LowerCaseI, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseDiphthongAE, StringData.LowerCaseDiphthongAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseAE, StringData.UpperCaseDiphthongAE, StringComparison.OrdinalIgnoreCase)]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualString_ShouldReturnOriginalValue_WhenValueIsBelowUpperBoundAndCurrentCultureIs_svSE(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresLessThanOrEqual(upperBound, comparisonType);

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
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualString_ShouldReturnOriginalValue_WhenValueIsEqualToUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresLessThanOrEqual(upperBound, comparisonType);

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
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualString_ShouldReturnOriginalValue_WhenValueAndUpperBoundAreDefaultAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String upperBound = default!;

      // Act.
      var result = value.RequiresLessThanOrEqual(upperBound, comparisonType);

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
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualString_ShouldReturnOriginalValue_WhenValueAndUpperBoundAreDefaultAndCurrentCultureIs_daDK(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String upperBound = default!;

      // Act.
      var result = value.RequiresLessThanOrEqual(upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData(StringData.UpperCaseI, StringData.LowerCaseDotlessI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.LowerCaseDotlessI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseZ, StringData.LowerCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseSlashedO, StringData.UpperCaseSlashedO, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseDotlessI, StringData.UpperCaseI, StringComparison.OrdinalIgnoreCase)]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualString_ShouldThrow_WhenValueIsAboveUpperBoundAndCurrentCultureIs_trTR(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, comparisonType);

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
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualString_ShouldThrow_WhenValueIsNotDefaultAndUpperBoundIsDefaultAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = "asdf";
      String upperBound = default!;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, comparisonType);

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
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualString_ShouldThrow_WhenValueIsNotDefaultAndUpperBoundIsDefaultAndCurrentCultureIs_svSE(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = "asdf";
      String upperBound = default!;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, comparisonType);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualString_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = StringData.UpperCaseZ;
      var upperBound = StringData.UpperCaseA;
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, comparisonType);

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_stringDataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.LessThanOrEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualString_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseZ;
      var upperBound = StringData.UpperCaseA;
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, comparisonType);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition LessThanOrEqual failed: {nameof(value)} must be less than or equal to {upperBound}";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualString_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseJ;
      var upperBound = StringData.UpperCaseH;
      var comparisonType = StringComparison.InvariantCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, comparisonType, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement LessThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualString_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseZ;
      var upperBound = StringData.UpperCaseJ;
      var comparisonType = StringComparison.InvariantCultureIgnoreCase;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition LessThanOrEqual failed: {nameof(value)} must be less than or equal to {upperBound}";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Fact]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualString_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseZ;
      var upperBound = StringData.LowerCaseA;
      var comparisonType = StringComparison.CurrentCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement LessThanOrEqual failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
