namespace DbC.Net.Tests.Unit;

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters

public class LessThanZeroExtensionsTests
{
   private const Int32 _dataCount = 4;

   #region EnsuresLessThanZero Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void LessThanZeroExtensions_EnsuresLessThanZero_ShouldNotThrow_WhenValueIsLessThanZero<T>(
      IComparableTestData<T> data) where T : ISignedNumber<T>, IComparable<T>
   {
      // Arrange.
      var value = data.MinValue;
      var act = () => _ = value.EnsuresLessThanZero();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void LessThanZeroExtensions_EnsuresLessThanZero_ShouldThrow_WhenValueIsZero<T>(
      IComparableTestData<T> data) where T : ISignedNumber<T>, IComparable<T>
   {
      // Arrange.
      var value = T.Zero;
      var act = () => _ = value.EnsuresLessThanZero();

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void LessThanZeroExtensions_EnsuresLessThanZero_ShouldThrow_WhenValueIsGreaterThanZero<T>(
      IComparableTestData<T> data) where T : ISignedNumber<T>, IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var act = () => _ = value.EnsuresLessThanZero();

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void LessThanZeroExtensions_EnsuresLessThanZero_ShouldReturnOriginalValue_WhenValueIsLessThanZero<T>(
      IComparableTestData<T> data) where T : ISignedNumber<T>, IComparable<T>
   {
      // Arrange.
      var value = data.MinValue;

      // Act.
      var result = value.EnsuresLessThanZero();

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void LessThanZeroExtensions_EnsuresLessThanZero_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = 0;
      var act = () => _ = value.EnsuresLessThanZero();

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.LessThanZero);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void LessThanZeroExtensions_EnsuresLessThanZero_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = 1.5;
      var act = () => _ = value.EnsuresLessThanZero();
      var expectedMessage = $"Postcondition LessThanZero failed: {nameof(value)} must be less than zero";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanZeroExtensions_EnsuresLessThanZero_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = 1.5M;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresLessThanZero(messageTemplate);
      var expectedMessage = $"Requirement LessThanZero failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanZeroExtensions_EnsuresLessThanZero_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = (Single)0;
      var act = () => _ = value.EnsuresLessThanZero(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition LessThanZero failed: {nameof(value)} must be less than zero";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanZeroExtensions_EnsuresLessThanZero_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = (Half)1;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresLessThanZero(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement LessThanZero failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresLessThanZero Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void LessThanZeroExtensions_RequiresLessThanZero_ShouldNotThrow_WhenValueIsLessThanZero<T>(
      IComparableTestData<T> data) where T : ISignedNumber<T>, IComparable<T>
   {
      // Arrange.
      var value = data.MinValue;
      var act = () => _ = value.RequiresLessThanZero();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void LessThanZeroExtensions_RequiresLessThanZero_ShouldThrow_WhenValueIsZero<T>(
      IComparableTestData<T> data) where T : ISignedNumber<T>, IComparable<T>
   {
      // Arrange.
      var value = T.Zero;
      var act = () => _ = value.RequiresLessThanZero();

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void LessThanZeroExtensions_RequiresLessThanZero_ShouldThrow_WhenValueIsGreaterThanZero<T>(
      IComparableTestData<T> data) where T : ISignedNumber<T>, IComparable<T>
   {
      // Arrange.
      var value = data.MaxValue;
      var act = () => _ = value.RequiresLessThanZero();

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>();
   }

   [Theory]
   [ClassData(typeof(SignedNumberTypesTestData))]
   public void LessThanZeroExtensions_RequiresLessThanZero_ShouldReturnOriginalValue_WhenValueIsLessThanZero<T>(
      IComparableTestData<T> data) where T : ISignedNumber<T>, IComparable<T>
   {
      // Arrange.
      var value = data.MinValue;

      // Act.
      var result = value.RequiresLessThanZero();

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void LessThanZeroExtensions_RequiresLessThanZero_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = 0;
      var act = () => _ = value.RequiresLessThanZero();

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.LessThanZero);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void LessThanZeroExtensions_RequiresLessThanZero_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = 1.5;
      var act = () => _ = value.RequiresLessThanZero();
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition LessThanZero failed: {nameof(value)} must be less than zero";

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void LessThanZeroExtensions_RequiresLessThanZero_ShouldThrowArgumentOutOfRangeExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = 1.5M;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresLessThanZero(messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement LessThanZero failed";

      // Act/assert.
      act.Should().Throw<ArgumentOutOfRangeException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*")
         .And.ActualValue.Should().Be(value);
   }

   [Fact]
   public void LessThanZeroExtensions_RequiresLessThanZero_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = (Single)0;
      var act = () => _ = value.RequiresLessThanZero(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition LessThanZero failed: {nameof(value)} must be less than zero";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void LessThanZeroExtensions_RequiresLessThanZero_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = (Half)1;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresLessThanZero(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement LessThanZero failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
