using System.Collections.Generic;

namespace XUnitStaticConstructorAndInheritance
{
    public class InternalToPublicClassModifierSyntaxRewriterTests 
        : CSharpSyntaxRewriterTest<InternalToPublicClassModifierSyntaxRewriter>
    {
        static InternalToPublicClassModifierSyntaxRewriterTests()
        {
            TestCases = new List<SyntaxRewriterTestCase>
            {
                ReplacesInternalModifierWithPublic(),
                LeavesModifiersIntactWhenClassModifierPublic(),
                LeavesModifiersIntactWhenClassModifierProtected(),
            };
        }

        private static SyntaxRewriterTestCase ReplacesInternalModifierWithPublic()
        {
            return new SyntaxRewriterTestCase(nameof(ReplacesInternalModifierWithPublic), @"internal class Foo { }",
                "public class Foo { }");
        }

        private static SyntaxRewriterTestCase LeavesModifiersIntactWhenClassModifierPublic()
        {
            return new SyntaxRewriterTestCase(nameof(LeavesModifiersIntactWhenClassModifierPublic),
                @"public class Foo { }", "public class Foo { }");
        }

        private static SyntaxRewriterTestCase LeavesModifiersIntactWhenClassModifierProtected()
        {
            return new SyntaxRewriterTestCase(nameof(LeavesModifiersIntactWhenClassModifierProtected),
                @"protected class Foo { }", "protected class Foo { }");
        }
    }
}