namespace DbC.Net.Tests.Unit;

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters

public class LessThanExtensionsTests
{
   private const Int32 _dataCount = 6;
   private const Int32 _stringDataCount = 7;

   #region EnsuresLessThan (IComparable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanExtensions_EnsuresLessThanIComparable_ShouldReturnOriginalValue_WhenValueIsBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MinValue;
      var upperBound = data.MaxValue;

      // Act.
      var result = value.EnsuresLessThan(upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanExtensions_EnsuresLessThanIComparable_ShouldReturnOriginalValue_WhenReferenceValueIsNullAndUpperBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      var upperBound = data.MinValue;

      // Act.
      var result = value.EnsuresLessThan(upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanExtensions_EnsuresLessThanIComparable_ShouldThrow_WhenValueIsEqualToUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var upperBound = data.MaxValue;
      var act = () => _ = value.EnsuresLessThan(upperBound);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanExtensions_EnsuresLessThanIComparable_ShouldThrow_WhenValueIsAboveUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var act = () => _ = value.EnsuresLessThan(upperBound);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanExtensions_EnsuresLessThanIComparable_ShouldThrow_WhenReferenceValueIsNotNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      T upperBound = default!;
      var act = () => _ = value.EnsuresLessThan(upperBound);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanExtensions_EnsuresLessThanIComparable_ShouldThrow_ReferenceValueIsNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T upperBound = default!;
      var act = () => _ = value.EnsuresLessThan(upperBound);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void LessThanExtensions_EnsuresLessThanIComparable_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var data = new Int32Data();
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var act = () => _ = value.EnsuresLessThan(upperBound);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.LessThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
   }

   [Fact]
   public void LessThanExtensions_EnsuresLessThanIComparable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var data = new PointStructData();
      var value = data.MaxValue;
      var upperBound = data.MaxValue;
      var act = () => _ = value.EnsuresLessThan(upperBound);
      var expectedMessage = $"Postcondition LessThan failed: {nameof(value)} must be less than {upperBound}";

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;
      ex.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void LessThanExtensions_EnsuresLessThanIComparable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new HalfData();
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresLessThan(upperBound, messageTemplate);
      var expectedMessage = $"Requirement LessThan failed";

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;
      ex.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void LessThanExtensions_EnsuresLessThanIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new UInt128Data();
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var act = () => _ = value.EnsuresLessThan(upperBound, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition LessThan failed: {nameof(value)} must be less than {upperBound}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void LessThanExtensions_EnsuresLessThanIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "Abc";
      String upperBound = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresLessThan(upperBound, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement LessThan failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

   #region EnsuresLessThan (IComparer) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanExtensions_EnsuresLessThanIComparer_ShouldReturnOriginalValue_WhenValueIsBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMinValue;
      var upperBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.EnsuresLessThan(upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanExtensions_EnsuresLessThanIComparer_ShouldReturnOriginalValue_WhenReferenceValueIsNullAndUpperBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      var upperBound = data.ReverseMaxValue;
      var comparer = Comparer<T>.Default;

      // Act.
      var result = value.EnsuresLessThan(upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanExtensions_EnsuresLessThanIComparer_ShouldThrow_WhenValueIsEqualToUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresLessThan(upperBound, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanExtensions_EnsuresLessThanIComparer_ShouldThrow_WhenValueIsAboveUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresLessThan(upperBound, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanExtensions_EnsuresLessThanIComparer_ShouldThrow_WhenReferenceValueIsNotNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      T upperBound = default!;
      var comparer = Comparer<T>.Default;
      var act = () => _ = value.EnsuresLessThan(upperBound, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanExtensions_EnsuresLessThanIComparer_ShouldThrow_ReferenceValueIsNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T upperBound = default!;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresLessThan(upperBound, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void LessThanExtensions_EnsuresLessThanIComparer_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var data = new DateTimeData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresLessThan(upperBound, comparer);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.LessThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
   }

   [Fact]
   public void LessThanExtensions_EnsuresLessThanIComparer_ShouldThrowPostconditionFailedExceptionExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var data = new BoxRecordData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresLessThan(upperBound, comparer);
      var expectedMessage = $"Postcondition LessThan failed: {nameof(value)} must be less than {upperBound}";

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;
      ex.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void LessThanExtensions_EnsuresLessThanIComparer_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new ByteData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresLessThan(upperBound, comparer, messageTemplate);
      var expectedMessage = $"Requirement LessThan failed";

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;
      ex.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void LessThanExtensions_EnsuresLessThanIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new DoubleData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresLessThan(upperBound, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition LessThan failed: {nameof(value)} must be less than {upperBound}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void LessThanExtensions_EnsuresLessThanIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = "abc";
      var upperBound = "ABC";
      var comparer = StringComparer.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresLessThan(upperBound, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement LessThan failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void LessThanExtensions_EnsuresLessThanIComparer_ShouldThrowArgumentNullException_WhenComparerIsNull()
   {
      // Arrange.
      var data = new TimeOnlyData();
      var value = data.ReverseMinValue;
      var upperBound = data.ReverseMaxValue;
      IComparer<TimeOnly> comparer = null!;
      var act = () => _ = value.EnsuresLessThan(upperBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(comparer))
         .And.Message.Should().StartWith(Messages.ComparerIsNull);
   }

   #endregion

   #region EnsuresLessThan (String) Tests
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
   public void LessThanExtensions_EnsuresLessThanString_ShouldReturnOriginalValue_WhenValueIsBelowUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresLessThan(upperBound, comparisonType);

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
   public void LessThanExtensions_EnsuresLessThanString_ShouldReturnOriginalValue_WhenValueIsBelowUpperBoundAndCurrentCultureIs_trTR(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresLessThan(upperBound, comparisonType);

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
   public void LessThanExtensions_EnsuresLessThanString_ShouldReturnOriginalValue_WhenValueIsBelowUpperBoundAndCurrentCultureIs_svSE(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresLessThan(upperBound, comparisonType);

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
   public void LessThanExtensions_EnsuresLessThanString_ShouldThrow_WhenValueIsEqualToUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresLessThan(upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData(StringData.UpperCaseI, StringData.LowerCaseDotlessI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.LowerCaseDotlessI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseSlashedO, StringData.UpperCaseSlashedO, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseDotlessI, StringData.UpperCaseI, StringComparison.OrdinalIgnoreCase)]
   public void LessThanExtensions_EnsuresLessThanString_ShouldThrow_WhenValueExceedsUpperBoundAndCurrentCultureIs_trTR(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresLessThan(upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void LessThanExtensions_EnsuresLessThanString_ShouldThrow_WhenValueIsNotDefaultAndUpperBoundIsDefaultAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = "asdf";
      String upperBound = default!;
      var act = () => _ = value.EnsuresLessThan(upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [UseCulture(CultureData.SwedishSweden)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void LessThanExtensions_EnsuresLessThanString_ShouldThrow_WhenValueIsNotDefaultAndUpperBoundIsDefaultAndCurrentCultureIs_svSE(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = "asdf";
      String upperBound = default!;
      var act = () => _ = value.EnsuresLessThan(upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void LessThanExtensions_EnsuresLessThanString_ShouldThrow_WhenValueAndUpperBoundAreDefaultAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String upperBound = default!;
      var act = () => _ = value.EnsuresLessThan(upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [UseCulture(CultureData.DanishDenmark)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void LessThanExtensions_EnsuresLessThanString_ShouldThrow_WhenValueAndUpperBoundAreDefaultAndCurrentCultureIs_daDK(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String upperBound = default!;
      var act = () => _ = value.EnsuresLessThan(upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void LessThanExtensions_EnsuresLessThanString_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = StringData.UpperCaseZ;
      var upperBound = StringData.UpperCaseA;
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.EnsuresLessThan(upperBound, comparisonType);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_stringDataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.LessThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void LessThanExtensions_EnsuresLessThanString_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = StringData.LowerCaseZ;
      var upperBound = StringData.LowerCaseA;
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var act = () => _ = value.EnsuresLessThan(upperBound, comparisonType);
      var expectedMessage = $"Postcondition LessThan failed: {nameof(value)} must be less than {upperBound}";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void LessThanExtensions_EnsuresLessThanString_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseJ;
      var upperBound = StringData.LowerCaseH;
      var comparisonType = StringComparison.InvariantCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresLessThan(upperBound, comparisonType, messageTemplate);
      var expectedMessage = $"Requirement LessThan failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void LessThanExtensions_EnsuresLessThanString_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseJ;
      var upperBound = StringData.LowerCaseJ;
      var comparisonType = StringComparison.InvariantCultureIgnoreCase;
      var act = () => _ = value.EnsuresLessThan(upperBound, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition LessThan failed: {nameof(value)} must be less than {upperBound}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Fact]
   public void LessThanExtensions_EnsuresLessThanString_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseZ;
      var upperBound = StringData.UpperCaseA;
      var comparisonType = StringComparison.CurrentCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresLessThan(upperBound, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement LessThan failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

   #region RequiresLessThan (IComparable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanExtensions_RequiresLessThanIComparable_ShouldReturnOriginalValue_WhenValueIsBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MinValue;
      var upperBound = data.MaxValue;

      // Act.
      var result = value.RequiresLessThan(upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanExtensions_RequiresLessThanIComparable_ShouldReturnOriginalValue_WhenReferenceValueIsNullAndUpperBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      var upperBound = data.MinValue;

      // Act.
      var result = value.RequiresLessThan(upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanExtensions_RequiresLessThanIComparable_ShouldThrow_WhenValueIsEqualToUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var upperBound = data.MaxValue;
      var act = () => _ = value.RequiresLessThan(upperBound);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanExtensions_RequiresLessThanIComparable_ShouldThrow_WhenValueIsAboveUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var act = () => _ = value.RequiresLessThan(upperBound);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanExtensions_RequiresLessThanIComparable_ShouldThrow_WhenReferenceValueIsNotNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      T upperBound = default!;
      var act = () => _ = value.RequiresLessThan(upperBound);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanExtensions_RequiresLessThanIComparable_ShouldThrow_ReferenceValueIsNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T upperBound = default!;
      var act = () => _ = value.RequiresLessThan(upperBound);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void LessThanExtensions_RequiresLessThanIComparable_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var data = new Int32Data();
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var act = () => _ = value.RequiresLessThan(upperBound);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.LessThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
   }

   [Fact]
   public void LessThanExtensions_RequiresLessThanIComparable_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var data = new PointStructData();
      var value = data.MaxValue;
      var upperBound = data.MaxValue;
      var act = () => _ = value.RequiresLessThan(upperBound);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition LessThan failed: {nameof(value)} must be less than {upperBound}";

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(expectedParameterName);
      ex.Message.Should().StartWith(expectedMessage);
      ex.ActualValue.Should().Be(value);
   }

   [Fact]
   public void LessThanExtensions_RequiresLessThanIComparable_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new HalfData();
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresLessThan(upperBound, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement LessThan failed";

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(expectedParameterName);
      ex.Message.Should().StartWith(expectedMessage);
      ex.ActualValue.Should().Be(value);
   }

   [Fact]
   public void LessThanExtensions_RequiresLessThanIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new UInt128Data();
      var value = data.MaxValue;
      var upperBound = data.MinValue;
      var act = () => _ = value.RequiresLessThan(upperBound, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition LessThan failed: {nameof(value)} must be less than {upperBound}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void LessThanExtensions_RequiresLessThanIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "Abc";
      String upperBound = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresLessThan(upperBound, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement LessThan failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

   #region RequiresLessThan (IComparer) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanExtensions_RequiresLessThanIComparer_ShouldReturnOriginalValue_WhenValueIsBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMinValue;
      var upperBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.RequiresLessThan(upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanExtensions_RequiresLessThanIComparer_ShouldReturnOriginalValue_WhenReferenceValueIsNullAndUpperBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      var upperBound = data.ReverseMaxValue;
      var comparer = Comparer<T>.Default;

      // Act.
      var result = value.RequiresLessThan(upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanExtensions_RequiresLessThanIComparer_ShouldThrow_WhenValueIsEqualToUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresLessThan(upperBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void LessThanExtensions_RequiresLessThanIComparer_ShouldThrow_WhenValueIsAboveUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresLessThan(upperBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanExtensions_RequiresLessThanIComparer_ShouldThrow_WhenReferenceValueIsNotNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      T upperBound = default!;
      var comparer = Comparer<T>.Default;
      var act = () => _ = value.RequiresLessThan(upperBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanExtensions_RequiresLessThanIComparer_ShouldThrow_ReferenceValueIsNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T upperBound = default!;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresLessThan(upperBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void LessThanExtensions_RequiresLessThanIComparer_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var data = new DateTimeData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresLessThan(upperBound, comparer);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.LessThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
   }

   [Fact]
   public void LessThanExtensions_RequiresLessThanIComparer_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var data = new BoxRecordData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresLessThan(upperBound, comparer);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition LessThan failed: {nameof(value)} must be less than {upperBound}";

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(expectedParameterName);
      ex.Message.Should().StartWith(expectedMessage);
      ex.ActualValue.Should().Be(value);
   }

   [Fact]
   public void LessThanExtensions_RequiresLessThanIComparer_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new ByteData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresLessThan(upperBound, comparer, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement LessThan failed";

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(expectedParameterName);
      ex.Message.Should().StartWith(expectedMessage);
      ex.ActualValue.Should().Be(value);
   }

   [Fact]
   public void LessThanExtensions_RequiresLessThanIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new DoubleData();
      var value = data.ReverseMaxValue;
      var upperBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresLessThan(upperBound, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition LessThan failed: {nameof(value)} must be less than {upperBound}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void LessThanExtensions_RequiresLessThanIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = "abc";
      var upperBound = "ABC";
      var comparer = StringComparer.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresLessThan(upperBound, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement LessThan failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void LessThanExtensions_RequiresLessThanIComparer_ShouldThrowArgumentNullException_WhenComparerIsNull()
   {
      // Arrange.
      var data = new TimeOnlyData();
      var value = data.ReverseMinValue;
      var upperBound = data.ReverseMaxValue;
      IComparer<TimeOnly> comparer = null!;
      var act = () => _ = value.RequiresLessThan(upperBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(comparer))
         .And.Message.Should().StartWith(Messages.ComparerIsNull);
   }

   #endregion

   #region RequiresLessThan (String) Tests
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
   public void LessThanExtensions_RequiresLessThanString_ShouldReturnOriginalValue_WhenValueIsBelowUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresLessThan(upperBound, comparisonType);

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
   public void LessThanExtensions_RequiresLessThanString_ShouldReturnOriginalValue_WhenValueIsBelowUpperBoundAndCurrentCultureIs_trTR(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresLessThan(upperBound, comparisonType);

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
   public void LessThanExtensions_RequiresLessThanString_ShouldReturnOriginalValue_WhenValueIsBelowUpperBoundAndCurrentCultureIs_svSE(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresLessThan(upperBound, comparisonType);

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
   public void LessThanExtensions_RequiresLessThanString_ShouldThrow_WhenValueIsEqualToUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresLessThan(upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData(StringData.UpperCaseI, StringData.LowerCaseDotlessI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.LowerCaseDotlessI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseSlashedO, StringData.UpperCaseSlashedO, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseDotlessI, StringData.UpperCaseI, StringComparison.OrdinalIgnoreCase)]
   public void LessThanExtensions_RequiresLessThanString_ShouldThrow_WhenValueExceedsUpperBoundAndCurrentCultureIs_trTR(
      String value,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresLessThan(upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void LessThanExtensions_RequiresLessThanString_ShouldThrow_WhenValueIsNotDefaultAndUpperBoundIsDefaultAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = "asdf";
      String upperBound = default!;
      var act = () => _ = value.RequiresLessThan(upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [UseCulture(CultureData.SwedishSweden)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void LessThanExtensions_RequiresLessThanString_ShouldThrow_WhenValueIsNotDefaultAndUpperBoundIsDefaultAndCurrentCultureIs_svSE(
      StringComparison comparisonType)
   {
      // Arrange.
      var value = "asdf";
      String upperBound = default!;
      var act = () => _ = value.RequiresLessThan(upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void LessThanExtensions_RequiresLessThanString_ShouldThrow_WhenValueAndUpperBoundAreDefaultAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String upperBound = default!;
      var act = () => _ = value.RequiresLessThan(upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [UseCulture(CultureData.DanishDenmark)]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void LessThanExtensions_RequiresLessThanString_ShouldThrow_WhenValueAndUpperBoundAreDefaultAndCurrentCultureIs_daDK(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String upperBound = default!;
      var act = () => _ = value.RequiresLessThan(upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void LessThanExtensions_RequiresLessThanString_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = StringData.UpperCaseZ;
      var upperBound = StringData.UpperCaseA;
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.RequiresLessThan(upperBound, comparisonType);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_stringDataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.LessThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void LessThanExtensions_RequiresLessThanString_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = StringData.LowerCaseZ;
      var upperBound = StringData.LowerCaseA;
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var act = () => _ = value.RequiresLessThan(upperBound, comparisonType);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition LessThan failed: {nameof(value)} must be less than {upperBound}";

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(expectedParameterName);
      ex.Message.Should().StartWith(expectedMessage);
      ex.ActualValue.Should().Be(value);
   }

   [Fact]
   public void LessThanExtensions_RequiresLessThanString_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseJ;
      var upperBound = StringData.LowerCaseH;
      var comparisonType = StringComparison.InvariantCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresLessThan(upperBound, comparisonType, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement LessThan failed";

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(expectedParameterName);
      ex.Message.Should().StartWith(expectedMessage);
      ex.ActualValue.Should().Be(value);
   }

   [Fact]
   public void LessThanExtensions_RequiresLessThanString_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseJ;
      var upperBound = StringData.LowerCaseJ;
      var comparisonType = StringComparison.InvariantCultureIgnoreCase;
      var act = () => _ = value.RequiresLessThan(upperBound, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition LessThan failed: {nameof(value)} must be less than {upperBound}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Fact]
   public void LessThanExtensions_RequiresLessThanString_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseZ;
      var upperBound = StringData.UpperCaseA;
      var comparisonType = StringComparison.CurrentCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresLessThan(upperBound, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement LessThan failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion
}
