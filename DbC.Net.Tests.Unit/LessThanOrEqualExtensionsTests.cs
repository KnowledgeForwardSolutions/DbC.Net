﻿namespace DbC.Net.Tests.Unit;

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
      act.Should().Throw<PostconditionFailedException>();
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
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanOrEqualExtensions_EnsuresLessThanOrEqualIComparable_ShouldThrow_WhenReferenceValueIsNullAndUpperBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      var upperBound = data.MinValue;
      var act = () => _ = value.EnsuresLessThanOrEqual(upperBound);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
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
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

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
      var ex = act.Should().Throw<PostconditionFailedException>().Which;
      ex.Message.Should().StartWith(expectedMessage);
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
      var ex = act.Should().Throw<PostconditionFailedException>().Which;
      ex.Message.Should().StartWith(expectedMessage);
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
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
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
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
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
      act.Should().Throw<ArgumentOutOfRangeException>();
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
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(ReferenceTypesTestData))]
   public void LessThanOrEqualExtensions_RequiresLessThanOrEqualIComparable_ShouldThrow_WhenReferenceValueIsNullAndUpperBoundIsNotNull<T>(
      IComparableTestData<T> data) where T : IComparable<T>
   {
      // Arrange.
      T value = default!;
      var upperBound = data.MinValue;
      var act = () => _ = value.RequiresLessThanOrEqual(upperBound);

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
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
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

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
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(expectedParameterName);
      ex.Message.Should().StartWith(expectedMessage);
      ex.ActualValue.Should().Be(value);
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
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(expectedParameterName);
      ex.Message.Should().StartWith(expectedMessage);
      ex.ActualValue.Should().Be(value);
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
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
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
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion
}
