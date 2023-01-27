namespace DbC.Net.Tests.Unit.ExceptionFactories;

public class InvalidOperationExceptionFactoryTests
{
   private readonly Dictionary<String, Object> _data = new() {
      { DataNames.RequirementType, RequirementType.Precondition },
      { DataNames.RequirementName, "RegexMatch" },
      { DataNames.Value, "asdf" },
      { DataNames.ValueExpression, "apiResponse" },
      { DataNames.Regex, @"\b[M]\w+" } };

   #region Instance Property Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void InvalidOperationExceptionFactory_Instance_ShouldNotBeNull() =>
       InvalidOperationExceptionFactory.Instance.Should().NotBeNull();

   #endregion

   #region CreateException Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void InvalidOperationExceptionFactory_CreateException_ShouldCreateExpectedException_WhenAllValuesSupplied()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: value (\"{Value}\") is not a word that starts with 'M'";

      var sut = InvalidOperationExceptionFactory.Instance;

      var expectedMessage = "Precondition RegexMatch failed: value (\"asdf\") is not a word that starts with 'M'";

      // Act.
      var ex = sut.CreateException(_data, messageTemplate);

      // Assert.
      ex.Should().NotBeNull();
      ex.Should().BeOfType<InvalidOperationException>();
      ex.Message.Should().StartWith(expectedMessage);

      ex.Data.Count.Should().Be(_data.Count);
      ex.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
      ex.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
      ex.Data[DataNames.Value].Should().Be(_data[DataNames.Value]);
      ex.Data[DataNames.ValueExpression].Should().Be(_data[DataNames.ValueExpression]);
      ex.Data[DataNames.Regex].Should().Be(_data[DataNames.Regex]);
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void InvalidOperationExceptionFactory_CreateException_ShouldThrowArgumentException_WhenMessageTemplateIsEmpty(String messageTemplate)
   {
      // Arrange.
      var sut = InvalidOperationExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(_data, messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void InvalidOperationExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenMessageTemplateIsNull()
   {
      // Arrange.
      String messageTemplate = null!;
      var sut = InvalidOperationExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(_data, messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(messageTemplate))
         .And.Message.Should().StartWith(Messages.MessageTemplateIsEmpty);
   }

   [Fact]
   public void InvalidOperationExceptionFactory_CreateException_ShouldThrowArgumentNullException_WhenDataDictionaryIsNull()
   {
      // Arrange.
      var messageTemplate = "{RequirementType} {RequirementName} failed: value (\"{Value}\") is not a word that starts with 'M'";
      Dictionary<String, Object> data = null!;
      var sut = InvalidOperationExceptionFactory.Instance;
      var act = () => _ = sut.CreateException(data, messageTemplate);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(data))
         .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
   }

   #endregion
}
