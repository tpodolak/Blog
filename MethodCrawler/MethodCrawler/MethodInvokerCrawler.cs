using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using ClrTest.Reflection;

namespace MethodCrawler
{
    public static class MethodInvokerCrawler
    {
        public const string DefaultPrefix = "MethodCrawler";


        public static IEnumerable<MethodBase> GetMethods(MethodBase caller, bool recursive = false, string namespacePrefix = DefaultPrefix)
        {
            ILReader reader = new ILReader(caller);
            foreach (InlineMethodInstruction method in
                reader.OfType<InlineMethodInstruction>())
            {

                yield return method.Method;
                if (recursive && method.Method.DeclaringType != null && method.Method.DeclaringType.FullName.StartsWith(namespacePrefix, StringComparison.InvariantCultureIgnoreCase))
                {
                    foreach (var innerMethod in GetMethods(method.Method))
                    {
                        yield return innerMethod;
                    }
                }
            }
        }
    }
}