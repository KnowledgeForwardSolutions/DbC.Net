namespace DbC.Net.Tests.Unit;

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters

public class GreaterThanOrEqualToExtensionsTests
{
   private const Int32 _dataCount = 6;
   private const Int32 _stringDataCount = 7;

   #region EnsuresGreaterThanOrEqual (IComparable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldReturnOriginalValue_WhenValueIsGreaterThanLowerBound<T>(
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
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldThrow_WhenValueIsLessThanLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldThrow_WhenReferenceValueIsNullAndLowerBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldThrowWithExpectedDataDictionary_WhenValueIsNotGreaterThanOrEqualToLowerBound()
   {
      // Arrange.
      var data = new Int32Data();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThanOrEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsNotGreaterThanOrEqualToLowerBound()
   {
      // Arrange.
      var data = new PointStructData();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound);
      var expectedMessage = $"Postcondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new HalfData();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, messageTemplate);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new UInt128Data();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var lowerBound = "ABC";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

   #region EnsuresGreaterThanOrEqual (IComparer) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldReturnOriginalValue_WhenValueIsGreaterThanLowerBound<T>(
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
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldThrow_WhenValueIsLessThanLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldThrow_WhenReferenceValueIsNullAndLowerBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = data.ReverseMaxValue;
      var comparer = Comparer<T>.Default;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldThrowWithExpectedDataDictionary_WhenValueIsNotGreaterThanLowerBound()
   {
      // Arrange.
      var data = new DateTimeData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparer);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThanOrEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldThrowPostconditionFailedExceptionExceptionWithExpectedMessage_WhenValueIsNotGreaterThanLowerBound()
   {
      // Arrange.
      var data = new BoxRecordData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparer);
      var expectedMessage = $"Postcondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
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
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new DoubleData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_EnsuresGreaterThanOrEqualIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = "ABC";
      var lowerBound = "def";
      var comparer = StringComparer.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThanOrEqual(lowerBound, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
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

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(comparer))
         .And.Message.Should().StartWith(Messages.ComparerIsNull);
   }

   #endregion

   #region RequiresGreaterThanOrEqual (IComparable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldReturnOriginalValue_WhenValueIsGreaterThanLowerBound<T>(
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
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldThrow_WhenValueIsLessThanLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldThrow_WhenReferenceValueIsNullAndLowerBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldThrowWithExpectedDataDictionary_WhenValueIsNotGreaterThanOrEqualToLowerBound()
   {
      // Arrange.
      var data = new Int32Data();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThanOrEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenValueIsNotGreaterThanOrEqualToLowerBound()
   {
      // Arrange.
      var data = new PointStructData();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(expectedParameterName);
      ex.Message.Should().StartWith(expectedMessage);
      ex.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
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
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(expectedParameterName);
      ex.Message.Should().StartWith(expectedMessage);
      ex.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new UInt128Data();
      var value = data.MinValue;
      var lowerBound = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var lowerBound = "ABC";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

   #region RequiresGreaterThanOrEqual (IComparer) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldReturnOriginalValue_WhenValueIsGreaterThanLowerBound<T>(
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
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldThrow_WhenValueIsLessThanLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldThrow_WhenReferenceValueIsNullAndLowerBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = data.ReverseMaxValue;
      var comparer = Comparer<T>.Default;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldThrowWithExpectedDataDictionary_WhenValueIsNotGreaterThanLowerBound()
   {
      // Arrange.
      var data = new DateTimeData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparer);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThanOrEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenValueIsNotGreaterThanLowerBound()
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
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(expectedParameterName);
      ex.Message.Should().StartWith(expectedMessage);
      ex.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
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
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(expectedParameterName);
      ex.Message.Should().StartWith(expectedMessage);
      ex.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new DoubleData();
      var value = data.ReverseMinValue;
      var lowerBound = data.ReverseMaxValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition GreaterThanOrEqual failed: {nameof(value)} must be greater than or equal to {lowerBound}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualExtensions_RequiresGreaterThanOrEqualIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = "ABC";
      var lowerBound = "def";
      var comparer = StringComparer.OrdinalIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThanOrEqual(lowerBound, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThanOrEqual failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
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

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(comparer))
         .And.Message.Should().StartWith(Messages.ComparerIsNull);
   }

   #endregion
}
