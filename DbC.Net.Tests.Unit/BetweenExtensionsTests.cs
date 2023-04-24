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
      var upperBound = data.WithinBoundsValue;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_EnsuresBetweenIComparable_ShouldNotThrow_WhenReferenceTypeBoundsAreNullAndUpperBoundIsNotAndValueIsNull<T>(
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
      var lowerBound = data.UpperBound;
      T upperBound = default!;
      var act = () => _ = value.EnsuresBetween(lowerBound, upperBound);
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
      var upperBound = data.WithinBoundsValue;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void BetweenExtensions_RequiresBetweenIComparable_ShouldNotThrow_WhenReferenceTypeBoundsAreNullAndUpperBoundIsNotAndValueIsNull<T>(
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
      var lowerBound = data.UpperBound;
      T upperBound = default!;
      var act = () => _ = value.RequiresBetween(lowerBound, upperBound);
      var expectedMessage = Messages.BetweenBoundsNotNormalized;

      // Act/assert.
      act.Should().Throw<InvalidOperationException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
