namespace DbC.Net.Tests.Unit.ExceptionFactories;

public class ArgumentNullExceptionFactoryTests
{
   private readonly Dictionary<String, Object> _data = new() {
      { DataNames.RequirementType, RequirementType.Precondition },
      { DataNames.RequirementName, "NotNull" },
      { DataNames.ValueExpression, "x" } };

   #region Instance Property Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
    public void ArgumentNullExceptionFactory_Instance_ShouldNotBeNull() =>
       ArgumentNullExceptionFactory.Instance.Should().NotBeNull();

   #endregion

   #region CreateException Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ArgumentNullExceptionFactory_CreateException_ShouldCreateExpectedException_WhenAllValuesSupplied()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: {ValueExpression} may not be null";
      
      var sut = ArgumentNullExceptionFactory.Instance;

      var expectedMessage = "Precondition NotNull failed: x may not be null";
      var expectedParamName = "x";

      // Act.
      var ex = sut.CreateException(_data, messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<ArgumentNullException>();
      ex.Message.Should().StartWith(expectedMessage);
      ex.ParamName.Should().Be(expectedParamName);

      ex.Data.Count.Should().Be(_data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
      ex.Data[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void ArgumentNullExceptionFactory_CreateException_ShouldThrowArgumentException_WhenMessageTemplateIsEmpty(String messageTemplate)
   {
      // Arrange.
      var sut = ArgumentNullExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(_data, messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void ArgumentNullExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenMessageTemplateIsNull()
   {
      // Arrange.
      String messageTemplate = null!;
      var sut = ArgumentNullExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(_data, messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void ArgumentNullExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenDataDictionaryIsNull()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: {ValueExpression} may not be null";
      Dictionary<String, Object> data = null!;
      var sut = ArgumentNullExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(data, messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(data))
         .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
   }

   #endregion
}
