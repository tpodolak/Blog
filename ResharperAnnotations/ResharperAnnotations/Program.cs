using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using JetBrains.Annotations;

namespace ResharperAnnotations
{
    class Program
    {
        private string _fooProperty;

        static void Main( string[] args )
        {

            List<Action> actionList = new List<Action>();

            Console.WriteLine("FOR");
            for (int i = 0; i < 10; i++)
            {
                int i1 = i;
                actionList.Add(() => Console.WriteLine(i1));
            }


            actionList.ForEach(x => x.Invoke());

            Console.WriteLine("Foreach");
            actionList.Clear();

            foreach (var i in Enumerable.Range(0, 10))
            {
                actionList.Add(() => Console.WriteLine(i));
            }
            actionList.ForEach(x => x.Invoke());


            Console.ReadKey();

//            List<object> objlList = new List<object>();
//            var result = objlList.SingleOrDefault();
//            Console.WriteLine(result.GetHashCode());

        }

        [StringFormatMethod( "format" )]
        private static string LogError( string format, params object[] args )
        {
            return string.Format( format, args );
        }


        private static void AddScriptBundle( [PathReferenceAttribute] string path )
        {
            //some logick
        }

        private static void Call()
        {
            AddScriptBundle("App.config");
        }




        [CanBeNull]
        private static object Foo()
        {
            return null;
        }


        public string FooProperty
        {
            
            get { return _fooProperty; }
            set
            {
                System.Object
                _fooProperty = value;
                NotifyPropertyChange("FooPropertyy");
            }
        }

        [NotifyPropertyChangedInvocator]
        protected virtual void NotifyPropertyChange(string propertyName)
        {
            
        }
       
    }
}
