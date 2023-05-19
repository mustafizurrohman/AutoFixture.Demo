using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using FluentAssertions;

namespace AutoFixture.Demo.Core.ExtensionMethods.FluentAssertions;

public static class DirectoryInfoAssertionsExtensions
{
    public static DirectoryInfoAssertions Should(this DirectoryInfo instance)
    {
        return new DirectoryInfoAssertions(instance);
    }
}

public class DirectoryInfoAssertions :
    ReferenceTypeAssertions<DirectoryInfo, DirectoryInfoAssertions>
{
    public DirectoryInfoAssertions(DirectoryInfo instance)
        : base(instance)
    {
    }

    protected override string Identifier => "directory";

    public AndConstraint<DirectoryInfoAssertions> ContainFile(
        string filename, string because = "", params object[] becauseArgs)
    {
        Execute.Assertion
            .BecauseOf(because, becauseArgs)
            .ForCondition(!string.IsNullOrEmpty(filename))
            .FailWith("You can't assert a file exist if you don't pass a proper name")
            .Then
            .Given(() => Subject.GetFiles())
            .ForCondition(files => files.Any(fileInfo => fileInfo.Name.Equals(filename)))
            .FailWith("Expected {context:directory} to contain {0}{reason}, but found {1}.",
                _ => filename, files => files.Select(file => file.Name));

        return new AndConstraint<DirectoryInfoAssertions>(this);
    }
}
