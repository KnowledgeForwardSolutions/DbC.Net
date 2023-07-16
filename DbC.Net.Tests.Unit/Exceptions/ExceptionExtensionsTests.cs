namespace DbC.Net.Tests.Unit.Exceptions;

public class ExceptionExtensionsTests
{
    private static readonly Dictionary<string, object> _data = new() {
         { DataNames.RequirementType, RequirementType.Precondition },
         { DataNames.RequirementName, "SomeRequirement" } };

    [Fact]
    public void ExceptionExtensions_PopulateExceptionData_ShouldReturnUpdatedException_WhenAllValuesSupplied()
    {
        // Arrange.
        var ex = new Exception();

        // Act.
        var result = ex.PopulateExceptionData(_data);

        // Assert.
        result.Should().Be(ex);

        result.Data.Count.Should().Be(_data.Count);
        result.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
        result.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
    }

    [Fact]
    public void ExceptionExtensions_PopulateExceptionData_ShouldOverwriteExistingValue_WhenItemKeysMatch()
    {
        // Arrange.
        var ex = new Exception();
        ex.Data[DataNames.RequirementName] = "SomeOtherRequirement";

        // Act.
        var result = ex.PopulateExceptionData(_data);

        // Assert.
        result.Should().Be(ex);

        result.Data.Count.Should().Be(_data.Count);
        result.Data[DataNames.RequirementType].Should().Be(_data[DataNames.RequirementType]);
        result.Data[DataNames.RequirementName].Should().Be(_data[DataNames.RequirementName]);
    }

    [Fact]
    public void ExceptionExtensions_PopulateExceptionData_ShouldNotUpdate_WhenDataDictionaryIsEmpty()
    {
        // Arrange.
        var ex = new Exception();
        var data = new Dictionary<string, object>();

        // Act.
        var result = ex.PopulateExceptionData(data);

        // Assert.
        result.Should().Be(ex);

        result.Data.Count.Should().Be(0);
    }

    [Fact]
    public void ExceptionExtensions_PopulateExceptionData_ShouldThrowArgumentNullException_WhenExceptionIsNull()
    {
        // Arrange.
        Exception ex = null!;
        var act = () => _ = ex.PopulateExceptionData(_data);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(ex))
           .And.Message.Should().StartWith(Messages.ExceptionIsNull);
    }

    [Fact]
    public void ExceptionExtensions_PopulateExceptionData_ShouldThrowArgumentNullException_WhenDataDictionaryIsNull()
    {
        // Arrange.
        var ex = new Exception();
        Dictionary<string, object> data = null!;
        var act = () => _ = ex.PopulateExceptionData(data);

        // Act/assert.
        act.Should().ThrowExactly<ArgumentNullException>()
           .WithParameterName(nameof(data))
           .And.Message.Should().StartWith(Messages.DataDictionaryIsNull);
    }
}
