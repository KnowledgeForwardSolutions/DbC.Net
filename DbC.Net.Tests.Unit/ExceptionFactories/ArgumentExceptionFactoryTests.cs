namespace DbC.Net.Tests.Unit.ExceptionFactories;

public class ArgumentExceptionFactoryTests
{
   private readonly Dictionary<String, Object> _data = new() {
      { DataNames.RequirementType, RequirementType.Postcondition },
      { DataNames.RequirementName, "MinLength" },
      { DataNames.Value, String.Empty },
      { DataNames.ValueExpression, "text.EnsuresNotNull()" },
      { DataNames.MinLength, 8 },
      { DataNames.MinLengthExpression, "8" } };

   #region Instance Property Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ArgumentExceptionFactory_Instance_ShouldNotBeNull() =>
       ArgumentExceptionFactory.Instance.Should().NotBeNull();

   #endregion

   #region CreateException Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ArgumentExceptionFactory_CreateException_ShouldCreateExpectedException_WhenAllValuesSupplied()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: value (\"{Value}\") does not meet minimum length of {MinLength}";

      var sut = ArgumentExceptionFactory.Instance;

      var expectedMessage = "Postcondition MinLength failed: value (\"\") does not meet minimum length of 8";
      var expectedParamName = "text";

      // Act.
      var ex = sut.CreateException(messageTemplate, _data);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<ArgumentException>();
      ex.Message.Should().StartWith(expectedMessage);
      ex.ParamName.Should().Be(expectedParamName);

      ex.Data.Count.Should().Be(_data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(_data[DataNames.Value]);
      ex.Data[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
      ex.Data[DataNames.MinLength].Should().Be(_data[DataNames.MinLength]);
      ex.Data[DataNames.MinLengthExpression].Should().Be(_data[DataNames.MinLengthExpression]);
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void ArgumentExceptionFactory_CreateException_ShouldThrowArgumentException_WhenMessageTemplateIsEmpty(String messageTemplate)
   {
      // Arrange.
      var sut = ArgumentExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(messageTemplate, _data);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void ArgumentExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenMessageTemplateIsNull()
   {
      // Arrange.
      String messageTemplate = null!;
      var sut = ArgumentExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(messageTemplate, _data);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void ArgumentExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenDataDictionaryIsNull()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: {ValueExpression} may not be null";
      Dictionary<String, Object> data = null!;
      var sut = ArgumentExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(messageTemplate, data);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(data))
         .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
   }

   #endregion
}
