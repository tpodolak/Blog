namespace XUnitMemberDataAndInheritance
{
    public class SyntaxRewriterTestCase
    {
        public SyntaxRewriterTestCase(string name, string input, string expectedResult)
        {
            Name = name;
            Input = input;
            ExpectedResult = expectedResult;
        }

        public string Name { get; }

        public string Input { get; }

        public string ExpectedResult { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}