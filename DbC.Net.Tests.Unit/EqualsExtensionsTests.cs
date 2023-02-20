namespace DbC.Net.Tests.Unit;

#pragma warning disable IDE0060 // Remove unused parameter
#pragma warning disable xUnit1026 // Theory methods should use all of their parameters
public class EqualsExtensionsTests
{
   private const Int32 _dataCount = 6;
   private const Int32 _stringDataCount = 7;

   #region EnsuresEqual (IEquatable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_EnsuresEqualIEquatable_ShouldReturnOriginalValue_WhenValueEqualsTarget<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      var target = data.EqualValue;

      // Act.
      var result = value.EnsuresEqual(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
    public void EqualExtensions_EnsuresEqualIEquatable_ShouldReturnOriginalValue_WhenValueAndTargetAreDefault<T>(EquatableValue<T> data) where T : IEquatable<T>
    {
      // Arrange.
      T value = default!;
      T target = default!;

      // Act.
      var result = value.EnsuresEqual(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_EnsuresEqualIEquatable_ShouldThrow_WhenValueDoesNotEqualTarget<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      var target = data.NotEqualValue;
      var act = () => _ = value.EnsuresEqual(target);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_EnsuresEqualIEquatable_ShouldThrow_WhenValueIsDefaultAndTargetIsNot<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      T value = default!;
      var target = data.NonDefaultNotEqualValue;
      var act = () => _ = value.EnsuresEqual(target);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_EnsuresEqualIEquatable_ShouldThrow_WhenValueIsNotDefaultAndTargetIs<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      T target = default!;
      var act = () => _ = value.EnsuresEqual(target);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void EqualExtensions_EnsuresEqualIEquatable_ShouldThrowWithExpectedDataDictionary_WhenValueDoesNotEqualTarget()
   {
      // Arrange.
      var value = UInt32.MinValue;
      var target = UInt32.MaxValue;
      var act = () => _ = value.EnsuresEqual(target);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.Equal);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
   }

   [Fact]
   public void EqualExtensions_EnsuresEqualIEquatable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueDoesNotEqualTarget()
   {
      // Arrange.
      var value = new BoxRecordData().EqualValue;
      var target = new BoxRecordData().NotEqualValue;
      var act = () => _ = value.EnsuresEqual(target);
      var expectedMessage = $"Postcondition Equal failed: {nameof(value)} must be equal to {target}";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_EnsuresEqualIEquatable_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = new Guid("75299d53-16e1-4969-acd8-840fc2f1f821");
      var target = new Guid("d0d5aa44-1eba-4878-8930-2c9fba8151cd");
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresEqual(target, messageTemplate);
      var expectedMessage = $"Requirement Equal failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_EnsuresEqualIEquatable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = SByte.MinValue;
      var target = SByte.MaxValue;
      var act = () => _ = value.EnsuresEqual(target, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition Equal failed: {nameof(value)} must be equal to {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_EnsuresEqualIEquatable_ShouldThrowCustomExceptionWithExpectedMessageWhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "asdf";
      var target = "qwerty";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresEqual(target, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement Equal failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

   #region EnsuresEqual (IEqualityComparer) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_EnsuresEqualIEqualityComparer_ShouldReturnOriginalValue_WhenValueEqualsTarget<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      var target = data.NotEqualValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.EnsuresEqual(target, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_EnsuresEqualIEqualityComparer_ShouldReturnOriginalValue_WhenAndTargetAreDefault<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      T value = default!;
      T target = default!;
      var comparer = EqualityComparer<T>.Default;

      // Act.
      var result = value.EnsuresEqual(target, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_EnsuresEqualIEqualityComparer_ShouldThrow_WhenValueDoesNotEqualTarget<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      var target = data.EqualValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.EnsuresEqual(target, comparer);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void EqualExtensions_EnsuresEqualIEqualityComparer_ShouldThrowWithExpectedDataDictionary_WhenValueDoesNotEqualTarget()
   {
      // Arrange.
      var value = 100M;
      var target = 100M;
      var comparer = new ReverseComparer<Decimal>();
      var act = () => _ = value.EnsuresEqual(target, comparer);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.Equal);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
   }

   [Fact]
   public void EqualExtensions_EnsuresEqualIEqualityComparer_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueDoesNotEqualTarget()
   {
      // Arrange.
      var value = true;
      var target = true;
      var comparer = new ReverseComparer<Boolean>();
      var act = () => _ = value.EnsuresEqual(target, comparer);
      var expectedMessage = $"Postcondition Equal failed: {nameof(value)} must be equal to {target}";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_EnsuresEqualIEqualityComparer_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = 'A';
      var target = 'A';
      var comparer = new ReverseComparer<Char>();
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresEqual(target, comparer, messageTemplate);
      var expectedMessage = $"Requirement Equal failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_EnsuresEqualIEqualityComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = new ObservationClassData().EqualValue;
      var target = new ObservationClassData().EqualValue;
      var comparer = new ReverseComparer<Observation>();
      var act = () => _ = value.EnsuresEqual(target, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition Equal failed: {nameof(value)} must be equal to {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_EnsuresEqualIEqualityComparer_ShouldThrowCustomExceptionWithExpectedMessageWhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = Int64.MaxValue;
      var target = Int64.MaxValue;
      var comparer = new ReverseComparer<Int64>();
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresEqual(target, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement Equal failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_EnsuresEqualIEqualityComparer_ShouldThrowArgumentNullException_WhenComparerIsNull()
   {
      // Arrange.
      var value = new DateTimeData().EqualValue;
      var target = value;
      IEqualityComparer<DateTime> comparer = null!;
      var act = () => _ = value.EnsuresEqual(target, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(comparer))
         .And.Message.Should().StartWith(Messages.ComparerIsNull);
   }

   #endregion

   #region EnsuresEqual (String) Tests
   // ==========================================================================
   // ==========================================================================

   [UseCulture("en-US")]
   [Theory]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.OrdinalIgnoreCase)]
   public void EqualExtensions_EnsuresEqualString_ShouldReturnOriginalValue_WhenValueEqualsTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresEqual(target, comparisonType);

      // Assert.
      result.Should().Be(value);
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
   public void EqualExtensions_EnsuresEqualString_ShouldReturnOriginalValue_WhenValueEqualsTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresEqual(target, comparisonType);

      // Assert.
      result.Should().Be(value);
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
   public void EqualExtensions_EnsuresEqualString_ShouldReturnOriginalValue_WhenValueEqualsTargetAndCurrentCultureIs_thTH(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.EnsuresEqual(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture("en-US")]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void EqualExtensions_EnsuresEqualString_ShouldReturnOriginalValue_WhenAndTargetAreDefaultAndCurrentCultureIs_enUS(StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String target = default!;

      // Act.
      var result = value.EnsuresEqual(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture("tr-TR")]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void EqualExtensions_EnsuresEqualString_ShouldReturnOriginalValue_WhenAndTargetAreDefaultAndCurrentCultureIs_trTR(StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String target = default!;

      // Act.
      var result = value.EnsuresEqual(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture("en-US")]
   [Theory]
   [InlineData(StringData.LowerCaseA, StringData.LowerCaseADash, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseA, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseI, StringData.UpperCaseDottedI, StringComparison.OrdinalIgnoreCase)]
   public void EqualExtensions_EnsuresEqualString_ShouldThrow_WhenValueDoesNotEqualTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      var act = () => _ = value.EnsuresEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [UseCulture("tr-TR")]
   [Theory]
   [InlineData(StringData.LowerCaseA, StringData.LowerCaseADash, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseA, StringData.LowerCaseADash, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseI, StringData.UpperCaseDottedI, StringComparison.OrdinalIgnoreCase)]
   public void EqualExtensions_EnsuresEqualString_ShouldThrow_WhenValueDoesNotEqualTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      var act = () => _ = value.EnsuresEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [UseCulture("th-TH")]
   [Theory]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseI, StringData.UpperCaseDottedI, StringComparison.OrdinalIgnoreCase)]
   public void EqualExtensions_EnsuresEqualString_ShouldThrow_WhenValueDoesNotEqualTargetAndCurrentCultureIs_thTH(
      String value,
      String target,
      StringComparison comparisonType)
   {
      var act = () => _ = value.EnsuresEqual(target, comparisonType);

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
   public void EqualExtensions_EnsuresEqualString_ShouldThrow_WhenValueIsDefaultAndTargetIsNotAndCurrentCultureIs_enUS(StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      var target = StringData.UpperCaseSlashedO;
      var act = () => _ = value.EnsuresEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [UseCulture("th-TH")]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void EqualExtensions_EnsuresEqualString_ShouldThrow_WhenValueIsDefaultAndTargetIsNotAndCurrentCultureIs_thTH(StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      var target = StringData.LowerCaseADash;
      var act = () => _ = value.EnsuresEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>();
   }

   [Fact]
   public void EqualExtensions_EnsuresEqualString_ShouldThrowWithExpectedDataDictionary_WhenValueDoesNotEqualTarget()
   {
      // Arrange.
      var value = StringData.LowerCaseDipthongAE;
      var target = StringData.UpperCaseEszett;
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.EnsuresEqual(target, comparisonType);

      // Act/assert.
      var ex = act.Should().Throw<PostconditionFailedException>().Which;

      ex.Data.Count.Should().Be(_stringDataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Postcondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.Equal);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void EqualExtensions_EnsuresEqualString_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenValueDoesNotEqualTarget()
   {
      // Arrange.
      var value = StringData.LowerCaseAE;
      var target = StringData.UpperCaseSlashedO;
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var act = () => _ = value.EnsuresEqual(target, comparisonType);
      var expectedMessage = $"Postcondition Equal failed: {nameof(value)} must be equal to {target}";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_EnsuresEqualString_ShouldThrowPostconditionFailedExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseAE;
      var target = StringData.UpperCaseSlashedO;
      var comparisonType = StringComparison.InvariantCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresEqual(target, comparisonType, messageTemplate);
      var expectedMessage = $"Requirement Equal failed";

      // Act/assert.
      act.Should().Throw<PostconditionFailedException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_EnsuresEqualString_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseDottedI;
      var target = StringData.LowerCaseJ;
      var comparisonType = StringComparison.InvariantCultureIgnoreCase;
      var act = () => _ = value.EnsuresEqual(target, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Postcondition Equal failed: {nameof(value)} must be equal to {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_EnsuresEqualString_ShouldThrowCustomExceptionWithExpectedMessageWhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseA;
      var target = StringData.UpperCaseZ;
      var comparisonType = StringComparison.CurrentCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.EnsuresEqual(target, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement Equal failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

   #region RequiresEqual (IEquatable) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_RequiresEqualIEquatable_ShouldReturnOriginalValue_WhenValueEqualsTarget<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      var target = data.EqualValue;

      // Act.
      var result = value.RequiresEqual(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_RequiresEqualIEquatable_ShouldReturnOriginalValue_WhenValueAndTargetAreDefault<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      T value = default!;
      T target = default!;

      // Act.
      var result = value.RequiresEqual(target);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_RequiresEqualIEquatable_ShouldThrow_WhenValueDoesNotEqualTarget<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      var target = data.NotEqualValue;
      var act = () => _= value.RequiresEqual(target);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_RequiresEqualIEquatable_ShouldThrow_WhenValueIsDefaultAndTargetIsNot<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      T value = default!;
      var target = data.NonDefaultNotEqualValue;
      var act = () => _ = value.RequiresEqual(target);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_RequiresEqualIEquatable_ShouldThrow_WhenValueIsNotDefaultAndTargetIs<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      T target = default!;
      var act = () => _ = value.RequiresEqual(target);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Fact]
   public void EqualExtensions_RequiresEqualIEquatable_ShouldThrowWithExpectedDataDictionary_WhenValueDoesNotEqualTarget()
   {
      // Arrange.
      var value = Single.Pi;
      var target = Single.E;
      var act = () => _ = value.RequiresEqual(target);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.Equal);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
   }

   [Fact]
   public void EqualExtensions_RequiresEqualIEquatable_ShouldThrowArgumentExceptionWithExpectedMessage_WhenValueDoesNotEqualTarget()
   {
      // Arrange.
      var value = new PointStructData().EqualValue;
      var target = new PointStructData().NotEqualValue;
      var act = () => _ = value.RequiresEqual(target);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition Equal failed: {nameof(value)} must be equal to {target}";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_RequiresEqualIEquatable_ShouldThrowArgumentExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = DateTimeOffset.MaxValue;
      var target = DateTimeOffset.MinValue;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresEqual(target, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement Equal failed";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_RequiresEqualIEquatable_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = TimeOnly.MinValue;
      var target = TimeOnly.MaxValue;
      var act = () => _ = value.RequiresEqual(target, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition Equal failed: {nameof(value)} must be equal to {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_RequiresEqualIEquatable_ShouldThrowCustomExceptionWithExpectedMessageWhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = "asdf";
      var target = "qwerty";
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresEqual(target, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement Equal failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion

   #region RequiresEqual (IEqualityComparer) Tests
   // ==========================================================================
   // ==========================================================================

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_RequiresEqualIEqualityComparer_ShouldReturnOriginalValue_WhenValueEqualsTarget<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      var target = data.NotEqualValue;
      var comparer = data.ReverseComparer;

      // Act.
      var result = value.RequiresEqual(target, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_RequiresEqualIEqualityComparer_ShouldReturnOriginalValue_WhenAndTargetAreDefault<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      T value = default!;
      T target = default!;
      var comparer = EqualityComparer<T>.Default;

      // Act.
      var result = value.RequiresEqual(target, comparer);

      // Assert.
      result.Should().Be(value);
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_RequiresEqualIEqualityComparer_ShouldThrow_WhenValueDoesNotEqualTarget<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      var target = data.EqualValue;
      var comparer = data.ReverseComparer;
      var act = () => _ = value.RequiresEqual(target, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_RequiresEqualIEqualityComparer_ShouldThrow_WhenValueIsDefaultAndTargetIsNot<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      T value = default!;
      var target = data.EqualValue;
      var comparer = EqualityComparer<T>.Default;
      var act = () => _ = value.RequiresEqual(target, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Theory]
   [ClassData(typeof(EquatableTypesTestData))]
   public void EqualExtensions_RequiresEqualIEqualityComparer_ShouldThrow_WhenValueIsNotDefaultAndTargetIs<T>(EquatableValue<T> data) where T : IEquatable<T>
   {
      // Arrange.
      var value = data.EqualValue;
      T target = default!;
      var comparer = EqualityComparer<T>.Default;
      var act = () => _ = value.RequiresEqual(target, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Fact]
   public void EqualExtensions_RequiresEqualIEqualityComparer_ShouldThrowWithExpectedDataDictionary_WhenValueDoesNotEqualTarget()
   {
      // Arrange.
      var value = nint.MinValue;
      var target = nint.MinValue;
      var comparer = new ReverseComparer<nint>();
      var act = () => _ = value.RequiresEqual(target, comparer);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_dataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.Equal);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
   }

   [Fact]
   public void EqualExtensions_RequiresEqualIEqualityComparer_ShouldThrowArgumentExceptionWithExpectedMessage_WhenValueDoesNotEqualTarget()
   {
      // Arrange.
      var value = BigInteger.MinusOne;
      var target = BigInteger.MinusOne;;
      var comparer = new ReverseComparer<BigInteger>();
      var act = () => _ = value.RequiresEqual(target, comparer);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition Equal failed: {nameof(value)} must be equal to {target}";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_RequiresEqualIEqualityComparer_ShouldThrowArgumentExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = UInt16.MaxValue;
      var target = UInt16.MaxValue;
      var comparer = new ReverseComparer<UInt16>();
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresEqual(target, comparer, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement Equal failed";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_RequiresEqualIEqualityComparer_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = Double.MaxValue;
      var target = Double.MaxValue;
      var comparer = new ReverseComparer<Double>();
      var act = () => _ = value.RequiresEqual(target, comparer, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition Equal failed: {nameof(value)} must be equal to {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_RequiresEqualIEqualityComparer_ShouldThrowCustomExceptionWithExpectedMessageWhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = DateTime.MaxValue;
      var target = DateTime.MaxValue;
      var comparer = new ReverseComparer<DateTime>();
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresEqual(target, comparer, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement Equal failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_RequiresEqualIEqualityComparer_ShouldThrowArgumentNullException_WhenComparerIsNull()
   {
      // Arrange.
      var value = Half.Pi;
      var target = Half.Tau;
      IEqualityComparer<Half> comparer = null!;
      var act = () => _ = value.RequiresEqual(target, comparer);

      // Act/assert.
      act.Should().Throw<ArgumentNullException>()
         .WithParameterName(nameof(comparer))
         .And.Message.Should().StartWith(Messages.ComparerIsNull);
   }

   #endregion

   #region RequiresEqual (String) Tests
   // ==========================================================================
   // ==========================================================================

   [UseCulture("en-US")]
   [Theory]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.LowerCaseAE, StringComparison.Ordinal)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.OrdinalIgnoreCase)]
   public void EqualExtensions_RequiresEqualString_ShouldReturnOriginalValue_WhenValueEqualsTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresEqual(target, comparisonType);

      // Assert.
      result.Should().Be(value);
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
   public void EqualExtensions_RequiresEqualString_ShouldReturnOriginalValue_WhenValueEqualsTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresEqual(target, comparisonType);

      // Assert.
      result.Should().Be(value);
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
   public void EqualExtensions_RequiresEqualString_ShouldReturnOriginalValue_WhenValueEqualsTargetAndCurrentCultureIs_thTH(
      String value,
      String target,
      StringComparison comparisonType)
   {
      // Act.
      var result = value.RequiresEqual(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture("en-US")]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void EqualExtensions_RequiresEqualString_ShouldReturnOriginalValue_WhenAndTargetAreDefaultAndCurrentCultureIs_enUS(StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String target = default!;

      // Act.
      var result = value.RequiresEqual(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture("tr-TR")]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void EqualExtensions_RequiresEqualString_ShouldReturnOriginalValue_WhenAndTargetAreDefaultAndCurrentCultureIs_trTR(StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      String target = default!;

      // Act.
      var result = value.RequiresEqual(target, comparisonType);

      // Assert.
      result.Should().Be(value);
   }

   [UseCulture("en-US")]
   [Theory]
   [InlineData(StringData.LowerCaseA, StringData.LowerCaseADash, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseAE, StringData.UpperCaseAE, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseA, StringData.UpperCaseAE, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseI, StringData.UpperCaseDottedI, StringComparison.OrdinalIgnoreCase)]
   public void EqualExtensions_RequiresEqualString_ShouldThrow_WhenValueDoesNotEqualTargetAndCurrentCultureIs_enUS(
      String value,
      String target,
      StringComparison comparisonType)
   {
      var act = () => _ = value.RequiresEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [UseCulture("tr-TR")]
   [Theory]
   [InlineData(StringData.LowerCaseA, StringData.LowerCaseADash, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseA, StringData.LowerCaseADash, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseI, StringData.UpperCaseDottedI, StringComparison.OrdinalIgnoreCase)]
   public void EqualExtensions_RequiresEqualString_ShouldThrow_WhenValueDoesNotEqualTargetAndCurrentCultureIs_trTR(
      String value,
      String target,
      StringComparison comparisonType)
   {
      var act = () => _ = value.RequiresEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [UseCulture("th-TH")]
   [Theory]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.CurrentCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.InvariantCulture)]
   [InlineData(StringData.LowerCaseI, StringData.UpperCaseDottedI, StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringData.LowerCaseDipthongAE, StringData.UpperCaseDipthongAE, StringComparison.Ordinal)]
   [InlineData(StringData.UpperCaseI, StringData.UpperCaseDottedI, StringComparison.OrdinalIgnoreCase)]
   public void EqualExtensions_RequiresEqualString_ShouldThrow_WhenValueDoesNotEqualTargetAndCurrentCultureIs_thTH(
      String value,
      String target,
      StringComparison comparisonType)
   {
      var act = () => _ = value.RequiresEqual(target, comparisonType);

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
   public void EqualExtensions_RequiresEqualString_ShouldThrow_WhenValueIsDefaultAndTargetIsNotAndCurrentCultureIs_enUS(StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      var target = StringData.UpperCaseSlashedO;
      var act = () => _ = value.RequiresEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [UseCulture("th-TH")]
   [Theory]
   [InlineData(StringComparison.CurrentCulture)]
   [InlineData(StringComparison.CurrentCultureIgnoreCase)]
   [InlineData(StringComparison.InvariantCulture)]
   [InlineData(StringComparison.InvariantCultureIgnoreCase)]
   [InlineData(StringComparison.Ordinal)]
   [InlineData(StringComparison.OrdinalIgnoreCase)]
   public void EqualExtensions_RequiresEqualString_ShouldThrow_WhenValueIsDefaultAndTargetIsNotAndCurrentCultureIs_thTH(StringComparison comparisonType)
   {
      // Arrange.
      String value = default!;
      var target = StringData.LowerCaseADash;
      var act = () => _ = value.RequiresEqual(target, comparisonType);

      // Act/assert.
      act.Should().Throw<ArgumentException>();
   }

   [Fact]
   public void EqualExtensions_RequiresEqualString_ShouldThrowWithExpectedDataDictionary_WhenValueDoesNotEqualTarget()
   {
      // Arrange.
      var value = StringData.LowerCaseDipthongAE;
      var target = StringData.UpperCaseEszett;
      var comparisonType = StringComparison.Ordinal;
      var act = () => _ = value.RequiresEqual(target, comparisonType);

      // Act/assert.
      var ex = act.Should().Throw<ArgumentException>().Which;

      ex.Data.Count.Should().Be(_stringDataCount);
      ex.Data[DataNames.RequirementType].Should().Be(RequirementType.Precondition);
      ex.Data[DataNames.RequirementName].Should().Be(RequirementNames.Equal);
      ex.Data[DataNames.Value].Should().Be(value);
      ex.Data[DataNames.ValueExpression].Should().Be(nameof(value));
      ex.Data[DataNames.Target].Should().Be(target);
      ex.Data[DataNames.TargetExpression].Should().Be(nameof(target));
      ex.Data[DataNames.StringComparison].Should().Be(comparisonType);
   }

   [Fact]
   public void EqualExtensions_RequiresEqualString_ShouldThrowArgumentExceptionWithExpectedMessage_WhenValueDoesNotEqualTarget()
   {
      // Arrange.
      var value = StringData.LowerCaseAE;
      var target = StringData.UpperCaseSlashedO;
      var comparisonType = StringComparison.OrdinalIgnoreCase;
      var act = () => _ = value.RequiresEqual(target, comparisonType);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Precondition Equal failed: {nameof(value)} must be equal to {target}";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_RequiresEqualString_ShouldThrowArgumentExceptionWithExpectedMessage_WhenCustomMessageTemplateIsUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseAE;
      var target = StringData.UpperCaseSlashedO;
      var comparisonType = StringComparison.InvariantCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresEqual(target, comparisonType, messageTemplate);
      var expectedParameterName = nameof(value);
      var expectedMessage = $"Requirement Equal failed";

      // Act/assert.
      act.Should().Throw<ArgumentException>()
         .WithParameterName(expectedParameterName)
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_RequiresEqualString_ShouldThrowCustomExceptionWithExpectedMessage_WhenCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.UpperCaseDottedI;
      var target = StringData.LowerCaseJ;
      var comparisonType = StringComparison.InvariantCultureIgnoreCase;
      var act = () => _ = value.RequiresEqual(target, comparisonType, exceptionFactory: TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Precondition Equal failed: {nameof(value)} must be equal to {target}";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   [Fact]
   public void EqualExtensions_RequiresEqualString_ShouldThrowCustomExceptionWithExpectedMessageWhenCustomMessageTemplateAndCustomExceptionFactoryIsUsed()
   {
      // Arrange.
      var value = StringData.LowerCaseA;
      var target = StringData.UpperCaseZ;
      var comparisonType = StringComparison.CurrentCulture;
      var messageTemplate = "Requirement {RequirementName} failed";
      var act = () => _ = value.RequiresEqual(target, comparisonType, messageTemplate, TestExceptionFactories.CustomExceptionFactory);
      var expectedMessage = $"Requirement Equal failed";

      // Act/assert.
      act.Should().Throw<CustomException>()
         .And.Message.Should().StartWith(expectedMessage);
   }

   #endregion
}
