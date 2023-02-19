namespace DbC.Net.Tests.Unit;

public class NotEqualExtensionsTests
{
   private const Int32 _dataCount = 6;
   private const Int32 _stringDataCount = 7;

   #region RequiresNotEqual (IEquatable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldReturnOriginalValue_WhenValueDoesNotEqualTarget<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      var target = data.NotEqualValue;

      // Act.
      var result = value.RequiresNotEqual(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldReturnOriginalValue_WhenValueIsDefaultAndTargetIsNot<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      T value = default!;
      var target = data.NonDefaultNotEqualValue;

      // Act.
      var result = value.RequiresNotEqual(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldReturnOriginalValue_WhenValueIsNotDefaultAndTargetIs<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      T target = default!;

      // Act.
      var result = value.RequiresNotEqual(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldThrow_WhenValueEqualsTarget<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      var target = data.EqualValue;
      var act = () => _ = value.RequiresNotEqual(target);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldThrow_WhenValueAndTargetAreDefault<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      T value = default!;
      T target = default!;
      var act = () => _ = value.RequiresNotEqual(target);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldThrowWithExpectedDataDictionary_WhenValueEqualsTarget()
   {
      // Arrange.
      var value = 100;
      var target = value;
      var act = () => _ = value.RequiresNotEqual(target);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldThrowArgumentExceptionWithExpectedMessage_WhenValueEqualsTarget()
   {
      // Arrange.
      var value = StringData.UpperCaseAE;
      var target = StringData.UpperCaseAE;
      var act = () => _ = value.RequiresNotEqual(target);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition NotEqual failed: {nameof(value)} must not be equal to {target}";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldThrowArgumentExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = new ObservationClassData().EqualValue;
      var target = new ObservationClassData().EqualValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotEqual(target, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement NotEqual failed";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = Double.Pi;
      var target = Double.Pi;
      var act = () => _ = value.RequiresNotEqual(target, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition NotEqual failed: {nameof(value)} must not be equal to {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldThrowCustomExceptionWithExpectedMessageWhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = new PointStructData().EqualValue;
      var target = new PointStructData().EqualValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotEqual(target, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotEqual failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion
}
