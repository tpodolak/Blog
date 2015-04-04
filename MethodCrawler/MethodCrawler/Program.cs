using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodCrawler
{
   internal class Program
    {
        public class FooClass
        {
            public FooClass()
            {
                this.X();
                this.Foo();
                this.Bar();
            }
 
            public void Foo(){}
 
            public void Bar()
            {
                this.Z();
                this.Foo();
            }
 
            public string X()
            {
                return null;
            }
 
            public void Y(){ }
 
            public void Z()
            {
                this.Y();
            }
        }
 
        public static void Main(string[] args)
        {
 
            Console.WriteLine("=== execution chain of Bar function no recursion ===");
            foreach (var s in MethodInvokerCrawler.GetMethods(typeof(FooClass).GetMethod("Bar")))
            {
                Console.WriteLine("{0}.{1}", s.DeclaringType.FullName, s.Name);
            }
 
            Console.WriteLine();
            Console.WriteLine("=== execution chain of Bar function with recursion ===");
            foreach (var s in MethodInvokerCrawler.GetMethods(typeof(FooClass).GetMethod("Bar"), true))
            {
                Console.WriteLine("{0}.{1}", s.DeclaringType.FullName, s.Name);
            }
 
            Console.WriteLine();
            Console.WriteLine("execution chain of FooClass default constructor no recursion");
            foreach (var s in MethodInvokerCrawler.GetMethods(typeof(FooClass).GetConstructors().Single()))
            {
                Console.WriteLine("{0}.{1}", s.DeclaringType.FullName, s.Name);
            }
 
            Console.WriteLine();
            Console.WriteLine("execution chain of FooClass default constructor with recursion");
            foreach (var s in MethodInvokerCrawler.GetMethods(typeof(FooClass).GetConstructors().Single(), true))
            {
                Console.WriteLine("{0}.{1}", s.DeclaringType.FullName, s.Name);
            }
 
            Console.ReadKey();
        }
    }
}
