namespace DbC.Net.Tests.Unit.ExceptionFactories;

public class ArgumentNullExceptionFactoryTests
{

   private readonly Dictionary<String, Object> _data = new() {
      { DataNames.RequirementType, RequirementType.Precondition },
      { DataNames.RequirementName, "NotNull" },
      { DataNames.ValueExpression, "x" } };

   [Fact]
    public void ArgumentNullExceptionFactory_Instance_ShouldNotBeNull() =>
       ArgumentNullExceptionFactory.Instance.Should().NotBeNull();

   [Fact]
   public void ArgumentNullExceptionFactory_CreateMessage_ShouldCreateExpectedMessage_WhenAllValuesButInnerExceptionSupplied()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: {ValueExpression} may not be null";
      
      var sut = ArgumentNullExceptionFactory.Instance;

      var expectedMessage = "Precondition NotNull failed: x may not be null";

      // Act.
      var ex = sut.CreateException(messageTemplate, _data);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<ArgumentNullException>();
      ex.Message.Should().Be(expectedMessage);

      ex.Data.Count.Should().Be(_data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
      ex.Data[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
   }

   [Fact]
   public void ArgumentNullExceptionFactory_CreateMessage_ShouldCreateExpectedMessage_WhenAllValuesIncludingInnerExceptionSupplied()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: {ValueExpression} may not be null";
      var innerException = new Exception();

      var sut = ArgumentNullExceptionFactory.Instance;

      var expectedMessage = "Precondition NotNull failed: x may not be null";

      // Act.
      var ex = sut.CreateException(messageTemplate, _data, innerException);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<ArgumentNullException>();
      ex.Message.Should().Be(expectedMessage);

      ex.Data.Count.Should().Be(_data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
      ex.Data[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);

      ex.InnerException.Should().Be(innerException);
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void ArgumentNullExceptionFactory_CreateMessage_ShouldThrowArgumentException_WhenMessageTemplateIsEmpty(String messageTemplate)
   {
      // Arrange.
      var sut = ArgumentNullExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(messageTemplate, _data);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void ArgumentNullExceptionFactory_CreateMessage_ShouldThrowArgumentNullException_WhenMessageTemplateIsNull()
   {
      // Arrange.
      String messageTemplate = null!;
      var sut = ArgumentNullExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(messageTemplate, _data);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void ArgumentNullExceptionFactory_CreateMessage_ShouldThrowArgumentNullException_WhenDataDictionaryIsNull()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: {ValueExpression} may not be null";
      Dictionary<String, Object> data = null!;
      var sut = ArgumentNullExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(messageTemplate, data);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(data))
         .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
   }
}
