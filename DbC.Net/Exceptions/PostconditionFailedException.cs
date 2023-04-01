namespace DbC.Net.Exceptions;

/// <summary>
///   Exception thrown when a DbC.Net Ensures... requirement fails.
/// </summary>
public sealed class PostconditionFailedException : Exception
{
    /// <summary>
    ///   Initialize a new <see cref="PostconditionFailedException"/> with the
    ///   supplied <paramref name="message"/>.
    /// </summary>
    /// <param name="message">
    ///   Message that describes the failed requirement.
    /// </param>
    public PostconditionFailedException(string? message = null)
       : base(message) { }
}
