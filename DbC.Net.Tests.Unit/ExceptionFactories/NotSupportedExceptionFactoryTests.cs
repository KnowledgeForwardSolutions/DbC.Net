namespace DbC.Net.Tests.Unit.ExceptionFactories;

public class NotSupportedExceptionFactoryTests
{
   private readonly Dictionary<String, Object> _data = new() {
      { DataNames.RequirementType, RequirementType.Precondition },
      { DataNames.RequirementName, "Equal" },
      { DataNames.Value, 0 },
      { DataNames.ValueExpression, "value" } };

   #region Instance Property Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void NotSupportedExceptionFactory_Instance_ShouldNotBeNull() =>
       NotSupportedExceptionFactory.Instance.Should().NotBeNull();

   #endregion

   #region CreateException Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void NotSupportedExceptionFactory_CreateException_ShouldCreateExpectedException_WhenAllValuesSupplied()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: operation is not defined for zero";

      var sut = NotSupportedExceptionFactory.Instance;

      var expectedMessage = "Precondition Equal failed: operation is not defined for zero";

      // Act.
      var ex = sut.CreateException(_data, messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<NotSupportedException>();
      ex.Message.Should().StartWith(expectedMessage);

      ex.Data.Count.Should().Be(_data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(_data[DataNames.Value]);
      ex.Data[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotSupportedExceptionFactory_CreateException_ShouldThrowArgumentException_WhenMessageTemplateIsEmpty(String messageTemplate)
   {
      // Arrange.
      var sut = NotSupportedExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(_data, messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void NotSupportedExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenMessageTemplateIsNull()
   {
      // Arrange.
      String messageTemplate = null!;
      var sut = NotSupportedExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(_data, messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void NotSupportedExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenDataDictionaryIsNull()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: operation is not defined for zero";
      Dictionary<String, Object> data = null!;
      var sut = NotSupportedExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(data, messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(data))
         .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
   }

   #endregion
}
