namespace DbC.Net.Tests.Unit;

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters

public class GreaterThanOrEqualToZeroExtensionsTests
{
   private const Int32 _dataCount = 4;

   #region EnsuresGreaterThanOrEqualToZero Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void GreaterThanOrEqualToZeroExtensions_EnsuresGreaterThanOrEqualToZero_ShouldNotThrow_WhenValueIsGreaterThanOrEqualToZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThanOrEqualToZero();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void GreaterThanOrEqualToZeroExtensions_EnsuresGreaterThanOrEqualToZero_ShouldNotThrow_WhenValueIsZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = T.Zero;
      var act = () => _ = value.EnsuresGreaterThanOrEqualToZero();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void GreaterThanOrEqualToZeroExtensions_EnsuresGreaterThanOrEqualToZero_ShouldThrow_WhenValueIsLessThanZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MinValue;
      var act = () => _ = value.EnsuresGreaterThanOrEqualToZero();

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void GreaterThanOrEqualToZeroExtensions_EnsuresGreaterThanOrEqualToZero_ShouldReturnOriginalValue_WhenValueIsGreaterThanOrEqualToZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MaxValue;

      // Act.
      var result = value.EnsuresGreaterThanOrEqualToZero();

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void GreaterThanOrEqualToZeroExtensions_EnsuresGreaterThanOrEqualToZero_ShouldReturnOriginalValue_WhenValueIsZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = T.Zero;

      // Act.
      var result = value.EnsuresGreaterThanOrEqualToZero();

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void GreaterThanOrEqualToZeroExtensions_EnsuresGreaterThanOrEqualToZero_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = -1;
      var act = () => _ = value.EnsuresGreaterThanOrEqualToZero();

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThanOrEqualToZero);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void GreaterThanOrEqualToZeroExtensions_EnsuresGreaterThanOrEqualToZero_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = -1.5;
      var act = () => _ = value.EnsuresGreaterThanOrEqualToZero();
      var expectedMessage = $"Postcondition GreaterThanOrEqualToZero failed: {nameof(value)} must be greater than or equal to zero";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualToZeroExtensions_EnsuresGreaterThanOrEqualToZero_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = -1.5M;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThanOrEqualToZero(messageTemplate);
      var expectedMessage = $"Requirement GreaterThanOrEqualToZero failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualToZeroExtensions_EnsuresGreaterThanOrEqualToZero_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = Single.MinValue;
      var act = () => _ = value.EnsuresGreaterThanOrEqualToZero(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition GreaterThanOrEqualToZero failed: {nameof(value)} must be greater than or equal to zero";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualToZeroExtensions_EnsuresGreaterThanOrEqualToZero_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = (Half)(-1);
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThanOrEqualToZero(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThanOrEqualToZero failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresGreaterThanOrEqualToZero Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void GreaterThanOrEqualToZeroExtensions_RequiresGreaterThanOrEqualToZero_ShouldNotThrow_WhenValueIsGreaterThanOrEqualToZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThanOrEqualToZero();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void GreaterThanOrEqualToZeroExtensions_RequiresGreaterThanOrEqualToZero_ShouldNotThrow_WhenValueIsZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = T.Zero;
      var act = () => _ = value.RequiresGreaterThanOrEqualToZero();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void GreaterThanOrEqualToZeroExtensions_RequiresGreaterThanOrEqualToZero_ShouldThrow_WhenValueIsLessThanZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MinValue;
      var act = () => _ = value.RequiresGreaterThanOrEqualToZero();

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void GreaterThanOrEqualToZeroExtensions_RequiresGreaterThanOrEqualToZero_ShouldReturnOriginalValue_WhenValueIsGreaterThanOrEqualToZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MaxValue;

      // Act.
      var result = value.RequiresGreaterThanOrEqualToZero();

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void GreaterThanOrEqualToZeroExtensions_RequiresGreaterThanOrEqualToZero_ShouldReturnOriginalValue_WhenValueIsZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = T.Zero;

      // Act.
      var result = value.RequiresGreaterThanOrEqualToZero();

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void GreaterThanOrEqualToZeroExtensions_RequiresGreaterThanOrEqualToZero_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = -1;
      var act = () => _ = value.RequiresGreaterThanOrEqualToZero();

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThanOrEqualToZero);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void GreaterThanOrEqualToZeroExtensions_RequiresGreaterThanOrEqualToZero_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = -1.5;
      var act = () => _ = value.RequiresGreaterThanOrEqualToZero();
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition GreaterThanOrEqualToZero failed: {nameof(value)} must be greater than or equal to zero";

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanOrEqualToZeroExtensions_RequiresGreaterThanOrEqualToZero_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = -1.5M;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThanOrEqualToZero(messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement GreaterThanOrEqualToZero failed";

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanOrEqualToZeroExtensions_RequiresGreaterThanOrEqualToZero_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = Single.MinValue;
      var act = () => _ = value.RequiresGreaterThanOrEqualToZero(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition GreaterThanOrEqualToZero failed: {nameof(value)} must be greater than or equal to zero";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanOrEqualToZeroExtensions_RequiresGreaterThanOrEqualToZero_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = (Half)(-1);
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThanOrEqualToZero(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThanOrEqualToZero failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
