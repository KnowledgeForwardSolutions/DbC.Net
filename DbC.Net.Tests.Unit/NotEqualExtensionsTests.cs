namespace DbC.Net.Tests.Unit;

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
public class NotEqualExtensionsTests
{
   private const Int32 _dataCount = 6;
   private const Int32 _stringDataCount = 7;

   #region EnsuresNotEqual (IEquatable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_EnsuresNotEqualIEquatable_ShouldReturnOriginalValue_WhenValueDoesNotEqualTarget<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      var target = data.NotEqualValue;

      // Act.
      var result = value.EnsuresNotEqual(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_EnsuresNotEqualIEquatable_ShouldReturnOriginalValue_WhenValueIsDefaultAndTargetIsNot<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      T value = default!;
      var target = data.NonDefaultNotEqualValue;

      // Act.
      var result = value.EnsuresNotEqual(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_EnsuresNotEqualIEquatable_ShouldReturnOriginalValue_WhenValueIsNotDefaultAndTargetIs<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      T target = default!;

      // Act.
      var result = value.EnsuresNotEqual(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_EnsuresNotEqualIEquatable_ShouldThrow_WhenValueEqualsTarget<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      var target = data.EqualValue;
      var act = () => _ = value.EnsuresNotEqual(target);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_EnsuresNotEqualIEquatable_ShouldThrow_WhenValueAndTargetAreDefault<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      T value = default!;
      T target = default!;
      var act = () => _ = value.EnsuresNotEqual(target);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void NotEqualExtensions_EnsuresNotEqualIEquatable_ShouldThrowWithExpectedDataDictionary_WhenValueEqualsTarget()
   {
      // Arrange.
      var value = 100;
      var target = value;
      var act = () => _ = value.EnsuresNotEqual(target);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
   }

   [Fact]
   public void NotEqualExtensions_EnsuresNotEqualIEquatable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueEqualsTarget()
   {
      // Arrange.
      var value = StringData.UpperCaseAE;
      var target = StringData.UpperCaseAE;
      var act = () => _ = value.EnsuresNotEqual(target);
      var expectedMessage = $"Postcondition NotEqual failed: {nameof(value)} must not be equal to {target}";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_EnsuresNotEqualIEquatable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = new ObservationClassData().EqualValue;
      var target = new ObservationClassData().EqualValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotEqual(target, messageTemplate);
      var expectedMessage = $"Requirement NotEqual failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_EnsuresNotEqualIEquatable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = Double.Pi;
      var target = Double.Pi;
      var act = () => _ = value.EnsuresNotEqual(target, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition NotEqual failed: {nameof(value)} must not be equal to {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_EnsuresNotEqualIEquatable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = new PointStructData().EqualValue;
      var target = new PointStructData().EqualValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotEqual(target, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotEqual failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

   #region EnsuresNotEqual (IEqualityComparer) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_EnsuresNotEqualIEqualityComparer_ShouldReturnOriginalValue_WhenValueDoesNotEqualTarget<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      var target = data.EqualValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.EnsuresNotEqual(target, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_EnsuresNotEqualIEqualityComparer_ShouldReturnOriginalValue_WhenValueIsDefaultAndTargetIsNot<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      T value = default!;
      var target = data.EqualValue;
      var comparer = EqualityComparer<T>.Default;

      // Act.
      var result = value.EnsuresNotEqual(target, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_EnsuresNotEqualIEqualityComparer_ShouldThrow_WhenValueIsNotDefaultAndTargetIs<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      T target = default!;
      var comparer = EqualityComparer<T>.Default;

      // Act.
      var result = value.EnsuresNotEqual(target, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_EnsuresNotEqualIEqualityComparer_ShouldThrow_WhenAndTargetAreDefault<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      T value = default!;
      T target = default!;
      var comparer = EqualityComparer<T>.Default;
      var act = () => _ = value.EnsuresNotEqual(target, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void NotEqualExtensions_EnsuresNotEqualIEqualityComparer_ShouldThrowWithExpectedDataDictionary_WhenValueDoesNotEqualTarget()
   {
      // Arrange.
      var value = nint.MinValue;
      var target = nint.MaxValue;
      var comparer = new ReverseComparer<nint>();
      var act = () => _ = value.EnsuresNotEqual(target, comparer);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
   }

   [Fact]
   public void NotEqualExtensions_EnsuresNotEqualIEqualityComparer_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueDoesNotEqualTarget()
   {
      // Arrange.
      var value = BigInteger.MinusOne;
      var target = BigInteger.One;
      var comparer = new ReverseComparer<BigInteger>();
      var act = () => _ = value.EnsuresNotEqual(target, comparer);
      var expectedMessage = $"Postcondition NotEqual failed: {nameof(value)} must not be equal to {target}";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_EnsuresNotEqualIEqualityComparer_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = UInt16.MaxValue;
      var target = UInt16.MinValue;
      var comparer = new ReverseComparer<UInt16>();
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotEqual(target, comparer, messageTemplate);
      var expectedMessage = $"Requirement NotEqual failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_EnsuresNotEqualIEqualityComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = Double.MaxValue;
      var target = Double.MinValue;
      var comparer = new ReverseComparer<Double>();
      var act = () => _ = value.EnsuresNotEqual(target, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition NotEqual failed: {nameof(value)} must not be equal to {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_EnsuresNotEqualIEqualityComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = DateTime.MaxValue;
      var target = DateTime.MinValue;
      var comparer = new ReverseComparer<DateTime>();
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotEqual(target, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotEqual failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_EnsuresNotEqualIEqualityComparer_ShouldThrowArgumentNullException_WhenComparerIsNull()
   {
      // Arrange.
      var value = Half.Pi;
      var target = Half.Tau;
      IEqualityComparer<Half> comparer = null!;
      var act = () => _ = value.EnsuresNotEqual(target, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(comparer))
         .And.Message.Should().StartWith(Messages.ComparerIsNull);
   }

   #endregion

   #region EnsuresNotEqual (String) Tests
   // ==========================================================================
   // ==========================================================================

   [UseCulture("en-US")]
   [Theory]
   [InlineData(StringData.LowerCaseA, StringData.LowerCaseADash, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseA, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseI, StringData.UpperCaseDottedI, StringComparison.OrdinalIgnoreCase)]
   public void NotEqualExtensions_EnsuresNotEqualString_ShouldReturnOriginalValue_WhenValueDoesNotEqualTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresNotEqual(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture("tr-TR")]
   [Theory]
   [InlineData(StringData.LowerCaseA, StringData.LowerCaseADash, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseA, StringData.LowerCaseADash, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseI, StringData.UpperCaseDottedI, StringComparison.OrdinalIgnoreCase)]
   public void NotEqualExtensions_EnsuresNotEqualString_ShouldReturnOriginalValue_WhenValueDoesNotEqualTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresNotEqual(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture("th-TH")]
   [Theory]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseI, StringData.UpperCaseDottedI, StringComparison.OrdinalIgnoreCase)]
   public void NotEqualExtensions_EnsuresNotEqualString_ShouldReturnOriginalValue_WhenValueDoesNotEqualTargetAndCurrentCultureIs_thTH(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresNotEqual(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture("en-US")]
   [Theory]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.OrdinalIgnoreCase)]
   public void NotEqualExtensions_EnsuresNotEqualString_ShouldThrow_WhenValueEqualsTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresNotEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   // Note: tr-TR culture considers "i" and upper case dotted "I" as equal when
   // case is ignored. Same for "I" and lowercase dot-less "i".
   [UseCulture("tr-TR")]
   [Theory]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseI, StringData.LowerCaseDotlessI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.OrdinalIgnoreCase)]
   public void NotEqualExtensions_EnsuresNotEqualString_ShouldThrow_WhenValueEqualsTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresNotEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   // Note: th-TH culture considers "a" and "a-" as equal.
   [UseCulture("th-TH")]
   [Theory]
   [InlineData(StringData.LowerCaseA, StringData.LowerCaseADash, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseA, StringData.LowerCaseADash, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.OrdinalIgnoreCase)]
   public void NotEqualExtensions_EnsuresNotEqualString_ShouldThrow_WhenValueEqualsTargetAndCurrentCultureIs_thTH(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.EnsuresNotEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [UseCulture("en-US")]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void NotEqualExtensions_EnsuresNotEqualString_ShouldThrow_WhenAndTargetAreDefaultAndCurrentCultureIs_enUS(StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String target = default!;
      var act = () => _ = value.EnsuresNotEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [UseCulture("tr-TR")]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void NotEqualExtensions_EnsuresNotEqualString_ShouldThrow_WhenAndTargetAreDefaultAndCurrentCultureIs_trTR(StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String target = default!;
      var act = () => _ = value.EnsuresNotEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void NotEqualExtensions_EnsuresNotEqualString_ShouldThrowWithExpectedDataDictionary_WhenValueEqualsTarget()
   {
      // Arrange.
      var value = StringData.LowerCaseDipthongAE;
      var target = StringData.LowerCaseDipthongAE;
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.EnsuresNotEqual(target, comparisonType);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_stringDataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void NotEqualExtensions_EnsuresNotEqualString_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueEqualsTarget()
   {
      // Arrange.
      var value = StringData.LowerCaseAE;
      var target = StringData.UpperCaseAE;
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var act = () => _ = value.EnsuresNotEqual(target, comparisonType);
      var expectedMessage = $"Postcondition NotEqual failed: {nameof(value)} must not be equal to {target}";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_EnsuresNotEqualString_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseSlashedO;
      var target = StringData.UpperCaseSlashedO;
      var comparisonType = StringComparison.InvariantCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotEqual(target, comparisonType, messageTemplate);
      var expectedMessage = $"Requirement NotEqual failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_EnsuresNotEqualString_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseI;
      var target = StringData.LowerCaseI;
      var comparisonType = StringComparison.InvariantCultureIgnoreCase;
      var act = () => _ = value.EnsuresNotEqual(target, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition NotEqual failed: {nameof(value)} must not be equal to {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_EnsuresNotEqualString_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseA;
      var target = StringData.UpperCaseA;
      var comparisonType = StringComparison.CurrentCultureIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresNotEqual(target, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotEqual failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

   #region RequiresNotEqual (IEquatable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldReturnOriginalValue_WhenValueDoesNotEqualTarget<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      var target = data.NotEqualValue;

      // Act.
      var result = value.RequiresNotEqual(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldReturnOriginalValue_WhenValueIsDefaultAndTargetIsNot<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      T value = default!;
      var target = data.NonDefaultNotEqualValue;

      // Act.
      var result = value.RequiresNotEqual(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldReturnOriginalValue_WhenValueIsNotDefaultAndTargetIs<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      T target = default!;

      // Act.
      var result = value.RequiresNotEqual(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldThrow_WhenValueEqualsTarget<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      var target = data.EqualValue;
      var act = () => _ = value.RequiresNotEqual(target);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldThrow_WhenValueAndTargetAreDefault<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      T value = default!;
      T target = default!;
      var act = () => _ = value.RequiresNotEqual(target);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldThrowWithExpectedDataDictionary_WhenValueEqualsTarget()
   {
      // Arrange.
      var value = 100;
      var target = value;
      var act = () => _ = value.RequiresNotEqual(target);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldThrowArgumentExceptionWithExpectedMessage_WhenValueEqualsTarget()
   {
      // Arrange.
      var value = StringData.UpperCaseAE;
      var target = StringData.UpperCaseAE;
      var act = () => _ = value.RequiresNotEqual(target);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition NotEqual failed: {nameof(value)} must not be equal to {target}";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldThrowArgumentExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = new ObservationClassData().EqualValue;
      var target = new ObservationClassData().EqualValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotEqual(target, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement NotEqual failed";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = Double.Pi;
      var target = Double.Pi;
      var act = () => _ = value.RequiresNotEqual(target, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition NotEqual failed: {nameof(value)} must not be equal to {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualIEquatable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = new PointStructData().EqualValue;
      var target = new PointStructData().EqualValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotEqual(target, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotEqual failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

   #region RequiresNotEqual (IEqualityComparer) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_RequiresNotEqualIEqualityComparer_ShouldReturnOriginalValue_WhenValueDoesNotEqualTarget<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      var target = data.EqualValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.RequiresNotEqual(target, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_RequiresNotEqualIEqualityComparer_ShouldReturnOriginalValue_WhenValueIsDefaultAndTargetIsNot<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      T value = default!;
      var target = data.EqualValue;
      var comparer = EqualityComparer<T>.Default;

      // Act.
      var result = value.RequiresNotEqual(target, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_RequiresNotEqualIEqualityComparer_ShouldThrow_WhenValueIsNotDefaultAndTargetIs<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      T target = default!;
      var comparer = EqualityComparer<T>.Default;

      // Act.
      var result = value.RequiresNotEqual(target, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void NotEqualExtensions_RequiresNotEqualIEqualityComparer_ShouldThrow_WhenAndTargetAreDefault<T>(IEquatableTestData<T> data) where T : IEquatable<T>
   {
      // Arrange.
      T value = default!;
      T target = default!;
      var comparer = EqualityComparer<T>.Default;
      var act = () => _ = value.RequiresNotEqual(target, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualIEqualityComparer_ShouldThrowWithExpectedDataDictionary_WhenValueDoesNotEqualTarget()
   {
      // Arrange.
      var value = nint.MinValue;
      var target = nint.MaxValue;
      var comparer = new ReverseComparer<nint>();
      var act = () => _ = value.RequiresNotEqual(target, comparer);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualIEqualityComparer_ShouldThrowArgumentExceptionWithExpectedMessage_WhenValueDoesNotEqualTarget()
   {
      // Arrange.
      var value = BigInteger.MinusOne;
      var target = BigInteger.One;
      var comparer = new ReverseComparer<BigInteger>();
      var act = () => _ = value.RequiresNotEqual(target, comparer);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition NotEqual failed: {nameof(value)} must not be equal to {target}";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualIEqualityComparer_ShouldThrowArgumentExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = UInt16.MaxValue;
      var target = UInt16.MinValue;
      var comparer = new ReverseComparer<UInt16>();
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotEqual(target, comparer, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement NotEqual failed";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualIEqualityComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = Double.MaxValue;
      var target = Double.MinValue;
      var comparer = new ReverseComparer<Double>();
      var act = () => _ = value.RequiresNotEqual(target, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition NotEqual failed: {nameof(value)} must not be equal to {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualIEqualityComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = DateTime.MaxValue;
      var target = DateTime.MinValue;
      var comparer = new ReverseComparer<DateTime>();
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotEqual(target, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotEqual failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualIEqualityComparer_ShouldThrowArgumentNullException_WhenComparerIsNull()
   {
      // Arrange.
      var value = Half.Pi;
      var target = Half.Tau;
      IEqualityComparer<Half> comparer = null!;
      var act = () => _ = value.RequiresNotEqual(target, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(comparer))
         .And.Message.Should().StartWith(Messages.ComparerIsNull);
   }

   #endregion

   #region RequiresNotEqual (String) Tests
   // ==========================================================================
   // ==========================================================================

   [UseCulture("en-US")]
   [Theory]
   [InlineData(StringData.LowerCaseA, StringData.LowerCaseADash, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseA, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseI, StringData.UpperCaseDottedI, StringComparison.OrdinalIgnoreCase)]
   public void NotEqualExtensions_RequiresNotEqualString_ShouldReturnOriginalValue_WhenValueDoesNotEqualTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresNotEqual(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture("tr-TR")]
   [Theory]
   [InlineData(StringData.LowerCaseA, StringData.LowerCaseADash, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseA, StringData.LowerCaseADash, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseI, StringData.UpperCaseDottedI, StringComparison.OrdinalIgnoreCase)]
   public void NotEqualExtensions_RequiresNotEqualString_ShouldReturnOriginalValue_WhenValueDoesNotEqualTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresNotEqual(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture("th-TH")]
   [Theory]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseI, StringData.UpperCaseDottedI, StringComparison.OrdinalIgnoreCase)]
   public void NotEqualExtensions_RequiresNotEqualString_ShouldReturnOriginalValue_WhenValueDoesNotEqualTargetAndCurrentCultureIs_thTH(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresNotEqual(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture("en-US")]
   [Theory]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.OrdinalIgnoreCase)]
   public void NotEqualExtensions_RequiresNotEqualString_ShouldThrow_WhenValueEqualsTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresNotEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   // Note: tr-TR culture considers "i" and upper case dotted "I" as equal when
   // case is ignored. Same for "I" and lowercase dot-less "i".
   [UseCulture("tr-TR")]
   [Theory]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.UpperCaseI, StringData.LowerCaseDotlessI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.OrdinalIgnoreCase)]
   public void NotEqualExtensions_RequiresNotEqualString_ShouldThrow_WhenValueEqualsTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresNotEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   // Note: th-TH culture considers "a" and "a-" as equal.
   [UseCulture("th-TH")]
   [Theory]
   [InlineData(StringData.LowerCaseA, StringData.LowerCaseADash, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseA, StringData.LowerCaseADash, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.OrdinalIgnoreCase)]
   public void NotEqualExtensions_RequiresNotEqualString_ShouldThrow_WhenValueEqualsTargetAndCurrentCultureIs_thTH(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Arrange.
      var act = () => _ = value.RequiresNotEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [UseCulture("en-US")]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void NotEqualExtensions_RequiresNotEqualString_ShouldThrow_WhenAndTargetAreDefaultAndCurrentCultureIs_enUS(StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String target = default!;
      var act = () => _ = value.RequiresNotEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [UseCulture("tr-TR")]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void NotEqualExtensions_RequiresNotEqualString_ShouldThrow_WhenAndTargetAreDefaultAndCurrentCultureIs_trTR(StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String target = default!;
      var act = () => _ = value.RequiresNotEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualString_ShouldThrowWithExpectedDataDictionary_WhenValueEqualsTarget()
   {
      // Arrange.
      var value = StringData.LowerCaseDipthongAE;
      var target = StringData.LowerCaseDipthongAE;
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.RequiresNotEqual(target, comparisonType);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_stringDataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.NotEqual);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualString_ShouldThrowArgumentExceptionWithExpectedMessage_WhenValueEqualsTarget()
   {
      // Arrange.
      var value = StringData.LowerCaseAE;
      var target = StringData.UpperCaseAE;
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var act = () => _ = value.RequiresNotEqual(target, comparisonType);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition NotEqual failed: {nameof(value)} must not be equal to {target}";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualString_ShouldThrowArgumentExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseSlashedO;
      var target = StringData.UpperCaseSlashedO;
      var comparisonType = StringComparison.InvariantCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotEqual(target, comparisonType, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement NotEqual failed";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualString_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseI;
      var target = StringData.LowerCaseI;
      var comparisonType = StringComparison.InvariantCultureIgnoreCase;
      var act = () => _ = value.RequiresNotEqual(target, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition NotEqual failed: {nameof(value)} must not be equal to {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void NotEqualExtensions_RequiresNotEqualString_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseA;
      var target = StringData.UpperCaseA;
      var comparisonType = StringComparison.CurrentCultureIgnoreCase;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresNotEqual(target, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement NotEqual failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion
}
