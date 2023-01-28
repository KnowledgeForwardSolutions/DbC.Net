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

   #region ArgumentNullExceptionFactory Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardExceptionFactories_ArgumentNullExceptionFactory_ShouldNotBeNull()
      => StandardExceptionFactories.ArgumentNullExceptionFactory.Should().NotBeNull();

   [Fact]
   public void StandardExceptionFactories_ArgumentNullExceptionFactory_ShouldNotTransformDataDictionaryValues()
   {
      // Arrange.
      var sut = StandardExceptionFactories.ArgumentNullExceptionFactory;
      IReadOnlyDictionary<String, Object> data = new Dictionary<String, Object>() {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, "NotNull" },
         { DataNames.ValueExpression, "x" } };
      var messageTemplate = "{ValueExpression} may not be null";

      var expectedMessage = "x may not be null";

      // Act.
      var ex = sut.CreateException(data, messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<ArgumentNullException>();
      ex.Message.Should().StartWith(expectedMessage);

      ex.Data.Count.Should().Be(data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(data[DataNames.RequirementName]);
      ex.Data[DataNames.ValueExpression].Should().Be(data[DataNames.ValueExpression]);
   }

   #endregion

   #region ArgumentOutOfRangeExceptionFactory Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardExceptionFactories_ArgumentOutOfRangeExceptionFactory_ShouldNotBeNull()
      => StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory.Should().NotBeNull();

   [Fact]
   public void StandardExceptionFactories_ArgumentOutOfRangeExceptionFactory_ShouldNotTransformDataDictionaryValues()
   {
      // Arrange.
      var sut = StandardExceptionFactories.ArgumentOutOfRangeExceptionFactory;
      IReadOnlyDictionary<String, Object> data = new Dictionary<String, Object>() {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, "GreaterThan" },
         { DataNames.Value, 99.9 },
         { DataNames.ValueExpression, "sum" },
         { DataNames.Limit, 100.0 },
         { DataNames.LimitExpression, "lowerBound" } };
      var messageTemplate = "{RequirementType} {RequirementName} failed: value ({Value}) is not greater than {Limit}";

      var expectedMessage = "Precondition GreaterThan failed: value (99.9) is not greater than 100";

      // Act.
      var ex = sut.CreateException(data, messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<ArgumentOutOfRangeException>();
      ex.Message.Should().StartWith(expectedMessage);

      ex.Data.Count.Should().Be(data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(data[DataNames.Value]);
      ex.Data[DataNames.ValueExpression].Should().Be(data[DataNames.ValueExpression]);
      ex.Data[DataNames.Limit].Should().Be(data[DataNames.Limit]);
      ex.Data[DataNames.LimitExpression].Should().Be(data[DataNames.LimitExpression]);
   }

   #endregion

   #region SecureArgumentExceptionFactory Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardExceptionFactories_SecureArgumentExceptionFactory_ShouldNotBeNull()
      => StandardExceptionFactories.SecureArgumentExceptionFactory.Should().NotBeNull();

   [Fact]
   public void StandardExceptionFactories_SecureArgumentExceptionFactory_ShouldTransformDataDictionaryValues()
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

   #region SecureArgumentOutOfRangeExceptionFactory Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardExceptionFactories_SecureArgumentOutOfRangeExceptionFactory_ShouldNotBeNull()
      => StandardExceptionFactories.SecureArgumentOutOfRangeExceptionFactory.Should().NotBeNull();

   [Fact]
   public void StandardExceptionFactories_SecureArgumentOutOfRangeExceptionFactory_ShouldTransformDataDictionaryValues()
   {
      // Arrange.
      var sut = StandardExceptionFactories.SecureArgumentOutOfRangeExceptionFactory;
      IReadOnlyDictionary<String, Object> data = new Dictionary<String, Object>() {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, "GreaterThan" },
         { DataNames.Value, 99.9 },
         { DataNames.ValueExpression, "sum" },
         { DataNames.Limit, 100.0 },
         { DataNames.LimitExpression, "lowerBound" } };
      var messageTemplate = "{RequirementType} {RequirementName} failed: value ({Value}) is not greater than {Limit}";

      var expectedValue = "****";
      var expectedMessage = "Precondition GreaterThan failed: value (****) is not greater than 100";

      // Act.
      var ex = sut.CreateException(data, messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<ArgumentOutOfRangeException>();
      ex.Message.Should().StartWith(expectedMessage);

      ex.Data.Count.Should().Be(data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(expectedValue);
      ex.Data[DataNames.ValueExpression].Should().Be(data[DataNames.ValueExpression]);
      ex.Data[DataNames.Limit].Should().Be(data[DataNames.Limit]);
      ex.Data[DataNames.LimitExpression].Should().Be(data[DataNames.LimitExpression]);
   }

   #endregion
}
