using DbC.Net.Tests.Unit.TestData;

namespace DbC.Net.Tests.Unit;

public class NotNullTests
{
   #region EnsuresNotNull Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void NotNull_EnsuresNotNull_ShouldReturnOriginalValue_WhenValueIsValueTypeAndDefault()
   {
      // Arrange.
      var value = default(Int32);

      // Act.
      var result = value.EnsuresNotNull();

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void NotNull_EnsuresNotNull_ShouldReturnOriginalValue_WhenValueIsValueTypeAndIsNotDefault()
   {
      // Arrange.
      var value = 42;

      // Act.
      var result = value.EnsuresNotNull();

      // Assert.
      result.Should().Be(value);
   }

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
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void NotNull_EnsuresNotNull_ShouldThrow_WhenValueIsReferenceTypeAndIsDefault()
   {
      // Arrange.
      var value = default(List<Double>);
      var act = () => _ = value.EnsuresNotNull();

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void NotNull_EnsuresNotNull_ShouldThrowExceptionWithExpectedDataDictionary_WhenValueIsReferenceTypeAndIsDefault()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresNotNull();

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(3);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(nameof(NotNull));
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void NotNull_EnsuresNotNull_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenAllDefaultsUsed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresNotNull();
      var expectedMessage = "Postcondition NotNull failed: value may not be null";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotNull_EnsuresNotNull_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotNull(messageTemplate);
      var expectedMessage = "Requirement NotNull failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotNull_EnsuresNotNull_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresNotNull(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = "Postcondition NotNull failed: value may not be null";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotNull_EnsuresNotNull_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotNull(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = "Requirement NotNull failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

   #region RequiresNotNull Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void NotNull_RequiresNotNull_ShouldReturnOriginalValue_WhenValueIsValueTypeAndDefault()
   {
      // Arrange.
      var value = default(Int32);

      // Act.
      var result = value.RequiresNotNull();

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void NotNull_RequiresNotNull_ShouldReturnOriginalValue_WhenValueIsValueTypeAndIsNotDefault()
   {
      // Arrange.
      var value = 42;

      // Act.
      var result = value.RequiresNotNull();

      // Assert.
      result.Should().Be(value);
   }

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
      act.Should().Throw<ArgumentNullException>();
   }

   [Fact]
   public void NotNull_RequiresNotNull_ShouldThrow_WhenValueIsReferenceTypeAndIsDefault()
   {
      // Arrange.
      var value = default(List<Double>);
      var act = () => _ = value.RequiresNotNull();

      // Act/assert.
      act.Should().Throw<ArgumentNullException>();
   }

   [Fact]
   public void NotNull_RequiresNotNull_ShouldThrowExceptionWithExpectedDataDictionary_WhenValueIsReferenceTypeAndIsDefault()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotNull();

      // Act/assert.
      var ex = act.Should().Throw<ArgumentNullException>().Which;

      ex.Data.Count.Should().Be(3);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(nameof(NotNull));
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void NotNull_RequiresNotNull_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenAllDefaultsUsed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotNull();
      var expectedParameterName = nameof(value);
      var expectedMessage = "Precondition NotNull failed: value may not be null";

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotNull_RequiresNotNull_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotNull(messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = "Requirement NotNull failed";

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotNull_RequiresNotNull_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotNull(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = "Precondition NotNull failed: value may not be null";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotNull_RequiresNotNull_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotNull(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = "Requirement NotNull failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion
}
