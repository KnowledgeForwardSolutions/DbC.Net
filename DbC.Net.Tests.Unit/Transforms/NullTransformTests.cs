namespace DbC.Net.Tests.Unit.Transforms;

public class NullTransformTests
{
   #region Constructor Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void NullTransform_Constructor_ShouldCreateObject()
   {
      // Act.
      var sut = new NullTransform();

      // Assert.
      sut.Should().NotBeNull();
   }

   #endregion

   #region TransformValue Method Tests
   // ==========================================================================
   // ==========================================================================

   public static TheoryData<Object> NullValueData => new()
   {
      { (String)null! },
      { (Int32?)null! },
      { (List<String>)null! },
   };

   [Theory]
   [MemberData(nameof(NullValueData))]
   public void NullTransform_TransformValue_ShouldReturnOriginalValue_WhenValueIsNull(Object value)
   {
      // Arrange.
      var sut = new NullTransform();

      // Act.
      var transformedValue = sut.TransformValue(value);

      // Assert.
      transformedValue.Should().BeSameAs(value);
   }

   public static TheoryData<Object> NonNullValueData => new()
   {
      { "stringValue" },
      { 99 },
      { Double.Pi },
      { Enumerable.Range(1, 3).ToList() },
   };

   [Theory]
   [MemberData(nameof(NonNullValueData))]
   public void NullTransform_TransformValue_ShouldReturnOriginalValue_WhenValueIsNotNull(Object value)
   {
      // Arrange.
      var sut = new NullTransform();

      // Act.
      var transformedValue = sut.TransformValue(value);

      // Assert.
      transformedValue.Should().BeSameAs(value);
   }

   #endregion
}
