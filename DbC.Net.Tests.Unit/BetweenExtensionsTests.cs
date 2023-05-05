namespace DbC.Net.Tests.Unit;

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters

public class BetweenExtensionsTests
{
   private const Int32 _dataCount = 8;
   private const Int32 _stringDataCount = 9;

   #region EnsuresBetween (IComparable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.WithinBoundsValue;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;

      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBoundAndBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.LowerBound;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;

      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndEqualToUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.UpperBound;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;

      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBoundAndUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.WithinBoundsValue;
      var lowerBound = data.WithinBoundsValue;
      var upperBound = data.WithinBoundsValue;

      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndReferenceTypeValueIsNotNullAndBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.WithinBoundsValue;
      T lowerBound = default!;
      var upperBound = data.UpperBound;

      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndReferenceTypeValueIsNotNullAndEqualToUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.UpperBound;
      T lowerBound = default!;
      var upperBound = data.UpperBound;

      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndReferenceTypeValueIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = default!;
      var upperBound = data.UpperBound;

      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldReturnOriginalValue_WhenReferenceTypeValueIsNullAndLowerAndUpperBoundsAreNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = default!;
      T upperBound = default!;

      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldThrow_WhenValueIsBelowLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.BelowLowerBoundValue;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldThrow_WhenValueIsAboveUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.AboveUpperBoundValue;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldThrow_WhenReferenceTypeValueIsNullAndLowerAndUpperBoundsAreNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var data = new Int32Data();
      var value = data.BelowLowerBoundValue;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.Between);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
   }

   [Fact]
   public void BetweenExtensions_EnsuresBetweenThanIComparable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var data = new PointStructData();
      var value = data.AboveUpperBoundValue;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound);
      var expectedMessage = $"Postcondition Between failed: {nameof(value)} must be between {lowerBound} and {upperBound} (inclusive)";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new HalfData();
      var value = data.AboveUpperBoundValue;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, messageTemplate);
      var expectedMessage = $"Requirement Between failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new UInt128Data();
      var value = data.AboveUpperBoundValue;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition Between failed: {nameof(value)} must be between {lowerBound} and {upperBound} (inclusive)";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var lowerBound = "ABC";
      var upperBound = "xyz";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement Between failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldNotThrow_WhenBoundsAreNormalizedAndValueIsInRange<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.WithinBoundsValue;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldNotThrow_WhenBoundsAreEqualAndValueIsInRange<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.WithinBoundsValue;
      var lowerBound = data.WithinBoundsValue;
      var upperBound = data.WithinBoundsValue;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldNotThrow_WhenReferenceTypeLowerBoundIsNullAndUpperBoundIsNotAndValueIsInRange<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.WithinBoundsValue;
      T lowerBound = default!;
      var upperBound = data.UpperBound;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldNotThrow_WhenReferenceTypeBoundsAreNullAndValueIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = default!;
      T upperBound = default!;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldThrowInvalidOperationException_WhenLowerBoundIsGreaterThanUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.WithinBoundsValue;
      var lowerBound = data.UpperBound;
      var upperBound = data.LowerBound;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound);
      var expectedMessage = Messages.BetweenBoundsNotNormalized;

      // Act/assert.
      act.Should().Throw<InvalidOperationException>()
         .WithMessage(expectedMessage);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldThrowInvalidOperationException_WhenReferenceTypeLowerBoundIsNotNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.WithinBoundsValue;
      var lowerBound = data.LowerBound;
      T upperBound = default!;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound);
      var expectedMessage = Messages.BetweenBoundsNotNormalized;

      // Act/assert.
      act.Should().Throw<InvalidOperationException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region EnsuresBetween (IComparer) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var value = data.WithinBoundsValue;

      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBoundAndBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var value = lowerBound;

      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndEqualToUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var value = upperBound;

      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBoundAndUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var lowerBound = data.WithinBoundsValue;
      var upperBound = data.WithinBoundsValue;
      var value = data.WithinBoundsValue;

      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndReferenceTypeValueIsNotNullAndBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(default!, data.UpperBound);
      var value = data.WithinBoundsValue;

      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndReferenceTypeValueIsNotNullAndEqualToUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(default!, data.UpperBound);
      var value = upperBound;

      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndReferenceTypeValueIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(default!, data.UpperBound);
      var value = lowerBound;

      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldReturnOriginalValue_WhenReferenceTypeValueIsNullAndLowerAndUpperBoundsAreNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      T lowerBound = default!;
      T upperBound = default!;
      T value = default!;

      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldThrow_WhenValueIsBelowLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var (value, _) = comparer.ReverseValues(data.BelowLowerBoundValue, data.AboveUpperBoundValue);
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldThrow_WhenValueIsAboveUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var (_, value) = comparer.ReverseValues(data.BelowLowerBoundValue, data.AboveUpperBoundValue);
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldThrow_WhenReferenceTypeValueIsNullAndLowerAndUpperBoundsAreNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      T value = default!;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var data = new Int32Data();
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var (value, _) = comparer.ReverseValues(data.BelowLowerBoundValue, data.AboveUpperBoundValue);
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparer);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.Between);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
   }

   [Fact]
   public void BetweenExtensions_EnsuresBetweenThanIComparer_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var data = new PointStructData();
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var (_, value) = comparer.ReverseValues(data.BelowLowerBoundValue, data.AboveUpperBoundValue);
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparer);
      var expectedMessage = $"Postcondition Between failed: {nameof(value)} must be between {lowerBound} and {upperBound} (inclusive)";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new HalfData();
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var (value, _) = comparer.ReverseValues(data.BelowLowerBoundValue, data.AboveUpperBoundValue);
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparer, messageTemplate);
      var expectedMessage = $"Requirement Between failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new UInt128Data();
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var (_, value) = comparer.ReverseValues(data.BelowLowerBoundValue, data.AboveUpperBoundValue);
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition Between failed: {nameof(value)} must be between {lowerBound} and {upperBound} (inclusive)";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new StringData();
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement Between failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldNotThrow_WhenBoundsAreNormalizedAndValueIsInRange<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var value = data.WithinBoundsValue;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparer);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldNotThrow_WhenBoundsAreEqualAndValueIsInRange<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var lowerBound = data.WithinBoundsValue;
      var upperBound = data.WithinBoundsValue;
      var value = data.WithinBoundsValue;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparer);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldNotThrow_WhenReferenceTypeLowerBoundIsNullAndUpperBoundIsNotAndValueIsInRange<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(default!, data.UpperBound);
      var value = data.WithinBoundsValue;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparer);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldNotThrow_WhenReferenceTypeBoundsAreNullAndValueIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      T lowerBound = default!;
      T upperBound = default!;
      T value = default!;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparer);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldThrowInvalidOperationException_WhenLowerBoundIsGreaterThanUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.UpperBound, data.LowerBound);
      var value = data.WithinBoundsValue;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparer);
      var expectedMessage = Messages.BetweenBoundsNotNormalized;

      // Act/assert.
      act.Should().Throw<InvalidOperationException>()
         .WithMessage(expectedMessage);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparer_ShouldThrowInvalidOperationException_WhenReferenceTypeLowerBoundIsNotNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, default!);
      var value = data.WithinBoundsValue;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparer);
      var expectedMessage = Messages.BetweenBoundsNotNormalized;

      // Act/assert.
      act.Should().Throw<InvalidOperationException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region EnsuresBetween (String) Tests
   // ==========================================================================
   // ==========================================================================

   // For ordinal comparison, caret(^) sorts between uppercase Z and lowercase A
   // For ordinal ignore case comparison, caret(^) sorts above Z
   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseA, StringData.LowerCaseZ, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseO, StringData.LowerCaseP, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusSlashCombiningCharacter, StringData.UpperCaseO, StringData.UpperCaseP, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.UpperCaseZ, StringData.LowerCaseA, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseAE, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndBelowUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   // Azerbaijani Latin alphabet sorts H, X, I(dotless), I(dotted), J, ...
   [UseCulture(CultureData.LatinAzerbaijan)]
   [Theory]
   [InlineData(StringData.LowerCaseX, StringData.UpperCaseH, StringData.UpperCaseI, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseX, StringData.LowerCaseH, StringData.LowerCaseDotlessI, StringComparison.CurrentCultureIgnoreCase)] // I without dot sorts before I with dot in tr-TR culture
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseO, StringData.LowerCaseP, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusSlashCombiningCharacter, StringData.UpperCaseO, StringData.UpperCaseP, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.UpperCaseZ, StringData.LowerCaseA, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseAE, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndBelowUpperBoundAndCurrentCultureIs_azLatnAZ(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   // sv-SE culture (Swedish/Sweden) sorts Z, A(overring), A(diaeresis), O(diaeresis)
   [UseCulture(CultureData.SwedishSweden)]
   [Theory]
   [InlineData(StringData.LowerCaseAWithOverring, StringData.LowerCaseZ, StringData.UpperCaseOWithDiaeresis, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseAWithOverring, StringData.UpperCaseZ, StringData.LowerCaseOWithDiaeresis, StringComparison.CurrentCultureIgnoreCase)] // I without dot sorts before I with dot in tr-TR culture
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseO, StringData.LowerCaseP, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusSlashCombiningCharacter, StringData.UpperCaseO, StringData.UpperCaseP, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.UpperCaseAE, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseAE, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndBelowUpperBoundAndCurrentCultureIs_svSE(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.UpperCaseA, StringData.UpperCaseA, StringData.LowerCaseZ, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseA, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseAPlusDiaeresisCombiningCharacter, StringData.UpperCaseAWithDiaeresis, StringData.LowerCaseZ, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseAWithDiaeresis, StringData.UpperCaseAWithDiaeresis, StringData.UpperCaseZ, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.Caret, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseA, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBoundAndBelowUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   // da-DK culture (Danish/Denmark) sorts Z, AE(diphthong), O(slashed), A(overring)
   [UseCulture(CultureData.DanishDenmark)]
   [Theory]
   [InlineData(StringData.UpperCaseDiphthongAE, StringData.UpperCaseDiphthongAE, StringData.LowerCaseAWithOverring, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseDiphthongAE, StringData.UpperCaseDiphthongAE, StringData.LowerCaseAWithOverring, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseOPlusSlashCombiningCharacter, StringData.UpperCaseSlashedO, StringData.LowerCaseZ, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseSlashedO, StringData.UpperCaseOPlusSlashCombiningCharacter, StringData.UpperCaseZ, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.Caret, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseA, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBoundAndBelowUpperBoundAndCurrentCultureIs_daDK(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseA, StringData.LowerCaseZ, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseZ, StringData.UpperCaseA, StringData.LowerCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseA, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOWithDiaeresis, StringData.UpperCaseA, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseZ, StringData.Caret, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndEqualToUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   // sv-SE culture (Swedish/Sweden) sorts Z, A(overring), A(diaeresis), O(diaeresis)
   [UseCulture(CultureData.SwedishSweden)]
   [Theory]
   [InlineData(StringData.LowerCaseAPlusOverringCombiningCharacter, StringData.UpperCaseZ, StringData.UpperCaseOWithDiaeresis, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseOWithDiaeresis, StringData.LowerCaseZ, StringData.LowerCaseOWithDiaeresis, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseA, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOWithDiaeresis, StringData.UpperCaseA, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseZ, StringData.Caret, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndEqualToUpperBoundAndCurrentCultureIs_svSE(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.UpperCaseH, StringData.UpperCaseH, StringData.UpperCaseH, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseH, StringData.UpperCaseH, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.Caret, StringData.Caret, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseH, StringData.UpperCaseH, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldReturnOriginalValue_WhenValueEqualToLowerBoundAndToUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData(StringData.UpperCaseDottedI, StringData.UpperCaseDottedI, StringData.UpperCaseDottedI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringData.UpperCaseDottedI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.Caret, StringData.Caret, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseH, StringData.UpperCaseH, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldReturnOriginalValue_WhenValueEqualToLowerBoundAndToUpperBoundAndCurrentCultureIs_trTR(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [InlineData(StringData.UpperCaseAE, null, StringData.LowerCaseZ, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseAE, null, StringData.UpperCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseSlashedO, null, StringData.LowerCaseP, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusSlashCombiningCharacter, null, StringData.UpperCaseP, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, null, StringData.LowerCaseA, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, null, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndValueIsNotNullAndBelowUpperBound(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [InlineData(StringData.UpperCaseH, null, StringData.UpperCaseH, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseH, null, StringData.UpperCaseH, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseOPlusDiaeresisCombiningCharacter, null, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, null, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, null, StringData.Caret, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, null, StringData.UpperCaseH, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndValueIsNotNullAndEqualToUpperBound(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [InlineData(null, null, StringData.UpperCaseH, StringComparison.CurrentCulture)]
   [InlineData(null, null, StringData.UpperCaseH, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(null, null, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(null, null, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(null, null, StringData.Caret, StringComparison.Ordinal)]
   [InlineData(null, null, StringData.UpperCaseH, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndValueIsNull(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [InlineData(null, null, null, StringComparison.CurrentCulture)]
   [InlineData(null, null, null, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(null, null, null, StringComparison.InvariantCulture)]
   [InlineData(null, null, null, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(null, null, null, StringComparison.Ordinal)]
   [InlineData(null, null, null, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldReturnOriginalValue_WhenValueIsNullAndLowerAndUpperBoundsAreNull(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseH, StringData.UpperCaseZ, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseH, StringData.LowerCaseI, StringData.LowerCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseZ, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseP, StringData.LowerCaseZ, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.LowerCaseA, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseA, StringData.LowerCaseX, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldThrow_WhenValueIsBelowLowerBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   // Azerbaijani Latin alphabet sorts H, X, I(dotless), I(dotted), J, ...
   [UseCulture(CultureData.LatinAzerbaijan)]
   [Theory]
   [InlineData(StringData.LowerCaseX, StringData.UpperCaseX, StringData.UpperCaseJ, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseX, StringData.LowerCaseDotlessI, StringData.LowerCaseJ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseZ, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseP, StringData.LowerCaseZ, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.LowerCaseA, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseA, StringData.LowerCaseX, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldThrow_WhenValueIsBelowLowerBoundAndCurrentCultureIs_azLatnAZ(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.LowerCaseP, StringData.UpperCaseA, StringData.UpperCaseO, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseP, StringData.LowerCaseA, StringData.LowerCaseO, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseA, StringData.UpperCaseO, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseA, StringData.LowerCaseO, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseZ, StringData.LowerCaseA, StringData.LowerCaseH, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldThrow_WhenValueIsAboveUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   // da-DK culture (Danish/Denmark) sorts Z, AE(diphthong), O(slashed), A(overring)
   [UseCulture(CultureData.DanishDenmark)]
   [Theory]
   [InlineData(StringData.LowerCaseSlashedO, StringData.UpperCaseA, StringData.UpperCaseDiphthongAE, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseDiphthongAE, StringData.LowerCaseA, StringData.LowerCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseA, StringData.UpperCaseO, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseA, StringData.LowerCaseO, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseZ, StringData.LowerCaseA, StringData.LowerCaseH, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldThrow_WhenValueIsAboveUpperBoundAndCurrentCultureIs_daDK(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }
   [Theory]
   [InlineData(null, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.CurrentCulture)]
   [InlineData(null, StringData.LowerCaseA, StringData.LowerCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(null, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.InvariantCulture)]
   [InlineData(null, StringData.LowerCaseA, StringData.LowerCaseZ, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(null, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.Ordinal)]
   [InlineData(null, StringData.LowerCaseA, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldThrow_WhenValueIsNullAndLowerAndUpperBoundsAreNotNull(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void BetweenExtensions_EnsuresBetweenString_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var comparisonType = StringComparison.Ordinal;
      var lowerBound = StringData.LowerCaseA;
      var upperBound = StringData.LowerCaseZ;
      var value = StringData.UpperCaseA;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_stringDataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.Between);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void BetweenExtensions_EnsuresBetweenString_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var lowerBound = StringData.LowerCaseA;
      var upperBound = StringData.LowerCaseZ;
      var value = StringData.Caret;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparisonType);
      var expectedMessage = $"Postcondition Between failed: {nameof(value)} must be between {lowerBound} and {upperBound} (inclusive)";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void BetweenExtensions_EnsuresBetweenString_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var comparisonType = StringComparison.InvariantCulture;
      var lowerBound = StringData.LowerCaseA;
      var upperBound = StringData.LowerCaseJ;
      var value = StringData.UpperCaseSlashedO;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparisonType, messageTemplate);
      var expectedMessage = $"Requirement Between failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void BetweenExtensions_EnsuresBetweenString_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var comparisonType = StringComparison.InvariantCultureIgnoreCase;
      var lowerBound = StringData.LowerCaseA;
      var upperBound = StringData.LowerCaseJ;
      var value = StringData.UpperCaseSlashedO;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition Between failed: {nameof(value)} must be between {lowerBound} and {upperBound} (inclusive)";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void BetweenExtensions_EnsuresBetweenString_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var comparisonType = StringComparison.Ordinal;
      var lowerBound = StringData.LowerCaseA;
      var upperBound = StringData.LowerCaseJ;
      var value = StringData.UpperCaseAPlusDiaeresisCombiningCharacter;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement Between failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseA, StringData.LowerCaseZ, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseZ, StringData.UpperCaseA, StringData.LowerCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseA, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOWithDiaeresis, StringData.UpperCaseA, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseZ, StringData.Caret, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldNotThrow_WhenBoundsAreNormalizedAndValueIsInRange(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData(StringData.UpperCaseDottedI, StringData.UpperCaseDottedI, StringData.UpperCaseDottedI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringData.UpperCaseDottedI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.Caret, StringData.Caret, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseH, StringData.UpperCaseH, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldNotThrow_WhenBoundsAreEqualAndValueIsInRange(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   // sv-SE culture (Swedish/Sweden) sorts Z, A(overring), A(diaeresis), O(diaeresis)
   [UseCulture(CultureData.SwedishSweden)]
   [Theory]
   [InlineData(StringData.LowerCaseAPlusOverringCombiningCharacter, null, StringData.UpperCaseOWithDiaeresis, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseOWithDiaeresis, null, StringData.LowerCaseOWithDiaeresis, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, null, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOWithDiaeresis, null, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseZ, null, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseZ, null, StringData.UpperCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldNotThrow_WhenLowerBoundIsNullAndUpperBoundIsNotAndValueIsInRange(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [InlineData(null, null, null, StringComparison.CurrentCulture)]
   [InlineData(null, null, null, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(null, null, null, StringComparison.InvariantCulture)]
   [InlineData(null, null, null, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(null, null, null, StringComparison.Ordinal)]
   [InlineData(null, null, null, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldNotThrow_WhenBoundsAreNullAndValueIsNull(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   // Azerbaijani Latin alphabet sorts H, X, I(dotless), I(dotted), J, ...
   [UseCulture(CultureData.LatinAzerbaijan)]
   [Theory]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseJ, StringData.UpperCaseX, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseI, StringData.LowerCaseJ, StringData.LowerCaseX, StringComparison.CurrentCultureIgnoreCase)] // I without dot sorts before I with dot in tr-TR culture
   [InlineData(StringData.UpperCaseSlashedO, StringData.UpperCaseP, StringData.LowerCaseP, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusSlashCombiningCharacter, StringData.LowerCaseP, StringData.LowerCaseO, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.LowerCaseZ, StringData.UpperCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseZ, StringData.LowerCaseA, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldThrowInvalidOperationException_WhenLowerBoundIsGreaterThanUpperBound(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparisonType);
      var expectedMessage = Messages.BetweenBoundsNotNormalized;

      // Act/assert.
      act.Should().Throw<InvalidOperationException>()
         .WithMessage(expectedMessage);
   }

   [Theory]
   [InlineData(StringData.LowerCaseH, StringData.LowerCaseA, null, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseH, StringData.LowerCaseA, null, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseH, StringData.LowerCaseA, null, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseH, StringData.LowerCaseA, null, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseH, StringData.LowerCaseA, null, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, StringData.LowerCaseA, null, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_EnsuresBetweenString_ShouldThrowInvalidOperationException_WhenLowerBoundIsNotNullAndUpperBoundIsNull(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound, comparisonType);
      var expectedMessage = Messages.BetweenBoundsNotNormalized;

      // Act/assert.
      act.Should().Throw<InvalidOperationException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresBetween (IComparable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.WithinBoundsValue;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;

      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBoundAndBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.LowerBound;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;

      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndEqualToUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.UpperBound;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;

      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBoundAndUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.WithinBoundsValue;
      var lowerBound = data.WithinBoundsValue;
      var upperBound = data.WithinBoundsValue;

      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndReferenceTypeValueIsNotNullAndBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.WithinBoundsValue;
      T lowerBound = default!;
      var upperBound = data.UpperBound;

      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndReferenceTypeValueIsNotNullAndEqualToUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.UpperBound;
      T lowerBound = default!;
      var upperBound = data.UpperBound;

      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndReferenceTypeValueIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = default!;
      var upperBound = data.UpperBound;

      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldReturnOriginalValue_WhenReferenceTypeValueIsNullAndLowerAndUpperBoundsAreNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = default!;
      T upperBound = default!;

      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldThrow_WhenValueIsBelowLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.BelowLowerBoundValue;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldThrow_WhenValueIsAboveUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.AboveUpperBoundValue;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldThrow_WhenReferenceTypeValueIsNullAndLowerAndUpperBoundsAreNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var data = new Int32Data();
      var value = data.BelowLowerBoundValue;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.Between);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
   }

   [Fact]
   public void BetweenExtensions_RequiresBetweenThanIComparable_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var data = new PointStructData();
      var value = data.AboveUpperBoundValue;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition Between failed: {nameof(value)} must be between {lowerBound} and {upperBound} (inclusive)";

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new HalfData();
      var value = data.AboveUpperBoundValue;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement Between failed";

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new UInt128Data();
      var value = data.AboveUpperBoundValue;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition Between failed: {nameof(value)} must be between {lowerBound} and {upperBound} (inclusive)";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var lowerBound = "ABC";
      var upperBound = "xyz";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement Between failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldNotThrow_WhenBoundsAreNormalizedAndValueIsInRange<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.WithinBoundsValue;
      var lowerBound = data.LowerBound;
      var upperBound = data.UpperBound;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldNotThrow_WhenBoundsAreEqualAndValueIsInRange<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.WithinBoundsValue;
      var lowerBound = data.WithinBoundsValue;
      var upperBound = data.WithinBoundsValue;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldNotThrow_WhenReferenceTypeLowerBoundIsNullAndUpperBoundIsNotAndValueIsInRange<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.WithinBoundsValue;
      T lowerBound = default!;
      var upperBound = data.UpperBound;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldNotThrow_WhenReferenceTypeBoundsAreNullAndValueIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      T lowerBound = default!;
      T upperBound = default!;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldThrowInvalidOperationException_WhenLowerBoundIsGreaterThanUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.WithinBoundsValue;
      var lowerBound = data.UpperBound;
      var upperBound = data.LowerBound;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound);
      var expectedMessage = Messages.BetweenBoundsNotNormalized;

      // Act/assert.
      act.Should().Throw<InvalidOperationException>()
         .WithMessage(expectedMessage);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldThrowInvalidOperationException_WhenReferenceTypeLowerBoundIsNotNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var value = data.WithinBoundsValue;
      var lowerBound = data.LowerBound;
      T upperBound = default!;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound);
      var expectedMessage = Messages.BetweenBoundsNotNormalized;

      // Act/assert.
      act.Should().Throw<InvalidOperationException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresBetween (IComparer) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var value = data.WithinBoundsValue;

      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBoundAndBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var value = lowerBound;

      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndEqualToUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var value = upperBound;

      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBoundAndUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var lowerBound = data.WithinBoundsValue;
      var upperBound = data.WithinBoundsValue;
      var value = data.WithinBoundsValue;

      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndReferenceTypeValueIsNotNullAndBelowUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(default!, data.UpperBound);
      var value = data.WithinBoundsValue;

      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndReferenceTypeValueIsNotNullAndEqualToUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(default!, data.UpperBound);
      var value = upperBound;

      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndReferenceTypeValueIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(default!, data.UpperBound);
      var value = lowerBound;

      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldReturnOriginalValue_WhenReferenceTypeValueIsNullAndLowerAndUpperBoundsAreNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      T lowerBound = default!;
      T upperBound = default!;
      T value = default!;

      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldThrow_WhenValueIsBelowLowerBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var (value, _) = comparer.ReverseValues(data.BelowLowerBoundValue, data.AboveUpperBoundValue);
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldThrow_WhenValueIsAboveUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var (_, value) = comparer.ReverseValues(data.BelowLowerBoundValue, data.AboveUpperBoundValue);
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldThrow_WhenReferenceTypeValueIsNullAndLowerAndUpperBoundsAreNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      T value = default!;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var data = new Int32Data();
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var (value, _) = comparer.ReverseValues(data.BelowLowerBoundValue, data.AboveUpperBoundValue);
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparer);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.Between);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
   }

   [Fact]
   public void BetweenExtensions_RequiresBetweenThanIComparer_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var data = new PointStructData();
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var (_, value) = comparer.ReverseValues(data.BelowLowerBoundValue, data.AboveUpperBoundValue);
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparer);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition Between failed: {nameof(value)} must be between {lowerBound} and {upperBound} (inclusive)";

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new HalfData();
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var (value, _) = comparer.ReverseValues(data.BelowLowerBoundValue, data.AboveUpperBoundValue);
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparer, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement Between failed";

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new UInt128Data();
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var (_, value) = comparer.ReverseValues(data.BelowLowerBoundValue, data.AboveUpperBoundValue);
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition Between failed: {nameof(value)} must be between {lowerBound} and {upperBound} (inclusive)";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new StringData();
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement Between failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldNotThrow_WhenBoundsAreNormalizedAndValueIsInRange<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, data.UpperBound);
      var value = data.WithinBoundsValue;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparer);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldNotThrow_WhenBoundsAreEqualAndValueIsInRange<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var lowerBound = data.WithinBoundsValue;
      var upperBound = data.WithinBoundsValue;
      var value = data.WithinBoundsValue;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparer);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldNotThrow_WhenReferenceTypeLowerBoundIsNullAndUpperBoundIsNotAndValueIsInRange<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(default!, data.UpperBound);
      var value = data.WithinBoundsValue;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparer);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldNotThrow_WhenReferenceTypeBoundsAreNullAndValueIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      T lowerBound = default!;
      T upperBound = default!;
      T value = default!;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparer);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(BoundedTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldThrowInvalidOperationException_WhenLowerBoundIsGreaterThanUpperBound<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.UpperBound, data.LowerBound);
      var value = data.WithinBoundsValue;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparer);
      var expectedMessage = Messages.BetweenBoundsNotNormalized;

      // Act/assert.
      act.Should().Throw<InvalidOperationException>()
         .WithMessage(expectedMessage);
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparer_ShouldThrowInvalidOperationException_WhenReferenceTypeLowerBoundIsNotNullAndUpperBoundIsNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      var comparer = data.ReverseComparer;
      var (lowerBound, upperBound) = comparer.ReverseValues(data.LowerBound, default!);
      var value = data.WithinBoundsValue;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparer);
      var expectedMessage = Messages.BetweenBoundsNotNormalized;

      // Act/assert.
      act.Should().Throw<InvalidOperationException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresBetween (String) Tests
   // ==========================================================================
   // ==========================================================================

   // For ordinal comparison, caret(^) sorts between uppercase Z and lowercase A
   // For ordinal ignore case comparison, caret(^) sorts above Z
   [UseCulture(CultureData.EnglishUS)]  
   [Theory]
   [InlineData(StringData.UpperCaseAE, StringData.LowerCaseA, StringData.LowerCaseZ, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseO, StringData.LowerCaseP, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusSlashCombiningCharacter, StringData.UpperCaseO, StringData.UpperCaseP, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.UpperCaseZ, StringData.LowerCaseA, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseAE, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndBelowUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   // Azerbaijani Latin alphabet sorts H, X, I(dotless), I(dotted), J, ...
   [UseCulture(CultureData.LatinAzerbaijan)] 
   [Theory]
   [InlineData(StringData.LowerCaseX, StringData.UpperCaseH, StringData.UpperCaseI, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseX, StringData.LowerCaseH, StringData.LowerCaseDotlessI, StringComparison.CurrentCultureIgnoreCase)] // I without dot sorts before I with dot in tr-TR culture
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseO, StringData.LowerCaseP, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusSlashCombiningCharacter, StringData.UpperCaseO, StringData.UpperCaseP, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.UpperCaseZ, StringData.LowerCaseA, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseAE, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndBelowUpperBoundAndCurrentCultureIs_azLatnAZ(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   // sv-SE culture (Swedish/Sweden) sorts Z, A(overring), A(diaeresis), O(diaeresis)
   [UseCulture(CultureData.SwedishSweden)]  
   [Theory]
   [InlineData(StringData.LowerCaseAWithOverring, StringData.LowerCaseZ, StringData.UpperCaseOWithDiaeresis, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseAWithOverring, StringData.UpperCaseZ, StringData.LowerCaseOWithDiaeresis, StringComparison.CurrentCultureIgnoreCase)] // I without dot sorts before I with dot in tr-TR culture
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseO, StringData.LowerCaseP, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusSlashCombiningCharacter, StringData.UpperCaseO, StringData.UpperCaseP, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.UpperCaseAE, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseAE, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndBelowUpperBoundAndCurrentCultureIs_svSE(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.UpperCaseA, StringData.UpperCaseA, StringData.LowerCaseZ, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseA, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseAPlusDiaeresisCombiningCharacter, StringData.UpperCaseAWithDiaeresis, StringData.LowerCaseZ, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseAWithDiaeresis, StringData.UpperCaseAWithDiaeresis, StringData.UpperCaseZ, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.Caret, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseA, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBoundAndBelowUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   // da-DK culture (Danish/Denmark) sorts Z, AE(diphthong), O(slashed), A(overring)
   [UseCulture(CultureData.DanishDenmark)]
   [Theory]
   [InlineData(StringData.UpperCaseDiphthongAE, StringData.UpperCaseDiphthongAE, StringData.LowerCaseAWithOverring, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseDiphthongAE, StringData.UpperCaseDiphthongAE, StringData.LowerCaseAWithOverring, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseOPlusSlashCombiningCharacter, StringData.UpperCaseSlashedO, StringData.LowerCaseZ, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseSlashedO, StringData.UpperCaseOPlusSlashCombiningCharacter, StringData.UpperCaseZ, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.Caret, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseA, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldReturnOriginalValue_WhenValueIsEqualToLowerBoundAndBelowUpperBoundAndCurrentCultureIs_daDK(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseA, StringData.LowerCaseZ, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseZ, StringData.UpperCaseA, StringData.LowerCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseA, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOWithDiaeresis, StringData.UpperCaseA, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseZ, StringData.Caret, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndEqualToUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   // sv-SE culture (Swedish/Sweden) sorts Z, A(overring), A(diaeresis), O(diaeresis)
   [UseCulture(CultureData.SwedishSweden)]
   [Theory]
   [InlineData(StringData.LowerCaseAPlusOverringCombiningCharacter, StringData.UpperCaseZ, StringData.UpperCaseOWithDiaeresis, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseOWithDiaeresis, StringData.LowerCaseZ, StringData.LowerCaseOWithDiaeresis, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseA, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOWithDiaeresis, StringData.UpperCaseA, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseZ, StringData.Caret, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldReturnOriginalValue_WhenValueIsAboveLowerBoundAndEqualToUpperBoundAndCurrentCultureIs_svSE(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.UpperCaseH, StringData.UpperCaseH, StringData.UpperCaseH, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseH, StringData.UpperCaseH, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.Caret, StringData.Caret, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseH, StringData.UpperCaseH, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldReturnOriginalValue_WhenValueEqualToLowerBoundAndToUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData(StringData.UpperCaseDottedI, StringData.UpperCaseDottedI, StringData.UpperCaseDottedI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringData.UpperCaseDottedI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.Caret, StringData.Caret, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseH, StringData.UpperCaseH, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldReturnOriginalValue_WhenValueEqualToLowerBoundAndToUpperBoundAndCurrentCultureIs_trTR(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [InlineData(StringData.UpperCaseAE, null, StringData.LowerCaseZ, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseAE, null, StringData.UpperCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseSlashedO, null, StringData.LowerCaseP, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusSlashCombiningCharacter, null, StringData.UpperCaseP, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, null, StringData.LowerCaseA, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, null, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndValueIsNotNullAndBelowUpperBound(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
         // Act.
         var result = value.RequiresBetween(lowerBound, upperBound, comparisonType);

         // Assert.
         result.Should().Be(value);
      }

   [Theory]
   [InlineData(StringData.UpperCaseH, null, StringData.UpperCaseH, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseH, null, StringData.UpperCaseH, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseOPlusDiaeresisCombiningCharacter, null, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, null, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, null, StringData.Caret, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, null, StringData.UpperCaseH, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndValueIsNotNullAndEqualToUpperBound(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [InlineData(null, null, StringData.UpperCaseH, StringComparison.CurrentCulture)]
   [InlineData(null, null, StringData.UpperCaseH, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(null, null, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(null, null, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(null, null, StringData.Caret, StringComparison.Ordinal)]
   [InlineData(null, null, StringData.UpperCaseH, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldReturnOriginalValue_WhenLowerBoundIsNullAndValueIsNull(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [InlineData(null, null, null, StringComparison.CurrentCulture)]
   [InlineData(null, null, null, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(null, null, null, StringComparison.InvariantCulture)]
   [InlineData(null, null, null, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(null, null, null, StringComparison.Ordinal)]
   [InlineData(null, null, null, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldReturnOriginalValue_WhenValueIsNullAndLowerAndUpperBoundsAreNull(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseH, StringData.UpperCaseZ, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseH, StringData.LowerCaseI, StringData.LowerCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseZ, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseP, StringData.LowerCaseZ, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.LowerCaseA, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseA, StringData.LowerCaseX, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldThrow_WhenValueIsBelowLowerBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   // Azerbaijani Latin alphabet sorts H, X, I(dotless), I(dotted), J, ...
   [UseCulture(CultureData.LatinAzerbaijan)]
   [Theory]
   [InlineData(StringData.LowerCaseX, StringData.UpperCaseX, StringData.UpperCaseJ, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseX, StringData.LowerCaseDotlessI, StringData.LowerCaseJ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseZ, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseP, StringData.LowerCaseZ, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.LowerCaseA, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseA, StringData.LowerCaseX, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldThrow_WhenValueIsBelowLowerBoundAndCurrentCultureIs_azLatnAZ(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.LowerCaseP, StringData.UpperCaseA, StringData.UpperCaseO, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseP, StringData.LowerCaseA, StringData.LowerCaseO, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseA, StringData.UpperCaseO, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseA, StringData.LowerCaseO, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseZ, StringData.LowerCaseA, StringData.LowerCaseH, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldThrow_WhenValueIsAboveUpperBoundAndCurrentCultureIs_enUS(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   // da-DK culture (Danish/Denmark) sorts Z, AE(diphthong), O(slashed), A(overring)
   [UseCulture(CultureData.DanishDenmark)]
   [Theory]
   [InlineData(StringData.LowerCaseSlashedO, StringData.UpperCaseA, StringData.UpperCaseDiphthongAE, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseDiphthongAE, StringData.LowerCaseA, StringData.LowerCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseA, StringData.UpperCaseO, StringComparison.InvariantCulture)]
   [InlineData(StringData.UpperCaseSlashedO, StringData.LowerCaseA, StringData.LowerCaseO, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseZ, StringData.LowerCaseA, StringData.LowerCaseH, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldThrow_WhenValueIsAboveUpperBoundAndCurrentCultureIs_daDK(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }
   [Theory]
   [InlineData(null, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.CurrentCulture)]
   [InlineData(null, StringData.LowerCaseA, StringData.LowerCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(null, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.InvariantCulture)]
   [InlineData(null, StringData.LowerCaseA, StringData.LowerCaseZ, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(null, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.Ordinal)]
   [InlineData(null, StringData.LowerCaseA, StringData.LowerCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldThrow_WhenValueIsNullAndLowerAndUpperBoundsAreNotNull(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Fact]
   public void BetweenExtensions_RequiresBetweenString_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var comparisonType = StringComparison.Ordinal;
      var lowerBound = StringData.LowerCaseA;
      var upperBound = StringData.LowerCaseZ;
      var value = StringData.UpperCaseA;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_stringDataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.Between);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.LowerBound].Should().Be(lowerBound);
      ex.Data[DataNames.LowerBoundExpression].Should().Be(nameof(lowerBound));
      ex.Data[DataNames.UpperBound].Should().Be(upperBound);
      ex.Data[DataNames.UpperBoundExpression].Should().Be(nameof(upperBound));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void BetweenExtensions_RequiresBetweenString_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var lowerBound = StringData.LowerCaseA;
      var upperBound = StringData.LowerCaseZ;
      var value = StringData.Caret;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparisonType);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition Between failed: {nameof(value)} must be between {lowerBound} and {upperBound} (inclusive)";

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void BetweenExtensions_RequiresBetweenString_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var comparisonType = StringComparison.InvariantCulture;
      var lowerBound = StringData.LowerCaseA;
      var upperBound = StringData.LowerCaseJ;
      var value = StringData.UpperCaseSlashedO;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparisonType, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement Between failed";

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void BetweenExtensions_RequiresBetweenString_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var comparisonType = StringComparison.InvariantCultureIgnoreCase;
      var lowerBound = StringData.LowerCaseA;
      var upperBound = StringData.LowerCaseJ;
      var value = StringData.UpperCaseSlashedO;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition Between failed: {nameof(value)} must be between {lowerBound} and {upperBound} (inclusive)";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void BetweenExtensions_RequiresBetweenString_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var comparisonType = StringComparison.Ordinal;
      var lowerBound = StringData.LowerCaseA;
      var upperBound = StringData.LowerCaseJ;
      var value = StringData.UpperCaseAPlusDiaeresisCombiningCharacter;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement Between failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [UseCulture(CultureData.EnglishUS)]
   [Theory]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseA, StringData.LowerCaseZ, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseZ, StringData.UpperCaseA, StringData.LowerCaseZ, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseA, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOWithDiaeresis, StringData.UpperCaseA, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseZ, StringData.Caret, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseZ, StringData.UpperCaseA, StringData.UpperCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldNotThrow_WhenBoundsAreNormalizedAndValueIsInRange(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [UseCulture(CultureData.TurkishTurkey)]
   [Theory]
   [InlineData(StringData.UpperCaseDottedI, StringData.UpperCaseDottedI, StringData.UpperCaseDottedI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringData.UpperCaseDottedI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, StringData.UpperCaseOWithDiaeresis, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.Caret, StringData.Caret, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseH, StringData.UpperCaseH, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldNotThrow_WhenBoundsAreEqualAndValueIsInRange(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   // sv-SE culture (Swedish/Sweden) sorts Z, A(overring), A(diaeresis), O(diaeresis)
   [UseCulture(CultureData.SwedishSweden)]
   [Theory]
   [InlineData(StringData.LowerCaseAPlusOverringCombiningCharacter, null, StringData.UpperCaseOWithDiaeresis, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseOWithDiaeresis, null, StringData.LowerCaseOWithDiaeresis, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseOPlusDiaeresisCombiningCharacter, null, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOWithDiaeresis, null, StringData.UpperCaseOWithDiaeresis, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseZ, null, StringData.LowerCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseZ, null, StringData.UpperCaseZ, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldNotThrow_WhenLowerBoundIsNullAndUpperBoundIsNotAndValueIsInRange(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [InlineData(null, null, null, StringComparison.CurrentCulture)]
   [InlineData(null, null, null, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(null, null, null, StringComparison.InvariantCulture)]
   [InlineData(null, null, null, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(null, null, null, StringComparison.Ordinal)]
   [InlineData(null, null, null, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldNotThrow_WhenBoundsAreNullAndValueIsNull(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparisonType);

      // Act/assert.
      act.Should().NotThrow();
   }

   // Azerbaijani Latin alphabet sorts H, X, I(dotless), I(dotted), J, ...
   [UseCulture(CultureData.LatinAzerbaijan)]
   [Theory]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseJ, StringData.UpperCaseX, StringComparison.CurrentCulture)]
   [InlineData(StringData.UpperCaseI, StringData.LowerCaseJ, StringData.LowerCaseX, StringComparison.CurrentCultureIgnoreCase)] // I without dot sorts before I with dot in tr-TR culture
   [InlineData(StringData.UpperCaseSlashedO, StringData.UpperCaseP, StringData.LowerCaseP, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseOPlusSlashCombiningCharacter, StringData.LowerCaseP, StringData.LowerCaseO, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.Caret, StringData.LowerCaseZ, StringData.UpperCaseZ, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, StringData.UpperCaseZ, StringData.LowerCaseA, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldThrowInvalidOperationException_WhenLowerBoundIsGreaterThanUpperBound(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparisonType);
      var expectedMessage = Messages.BetweenBoundsNotNormalized;

      // Act/assert.
      act.Should().Throw<InvalidOperationException>()
         .WithMessage(expectedMessage);
   }

   [Theory]
   [InlineData(StringData.LowerCaseH, StringData.LowerCaseA, null, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseH, StringData.LowerCaseA, null, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseH, StringData.LowerCaseA, null, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseH, StringData.LowerCaseA, null, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseH, StringData.LowerCaseA, null, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseH, StringData.LowerCaseA, null, StringComparison.OrdinalIgnoreCase)]
   public void BetweenExtensions_RequiresBetweenString_ShouldThrowInvalidOperationException_WhenLowerBoundIsNotNullAndUpperBoundIsNull(
      String value,
      String lowerBound,
      String upperBound,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound, comparisonType);
      var expectedMessage = Messages.BetweenBoundsNotNormalized;

      // Act/assert.
      act.Should().Throw<InvalidOperationException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
