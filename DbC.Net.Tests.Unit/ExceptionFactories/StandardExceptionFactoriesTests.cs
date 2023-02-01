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

   #region FormatExceptionFactory Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardExceptionFactories_FormatExceptionFactory_ShouldNotBeNull()
      => StandardExceptionFactories.FormatExceptionFactory.Should().NotBeNull();

   [Fact]
   public void StandardExceptionFactories_FormatExceptionFactory_ShouldNotTransformDataDictionaryValues()
   {
      // Arrange.
      var sut = StandardExceptionFactories.FormatExceptionFactory;
      IReadOnlyDictionary<String, Object> data = new Dictionary<String, Object>() {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, "True" },
         { DataNames.Value, "a.b" },
         { DataNames.ValueExpression, "threePartName" } };
      var messageTemplate = "Value ({Value}) is not formatted properly";

      var expectedMessage = "Value (a.b) is not formatted properly";

      // Act.
      var ex = sut.CreateException(data, messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<FormatException>();
      ex.Message.Should().StartWith(expectedMessage);

      ex.Data.Count.Should().Be(data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(data[DataNames.Value]);
      ex.Data[DataNames.ValueExpression].Should().Be(data[DataNames.ValueExpression]);
   }

   #endregion

   #region InvalidOperationExceptionFactory Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardExceptionFactories_InvalidOperationExceptionFactory_ShouldNotBeNull()
      => StandardExceptionFactories.InvalidOperationExceptionFactory.Should().NotBeNull();

   [Fact]
   public void StandardExceptionFactories_InvalidOperationExceptionFactory_ShouldNotTransformDataDictionaryValues()
   {
      // Arrange.
      var sut = StandardExceptionFactories.InvalidOperationExceptionFactory;
      IReadOnlyDictionary<String, Object> data = new Dictionary<String, Object>() {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, "RegexMatch" },
         { DataNames.Value, "asdf" },
         { DataNames.ValueExpression, "apiResponse" },
         { DataNames.Regex, @"\b[M]\w+" } };
      var messageTemplate = "{RequirementType} {RequirementName} failed: value (\"{Value}\") is not a word that starts with 'M'";

      var expectedMessage = "Precondition RegexMatch failed: value (\"asdf\") is not a word that starts with 'M'";

      // Act.
      var ex = sut.CreateException(data, messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<InvalidOperationException>();
      ex.Message.Should().StartWith(expectedMessage);

      ex.Data.Count.Should().Be(data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(data[DataNames.Value]);
      ex.Data[DataNames.ValueExpression].Should().Be(data[DataNames.ValueExpression]);
      ex.Data[DataNames.Regex].Should().Be(data[DataNames.Regex]);
   }

   #endregion

   #region NotSupportedExceptionFactory Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardExceptionFactories_NotSupportedExceptionFactory_ShouldNotBeNull()
      => StandardExceptionFactories.NotSupportedExceptionFactory.Should().NotBeNull();

   [Fact]
   public void StandardExceptionFactories_NotSupportedExceptionFactory_ShouldNotTransformDataDictionaryValues()
   {
      // Arrange.
      var sut = StandardExceptionFactories.NotSupportedExceptionFactory;
      IReadOnlyDictionary<String, Object> data = new Dictionary<String, Object>() {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, "Equal" },
         { DataNames.Value, 0 },
         { DataNames.ValueExpression, "value" } };
      var messageTemplate = "{RequirementType} {RequirementName} failed: operation is not defined for {Value}";

      var expectedMessage = "Precondition Equal failed: operation is not defined for 0";

      // Act.
      var ex = sut.CreateException(data, messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<NotSupportedException>();
      ex.Message.Should().StartWith(expectedMessage);

      ex.Data.Count.Should().Be(data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(data[DataNames.Value]);
      ex.Data[DataNames.ValueExpression].Should().Be(data[DataNames.ValueExpression]);
   }

   #endregion

   #region PostconditionFailedExceptionFactory Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardExceptionFactories_PostconditionFailedExceptionFactory_ShouldNotBeNull()
      => StandardExceptionFactories.PostconditionFailedExceptionFactory.Should().NotBeNull();

   [Fact]
   public void StandardExceptionFactories_PostconditionFailedExceptionFactory_ShouldNotTransformDataDictionaryValues()
   {
      // Arrange.
      var sut = StandardExceptionFactories.PostconditionFailedExceptionFactory;
      IReadOnlyDictionary<String, Object> data = new Dictionary<String, Object>() {
         { DataNames.RequirementType, RequirementType.Postcondition },
         { DataNames.RequirementName, "True" },
         { DataNames.Value, 17 },
         { DataNames.ValueExpression, "result" } };
      var messageTemplate = "{RequirementType} {RequirementName} failed: value ({Value}) is not an even integer";

      var expectedMessage = "Postcondition True failed: value (17) is not an even integer";

      // Act.
      var ex = sut.CreateException(data, messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<PostconditionFailedException>();
      ex.Message.Should().StartWith(expectedMessage);

      ex.Data.Count.Should().Be(data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(data[DataNames.Value]);
      ex.Data[DataNames.ValueExpression].Should().Be(data[DataNames.ValueExpression]);
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

   #region SecureInvalidOperationExceptionFactory Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardExceptionFactories_SecureInvalidOperationExceptionFactory_ShouldNotBeNull()
      => StandardExceptionFactories.SecureInvalidOperationExceptionFactory.Should().NotBeNull();

   [Fact]
   public void StandardExceptionFactories_SecureInvalidOperationExceptionFactory_ShouldNotTransformDataDictionaryValues()
   {
      // Arrange.
      var sut = StandardExceptionFactories.SecureInvalidOperationExceptionFactory;
      IReadOnlyDictionary<String, Object> data = new Dictionary<String, Object>() {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, "RegexMatch" },
         { DataNames.Value, "asdf" },
         { DataNames.ValueExpression, "apiResponse" },
         { DataNames.Regex, @"\b[M]\w+" } };
      var messageTemplate = "{RequirementType} {RequirementName} failed: value (\"{Value}\") is not a word that starts with 'M'";

      var expectedValue = "****";
      var expectedMessage = "Precondition RegexMatch failed: value (\"****\") is not a word that starts with 'M'";

      // Act.
      var ex = sut.CreateException(data, messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<InvalidOperationException>();
      ex.Message.Should().StartWith(expectedMessage);

      ex.Data.Count.Should().Be(data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(expectedValue);
      ex.Data[DataNames.ValueExpression].Should().Be(data[DataNames.ValueExpression]);
      ex.Data[DataNames.Regex].Should().Be(data[DataNames.Regex]);
   }

   #endregion

   #region SecureNotSupportedExceptionFactory Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardExceptionFactories_SecureNotSupportedExceptionFactory_ShouldNotBeNull()
      => StandardExceptionFactories.SecureNotSupportedExceptionFactory.Should().NotBeNull();

   [Fact]
   public void StandardExceptionFactories_SecureNotSupportedExceptionFactory_ShouldNotTransformDataDictionaryValues()
   {
      // Arrange.
      var sut = StandardExceptionFactories.SecureNotSupportedExceptionFactory;
      IReadOnlyDictionary<String, Object> data = new Dictionary<String, Object>() {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, "Equal" },
         { DataNames.Value, 0 },
         { DataNames.ValueExpression, "value" } };
      var messageTemplate = "{RequirementType} {RequirementName} failed: operation is not defined for {Value}";

      var expectedValue = "*";
      var expectedMessage = "Precondition Equal failed: operation is not defined for *";

      // Act.
      var ex = sut.CreateException(data, messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<NotSupportedException>();
      ex.Message.Should().StartWith(expectedMessage);

      ex.Data.Count.Should().Be(data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(expectedValue);
      ex.Data[DataNames.ValueExpression].Should().Be(data[DataNames.ValueExpression]);
   }

   #endregion

   #region SecurePostconditionFailedExceptionFactory Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardExceptionFactories_SecurePostconditionFailedExceptionFactory_ShouldNotBeNull()
      => StandardExceptionFactories.SecurePostconditionFailedExceptionFactory.Should().NotBeNull();

   [Fact]
   public void StandardExceptionFactories_SecurePostconditionFailedExceptionFactory_ShouldNotTransformDataDictionaryValues()
   {
      // Arrange.
      var sut = StandardExceptionFactories.SecurePostconditionFailedExceptionFactory;
      IReadOnlyDictionary<String, Object> data = new Dictionary<String, Object>() {
         { DataNames.RequirementType, RequirementType.Postcondition },
         { DataNames.RequirementName, "True" },
         { DataNames.Value, 17 },
         { DataNames.ValueExpression, "result" } };
      var messageTemplate = "{RequirementType} {RequirementName} failed: value ({Value}) is not an even integer";

      var expectedValue = "**";
      var expectedMessage = "Postcondition True failed: value (**) is not an even integer";

      // Act.
      var ex = sut.CreateException(data, messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<PostconditionFailedException>();
      ex.Message.Should().StartWith(expectedMessage);

      ex.Data.Count.Should().Be(data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(expectedValue);
      ex.Data[DataNames.ValueExpression].Should().Be(data[DataNames.ValueExpression]);
   }

   #endregion
}
