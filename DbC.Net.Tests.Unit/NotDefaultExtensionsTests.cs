namespace DbC.Net.Tests.Unit;

public class NotDefaultExtensionsTests
{
   private const Int32 _dataCount = 4;

   #region EnsuresNotDefault Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void NotDefault_EnsuresNotDefault_ShouldReturnOriginalValue_WhenValueIsValueTypeAndNotDefault()
   {
      // Arrange.
      var value = Single.Pi;

      // Act.
      var result = value.EnsuresNotDefault();

      // Assert.
      result.Should().Be(value);
   }

   [Fact]
   public void NotDefault_EnsuresNotDefault_ShouldReturnOriginalValue_WhenValueIsReferenceTypeAndIsNotDefault()
   {
      // Arrange.
      var value = new List<Int32> { 1, 2, 3 };

      // Act.
      var result = value.EnsuresNotDefault();

      // Assert.
      result.Should().BeSameAs(value);
   }

   [Fact]
   public void NotDefault_EnsuresNotDefault_ShouldThrow_WhenValueIsValueTypeAndIsDefault()
   {
      // Arrange.
      var value = default(SByte);
      var act = () => _ = value.EnsuresNotDefault();

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void NotDefault_EnsuresNotDefault_ShouldThrow_WhenValueIsReferenceTypeAndIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresNotDefault();

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void NotDefault_EnsuresNotDefault_ShouldThrow_WhenValueIsReferenceTypeAndIsDefault()
   {
      // Arrange.
      var value = default(List<Double>);
      var act = () => _ = value.EnsuresNotDefault();

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>();
   }

   [Fact]
   public void NotDefault_EnsuresNotDefault_ShouldThrowExceptionWithExpectedDataDictionary_WhenValueIsValueTypeAndIsDefault()
   {
      // Arrange.
      Char value = default;
      var act = () => _ = value.EnsuresNotDefault();

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotDefault);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.ValueDatatype].Should().Be(nameof(Char));
   }

   [Fact]
   public void NotDefault_EnsuresNotDefault_ShouldThrowExceptionWithExpectedDataDictionary_WhenValueIsReferenceTypeAndIsNull()
   {
      // Arrange.
      ICollection<DateTime> value = null!;
      var act = () => _ = value.EnsuresNotDefault();

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotDefault);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.ValueDatatype].Should().Be("ICollection`1");
   }

   [Fact]
   public void NotDefault_EnsuresNotDefault_ShouldThrowExceptionWithExpectedDataDictionary_WhenValueIsReferenceTypeAndIsDefault()
   {
      // Arrange.
      String value = default!;
      var act = () => _ = value.EnsuresNotDefault();

      // Act/assert.
      var ex = act.Should().ThrowExactly<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotDefault);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.ValueDatatype].Should().Be(nameof(String));
   }

   [Fact]
   public void NotDefault_EnsuresNotDefault_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      String value = default!;
      var act = () => _ = value.EnsuresNotDefault();
      var expectedMessage = "Postcondition NotDefault failed: value may not be default(String)";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotDefault_EnsuresNotDefault_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotDefault(messageTemplate);
      var expectedMessage = "Requirement NotDefault failed";

      // Act/assert.
      act.Should().ThrowExactly<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotDefault_EnsuresNotDefault_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      Single value = default;
      var act = () => _ = value.EnsuresNotDefault(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = "Postcondition NotDefault failed: value may not be default(Single)";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotDefault_EnsuresNotDefault_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      Point value = default;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotDefault(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = "Requirement NotDefault failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

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
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrow_WhenValueIsReferenceTypeAndIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotDefault();

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrow_WhenValueIsReferenceTypeAndIsDefault()
   {
      // Arrange.
      var value = default(List<Double>);
      var act = () => _ = value.RequiresNotDefault();

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>();
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrowExceptionWithExpectedDataDictionary_WhenValueIsValueTypeAndIsDefault()
   {
      // Arrange.
      Char value = default;
      var act = () => _ = value.RequiresNotDefault();

      // Act/assert.
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotDefault);
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
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotDefault);
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
      var ex = act.Should().ThrowExactly<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotDefault);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.ValueDatatype].Should().Be(nameof(String));
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndAllDefaultsAreUsed()
   {
      // Arrange.
      String value = default!;
      var act = () => _ = value.RequiresNotDefault();
      var expectedParameterName = nameof(value);
      var expectedMessage = "Precondition NotDefault failed: value may not be default(String)";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrowArgumentExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotDefault(messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = "Requirement NotDefault failed";

      // Act/assert.
      act.Should().ThrowExactly<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      Single value = default;
      var act = () => _ = value.RequiresNotDefault(exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = "Precondition NotDefault failed: value may not be default(Single)";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotDefault_RequiresNotDefault_ShouldThrowCustomExceptionWithExpectedMessage_WhenRequirementIsFailedAndCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      Point value = default;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotDefault(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = "Requirement NotDefault failed";

      // Act/assert.
      act.Should().ThrowExactly<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion
}
