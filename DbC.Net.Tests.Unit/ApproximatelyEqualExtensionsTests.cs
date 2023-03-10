namespace DbC.Net.Tests.Unit;

public class ApproximatelyEqualExtensionsTests
{
   private const Int32 _dataCount = 8;

   #region EnsuresApproximatelyEqual Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(FloatingPointTypesTestData))]
   public void ApproximatelyEqualExtensions_EnsuresApproximatelyEqual_ShouldReturnOriginalValue_WhenValueIsWithinPositiveEpsilon<T>(
      FloatingPointValue<T> data) where T : IFloatingPoint<T>
   {
      // Arrange.
      var value = data.Value + data.WithinToleranceDelta;
      var target = data.Value;
      var epsilon = data.FixedEpsilon;
      var comparer = data.FixedErrorComparer;

      // Act.
      var result = value.EnsuresApproximatelyEqual(target, epsilon, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(NonDecimalFloatingPointTypesTestData))]
   public void ApproximatelyEqualExtensions_EnsuresApproximatelyEqual_ShouldReturnOriginalValue_WhenValueIsWithinNegativeEpsilon<T>(
      FloatingPointValue<T> data) where T : IFloatingPoint<T>
   {
      // Arrange.
      var value = data.Value - data.WithinToleranceDelta;
      var target = data.Value;
      var epsilon = data.RelativeEpsilon;
      var comparer = data.RelativeErrorComparer;

      // Act.
      var result = value.EnsuresApproximatelyEqual(target, epsilon, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(NonDecimalFloatingPointTypesTestData))]
   public void ApproximatelyEqualExtensions_EnsuresApproximatelyEqual_ShouldThrow_WhenValueIsGreaterThanPositiveEpsilon<T>(
      FloatingPointValue<T> data) where T : IFloatingPoint<T>
   {
      // Arrange.
      var value = data.Value + data.OutOfToleranceDelta;
      var target = data.Value;
      var epsilon = data.RelativeEpsilon;
      var comparer = data.RelativeErrorComparer;
      var act = () => _ = value.EnsuresApproximatelyEqual(target, epsilon, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(FloatingPointTypesTestData))]
   public void ApproximatelyEqualExtensions_EnsuresApproximatelyEqual_ShouldThrow_WhenValueIsLessThanNegativeEpsilon<T>(
      FloatingPointValue<T> data) where T : IFloatingPoint<T>
   {
      // Arrange.
      var value = data.Value - data.OutOfToleranceDelta;
      var target = data.Value;
      var epsilon = data.FixedEpsilon;
      var comparer = data.FixedErrorComparer;
      var act = () => _ = value.EnsuresApproximatelyEqual(target, epsilon, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void ApproximatelyEqualExtensions_EnsuresApproximatelyEqual_ShouldThrowWithExpectedDataDictionary_WhenValueIsNotApproximatelyEqualToTarget()
   {
      // Arrange.
      var data = new SingleData();
      var value = data.Value - data.OutOfToleranceDelta;
      var target = data.Value;
      var epsilon = data.RelativeEpsilon;
      var comparer = data.RelativeErrorComparer;
      var act = () => _ = value.EnsuresApproximatelyEqual(target, epsilon, comparer);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.ApproximatelyEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
      ex.Data[DataNames.Epsilon].Should().Be(epsilon);
      ex.Data[DataNames.EpsilonExpression].Should().Be(nameof(epsilon));
   }

   [Fact]
   public void ApproximatelyEqualExtensions_EnsuresApproximatelyEqual_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsNotApproximatelyEqualToTarget()
   {
      // Arrange.
      var data = new DoubleData();
      var value = data.Value - data.OutOfToleranceDelta;
      var target = data.Value;
      var epsilon = data.RelativeEpsilon;
      var comparer = data.RelativeErrorComparer;
      var act = () => _ = value.EnsuresApproximatelyEqual(target, epsilon, comparer);
      var expectedMessage = $"Postcondition ApproximatelyEqual failed: {nameof(value)} must be within +/- {epsilon} of {target}";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void ApproximatelyEqualExtensions_EnsuresApproximatelyEqual_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new HalfData();
      var value = data.Value + data.OutOfToleranceDelta;
      var target = data.Value;
      var epsilon = data.FixedEpsilon;
      var comparer = data.FixedErrorComparer;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresApproximatelyEqual(target, epsilon, comparer, messageTemplate);
      var expectedMessage = $"Requirement ApproximatelyEqual failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void ApproximatelyEqualExtensions_EnsuresApproximatelyEqual_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new DecimalData();
      var value = data.Value + data.OutOfToleranceDelta;
      var target = data.Value;
      var epsilon = data.FixedEpsilon;
      var comparer = data.FixedErrorComparer;
      var act = () => _ = value.EnsuresApproximatelyEqual(target, epsilon, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition ApproximatelyEqual failed: {nameof(value)} must be within +/- {epsilon} of {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void ApproximatelyEqualExtensions_EnsuresApproximatelyEqual_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new SingleData();
      var value = data.Value - data.OutOfToleranceDelta;
      var target = data.Value;
      var epsilon = data.RelativeEpsilon;
      var comparer = data.RelativeErrorComparer;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresApproximatelyEqual(target, epsilon, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement ApproximatelyEqual failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

   #region RequiresApproximatelyEqual Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(FloatingPointTypesTestData))]
   public void ApproximatelyEqualExtensions_RequiresApproximatelyEqual_ShouldReturnOriginalValue_WhenValueIsWithinPositiveEpsilon<T>(
      FloatingPointValue<T> data) where T : IFloatingPoint<T>
   {
      // Arrange.
      var value = data.Value + data.WithinToleranceDelta;
      var target = data.Value;
      var epsilon = data.FixedEpsilon;
      var comparer = data.FixedErrorComparer;

      // Act.
      var result = value.RequiresApproximatelyEqual(target, epsilon, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(NonDecimalFloatingPointTypesTestData))]
   public void ApproximatelyEqualExtensions_RequiresApproximatelyEqual_ShouldReturnOriginalValue_WhenValueIsWithinNegativeEpsilon<T>(
      FloatingPointValue<T> data) where T : IFloatingPoint<T>
   {
      // Arrange.
      var value = data.Value - data.WithinToleranceDelta;
      var target = data.Value;
      var epsilon = data.RelativeEpsilon;
      var comparer = data.RelativeErrorComparer;

      // Act.
      var result = value.RequiresApproximatelyEqual(target, epsilon, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(NonDecimalFloatingPointTypesTestData))]
   public void ApproximatelyEqualExtensions_RequiresApproximatelyEqual_ShouldThrow_WhenValueIsGreaterThanPositiveEpsilon<T>(
      FloatingPointValue<T> data) where T : IFloatingPoint<T>
   {
      // Arrange.
      var value = data.Value + data.OutOfToleranceDelta;
      var target = data.Value;
      var epsilon = data.RelativeEpsilon;
      var comparer = data.RelativeErrorComparer;
      var act = () => _ =  value.RequiresApproximatelyEqual(target, epsilon, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Theory]
   [ClassData(typeof(FloatingPointTypesTestData))]
   public void ApproximatelyEqualExtensions_RequiresApproximatelyEqual_ShouldThrow_WhenValueIsLessThanNegativeEpsilon<T>(
      FloatingPointValue<T> data) where T : IFloatingPoint<T>
   {
      // Arrange.
      var value = data.Value - data.OutOfToleranceDelta;
      var target = data.Value;
      var epsilon = data.FixedEpsilon;
      var comparer = data.FixedErrorComparer;
      var act = () => _ = value.RequiresApproximatelyEqual(target, epsilon, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Fact]
   public void ApproximatelyEqualExtensions_RequiresApproximatelyEqual_ShouldThrowWithExpectedDataDictionary_WhenValueIsNotApproximatelyEqualToTarget()
   {
      // Arrange.
      var data = new SingleData();
      var value = data.Value - data.OutOfToleranceDelta;
      var target = data.Value;
      var epsilon = data.RelativeEpsilon;
      var comparer = data.RelativeErrorComparer;
      var act = () => _ = value.RequiresApproximatelyEqual(target, epsilon, comparer);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.ApproximatelyEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
      ex.Data[DataNames.Epsilon].Should().Be(epsilon);
      ex.Data[DataNames.EpsilonExpression].Should().Be(nameof(epsilon));
   }

   [Fact]
   public void ApproximatelyEqualExtensions_RequiresApproximatelyEqual_ShouldThrowArgumentExceptionWithExpectedMessage_WhenValueIsNotApproximatelyEqualToTarget()
   {
      // Arrange.
      var data = new DoubleData();
      var value = data.Value - data.OutOfToleranceDelta;
      var target = data.Value;
      var epsilon = data.RelativeEpsilon;
      var comparer = data.RelativeErrorComparer;
      var act = () => _ = value.RequiresApproximatelyEqual(target, epsilon, comparer);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition ApproximatelyEqual failed: {nameof(value)} must be within +/- {epsilon} of {target}";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void ApproximatelyEqualExtensions_RequiresApproximatelyEqual_ShouldThrowArgumentExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var data = new HalfData();
      var value = data.Value + data.OutOfToleranceDelta;
      var target = data.Value;
      var epsilon = data.FixedEpsilon;
      var comparer = data.FixedErrorComparer;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresApproximatelyEqual(target, epsilon, comparer, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement ApproximatelyEqual failed";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void ApproximatelyEqualExtensions_RequiresApproximatelyEqual_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new DecimalData();
      var value = data.Value + data.OutOfToleranceDelta;
      var target = data.Value;
      var epsilon = data.FixedEpsilon;
      var comparer = data.FixedErrorComparer;
      var act = () => _ = value.RequiresApproximatelyEqual(target, epsilon, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition ApproximatelyEqual failed: {nameof(value)} must be within +/- {epsilon} of {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void ApproximatelyEqualExtensions_RequiresApproximatelyEqual_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var data = new SingleData();
      var value = data.Value - data.OutOfToleranceDelta;
      var target = data.Value;
      var epsilon = data.RelativeEpsilon;
      var comparer = data.RelativeErrorComparer;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresApproximatelyEqual(target, epsilon, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement ApproximatelyEqual failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion
}
