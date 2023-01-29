namespace DbC.Net.Tests.Unit.Transforms;

public class StandardTransformsTests
{
   #region AsteriskMaskTransform Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardTransforms_AsteriskMaskTransform_ShouldNotBeNull()
      => StandardTransforms.AsteriskMaskTransform.Should().NotBeNull();

   [Fact]
   public void StandardTransforms_AsteriskMaskTransform_ShouldApplyExpectedTransform()
   {
      // Arrange.
      var sut = StandardTransforms.AsteriskMaskTransform;
      var value = "password";
      var expected = "********";

      // Act.
      var result = sut.TransformValue(value);

      // Assert.
      result.Should().Be(expected);
   }

   #endregion

   #region FixedLengthTransform Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardTransforms_FixedLengthTransform_ShouldNotBeNull()
      => StandardTransforms.FixedLengthTransform.Should().NotBeNull();

   [Fact]
   public void StandardTransforms_FixedLengthTransform_ShouldApplyExpectedTransform()
   {
      // Arrange.
      var sut = StandardTransforms.FixedLengthTransform;
      var value = "This value is too long. Like really too long.";
      var expected = "This val";

      // Act.
      var result = sut.TransformValue(value);

      // Assert.
      result.Should().Be(expected);
   }

   #endregion

   #region DigitAsteriskMaskTransform Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardTransforms_DigitAsteriskMaskTransform_ShouldNotBeNull()
      => StandardTransforms.DigitAsteriskMaskTransform.Should().NotBeNull();

   [Fact]
   public void StandardTransforms_DigitAsteriskMaskTransform_ShouldApplyExpectedTransform()
   {
      // Arrange.
      var sut = StandardTransforms.DigitAsteriskMaskTransform;
      var value = "123-456-7890";
      var expected = "***-***-****";

      // Act.
      var result = sut.TransformValue(value);

      // Assert.
      result.Should().Be(expected);
   }

   #endregion

   #region NullTransform Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardTransforms_NullTransform_ShouldNotBeNull()
      => StandardTransforms.NullTransform.Should().NotBeNull();

   [Fact]
   public void StandardTransforms_NullTransform_ShouldApplyExpectedTransform()
   {
      // Arrange.
      var sut = StandardTransforms.NullTransform;
      var value = Double.Pi;

      // Act.
      var result = sut.TransformValue(value);

      // Assert.
      result.Should().Be(value);
   }

   #endregion

   #region PhiSensitiveTransform Tests
   // ==========================================================================
   // ==========================================================================

   [Fact]
   public void StandardTransforms_PhiSensitiveTransform_ShouldNotBeNull()
      => StandardTransforms.PhiSensitiveTransform.Should().NotBeNull();

   [Fact]
   public void StandardTransforms_PhiSensitiveTransform_ShouldApplyExpectedTransform()
   {
      // Arrange.
      var sut = StandardTransforms.PhiSensitiveTransform;
      var value = "111-222-3333";

      // Act.
      var result = sut.TransformValue(value);

      // Assert.
      result.Should().Be(StandardTransforms.PhiTransformValue);
   }

   #endregion
}
