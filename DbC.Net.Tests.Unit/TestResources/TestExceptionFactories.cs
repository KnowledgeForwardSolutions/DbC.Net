namespace DbC.Net.Tests.Unit.TestResources;

public static class TestExceptionFactories
{
    private static readonly Lazy<IExceptionFactory> _customExceptionFactory =
       new(() => new CustomExceptionFactory());

    public static IExceptionFactory CustomExceptionFactory => _customExceptionFactory.Value;

}
