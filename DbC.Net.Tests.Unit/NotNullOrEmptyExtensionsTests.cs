namespace DbC.Net.Tests.Unit;

public  class NotNullOrEmptyExtensionsTests
{
   private const Int32 _dataCount = 4;

   #region EnsuresNotNullOrEmpty Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void NotNullOrEmptyExtensions_EnsuresNotNullOrEmpty_ShouldNotThrow_WhenValueIsNotANullOrEmptyString()
   {
      // Arrange.
      var value = "asdf";
      var act = () => _ = value.EnsuresNotNullOrEmpty();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void NotNullOrEmptyExtensions_EnsuresNotNullOrEmpty_ShouldNotThrow_WhenValueIsAllWhiteSpace()
   {
      // Arrange.
      var value = "\t  \t";
      var act = () => _ = value.EnsuresNotNullOrEmpty();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void NotNullOrEmptyExtensions_EnsuresNotNullOrEmpty_ShouldThrow_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresNotNullOrEmpty();

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void NotNullOrEmptyExtensions_EnsuresNotNullOrEmpty_ShouldThrow_WhenValueIsEmpty()
   {
      // Arrange.
      var value = String.Empty;
      var act = () => _ = value.EnsuresNotNullOrEmpty();

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void NotNullOrEmptyExtensions_EnsuresNotNullOrEmpty_ShouldReturnOriginalValue_WhenValueIsNotANullOrEmptyString()
   {
      // Arrange.
      var value = "asdf";

      // Act.
      var result = value.EnsuresNotNullOrEmpty();

      // Act/assert.
      result.Should().Be(value);
   }

   [Fact]
   public void NotNullOrEmptyExtensions_EnsuresNotNullOrEmpty_ShouldThrowWithExpectedDataDictionary_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresNotNullOrEmpty();

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotNullOrEmpty);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void NotNullOrEmptyExtensions_EnsuresNotNullOrEmpty_ShouldThrowWithExpectedDataDictionary_WhenValueIsEmpty()
   {
      // Arrange.
      var value = String.Empty;
      var act = () => _ = value.EnsuresNotNullOrEmpty();

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotNullOrEmpty);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsNullAndAllDefaultsAreUsed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresNotNullOrEmpty();
      var expectedMessage = $"Postcondition NotNullOrEmpty failed: value may not be null or String.Empty";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsEmptyAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = String.Empty;
      var act = () => _ = value.EnsuresNotNullOrEmpty();
      var expectedMessage = $"Postcondition NotNullOrEmpty failed: value may not be null or String.Empty";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsNullAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotNullOrEmpty(messageTemplate);
      var expectedMessage = $"Requirement NotNullOrEmpty failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueIsEmptyAndAllCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = String.Empty;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotNullOrEmpty(messageTemplate);
      var expectedMessage = $"Requirement NotNullOrEmpty failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsNullAndCustomNullExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.EnsuresNotNullOrEmpty(nullExceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition NotNullOrEmpty failed: value may not be null or String.Empty";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsEmptyAndCustomEmptyExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = String.Empty;
      var act = () => _ = value.EnsuresNotNullOrEmpty(emptyExceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition NotNullOrEmpty failed: value may not be null or String.Empty";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsNullAndCustomMessageTemplateAndCustomNullExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotNullOrEmpty(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotNullOrEmpty failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MaxLengthExtensions_EnsuresMaxLength_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsEmptyAndCustomMessageTemplateAndCustomEmptyExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = String.Empty;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotNullOrEmpty(messageTemplate, emptyExceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotNullOrEmpty failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   #endregion

   #region RequiresNotNullOrEmpty Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void NotNullOrEmptyExtensions_RequiresNotNullOrEmpty_ShouldNotThrow_WhenValueIsNotANullOrEmptyString()
   {
      // Arrange.
      var value = "asdf";
      var act = () => _ = value.RequiresNotNullOrEmpty();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void NotNullOrEmptyExtensions_RequiresNotNullOrEmpty_ShouldNotThrow_WhenValueIsAllWhiteSpace()
   {
      // Arrange.
      var value = "\t  \t";
      var act = () => _ = value.RequiresNotNullOrEmpty();

      // Act/assert.
      act.Should().NotThrow();
   }

   [Fact]
   public void NotNullOrEmptyExtensions_RequiresNotNullOrEmpty_ShouldThrowArgumentNullException_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotNullOrEmpty();

      // Act/assert.
      act.Should().Throw<ArgumentNullException>();
   }

   [Fact]
   public void NotNullOrEmptyExtensions_RequiresNotNullOrEmpty_ShouldThrowArgumentException_WhenValueIsEmpty()
   {
      // Arrange.
      var value = String.Empty;
      var act = () => _ = value.RequiresNotNullOrEmpty();

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Fact]
   public void NotNullOrEmptyExtensions_RequiresNotNullOrEmpty_ShouldReturnOriginalValue_WhenValueIsNotANullOrEmptyString()
   {
      // Arrange.
      var value = "asdf";

      // Act.
      var result = value.RequiresNotNullOrEmpty();

      // Act/assert.
      result.Should().Be(value);
   }

   [Fact]
   public void NotNullOrEmptyExtensions_RequiresNotNullOrEmpty_ShouldThrowWithExpectedDataDictionary_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotNullOrEmpty();

      // Act/assert.
      var ex = act.Should().Throw<ArgumentNullException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotNullOrEmpty);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void NotNullOrEmptyExtensions_RequiresNotNullOrEmpty_ShouldThrowWithExpectedDataDictionary_WhenValueIsEmpty()
   {
      // Arrange.
      var value = String.Empty;
      var act = () => _ = value.RequiresNotNullOrEmpty();

      // Act/assert.
      var ex = act.Should().Throw<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotNullOrEmpty);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenValueIsNullAndAllDefaultsAreUsed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotNullOrEmpty();
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition NotNullOrEmpty failed: value may not be null or String.Empty";

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldThrowArgumentExceptionWithExpectedMessage_WhenValueIsEmptyAndAllDefaultsAreUsed()
   {
      // Arrange.
      var value = String.Empty;
      var act = () => _ = value.RequiresNotNullOrEmpty();
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition NotNullOrEmpty failed: value may not be null or String.Empty";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldThrowArgumentNullExceptionWithExpectedMessage_WhenValueIsNullAndCustomMessageTemplateIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotNullOrEmpty(messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement NotNullOrEmpty failed";

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldThrowArgumentExceptionWithExpectedMessage_WhenValueIsEmptyAndAllCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = String.Empty;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotNullOrEmpty(messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement NotNullOrEmpty failed";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsNullAndCustomNullExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var act = () => _ = value.RequiresNotNullOrEmpty(nullExceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition NotNullOrEmpty failed: value may not be null or String.Empty";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsEmptyAndCustomEmptyExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = String.Empty;
      var act = () => _ = value.RequiresNotNullOrEmpty(emptyExceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition NotNullOrEmpty failed: value may not be null or String.Empty";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsNullAndCustomMessageTemplateAndCustomNullExceptionFactoryIsUsed()
   {
      // Arrange.
      String value = null!;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotNullOrEmpty(messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotNullOrEmpty failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   [Fact]
   public void MaxLengthExtensions_RequiresMaxLength_ShouldThrowCustomExceptionWithExpectedMessage_WhenValueIsEmptyAndCustomMessageTemplateAndCustomEmptyExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = String.Empty;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotNullOrEmpty(messageTemplate, emptyExceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotNullOrEmpty failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .WithMessage(expectedMessage + "*");
   }

   #endregion
}
