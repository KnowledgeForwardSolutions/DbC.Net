namespace DbC.Net.Tests.Unit.ExceptionFactories;

public class ArgumentOutOfRangeExceptionFactoryTests
{
   private readonly Dictionary<String, Object> _data = new() {
      { DataNames.RequirementType, RequirementType.Precondition },
      { DataNames.RequirementName, "GreaterThan" },
      { DataNames.Value, 99.9 },
      { DataNames.ValueExpression, "sum" },
      { DataNames.Limit, 100.0 },
      { DataNames.LimitExpression, "lowerBound" } };

   #region Instance Property Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ArgumentOutOfRangeExceptionFactory_Instance_ShouldNotBeNull() =>
       ArgumentOutOfRangeExceptionFactory.Instance.Should().NotBeNull();

   #endregion

   #region CreateException Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ArgumentOutOfRangeExceptionFactory_CreateException_ShouldCreateExpectedException_WhenAllValuesSupplied()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: value ({Value}) is not greater than {Limit}";

      var sut = ArgumentOutOfRangeExceptionFactory.Instance;

      var expectedMessage = "Precondition GreaterThan failed: value (99.9) is not greater than 100";
      var expectedParamName = "sum";

      // Act.
      var ex = sut.CreateException(_data, messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<ArgumentOutOfRangeException>();
      ex.Message.Should().StartWith(expectedMessage);
      ex.ParamName.Should().Be(expectedParamName);
      ex.ActualValue.Should().Be(_data[DataNames.Value]);

      ex.Data.Count.Should().Be(_data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(_data[DataNames.Value]);
      ex.Data[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
      ex.Data[DataNames.Limit].Should().Be(_data[DataNames.Limit]);
      ex.Data[DataNames.LimitExpression].Should().Be(_data[DataNames.LimitExpression]);
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void ArgumentOutOfRangeExceptionFactory_CreateException_ShouldThrowArgumentException_WhenMessageTemplateIsEmpty(String messageTemplate)
   {
      // Arrange.
      var sut = ArgumentOutOfRangeExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(_data, messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void ArgumentOutOfRangeExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenMessageTemplateIsNull()
   {
      // Arrange.
      String messageTemplate = null!;
      var sut = ArgumentOutOfRangeExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(_data, messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void ArgumentOutOfRangeExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenDataDictionaryIsNull()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: value ({Value}) is not greater than {Limit}";
      Dictionary<String, Object> data = null!;
      var sut = ArgumentOutOfRangeExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(data, messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(data))
         .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
   }

   #endregion
}
