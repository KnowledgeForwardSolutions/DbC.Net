namespace DbC.Net.Tests.Unit.Exceptions;

public class ExceptionDataBuilderTests
{
   #region Build Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ExceptionDataBuilder_Build_ShouldReturnExpectedDictionary_WhenItemsAdded()
   {
      // Arrange.
      var value = 10;
      var valueExpression = nameof(value);

      var sut = ExceptionDataBuilder.Create()
         .WithValue(value, valueExpression);

      var expectedCount = 2;

      // Act.
      var data = sut.Build();

      // Assert.
      data.Should().NotBeNull();
      data.Should().HaveCount(expectedCount);
      data[DataNames.Value].Should().Be(value);
      data[DataNames.ValueExpression].Should().Be(valueExpression);
   }

   [Fact]
   public void ExceptionDataBuilder_Build_ShouldReturnEmptyDictionary_WhenNoItemsAdded()
   {
      // Arrange.
      var sut = ExceptionDataBuilder.Create();

      // Act.
      var data = sut.Build();

      // Assert.
      data.Should().NotBeNull();
      data.Should().BeEmpty();
   }

   [Fact]
   public void ExceptionDataBuilder_Build_ShouldThrowInvalidOperationException_AfterFirstInvocation()
   {
      // Arrange.
      var sut = ExceptionDataBuilder.Create()
         .WithValue(10, "value");
      _ = sut.Build();
      var act = () => sut.Build();

      // Act/assert.
      act.Should().Throw<InvalidOperationException>()
         .WithMessage(Messages.ExceptionDataAlreadyBuilt);
   }

   #endregion

   #region Create Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ExceptionDataBuilder_Create_ShouldReturnExceptionDataBuilderObject()
   {
      // Act.
      var sut = ExceptionDataBuilder.Create();

      // Assert.
      sut.Should().NotBeNull();
      sut.Should().BeOfType<ExceptionDataBuilder>();
   }

   #endregion

   #region WithEpsilon Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ExceptionDataBuilder_WithEpsilon_ShouldAddEpsilonAndEpsilonExpressionItems()
   {
      // Arrange.
      var epsilon = 100;
      var epsilonExpression = nameof(epsilon);
      var expectedCount = 2;

      var sut = ExceptionDataBuilder.Create();

      // Act.
      sut.WithEpsilon(epsilon, epsilonExpression);

      // Assert.
      var data = sut.Build();
      data.Should().HaveCount(expectedCount);
      data[DataNames.Epsilon].Should().Be(epsilon);
      data[DataNames.EpsilonExpression].Should().Be(epsilonExpression);
   }

   [Fact]
   public void ExceptionDataBuilder_WithEpsilon_ShouldReturnReferenceToSelf()
   {
      // Arrange.
      var sut = ExceptionDataBuilder.Create();

      // Act.
      var result = sut.WithEpsilon(99, "epsilon");

      // Assert.
      result.Should().Be(sut);
   }

   [Fact]
   public void ExceptionDataBuilder_WithEpsilon_ShouldThrowArgumentException_WhenEpsilonExpressionIsEmpty()
   {
      // Arrange.
      var epsilon = 100;
      var epsilonExpression = String.Empty;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithEpsilon(epsilon, epsilonExpression);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(epsilonExpression));
   }

   [Fact]
   public void ExceptionDataBuilder_WithEpsilon_ShouldThrowArgumentNullException_WhenEpsilonExpressionIsNull()
   {
      // Arrange.
      var epsilon = 100;
      String epsilonExpression = null!;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithEpsilon(epsilon, epsilonExpression);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(epsilonExpression));
   }

   #endregion

   #region WithItem Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ExceptionDataBuilder_WithItem_ShouldAddExpectedItem()
   {
      // Arrange.
      var name = DataNames.ValueDatatype;
      var value = "SomeTypeName";
      var expectedCount = 1;

      var sut = ExceptionDataBuilder.Create();

      // Act.
      sut.WithItem(name, value);

      // Assert.
      var data = sut.Build();
      data.Should().HaveCount(expectedCount);
      data[name].Should().Be(value);
   }

   [Fact]
   public void ExceptionDataBuilder_WithItem_ShouldReturnReferenceToSelf()
   {
      // Arrange.
      var sut = ExceptionDataBuilder.Create();

      // Act.
      var result = sut.WithItem(DataNames.Value, 3.14);

      // Assert.
      result.Should().Be(sut);
   }

   [Fact]
   public void ExceptionDataBuilder_WithItem_ShouldThrowArgumentException_WhenNameIsEmpty()
   {
      // Arrange.
      var name = String.Empty;
      var value = "SomeTypeName";
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithItem(name, value);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(name));
   }

   [Fact]
   public void ExceptionDataBuilder_WithItem_ShouldThrowArgumentNullException_WhenNameIsNull()
   {
      // Arrange.
      String name = null!;
      var value = "SomeTypeName";
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithItem(name, value);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(name));
   }

   #endregion

   #region WithLowerBound Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ExceptionDataBuilder_WithLowerBound_ShouldAddLowerBoundAndLowerBoundExpressionItems()
   {
      // Arrange.
      var lowerBound = 100;
      var lowerBoundExpression = nameof(lowerBound);
      var expectedCount = 2;

      var sut = ExceptionDataBuilder.Create();

      // Act.
      sut.WithLowerBound(lowerBound, lowerBoundExpression);

      // Assert.
      var data = sut.Build();
      data.Should().HaveCount(expectedCount);
      data[DataNames.LowerBound].Should().Be(lowerBound);
      data[DataNames.LowerBoundExpression].Should().Be(lowerBoundExpression);
   }

   [Fact]
   public void ExceptionDataBuilder_WithLowerBound_ShouldAddLowerBoundAndLowerBoundExpressionItems_WhenLowerBoundIsNull()
   {
      // Arrange.
      String lowerBound = null!;
      var lowerBoundExpression = nameof(lowerBound);
      var expectedCount = 2;

      var sut = ExceptionDataBuilder.Create();

      // Act.
      sut.WithLowerBound(lowerBound, lowerBoundExpression);

      // Assert.
      var data = sut.Build();
      data.Should().HaveCount(expectedCount);
      data[DataNames.LowerBound].Should().Be(lowerBound);
      data[DataNames.LowerBoundExpression].Should().Be(lowerBoundExpression);
   }

   [Fact]
   public void ExceptionDataBuilder_WithLowerBound_ShouldReturnReferenceToSelf()
   {
      // Arrange.
      var sut = ExceptionDataBuilder.Create();

      // Act.
      var result = sut.WithLowerBound(99, "lowerBound");

      // Assert.
      result.Should().Be(sut);
   }

   [Fact]
   public void ExceptionDataBuilder_WithLowerBound_ShouldThrowArgumentException_WhenLowerBoundExpressionIsEmpty()
   {
      // Arrange.
      var lowerBound = 100;
      var lowerBoundExpression = String.Empty;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithLowerBound(lowerBound, lowerBoundExpression);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(lowerBoundExpression));
   }

   [Fact]
   public void ExceptionDataBuilder_WithLowerBound_ShouldThrowArgumentNullException_WhenLowerBoundExpressionIsNull()
   {
      // Arrange.
      var lowerBound = 100;
      String lowerBoundExpression = null!;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithLowerBound(lowerBound, lowerBoundExpression);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(lowerBoundExpression));
   }

   #endregion

   #region WithMaxLength Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ExceptionDataBuilder_WithMaxLength_ShouldAddMaxLengthAndMaxLengthExpressionItems()
   {
      // Arrange.
      var maxLength = 100;
      var maxLengthExpression = nameof(maxLength);
      var expectedCount = 2;

      var sut = ExceptionDataBuilder.Create();

      // Act.
      sut.WithMaxLength(maxLength, maxLengthExpression);

      // Assert.
      var data = sut.Build();
      data.Should().HaveCount(expectedCount);
      data[DataNames.MaxLength].Should().Be(maxLength);
      data[DataNames.MaxLengthExpression].Should().Be(maxLengthExpression);
   }

   [Fact]
   public void ExceptionDataBuilder_WithMaxLength_ShouldReturnReferenceToSelf()
   {
      // Arrange.
      var sut = ExceptionDataBuilder.Create();

      // Act.
      var result = sut.WithMaxLength(99, "maxLength");

      // Assert.
      result.Should().Be(sut);
   }

   [Fact]
   public void ExceptionDataBuilder_WithMaxLength_ShouldThrowArgumentException_WhenMaxLengthExpressionIsEmpty()
   {
      // Arrange.
      var maxLength = 100;
      var maxLengthExpression = String.Empty;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithMaxLength(maxLength, maxLengthExpression);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(maxLengthExpression));
   }

   [Fact]
   public void ExceptionDataBuilder_WithMaxLength_ShouldThrowArgumentNullException_WhenMaxLengthExpressionIsNull()
   {
      // Arrange.
      var maxLength = 100;
      String maxLengthExpression = null!;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithMaxLength(maxLength, maxLengthExpression);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(maxLengthExpression));
   }

   #endregion

   #region WithMinLength Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ExceptionDataBuilder_WithMinLength_ShouldAddMinLengthAndMinLengthExpressionItems()
   {
      // Arrange.
      var minLength = 100;
      var minLengthExpression = nameof(minLength);
      var expectedCount = 2;

      var sut = ExceptionDataBuilder.Create();

      // Act.
      sut.WithMinLength(minLength, minLengthExpression);

      // Assert.
      var data = sut.Build();
      data.Should().HaveCount(expectedCount);
      data[DataNames.MinLength].Should().Be(minLength);
      data[DataNames.MinLengthExpression].Should().Be(minLengthExpression);
   }

   [Fact]
   public void ExceptionDataBuilder_WithMinLength_ShouldReturnReferenceToSelf()
   {
      // Arrange.
      var sut = ExceptionDataBuilder.Create();

      // Act.
      var result = sut.WithMinLength(99, "minLength");

      // Assert.
      result.Should().Be(sut);
   }

   [Fact]
   public void ExceptionDataBuilder_WithMinLength_ShouldThrowArgumentException_WhenMinLengthExpressionIsEmpty()
   {
      // Arrange.
      var minLength = 100;
      var minLengthExpression = String.Empty;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithMinLength(minLength, minLengthExpression);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(minLengthExpression));
   }

   [Fact]
   public void ExceptionDataBuilder_WithMinLength_ShouldThrowArgumentNullException_WhenMinLengthExpressionIsNull()
   {
      // Arrange.
      var minLength = 100;
      String minLengthExpression = null!;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithMinLength(minLength, minLengthExpression);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(minLengthExpression));
   }

   #endregion

   #region WithRequirement Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ExceptionDataBuilder_WithRequirement_ShouldAddRequirementTypeAndRequirementNameItems()
   {
      // Arrange.
      var requirementType = RequirementType.Precondition;
      var requirementName = RequirementNames.NotDefault;
      var expectedCount = 2;

      var sut = ExceptionDataBuilder.Create();

      // Act.
      sut.WithRequirement(requirementType, requirementName);

      // Assert.
      var data = sut.Build();
      data.Should().HaveCount(expectedCount);
      data[DataNames.RequirementType].Should().Be(requirementType);
      data[DataNames.RequirementName].Should().Be(requirementName);
   }

   [Fact]
   public void ExceptionDataBuilder_WithRequirement_ShouldReturnReferenceToSelf()
   {
      // Arrange.
      var sut = ExceptionDataBuilder.Create();

      // Act.
      var result = sut.WithRequirement(RequirementType.Precondition, RequirementNames.GreaterThan);

      // Assert.
      result.Should().Be(sut);
   }

   [Fact]
   public void ExceptionDataBuilder_WithRequirement_ShouldThrowArgumentOutOfRangeException_WhenRequirementTypeIsNotDefined()
   {
      // Arrange.
      var requirementType = (RequirementType)99;
      var requirementName = RequirementNames.NotNull;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithRequirement(requirementType, requirementName);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentOutOfRangeException>().Which;
      ex.ParamName.Should().Be(nameof(requirementType));
      ex.ActualValue.Should().Be(requirementType);
      ex.Message.Should().StartWith(Messages.RequirementTypeIsNotDefined);
   }

   [Fact]
   public void ExceptionDataBuilder_WithRequirement_ShouldThrowArgumentException_WhenRequirementNameIsEmpty()
   {
      // Arrange.
      var requirementType = RequirementType.Postcondition;
      var requirementName = String.Empty;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithRequirement(requirementType, requirementName);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(requirementName));
   }

   [Fact]
   public void ExceptionDataBuilder_WithRequirement_ShouldThrowArgumentNullException_WhenRequirementNameIsNull()
   {
      // Arrange.
      var requirementType = RequirementType.Postcondition;
      String requirementName = null!;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithRequirement(requirementType, requirementName);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(requirementName));
   }

   #endregion

   #region WithTarget Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ExceptionDataBuilder_WithTarget_ShouldAddTargetAndTargetExpressionItems()
   {
      // Arrange.
      var target = 100;
      var targetExpression = nameof(target);
      var expectedCount = 2;

      var sut = ExceptionDataBuilder.Create();

      // Act.
      sut.WithTarget(target, targetExpression);

      // Assert.
      var data = sut.Build();
      data.Should().HaveCount(expectedCount);
      data[DataNames.Target].Should().Be(target);
      data[DataNames.TargetExpression].Should().Be(targetExpression);
   }

   [Fact]
   public void ExceptionDataBuilder_WithTarget_ShouldAddTargetAndTargetExpressionItems_WhenTargetIsNull()
   {
      // Arrange.
      String target = null!;
      var targetExpression = nameof(target);
      var expectedCount = 2;

      var sut = ExceptionDataBuilder.Create();

      // Act.
      sut.WithTarget(target, targetExpression);

      // Assert.
      var data = sut.Build();
      data.Should().HaveCount(expectedCount);
      data[DataNames.Target].Should().Be(target);
      data[DataNames.TargetExpression].Should().Be(targetExpression);
   }

   [Fact]
   public void ExceptionDataBuilder_WithTarget_ShouldReturnReferenceToSelf()
   {
      // Arrange.
      var sut = ExceptionDataBuilder.Create();

      // Act.
      var result = sut.WithTarget(99, "target");

      // Assert.
      result.Should().Be(sut);
   }

   [Fact]
   public void ExceptionDataBuilder_WithTarget_ShouldThrowArgumentException_WhenTargetExpressionIsEmpty()
   {
      // Arrange.
      var target = 100;
      var targetExpression = String.Empty;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithTarget(target, targetExpression);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(targetExpression));
   }

   [Fact]
   public void ExceptionDataBuilder_WithTarget_ShouldThrowArgumentNullException_WhenTargetExpressionIsNull()
   {
      // Arrange.
      var target = 100;
      String targetExpression = null!;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithTarget(target, targetExpression);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(targetExpression));
   }

   #endregion

   #region WithUpperBound Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ExceptionDataBuilder_WithUpperBound_ShouldAddUpperBoundAndUpperBoundExpressionItems()
   {
      // Arrange.
      var upperBound = 100;
      var upperBoundExpression = nameof(upperBound);
      var expectedCount = 2;

      var sut = ExceptionDataBuilder.Create();

      // Act.
      sut.WithUpperBound(upperBound, upperBoundExpression);

      // Assert.
      var data = sut.Build();
      data.Should().HaveCount(expectedCount);
      data[DataNames.UpperBound].Should().Be(upperBound);
      data[DataNames.UpperBoundExpression].Should().Be(upperBoundExpression);
   }

   [Fact]
   public void ExceptionDataBuilder_WithUpperBound_ShouldAddUpperBoundAndUpperBoundExpressionItems_WhenUpperBoundIsNull()
   {
      // Arrange.
      String upperBound = null!;
      var upperBoundExpression = nameof(upperBound);
      var expectedCount = 2;

      var sut = ExceptionDataBuilder.Create();

      // Act.
      sut.WithUpperBound(upperBound, upperBoundExpression);

      // Assert.
      var data = sut.Build();
      data.Should().HaveCount(expectedCount);
      data[DataNames.UpperBound].Should().Be(upperBound);
      data[DataNames.UpperBoundExpression].Should().Be(upperBoundExpression);
   }

   [Fact]
   public void ExceptionDataBuilder_WithUpperBound_ShouldReturnReferenceToSelf()
   {
      // Arrange.
      var sut = ExceptionDataBuilder.Create();

      // Act.
      var result = sut.WithUpperBound(99, "upperBound");

      // Assert.
      result.Should().Be(sut);
   }

   [Fact]
   public void ExceptionDataBuilder_WithUpperBound_ShouldThrowArgumentException_WhenUpperBoundExpressionIsEmpty()
   {
      // Arrange.
      var upperBound = 100;
      var upperBoundExpression = String.Empty;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithUpperBound(upperBound, upperBoundExpression);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(upperBoundExpression));
   }

   [Fact]
   public void ExceptionDataBuilder_WithUpperBound_ShouldThrowArgumentNullException_WhenUpperBoundExpressionIsNull()
   {
      // Arrange.
      var upperBound = 100;
      String upperBoundExpression = null!;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithUpperBound(upperBound, upperBoundExpression);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(upperBoundExpression));
   }

   #endregion

   #region WithValue Method Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ExceptionDataBuilder_WithValue_ShouldAddValueAndValueExpressionItems()
   {
      // Arrange.
      var value = 100;
      var valueExpression = nameof(value);
      var expectedCount = 2;

      var sut = ExceptionDataBuilder.Create();

      // Act.
      sut.WithValue(value, valueExpression);

      // Assert.
      var data = sut.Build();
      data.Should().HaveCount(expectedCount);
      data[DataNames.Value].Should().Be(value);
      data[DataNames.ValueExpression].Should().Be(valueExpression);
   }

   [Fact]
   public void ExceptionDataBuilder_WithValue_ShouldAddValueAndValueExpressionItems_WhenValueIsNull()
   {
      // Arrange.
      String value = null!;
      var valueExpression = nameof(value);
      var expectedCount = 2;

      var sut = ExceptionDataBuilder.Create();

      // Act.
      sut.WithValue(value, valueExpression);

      // Assert.
      var data = sut.Build();
      data.Should().HaveCount(expectedCount);
      data[DataNames.Value].Should().Be(value);
      data[DataNames.ValueExpression].Should().Be(valueExpression);
   }

   [Fact]
   public void ExceptionDataBuilder_WithValue_ShouldReturnReferenceToSelf()
   {
      // Arrange.
      var sut = ExceptionDataBuilder.Create();

      // Act.
      var result = sut.WithValue(99, "value");

      // Assert.
      result.Should().Be(sut);
   }

   [Fact]
   public void ExceptionDataBuilder_WithValue_ShouldThrowArgumentException_WhenValueExpressionIsEmpty()
   {
      // Arrange.
      var value = 100;
      var valueExpression = String.Empty;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithValue(value, valueExpression);

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(nameof(valueExpression));
   }

   [Fact]
   public void ExceptionDataBuilder_WithValue_ShouldThrowArgumentNullException_WhenValueExpressionIsNull()
   {
      // Arrange.
      var value = 100;
      String valueExpression = null!;
      var sut = ExceptionDataBuilder.Create();
      var act = () => _ = sut.WithValue(value, valueExpression);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(valueExpression));
   }

   #endregion
}
