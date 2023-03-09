namespace DbC.Net.Tests.Unit;

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters

public class GreaterThanExtensionsTests
{
   private const Int32 _dataCount = 6;
   private const Int32 _stringDataCount = 7;

   #region RequiresGreaterThan (IComparable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(ComparableTypesTestData))]
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldReturnOriginalValue_WhenComparableValueIsGreaterThanTarget<T>(
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
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldReturnOriginalValue_WhenValueIsNotNullAndTargetIsNull<T>(
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
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrow_WhenComparableValueIsEqualToTarget<T>(
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
   public void GreaterThanExtensions_RequiresGreaterThanIComparable_ShouldThrow_WhenComparableValueIsLessThanTarget<T>(
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
      var value = 10;
      var target = 100;
      var act = () => _ = value.RequiresGreaterThan(target);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentException>().Which;

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
      var value = Half.MinValue;
      var target = Half.MinValue;
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
      var value = UInt128.MinValue;
      var target = UInt128.MaxValue;
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
}
