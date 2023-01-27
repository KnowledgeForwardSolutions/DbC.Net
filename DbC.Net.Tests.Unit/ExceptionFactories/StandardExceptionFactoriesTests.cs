namespace DbC.Net.Tests.Unit.ExceptionFactories;

public class StandardExceptionFactoriesTests
{
   #region ArgumentExceptionFactory Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardExceptionFactories_ArgumentExceptionFactory_ShouldNotBeNull()
      => StandardExceptionFactories.ArgumentExceptionFactory.Should().NotBeNull();

   [Fact]
   public void StandardExceptionFactories_ArgumentExceptionFactory_ShouldNotTransformDataDictionaryValues()
   {
      // Arrange.
      var sut = StandardExceptionFactories.ArgumentExceptionFactory;
      IReadOnlyDictionary<String, Object> data = new Dictionary<String, Object>() {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, "MinLength" },
         { DataNames.Value, "Ab" },
         { DataNames.ValueExpression, "firstName.EnsuresNotNull()" },
         { DataNames.MinLength, 5 },
         { DataNames.MinLengthExpression, "5" } };
      var messageTemplate = "Value ({Value}) is not long enough";

      var expectedMessage = "Value (Ab) is not long enough";

      // Act.
      var ex = sut.CreateException(data, messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<ArgumentException>();
      ex.Message.Should().StartWith(expectedMessage);

      ex.Data.Count.Should().Be(data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(data[DataNames.Value]);
      ex.Data[DataNames.ValueExpression].Should().Be(data[DataNames.ValueExpression]);
      ex.Data[DataNames.MinLength].Should().Be(data[DataNames.MinLength]);
      ex.Data[DataNames.MinLengthExpression].Should().Be(data[DataNames.MinLengthExpression]);
   }

   #endregion

   #region SecureArgumentExceptionFactory Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardExceptionFactories_SecureArgumentExceptionFactory_ShouldNotBeNull()
      => StandardExceptionFactories.SecureArgumentExceptionFactory.Should().NotBeNull();

   [Fact]
   public void StandardExceptionFactories_SecureArgumentExceptionFactory_ShouldNotTransformDataDictionaryValues()
   {
      // Arrange.
      var sut = StandardExceptionFactories.SecureArgumentExceptionFactory;
      IReadOnlyDictionary<String, Object> data = new Dictionary<String, Object>() {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, "MinLength" },
         { DataNames.Value, "Ab" },
         { DataNames.ValueExpression, "firstName.EnsuresNotNull()" },
         { DataNames.MinLength, 5 },
         { DataNames.MinLengthExpression, "5" } };
      var messageTemplate = "Value ({Value}) is not long enough";

      var expectedValue = "**";
      var expectedMessage = "Value (**) is not long enough";

      // Act.
      var ex = sut.CreateException(data, messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<ArgumentException>();
      ex.Message.Should().StartWith(expectedMessage);

      ex.Data.Count.Should().Be(data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(expectedValue);
      ex.Data[DataNames.ValueExpression].Should().Be(data[DataNames.ValueExpression]);
      ex.Data[DataNames.MinLength].Should().Be(data[DataNames.MinLength]);
      ex.Data[DataNames.MinLengthExpression].Should().Be(data[DataNames.MinLengthExpression]);
   }

   #endregion
}
