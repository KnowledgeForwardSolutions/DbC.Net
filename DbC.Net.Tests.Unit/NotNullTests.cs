namespace DbC.Net.Tests.Unit;

public class NotNullTests
{
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
   public void NotNull_RequiresNotNull_ShouldThrow_WhenValueIsReferenceTypeAndIsDefault()
   {
      // Arrange.
      var value = default(String);
      var act = () => _ = value.RequiresNotNull();

      // Act/assert.
      act.Should().Throw<ArgumentNullException>();
   }

   [Fact]
   public void NotNull_RequiresNotNull_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenAllDefaultsUsed()
   {
      // Arrange.
      var value = default(String);
      var act = () => _ = value.RequiresNotNull();
      var expectedParameterName = nameof(value);
      var expectedMessage = "Precondition NotNull failed: value may not be null";

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion
}
