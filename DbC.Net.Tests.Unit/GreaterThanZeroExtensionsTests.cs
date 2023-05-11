namespace DbC.Net.Tests.Unit;

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters

public class GreaterThanZeroExtensionsTests
{
   private const Int32 _dataCount = 4;

   #region EnsuresGreaterThanZero Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(NumberTypesTestData))]
   public void GreaterThanZeroExtensions_EnsuresGreaterThan_ShouldNotThrow_WhenValueIsGreaterThanZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var act = () => _ = value.EnsuresGreaterThanZero();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(NumberTypesTestData))]
   public void GreaterThanZeroExtensions_EnsuresGreaterThan_ShouldThrow_WhenValueIsZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = T.Zero;
      var act = () => _ = value.EnsuresGreaterThanZero();

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void GreaterThanZeroExtensions_EnsuresGreaterThan_ShouldThrow_WhenValueIsLessThanZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MinValue;
      var act = () => _ = value.EnsuresGreaterThanZero();

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(NumberTypesTestData))]
   public void GreaterThanZeroExtensions_EnsuresGreaterThan_ShouldReturnOriginalValue_WhenValueIsGreaterThanZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MaxValue;

      // Act.
      var result = value.EnsuresGreaterThanZero();

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThan_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = 0;
      var act = () => _ = value.EnsuresGreaterThanZero();

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThanZero);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThan_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = -1.5;
      var act = () => _ = value.EnsuresGreaterThanZero();
      var expectedMessage = $"Postcondition GreaterThanZero failed: {nameof(value)} must be greater than zero";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThan_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = -1.5M;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThanZero(messageTemplate);
      var expectedMessage = $"Requirement GreaterThanZero failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThan_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = (Single)0;
      var act = () => _ = value.EnsuresGreaterThanZero(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition GreaterThanZero failed: {nameof(value)} must be greater than zero";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_EnsuresGreaterThan_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = (Half)(-1);
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresGreaterThanZero(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThanZero failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresGreaterThanZero Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(NumberTypesTestData))]
   public void GreaterThanZeroExtensions_RequiresGreaterThan_ShouldNotThrow_WhenValueIsGreaterThanZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var act = () => _ = value.RequiresGreaterThanZero();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(NumberTypesTestData))]
   public void GreaterThanZeroExtensions_RequiresGreaterThan_ShouldThrow_WhenValueIsZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = T.Zero;
      var act = () => _ = value.RequiresGreaterThanZero();

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void GreaterThanZeroExtensions_RequiresGreaterThan_ShouldThrow_WhenValueIsLessThanZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MinValue;
      var act = () => _ = value.RequiresGreaterThanZero();

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(NumberTypesTestData))]
   public void GreaterThanZeroExtensions_RequiresGreaterThan_ShouldReturnOriginalValue_WhenValueIsGreaterThanZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MaxValue;

      // Act.
      var result = value.RequiresGreaterThanZero();

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThan_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = 0;
      var act = () => _ = value.RequiresGreaterThanZero();

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.GreaterThanZero);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThan_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = -1.5;
      var act = () => _ = value.RequiresGreaterThanZero();
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition GreaterThanZero failed: {nameof(value)} must be greater than zero";

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThan_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = -1.5M;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThanZero(messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement GreaterThanZero failed";

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThan_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = (Single)0;
      var act = () => _ = value.RequiresGreaterThanZero(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition GreaterThanZero failed: {nameof(value)} must be greater than zero";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void GreaterThanExtensions_RequiresGreaterThan_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = (Half)(-1);
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresGreaterThanZero(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement GreaterThanZero failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
