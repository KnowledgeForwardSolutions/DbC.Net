using DbC.Net.Tests.Unit.TestData;

namespace DbC.Net.Tests.Unit;

public class NotDefaultTests
{
   #region RequiresNotDefault Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldReturnOriginalValue_WhenValueIsValueTypeAndNotDefault()
   {
      // Arrange.
      var value = Single.Pi;

      // Act.
      var result = value.RequiresNotDefault();

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldReturnOriginalValue_WhenValueIsReferenceTypeAndIsNotDefault()
   {
      // Arrange.
      var value = new List<Int32> { 1, 2, 3 };

      // Act.
      var result = value.RequiresNotDefault();

      // Assert.
      result.Should().BeSameAs(value);
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrow_WhenValueIsValueTypeAndIsDefault()
   {
      // Arrange.
      var value = default(SByte);
      var act = () => _ = value.RequiresNotDefault();

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrow_WhenValueIsReferenceTypeAndIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotDefault();

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrow_WhenValueIsReferenceTypeAndIsDefault()
   {
      // Arrange.
      var value = default(List<Double>);
      var act = () => _ = value.RequiresNotDefault();

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrowExceptionWithExpectedDataDictionary_WhenValueIsValueTypeAndIsDefault()
   {
      // Arrange.
      Char value = default;
      var act = () => _ = value.RequiresNotDefault();

      // Act/assert.
      var ex = act.Should().Throw<ArgumentException>().Which;

      ex.Data.Count.Should().Be(4);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(nameof(NotDefault));
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.ValueDatatype].Should().Be(nameof(Char));
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrowExceptionWithExpectedDataDictionary_WhenValueIsReferenceTypeAndIsNull()
   {
      // Arrange.
      ICollection<DateTime> value = null!;
      var act = () => _ = value.RequiresNotDefault();

      // Act/assert.
      var ex = act.Should().Throw<ArgumentException>().Which;

      ex.Data.Count.Should().Be(4);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(nameof(NotDefault));
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.ValueDatatype].Should().Be("ICollection`1");
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrowExceptionWithExpectedDataDictionary_WhenValueIsReferenceTypeAndIsDefault()
   {
      // Arrange.
      String value = default!;
      var act = () => _ = value.RequiresNotDefault();

      // Act/assert.
      var ex = act.Should().Throw<ArgumentException>().Which;

      ex.Data.Count.Should().Be(4);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(nameof(NotDefault));
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.ValueDatatype].Should().Be(nameof(String));
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrowArgumentExceptionWithExpectedMessage_WhenAllDefaultsUsed()
   {
      // Arrange.
      String value = default!;
      var act = () => _ = value.RequiresNotDefault();
      var expectedParameterName = nameof(value);
      var expectedMessage = "Precondition NotDefault failed: value may not be default(String)";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotDefault(messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = "Requirement NotDefault failed";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      Single value = default;
      var act = () => _ = value.RequiresNotDefault(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = "Precondition NotDefault failed: value may not be default(Single)";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      PointStruct value = default;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotDefault(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = "Requirement NotDefault failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion
}
