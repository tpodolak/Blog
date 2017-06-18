using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.CodeAnalysis.CSharp;
using NSubstituteAutoMocker;
using Xunit;

namespace XUnitMemberDataAndInheritance
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
            var inputTree = SyntaxFactory.ParseSyntaxTree(testCase.Input);

            var result = Subject.Visit(inputTree.GetRoot());

            inputTree.GetDiagnostics().Should().BeEmpty();
            result.GetDiagnostics().Should().BeEmpty();
            result.ToFullString().Should().Be(testCase.ExpectedResult);
        }

        protected TDependency Get<TDependency>()
        {
            return _autoMock.Get<TDependency>();
        }
    }
}