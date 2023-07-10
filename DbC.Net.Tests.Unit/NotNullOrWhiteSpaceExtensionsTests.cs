namespace DbC.Net.Tests.Unit;

public class NotNullOrWhiteSpaceExtensionsTests
{
   private const Int32 _dataCount = 4;

   #region EnsuresNotNullOrWhiteSpace Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void NotNullOrWhiteSpaceExtensions_EnsuresNotNullOrWhiteSpace_ShouldNotThrow_WhenValueIsNotANullOrEmptyString()
   {
      // Arrange.
      var value = "asdf";
      var act = () => _ = value.EnsuresNotNullOrWhiteSpace();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void NotNullOrWhiteSpaceExtensions_EnsuresNotNullOrWhiteSpace_ShouldThrow_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresNotNullOrWhiteSpace();

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void NotNullOrWhiteSpaceExtensions_EnsuresNotNullOrWhiteSpace_ShouldThrow_WhenValueIsEmpty()
   {
      // Arrange.
      var value = String.Empty;
      var act = () => _ = value.EnsuresNotNullOrWhiteSpace();

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void NotNullOrWhiteSpaceExtensions_EnsuresNotNullOrWhiteSpace_ShouldThrowWithExpectedDataDictionary_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresNotNullOrWhiteSpace();

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotNullOrWhiteSpace);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotNullOrWhiteSpaceExtensions_EnsuresNotNullOrWhiteSpace_ShouldThrowWithExpectedDataDictionary_WhenValueIsEmptyOrWhiteSpace(String value)
   {
      // Arrange.
      var act = () => _ = value.EnsuresNotNullOrWhiteSpace();

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotNullOrWhiteSpace);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void NotNullOrWhiteSpaceExtensions_EnsuresNotNullOrWhiteSpace_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsNullAndAllDefaultsAreUsed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresNotNullOrWhiteSpace();
      var expectedMessage = $"Postcondition NotNullOrWhiteSpace failed: value may not be null, String.Empty or all whitespace characters";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage + "*");
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotNullOrWhiteSpaceExtensions_EnsuresNotNullOrWhiteSpace_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsEmptyOrWhiteSpaceAndAllDefaultsAreUsed(String value)
   {
      // Arrange.
      var act = () => _ = value.EnsuresNotNullOrWhiteSpace();
      var expectedMessage = $"Postcondition NotNullOrWhiteSpace failed: value may not be null, String.Empty or all whitespace characters";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void NotNullOrWhiteSpaceExtensions_EnsuresNotNullOrWhiteSpace_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsNullAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotNullOrWhiteSpace(messageTemplate);
      var expectedMessage = $"Requirement NotNullOrWhiteSpace failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage + "*");
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotNullOrWhiteSpaceExtensions_EnsuresNotNullOrWhiteSpace_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsEmptyOrWhiteSpaceAndAllCustomMessageTemplateIsUsed(String value)
   {
      // Arrange.
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotNullOrWhiteSpace(messageTemplate);
      var expectedMessage = $"Requirement NotNullOrWhiteSpace failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void NotNullOrWhiteSpaceExtensions_EnsuresNotNullOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsNullAndCustomNullExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresNotNullOrWhiteSpace(nullExceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition NotNullOrWhiteSpace failed: value may not be null, String.Empty or all whitespace characters";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotNullOrWhiteSpaceExtensions_EnsuresNotNullOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsEmptyOrWhiteSpaceAndCustomEmptyExceptionFactoryIsUsed(String value)
   {
      // Arrange.
      var act = () => _ = value.EnsuresNotNullOrWhiteSpace(emptyExceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition NotNullOrWhiteSpace failed: value may not be null, String.Empty or all whitespace characters";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void NotNullOrWhiteSpaceExtensions_EnsuresNotNullOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsNullAndCustomMessageTemplateAndCustomNullExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotNullOrWhiteSpace(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotNullOrWhiteSpace failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotNullOrWhiteSpaceExtensions_EnsuresNotNullOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsEmptyOrWhiteSpaceAndCustomMessageTemplateAndCustomEmptyExceptionFactoryIsUsed(String value)
   {
      // Arrange.
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotNullOrWhiteSpace(messageTemplate, emptyExceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotNullOrWhiteSpace failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   #endregion

   #region RequiresNotNullOrWhiteSpace Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void NotNullOrWhiteSpaceExtensions_RequiresNotNullOrWhiteSpace_ShouldNotThrow_WhenValueIsNotANullOrEmptyString()
   {
      // Arrange.
      var value = "asdf";
      var act = () => _ = value.RequiresNotNullOrWhiteSpace();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void NotNullOrWhiteSpaceExtensions_RequiresNotNullOrWhiteSpace_ShouldThrowArgumentNullException_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotNullOrWhiteSpace();

      // Act/assert.
      act.Should().Throw<ArgumentNullException>();
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotNullOrWhiteSpaceExtensions_RequiresNotNullOrWhiteSpace_ShouldThrowArgumentException_WhenValueIsEmptyOrWhiteSpace(String value)
   {
      // Arrange.
      var act = () => _ = value.RequiresNotNullOrWhiteSpace();

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Fact]
   public void NotNullOrWhiteSpaceExtensions_RequiresNotNullOrWhiteSpace_ShouldThrowWithExpectedDataDictionary_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotNullOrWhiteSpace();

      // Act/assert.
      var ex = act.Should().Throw<ArgumentNullException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotNullOrWhiteSpace);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void NotNullOrWhiteSpaceExtensions_RequiresNotNullOrWhiteSpace_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenValueIsNullAndAllDefaultsAreUsed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotNullOrWhiteSpace();
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition NotNullOrWhiteSpace failed: value may not be null, String.Empty or all whitespace characters";

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotNullOrWhiteSpaceExtensions_RequiresNotNullOrWhiteSpace_ShouldThrowArgumentExceptionWithExpectedMessage_WhenValueIsEmptyOrWhiteSpaceAndAllDefaultsAreUsed(String value)
   {
      // Arrange.
      var act = () => _ = value.RequiresNotNullOrWhiteSpace();
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition NotNullOrWhiteSpace failed: value may not be null, String.Empty or all whitespace characters";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void NotNullOrWhiteSpaceExtensions_RequiresNotNullOrWhiteSpace_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenValueIsNullAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotNullOrWhiteSpace(messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement NotNullOrWhiteSpace failed";

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotNullOrWhiteSpaceExtensions_RequiresNotNullOrWhiteSpace_ShouldThrowArgumentExceptionWithExpectedMessage_WhenValueIsEmptyOrWhiteSpaceAndAllCustomMessageTemplateIsUsed(String value)
   {
      // Arrange.
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotNullOrWhiteSpace(messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement NotNullOrWhiteSpace failed";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void NotNullOrWhiteSpaceExtensions_RequiresNotNullOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsNullAndCustomNullExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotNullOrWhiteSpace(nullExceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition NotNullOrWhiteSpace failed: value may not be null, String.Empty or all whitespace characters";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotNullOrWhiteSpaceExtensions_RequiresNotNullOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsEmptyOrWhiteSpaceAndCustomEmptyExceptionFactoryIsUsed(String value)
   {
      // Arrange.
      var act = () => _ = value.RequiresNotNullOrWhiteSpace(emptyExceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition NotNullOrWhiteSpace failed: value may not be null, String.Empty or all whitespace characters";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void NotNullOrWhiteSpaceExtensions_RequiresNotNullOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsNullAndCustomMessageTemplateAndCustomNullExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotNullOrWhiteSpace(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotNullOrWhiteSpace failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   [Theory]
   [InlineData("")]
   [InlineData("\t")]
   public void NotNullOrWhiteSpaceExtensions_RequiresNotNullOrWhiteSpace_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsEmptyOrWhiteSpaceAndCustomMessageTemplateAndCustomEmptyExceptionFactoryIsUsed(String value)
   {
      // Arrange.
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotNullOrWhiteSpace(messageTemplate, emptyExceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotNullOrWhiteSpace failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   #endregion
}
