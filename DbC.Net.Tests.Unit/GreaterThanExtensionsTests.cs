namespace DbC.Net.Tests.Unit;

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters

public class GreaterThanExtensionsTests
{
   private const Int32 _dataCount = 6;
   private const Int32 _stringDataCount = 7;

   #region EnsuresGreaterThan (IComparable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldReturnOriginalValue_WhenValueIsGreaterThanLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var lowerBound = data.MinValue;

      // Act.
      var result = value.EnsuresGreaterThan(lowerBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldReturnOriginalValue_WhenReferenceValueIsNotNullAndLowerBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      T lowerBound = default!;

      // Act.
      var result = value.EnsuresGreaterThan(lowerBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldThrow_WhenCValueIsEqualToLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldThrow_WhenValueIsLessThanLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldThrow_WhenReferenceValueIsNullAndLowerBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldThrow_ReferenceValueIsNullAndLowerBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = default!;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldThrowWithExpectedDataDictionary_WhenValueIsNotGreaterThanLowerBound()
   {
      // Arrange.
      var data = new Int32Data();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsNotGreaterThanLowerBound()
   {
      // Arrange.
      var data = new PointStructData();
      var value = data.MaxValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound);
      var expectedMessage = $"Postcondition GreaterThan failed: {nameof(value)} must be greater than {lowerBound}";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new HalfData();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, messageTemplate);
      var expectedMessage = $"Requirement GreaterThan failed";

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new UInt128Data();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition GreaterThan failed: {nameof(value)} must be greater than {lowerBound}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var lowerBound = "ABC";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThan failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

   #region EnsuresGreaterThan (IComparer) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldReturnOriginalValue_WhenValueIsGreaterThanLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var lowerBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.EnsuresGreaterThan(lowerBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldReturnOriginalValue_WhenReferenceValueIsNotNullAndLowerBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      T lowerBound = default!;
      var comparer = Comparer<T>.Default;

      // Act.
      var result = value.EnsuresGreaterThan(lowerBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrow_WhenValueIsEqualToLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrow_WhenValueIsLessThanLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrow_WhenReferenceValueIsNullAndLowerBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = data.ReverseMaxValue;
      var comparer = Comparer<T>.Default;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrow_ReferenceValueIsNullAndLowerBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = default!;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrowWithExpectedDataDictionary_WhenValueIsNotGreaterThanLowerBound()
   {
      // Arrange.
      var data = new DateTimeData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparer);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsNotGreaterThanLowerBound()
   {
      // Arrange.
      var data = new BoxRecordData();
      var value = data.MaxValue;
      var lowerBound = data.MaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparer);
      var expectedMessage = $"Postcondition GreaterThan failed: {nameof(value)} must be greater than {lowerBound}";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().Be(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new ByteData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparer, messageTemplate);
      var expectedMessage = $"Requirement GreaterThan failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().Be(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new DoubleData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition GreaterThan failed: {nameof(value)} must be greater than {lowerBound}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = "ABC";
      var lowerBound = "abc";
      var comparer = StringComparer.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThan failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrowArgumentNullException_WhenComparerIsNull()
   {
      // Arrange.
      var data = new TimeOnlyData();
      var value = data.ReverseMaxValue;
      var lowerBound = data.ReverseMinValue;
      IComparer<TimeOnly> comparer = null!;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(comparer))
         .And.Message.Should().StartWith(Messages.ComparerIsNull);
   }

   #endregion

   #region EnsuresGreaterThan (String) Tests
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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldReturnOriginalValue_WhenValueIsGreaterThanLowerBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresGreaterThan(lowerBound, comparisonType);

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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldReturnOriginalValue_WhenValueIsGreaterThanLowerBoundAndCurrentCultureIs_trTR(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresGreaterThan(lowerBound, comparisonType);

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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldReturnOriginalValue_WhenValueIsGreaterThanLowerBoundAndCurrentCultureIs_svSE(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresGreaterThan(lowerBound, comparisonType);

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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrow_WhenValueIsEqualToLowerBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData(StringData.LowerCaseDotlessI, StringData.UpperCaseI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseDotlessI, StringData.LowerCaseI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseSlashedO, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseI, StringData.LowerCaseDotlessI, StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrow_WhenValueIsLessThanLowerBoundAndCurrentCultureIs_trTR(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparisonType);

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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrow_WhenValueIsDefaultAndLowerBoundIsNotAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      var lowerBound = "asdf";
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparisonType);

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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrow_WhenValueIsDefaultAndLowerBoundIsNotAndCurrentCultureIs_svSE(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      var lowerBound = "asdf";
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparisonType);

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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrow_WhenValueAndLowerBoundAreDefaultAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String lowerBound = default!;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparisonType);

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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrow_WhenValueAndLowerBoundAreDefaultAndCurrentCultureIs_daDK(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String lowerBound = default!;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrowWithExpectedDataDictionary_WhenValueIsLessThanLowerBound()
   {
      // Arrange.
      var value = StringData.UpperCaseA;
      var lowerBound = StringData.UpperCaseZ;
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparisonType);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_stringDataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsLessThanLowerBound()
   {
      // Arrange.
      var value = StringData.LowerCaseA;
      var lowerBound = StringData.LowerCaseZ;
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparisonType);
      var expectedMessage = $"Postcondition GreaterThan failed: {nameof(value)} must be greater than {lowerBound}";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseH;
      var lowerBound = StringData.LowerCaseJ;
      var comparisonType = StringComparison.InvariantCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparisonType, messageTemplate);
      var expectedMessage = $"Requirement GreaterThan failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseJ;
      var lowerBound = StringData.LowerCaseJ;
      var comparisonType = StringComparison.InvariantCultureIgnoreCase;
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition GreaterThan failed: {nameof(value)} must be greater than {lowerBound}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseA;
      var lowerBound = StringData.UpperCaseZ;
      var comparisonType = StringComparison.CurrentCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThan(lowerBound, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThan failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

   #region RequiresGreaterThan (IComparable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldReturnOriginalValue_WhenValueIsGreaterThanLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var lowerBound = data.MinValue;

      // Act.
      var result = value.RequiresGreaterThan(lowerBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldReturnOriginalValue_WhenReferenceValueIsNotNullAndLowerBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      T lowerBound = default!;

      // Act.
      var result = value.RequiresGreaterThan(lowerBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrow_WhenValueIsEqualToLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThan(lowerBound);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrow_WhenValueIsLessThanLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThan(lowerBound);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrow_WhenReferenceValueIsNullAndLowerBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThan(lowerBound);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrow_ReferenceValueIsNullAndLowerBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = default!;
      var act = () => _ = value.RequiresGreaterThan(lowerBound);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrowWithExpectedDataDictionary_WhenValueIsNotGreaterThanLowerBound()
   {
      // Arrange.
      var data = new Int32Data();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThan(lowerBound);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenValueIsNotGreaterThanLowerBound()
   {
      // Arrange.
      var data = new PointStructData();
      var value = data.MaxValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThan(lowerBound);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition GreaterThan failed: {nameof(value)} must be greater than {lowerBound}";

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(expectedParameterName);
      ex.Message.Should().StartWith(expectedMessage);
      ex.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new HalfData();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThan(lowerBound, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement GreaterThan failed";

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(expectedParameterName);
      ex.Message.Should().StartWith(expectedMessage);
      ex.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new UInt128Data();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThan(lowerBound, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition GreaterThan failed: {nameof(value)} must be greater than {lowerBound}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var lowerBound = "ABC";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThan(lowerBound, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThan failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

   #region RequiresGreaterThan (IComparer) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldReturnOriginalValue_WhenValueIsGreaterThanLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var lowerBound = data.ReverseMinValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.RequiresGreaterThan(lowerBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldReturnOriginalValue_WhenReferenceValueIsNotNullAndLowerBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      T lowerBound = default!;
      var comparer = Comparer<T>.Default;

      // Act.
      var result = value.RequiresGreaterThan(lowerBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrow_WhenValueIsEqualToLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrow_WhenValueIsLessThanLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrow_WhenReferenceValueIsNullAndLowerBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = data.ReverseMaxValue;
      var comparer = Comparer<T>.Default;
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrow_ReferenceValueIsNullAndLowerBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = default!;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrowWithExpectedDataDictionary_WhenValueIsNotGreaterThanLowerBound()
   {
      // Arrange.
      var data = new DateTimeData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparer);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenValueIsNotGreaterThanLowerBound()
   {
      // Arrange.
      var data = new BoxRecordData();
      var value = data.MaxValue;
      var lowerBound = data.MaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparer);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition GreaterThan failed: {nameof(value)} must be greater than {lowerBound}";

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(expectedParameterName);
      ex.Message.Should().StartWith(expectedMessage);
      ex.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new ByteData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparer, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement GreaterThan failed";

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(expectedParameterName);
      ex.Message.Should().StartWith(expectedMessage);
      ex.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new DoubleData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition GreaterThan failed: {nameof(value)} must be greater than {lowerBound}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = "ABC";
      var lowerBound = "abc";
      var comparer = StringComparer.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThan failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrowArgumentNullException_WhenComparerIsNull()
   {
      // Arrange.
      var data = new TimeOnlyData();
      var value = data.ReverseMaxValue;
      var lowerBound = data.ReverseMinValue;
      IComparer<TimeOnly> comparer = null!;
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(comparer))
         .And.Message.Should().StartWith(Messages.ComparerIsNull);
   }

   #endregion

   #region RequiresGreaterThan (String) Tests
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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldReturnOriginalValue_WhenValueIsGreaterThanLowerBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresGreaterThan(lowerBound, comparisonType);

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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldReturnOriginalValue_WhenValueIsGreaterThanLowerBoundAndCurrentCultureIs_trTR(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresGreaterThan(lowerBound, comparisonType);

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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldReturnOriginalValue_WhenValueIsGreaterThanLowerBoundAndCurrentCultureIs_svSE(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresGreaterThan(lowerBound, comparisonType);

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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrow_WhenValueIsEqualToLowerBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData(StringData.LowerCaseDotlessI, StringData.UpperCaseI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseDotlessI, StringData.LowerCaseI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseSlashedO, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseI, StringData.LowerCaseDotlessI, StringComparison.OrdinalIgnoreCase)]
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrow_WhenValueIsLessThanLowerBoundAndCurrentCultureIs_trTR(
      String value,
      String lowerBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparisonType);

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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrow_WhenValueIsDefaultAndLowerBoundIsNotAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      var lowerBound = "asdf";
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparisonType);

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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrow_WhenValueIsDefaultAndLowerBoundIsNotAndCurrentCultureIs_svSE(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      var lowerBound = "asdf";
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparisonType);

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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrow_WhenValueAndLowerBoundAreDefaultAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String lowerBound = default!;
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparisonType);

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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrow_WhenValueAndLowerBoundAreDefaultAndCurrentCultureIs_daDK(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String lowerBound = default!;
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrowWithExpectedDataDictionary_WhenValueIsLessThanLowerBound()
   {
      // Arrange.
      var value = StringData.UpperCaseA;
      var lowerBound = StringData.UpperCaseZ;
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparisonType);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_stringDataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenValueIsLessThanLowerBound()
   {
      // Arrange.
      var value = StringData.LowerCaseA;
      var lowerBound = StringData.LowerCaseZ;
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparisonType);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition GreaterThan failed: {nameof(value)} must be greater than {lowerBound}";

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseH;
      var lowerBound = StringData.LowerCaseJ;
      var comparisonType = StringComparison.InvariantCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparisonType, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement GreaterThan failed";

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseJ;
      var lowerBound = StringData.LowerCaseJ;
      var comparisonType = StringComparison.InvariantCultureIgnoreCase;
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition GreaterThan failed: {nameof(value)} must be greater than {lowerBound}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseA;
      var lowerBound = StringData.UpperCaseZ;
      var comparisonType = StringComparison.CurrentCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThan(lowerBound, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThan failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion
}
