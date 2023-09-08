namespace DbC.Net.Tests.Unit;

public class ValidCheckDigitExtensionsTests
{
   private const Int32 _dataCount = 5;

   private static readonly ICheckDigitAlgorithm _alwaysSucceedsAlgorithm = new AlwaysSucceedsCheckDigitAlgorithm();
   private static readonly ICheckDigitAlgorithm _alwaysFailsAlgorithm = new AlwaysFailsCheckDigitAlgorithm();

   #region EnsuresValidCheckDigit Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ValidCheckDigitExtensions_EnsuresValidCheckDigit_ShouldNotThrow_WhenValueHasValidCheckDigit()
   {
      // Arrange.
      var value = "123456789ABC";
      var checkDigitAlgorithm = _alwaysSucceedsAlgorithm;
      var act = () => _ = value.EnsuresValidCheckDigit(checkDigitAlgorithm);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ValidCheckDigitExtensions_EnsuresValidCheckDigit_ShouldThrow_WhenValueHasInvalidCheckDigit()
   {
      // Arrange.
      var value = "123456789ABC";
      var checkDigitAlgorithm = _alwaysFailsAlgorithm;
      var act = () => _ = value.EnsuresValidCheckDigit(checkDigitAlgorithm);

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void ValidCheckDigitExtensions_EnsuresValidCheckDigit_ShouldReturnOriginalValue_WhenValueHasValidCheckDigit()
   {
      // Arrange.
      var value = "123456789ABC";
      var checkDigitAlgorithm = _alwaysSucceedsAlgorithm;

      // Act.
      var result = value.EnsuresValidCheckDigit(checkDigitAlgorithm);

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void ValidCheckDigitExtensions_EnsuresValidCheckDigit_ShouldThrowArgumentNullException_WhenCheckDigitAlgorithmIsNull()
   {
      // Arrange.
      var value = "123456789ABC";
      ICheckDigitAlgorithm checkDigitAlgorithm = null!;
      var act = () => _ = value.EnsuresValidCheckDigit(checkDigitAlgorithm);
      var expectedMessage = Messages.CheckDigitAlgorithmIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(checkDigitAlgorithm))
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void ValidCheckDigitExtensions_EnsuresValidCheckDigit_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = "123456789ABC";
      var checkDigitAlgorithm = _alwaysFailsAlgorithm;
      var act = () => _ = value.EnsuresValidCheckDigit(checkDigitAlgorithm);
      var expectedAlgorithmName = checkDigitAlgorithm.Name;

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.ValidCheckDigit);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.CheckDigitAlgorithm].Should().Be(expectedAlgorithmName);
   }

   [Fact]
   public void ValidCheckDigitExtensions_EnsuresValidCheckDigit_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "123456789ABC";
      var checkDigitAlgorithm = _alwaysFailsAlgorithm;
      var act = () => _ = value.EnsuresValidCheckDigit(checkDigitAlgorithm);
      var expectedMessage = $"Postcondition ValidCheckDigit failed: {nameof(value)} must contain a valid check digit";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void ValidCheckDigitExtensions_EnsuresValidCheckDigit_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "123456789ABC";
      var checkDigitAlgorithm = _alwaysFailsAlgorithm;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresValidCheckDigit(checkDigitAlgorithm, messageTemplate);
      var expectedMessage = $"Requirement ValidCheckDigit failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void ValidCheckDigitExtensions_EnsuresValidCheckDigit_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "123456789ABC";
      var checkDigitAlgorithm = _alwaysFailsAlgorithm;
      var act = () => _ = value.EnsuresValidCheckDigit(checkDigitAlgorithm, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition ValidCheckDigit failed: {nameof(value)} must contain a valid check digit";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void ValidCheckDigitExtensions_EnsuresValidCheckDigit_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "123456789ABC";
      var checkDigitAlgorithm = _alwaysFailsAlgorithm;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresValidCheckDigit(checkDigitAlgorithm, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement ValidCheckDigit failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresValidCheckDigit Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ValidCheckDigitExtensions_RequiresValidCheckDigit_ShouldNotThrow_WhenValueHasValidCheckDigit()
   {
      // Arrange.
      var value = "123456789ABC";
      var checkDigitAlgorithm = _alwaysSucceedsAlgorithm;
      var act = () => _ = value.RequiresValidCheckDigit(checkDigitAlgorithm);

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void ValidCheckDigitExtensions_RequiresValidCheckDigit_ShouldThrow_WhenValueHasInvalidCheckDigit()
   {
      // Arrange.
      var value = "123456789ABC";
      var checkDigitAlgorithm = _alwaysFailsAlgorithm;
      var act = () => _ = value.RequiresValidCheckDigit(checkDigitAlgorithm);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Fact]
   public void ValidCheckDigitExtensions_RequiresValidCheckDigit_ShouldReturnOriginalValue_WhenValueHasValidCheckDigit()
   {
      // Arrange.
      var value = "123456789ABC";
      var checkDigitAlgorithm = _alwaysSucceedsAlgorithm;

      // Act.
      var result = value.RequiresValidCheckDigit(checkDigitAlgorithm);

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void ValidCheckDigitExtensions_RequiresValidCheckDigit_ShouldThrowArgumentNullException_WhenCheckDigitAlgorithmIsNull()
   {
      // Arrange.
      var value = "123456789ABC";
      ICheckDigitAlgorithm checkDigitAlgorithm = null!;
      var act = () => _ = value.RequiresValidCheckDigit(checkDigitAlgorithm);
      var expectedMessage = Messages.CheckDigitAlgorithmIsNull;

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(checkDigitAlgorithm))
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void ValidCheckDigitExtensions_RequiresValidCheckDigit_ShouldThrowWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      var value = "123456789ABC";
      var checkDigitAlgorithm = _alwaysFailsAlgorithm;
      var act = () => _ = value.RequiresValidCheckDigit(checkDigitAlgorithm);
      var expectedAlgorithmName = checkDigitAlgorithm.Name;

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.ValidCheckDigit);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.CheckDigitAlgorithm].Should().Be(expectedAlgorithmName);
   }

   [Fact]
   public void ValidCheckDigitExtensions_RequiresValidCheckDigit_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = "123456789ABC";
      var checkDigitAlgorithm = _alwaysFailsAlgorithm;
      var act = () => _ = value.RequiresValidCheckDigit(checkDigitAlgorithm);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition ValidCheckDigit failed: {nameof(value)} must contain a valid check digit";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void ValidCheckDigitExtensions_RequiresValidCheckDigit_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = "123456789ABC";
      var checkDigitAlgorithm = _alwaysFailsAlgorithm;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresValidCheckDigit(checkDigitAlgorithm, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement ValidCheckDigit failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void ValidCheckDigitExtensions_RequiresValidCheckDigit_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "123456789ABC";
      var checkDigitAlgorithm = _alwaysFailsAlgorithm;
      var act = () => _ = value.RequiresValidCheckDigit(checkDigitAlgorithm, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition ValidCheckDigit failed: {nameof(value)} must contain a valid check digit";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void ValidCheckDigitExtensions_RequiresValidCheckDigit_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "123456789ABC";
      var checkDigitAlgorithm = _alwaysFailsAlgorithm;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresValidCheckDigit(checkDigitAlgorithm, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement ValidCheckDigit failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
