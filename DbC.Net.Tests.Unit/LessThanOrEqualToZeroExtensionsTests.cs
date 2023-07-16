namespace DbC.Net.Tests.Unit;

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters

public class LessThanOrEqualToZeroExtensionsTests
{
   private const Int32 _dataCount = 4;

   #region EnsuresLessThanOrEqualToZero Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void LessThanOrEqualToZeroExtensions_EnsuresLessThanOrEqualToZero_ShouldNotThrow_WhenValueIsLessThanZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MinValue;
      var act = () => _ = value.EnsuresLessThanOrEqualToZero();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(NumberTypesTestData))]
   public void LessThanOrEqualToZeroExtensions_EnsuresLessThanOrEqualToZero_ShouldNotThrow_WhenValueIsZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = T.Zero;
      var act = () => _ = value.EnsuresLessThanOrEqualToZero();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(NumberTypesTestData))]
   public void LessThanOrEqualToZeroExtensions_EnsuresLessThanOrEqualToZero_ShouldThrow_WhenValueIsGreaterThanZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var act = () => _ = value.EnsuresLessThanOrEqualToZero();

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void LessThanOrEqualToZeroExtensions_EnsuresLessThanOrEqualToZero_ShouldReturnOriginalValue_WhenValueIsLessThanZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MinValue;

      // Act.
      var result = value.EnsuresLessThanOrEqualToZero();

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(NumberTypesTestData))]
   public void LessThanOrEqualToZeroExtensions_EnsuresLessThanOrEqualToZero_ShouldReturnOriginalValue_WhenValueIsZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = T.Zero;

      // Act.
      var result = value.EnsuresLessThanOrEqualToZero();

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void LessThanOrEqualToZeroExtensions_EnsuresLessThanOrEqualToZero_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = 1;
      var act = () => _ = value.EnsuresLessThanOrEqualToZero();

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.LessThanOrEqualToZero);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void LessThanOrEqualToZeroExtensions_EnsuresLessThanOrEqualToZero_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = 1.5;
      var act = () => _ = value.EnsuresLessThanOrEqualToZero();
      var expectedMessage = $"Postcondition LessThanOrEqualToZero failed: {nameof(value)} must be less than or equal to zero";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanOrEqualToZeroExtensions_EnsuresLessThanOrEqualToZero_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = 1.5M;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresLessThanOrEqualToZero(messageTemplate);
      var expectedMessage = $"Requirement LessThanOrEqualToZero failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanOrEqualToZeroExtensions_EnsuresLessThanOrEqualToZero_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = Single.MaxValue;
      var act = () => _ = value.EnsuresLessThanOrEqualToZero(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition LessThanOrEqualToZero failed: {nameof(value)} must be less than or equal to zero";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanOrEqualToZeroExtensions_EnsuresLessThanOrEqualToZero_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = (Half)1;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresLessThanOrEqualToZero(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement LessThanOrEqualToZero failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresLessThanOrEqualToZero Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void LessThanOrEqualToZeroExtensions_RequiresLessThanOrEqualToZero_ShouldNotThrow_WhenValueIsLessThanZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MinValue;
      var act = () => _ = value.RequiresLessThanOrEqualToZero();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(NumberTypesTestData))]
   public void LessThanOrEqualToZeroExtensions_RequiresLessThanOrEqualToZero_ShouldNotThrow_WhenValueIsZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = T.Zero;
      var act = () => _ = value.RequiresLessThanOrEqualToZero();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(NumberTypesTestData))]
   public void LessThanOrEqualToZeroExtensions_RequiresLessThanOrEqualToZero_ShouldThrow_WhenValueIsGreaterThanZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var act = () => _ = value.RequiresLessThanOrEqualToZero();

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void LessThanOrEqualToZeroExtensions_RequiresLessThanOrEqualToZero_ShouldReturnOriginalValue_WhenValueIsLessThanZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = data.MinValue;

      // Act.
      var result = value.RequiresLessThanOrEqualToZero();

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(NumberTypesTestData))]
   public void LessThanOrEqualToZeroExtensions_RequiresLessThanOrEqualToZero_ShouldReturnOriginalValue_WhenValueIsZero<T>(
      IComparableTestData<T> data) where T : INumber<T>
   {
      // Arrange.
      var value = T.Zero;

      // Act.
      var result = value.RequiresLessThanOrEqualToZero();

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void LessThanOrEqualToZeroExtensions_RequiresLessThanOrEqualToZero_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = 1;
      var act = () => _ = value.RequiresLessThanOrEqualToZero();

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.LessThanOrEqualToZero);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void LessThanOrEqualToZeroExtensions_RequiresLessThanOrEqualToZero_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = 1.5;
      var act = () => _ = value.RequiresLessThanOrEqualToZero();
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition LessThanOrEqualToZero failed: {nameof(value)} must be less than or equal to zero";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void LessThanOrEqualToZeroExtensions_RequiresLessThanOrEqualToZero_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = 1.5M;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresLessThanOrEqualToZero(messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement LessThanOrEqualToZero failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void LessThanOrEqualToZeroExtensions_RequiresLessThanOrEqualToZero_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = Single.MaxValue;
      var act = () => _ = value.RequiresLessThanOrEqualToZero(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition LessThanOrEqualToZero failed: {nameof(value)} must be less than or equal to zero";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanOrEqualToZeroExtensions_RequiresLessThanOrEqualToZero_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = (Half)1;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresLessThanOrEqualToZero(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement LessThanOrEqualToZero failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
