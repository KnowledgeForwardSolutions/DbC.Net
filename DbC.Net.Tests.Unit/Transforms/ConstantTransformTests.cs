namespace DbC.Net.Tests.Unit.Transforms;

public class ConstantTransformTests
{
   private const String _constantValue = "PHI Sensitive Value";

   #region Constructor Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void ConstantTransform_Constructor_ShouldCreateObject_WhenAllValuesSupplied()
   {
      // Act.
      var sut = new ConstantTransform(_constantValue);

      // Assert.
      sut.Should().NotBeNull();
      sut.ConstantValue.Should().Be(_constantValue);
   }

   [Fact]
   public void ConstantTransform_Constructor_ShouldThrowArgumentNullException_WhenBaseTransformIsNull()
   {
      // Arrange.
      Object constantValue = null!;
      var act = () => _ = new ConstantTransform(constantValue);

      // Act/assert.
      act.Should().ThrowExactly<ArgumentNullException>()
         .WithParameterName(nameof(constantValue))
         .And.Message.Should().StartWith(Messages.ConstantValueIsNull);
   }

   #endregion

   #region TransformValue Method Tests
   // ==========================================================================
   // ==========================================================================

   public static TheoryData<Object> ConstantTransformTestData => new()
   {
      { (String)null! },
      { (Int32?)null! },
      { (Exception)null! },
      { "stringValue" },
      { 99 },
      { Double.Pi },
      { Enumerable.Range(1, 3).ToList() },
   };

   [Theory]
   [MemberData(nameof(ConstantTransformTestData))]
   public void ConstantTransform_TransformValue_ShouldAlwaysReturnConstantValue(Object value)
   {
      // Arrange.
      var sut = new ConstantTransform(_constantValue);

      // Act.
      var transformedValue = sut.TransformValue(value);

      // Assert.
      transformedValue.Should().Be(sut.ConstantValue);
   }

   #endregion
}
