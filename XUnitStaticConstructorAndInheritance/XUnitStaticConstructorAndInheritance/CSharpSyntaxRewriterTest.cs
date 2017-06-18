using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.CodeAnalysis.CSharp;
using static Microsoft.CodeAnalysis.CSharp.SyntaxFactory;
using NSubstituteAutoMocker;
using Xunit;

namespace XUnitStaticConstructorAndInheritance
{
    public abstract class CSharpSyntaxRewriterTest<T> where T : CSharpSyntaxRewriter
    {
        public static IEnumerable<SyntaxRewriterTestCase> TestCases { get; set; }

        public static IEnumerable<object[]> AvailableTestCases => TestCases.Select(testCase => new object[] { testCase });

        protected T Subject { get; }

        private readonly NSubstituteAutoMocker<T> _autoMock;

        protected CSharpSyntaxRewriterTest()
        {
            _autoMock = new NSubstituteAutoMocker<T>();
            Subject = _autoMock.ClassUnderTest;
        }

        [Theory]
        [CustomMemberData(nameof(AvailableTestCases))]
        public void Verify(SyntaxRewriterTestCase testCase)
        {
            var inputTree = ParseSyntaxTree(testCase.Input);
            var expectedResultTree = ParseSyntaxTree(testCase.ExpectedResult);

            var compilation = CSharpCompilation.Create("name", new[] {inputTree});

            var result = Subject.Visit(inputTree.GetRoot());

            inputTree.GetDiagnostics().Should().BeEmpty();
            expectedResultTree.GetDiagnostics().Should().BeEmpty();
            result.GetDiagnostics().Should().BeEmpty();
            result.ToFullString().Should().Be(expectedResultTree.GetRoot().ToFullString());
        }

        protected TDependency Get<TDependency>()
        {
            return _autoMock.Get<TDependency>();
        }
    }
}