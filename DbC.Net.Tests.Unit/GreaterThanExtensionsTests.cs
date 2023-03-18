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
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldReturnOriginalValue_WhenValueIsGreaterThanTarget<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var target = data.MinValue;

      // Act.
      var result = value.EnsuresGreaterThan(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldReturnOriginalValue_WhenReferenceValueIsNotNullAndTargetIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      T target = default!;

      // Act.
      var result = value.EnsuresGreaterThan(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldThrow_WhenCValueIsEqualToTarget<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var target = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThan(target);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldThrow_WhenValueIsLessThanTarget<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MinValue;
      var target = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThan(target);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldThrow_WhenReferenceValueIsNullAndTargetIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T target = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThan(target);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldThrow_ReferenceValueIsNullAndTargetIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T target = default!;
      var act = () => _ = value.EnsuresGreaterThan(target);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldThrowWithExpectedDataDictionary_WhenValueIsNotGreaterThanTarget()
   {
      // Arrange.
      var data = new Int32Data();
      var value = data.MinValue;
      var target = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThan(target);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsNotGreaterThanTarget()
   {
      // Arrange.
      var data = new PointStructData();
      var value = data.MaxValue;
      var target = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThan(target);
      var expectedMessage = $"Postcondition GreaterThan failed: {nameof(value)} must be greater than {target}";

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
      var target = data.MaxValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThan(target, messageTemplate);
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
      var target = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThan(target, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition GreaterThan failed: {nameof(value)} must be greater than {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var target = "ABC";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThan(target, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
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
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldReturnOriginalValue_WhenValueIsGreaterThanTarget<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var target = data.ReverseMinValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.EnsuresGreaterThan(target, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldReturnOriginalValue_WhenReferenceValueIsNotNullAndTargetIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      T target = default!;
      var comparer = Comparer<T>.Default;

      // Act.
      var result = value.EnsuresGreaterThan(target, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrow_WhenValueIsEqualToTarget<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var target = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThan(target, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrow_WhenValueIsLessThanTarget<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMinValue;
      var target = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThan(target, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrow_WhenReferenceValueIsNullAndTargetIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T target = data.ReverseMaxValue;
      var comparer = Comparer<T>.Default;
      var act = () => _ = value.EnsuresGreaterThan(target, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrow_ReferenceValueIsNullAndTargetIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T target = default!;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThan(target, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrowWithExpectedDataDictionary_WhenValueIsNotGreaterThanTarget()
   {
      // Arrange.
      var data = new DateTimeData();
      var value = data.ReverseMinValue;
      var target = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThan(target, comparer);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsNotGreaterThanTarget()
   {
      // Arrange.
      var data = new BoxRecordData();
      var value = data.MaxValue;
      var target = data.MaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThan(target, comparer);
      var expectedMessage = $"Postcondition GreaterThan failed: {nameof(value)} must be greater than {target}";

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
      var target = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThan(target, comparer, messageTemplate);
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
      var target = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThan(target, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition GreaterThan failed: {nameof(value)} must be greater than {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = "ABC";
      var target = "abc";
      var comparer = StringComparer.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThan(target, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
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
      var target = data.ReverseMinValue;
      IComparer<TimeOnly> comparer = null!;
      var act = () => _ = value.EnsuresGreaterThan(target, comparer);

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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldReturnOriginalValue_WhenValueIsGreaterThanTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresGreaterThan(target, comparisonType);

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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldReturnOriginalValue_WhenValueIsGreaterThanTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresGreaterThan(target, comparisonType);

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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldReturnOriginalValue_WhenValueIsGreaterThanTargetAndCurrentCultureIs_svSE(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresGreaterThan(target, comparisonType);

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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrow_WhenValueIsEqualToTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresGreaterThan(target, comparisonType);

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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrow_WhenValueIsLessThanTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresGreaterThan(target, comparisonType);

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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrow_WhenValueIsDefaultAndTargetIsNotAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      var target = "asdf";
      var act = () => _ = value.EnsuresGreaterThan(target, comparisonType);

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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrow_WhenValueIsDefaultAndTargetIsNotAndCurrentCultureIs_svSE(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      var target = "asdf";
      var act = () => _ = value.EnsuresGreaterThan(target, comparisonType);

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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrow_WhenValueAndTargetAreDefaultAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String target = default!;
      var act = () => _ = value.EnsuresGreaterThan(target, comparisonType);

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
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrow_WhenValueAndTargetAreDefaultAndCurrentCultureIs_daDK(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String target = default!;
      var act = () => _ = value.EnsuresGreaterThan(target, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrowWithExpectedDataDictionary_WhenValueIsLessThanTarget()
   {
      // Arrange.
      var value = StringData.UpperCaseA;
      var target = StringData.UpperCaseZ;
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.EnsuresGreaterThan(target, comparisonType);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_stringDataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsLessThanTarget()
   {
      // Arrange.
      var value = StringData.LowerCaseA;
      var target = StringData.LowerCaseZ;
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var act = () => _ = value.EnsuresGreaterThan(target, comparisonType);
      var expectedMessage = $"Postcondition GreaterThan failed: {nameof(value)} must be greater than {target}";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThanString_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseH;
      var target = StringData.LowerCaseJ;
      var comparisonType = StringComparison.InvariantCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThan(target, comparisonType, messageTemplate);
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
      var target = StringData.LowerCaseJ;
      var comparisonType = StringComparison.InvariantCultureIgnoreCase;
      var act = () => _ = value.EnsuresGreaterThan(target, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition GreaterThan failed: {nameof(value)} must be greater than {target}";

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
      var target = StringData.UpperCaseZ;
      var comparisonType = StringComparison.CurrentCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThan(target, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
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
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldReturnOriginalValue_WhenValueIsGreaterThanTarget<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var target = data.MinValue;

      // Act.
      var result = value.RequiresGreaterThan(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldReturnOriginalValue_WhenReferenceValueIsNotNullAndTargetIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      T target = default!;

      // Act.
      var result = value.RequiresGreaterThan(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrow_WhenValueIsEqualToTarget<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var target = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThan(target);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrow_WhenValueIsLessThanTarget<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MinValue;
      var target = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThan(target);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrow_WhenReferenceValueIsNullAndTargetIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T target = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThan(target);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrow_ReferenceValueIsNullAndTargetIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T target = default!;
      var act = () => _ = value.RequiresGreaterThan(target);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrowWithExpectedDataDictionary_WhenValueIsNotGreaterThanTarget()
   {
      // Arrange.
      var data = new Int32Data();
      var value = data.MinValue;
      var target = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThan(target);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenValueIsNotGreaterThanTarget()
   {
      // Arrange.
      var data = new PointStructData();
      var value = data.MaxValue;
      var target = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThan(target);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition GreaterThan failed: {nameof(value)} must be greater than {target}";

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
      var target = data.MaxValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThan(target, messageTemplate);
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
      var target = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThan(target, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition GreaterThan failed: {nameof(value)} must be greater than {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var target = "ABC";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThan(target, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
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
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldReturnOriginalValue_WhenValueIsGreaterThanTarget<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var target = data.ReverseMinValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.RequiresGreaterThan(target, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldReturnOriginalValue_WhenReferenceValueIsNotNullAndTargetIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      T target = default!;
      var comparer = Comparer<T>.Default;

      // Act.
      var result = value.RequiresGreaterThan(target, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrow_WhenValueIsEqualToTarget<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMaxValue;
      var target = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThan(target, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrow_WhenValueIsLessThanTarget<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMinValue;
      var target = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThan(target, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrow_WhenReferenceValueIsNullAndTargetIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T target = data.ReverseMaxValue;
      var comparer = Comparer<T>.Default;
      var act = () => _ = value.RequiresGreaterThan(target, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrow_ReferenceValueIsNullAndTargetIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T target = default!;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThan(target, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrowWithExpectedDataDictionary_WhenValueIsNotGreaterThanTarget()
   {
      // Arrange.
      var data = new DateTimeData();
      var value = data.ReverseMinValue;
      var target = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThan(target, comparer);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenValueIsNotGreaterThanTarget()
   {
      // Arrange.
      var data = new BoxRecordData();
      var value = data.MaxValue;
      var target = data.MaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThan(target, comparer);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition GreaterThan failed: {nameof(value)} must be greater than {target}";

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
      var target = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThan(target, comparer, messageTemplate);
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
      var target = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThan(target, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition GreaterThan failed: {nameof(value)} must be greater than {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = "ABC";
      var target = "abc";
      var comparer = StringComparer.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThan(target, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
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
      var target = data.ReverseMinValue;
      IComparer<TimeOnly> comparer = null!;
      var act = () => _ = value.RequiresGreaterThan(target, comparer);

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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldReturnOriginalValue_WhenValueIsGreaterThanTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresGreaterThan(target, comparisonType);

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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldReturnOriginalValue_WhenValueIsGreaterThanTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresGreaterThan(target, comparisonType);

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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldReturnOriginalValue_WhenValueIsGreaterThanTargetAndCurrentCultureIs_svSE(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresGreaterThan(target, comparisonType);

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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrow_WhenValueIsEqualToTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresGreaterThan(target, comparisonType);

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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrow_WhenValueIsLessThanTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresGreaterThan(target, comparisonType);

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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrow_WhenValueIsDefaultAndTargetIsNotAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      var target = "asdf";
      var act = () => _ = value.RequiresGreaterThan(target, comparisonType);

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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrow_WhenValueIsDefaultAndTargetIsNotAndCurrentCultureIs_svSE(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      var target = "asdf";
      var act = () => _ = value.RequiresGreaterThan(target, comparisonType);

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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrow_WhenValueAndTargetAreDefaultAndCurrentCultureIs_enUS(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String target = default!;
      var act = () => _ = value.RequiresGreaterThan(target, comparisonType);

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
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrow_WhenValueAndTargetAreDefaultAndCurrentCultureIs_daDK(
      StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String target = default!;
      var act = () => _ = value.RequiresGreaterThan(target, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrowWithExpectedDataDictionary_WhenValueIsLessThanTarget()
   {
      // Arrange.
      var value = StringData.UpperCaseA;
      var target = StringData.UpperCaseZ;
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.RequiresGreaterThan(target, comparisonType);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_stringDataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThan);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThanString_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenValueIsLessThanTarget()
   {
      // Arrange.
      var value = StringData.LowerCaseA;
      var target = StringData.LowerCaseZ;
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var act = () => _ = value.RequiresGreaterThan(target, comparisonType);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition GreaterThan failed: {nameof(value)} must be greater than {target}";

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
      var target = StringData.LowerCaseJ;
      var comparisonType = StringComparison.InvariantCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThan(target, comparisonType, messageTemplate);
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
      var target = StringData.LowerCaseJ;
      var comparisonType = StringComparison.InvariantCultureIgnoreCase;
      var act = () => _ = value.RequiresGreaterThan(target, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition GreaterThan failed: {nameof(value)} must be greater than {target}";

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
      var target = StringData.UpperCaseZ;
      var comparisonType = StringComparison.CurrentCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThan(target, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThan failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion
}
