namespace DbC.Net.Tests.Unit.ExceptionFactories;

public class FormatExceptionFactoryTests
{
   private readonly Dictionary<String, Object> _data = new() {
      { DataNames.RequirementType, RequirementType.Precondition },
      { DataNames.RequirementName, "True" },
      { DataNames.Value, "a.b" },
      { DataNames.ValueExpression, "threePartName" } };

   #region Instance Property Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void FormatExceptionFactory_Instance_ShouldNotBeNull() =>
       FormatExceptionFactory.Instance.Should().NotBeNull();

   #endregion

   #region CreateException Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void FormatExceptionFactory_CreateException_ShouldCreateExpectedException_WhenAllValuesSupplied()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: value (\"{Value}\") is not a valid three part name";

      var sut = FormatExceptionFactory.Instance;

      var expectedMessage = "Precondition True failed: value (\"a.b\") is not a valid three part name";

      // Act.
      var ex = sut.CreateException(messageTemplate, _data);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<FormatException>();
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
   public void FormatExceptionFactory_CreateException_ShouldThrowArgumentException_WhenMessageTemplateIsEmpty(String messageTemplate)
   {
      // Arrange.
      var sut = FormatExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(messageTemplate, _data);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void FormatExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenMessageTemplateIsNull()
   {
      // Arrange.
      String messageTemplate = null!;
      var sut = FormatExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(messageTemplate, _data);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void FormatExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenDataDictionaryIsNull()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: value (\"{Value}\") is not a valid three part name";
      Dictionary<String, Object> data = null!;
      var sut = FormatExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(messageTemplate, data);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(data))
         .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
   }

   #endregion
}
