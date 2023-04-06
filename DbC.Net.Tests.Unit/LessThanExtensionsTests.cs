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
}
