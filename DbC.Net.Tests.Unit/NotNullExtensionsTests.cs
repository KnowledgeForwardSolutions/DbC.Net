﻿namespace DbC.Net.Tests.Unit;

public class NotNullExtensionsTests
{
   private const Int32 _dataCount = 3;

   #region EnsuresNotNull Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void NotNull_EnsuresNotNull_ShouldReturnOriginalValue_WhenValueIsReferenceTypeAndIsNotDefault()
   {
      // Arrange.
      var value = "This is a test";

      // Act.
      var result = value.EnsuresNotNull();

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void NotNull_EnsuresNotNull_ShouldThrow_WhenValueIsReferenceTypeAndIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresNotNull();

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void NotNull_EnsuresNotNull_ShouldThrow_WhenValueIsReferenceTypeAndIsDefault()
   {
      // Arrange.
      List<Double> value = default!;
      var act = () => _ = value.EnsuresNotNull();

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void NotNull_EnsuresNotNull_ShouldThrowExceptionWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresNotNull();

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotNull);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void NotNull_EnsuresNotNull_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresNotNull();
      var expectedMessage = "Postcondition NotNull failed: value may not be null";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void NotNull_EnsuresNotNull_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotNull(messageTemplate);
      var expectedMessage = "Requirement NotNull failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void NotNull_EnsuresNotNull_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresNotNull(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = "Postcondition NotNull failed: value may not be null";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void NotNull_EnsuresNotNull_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotNull(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = "Requirement NotNull failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion

   #region RequiresNotNull Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void NotNull_RequiresNotNull_ShouldReturnOriginalValue_WhenValueIsReferenceTypeAndIsNotDefault()
   {
      // Arrange.
      var value = "This is a test";

      // Act.
      var result = value.RequiresNotNull();

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void NotNull_RequiresNotNull_ShouldThrow_WhenValueIsReferenceTypeAndIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotNull();

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>();
   }

   [Fact]
   public void NotNull_RequiresNotNull_ShouldThrow_WhenValueIsReferenceTypeAndIsDefault()
   {
      // Arrange.
      List<Double> value = default!;
      var act = () => _ = value.RequiresNotNull();

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>();
   }

   [Fact]
   public void NotNull_RequiresNotNull_ShouldThrowExceptionWithExpectedDataDictionary_WhenRequirementIsFailed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotNull();

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentNullException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotNull);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void NotNull_RequiresNotNull_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotNull();
      var expectedParameterName = nameof(value);
      var expectedMessage = "Precondition NotNull failed: value may not be null";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void NotNull_RequiresNotNull_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotNull(messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = "Requirement NotNull failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void NotNull_RequiresNotNull_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotNull(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = "Precondition NotNull failed: value may not be null";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   [Fact]
   public void NotNull_RequiresNotNull_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotNull(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = "Requirement NotNull failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .WithMessage(expectedMessage);
   }

   #endregion
}
