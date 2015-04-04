using System;
using System.ComponentModel;

namespace NotifyPropertyChangedCallerMemberName
{
    class Program
    {
        static void Main(string[] args)
        {
            // Extracted property names will be visible on console
            var lambdaViewModel = new MainViewModelLambda();
            var callerMemberNameViewModel = new MainViewModelCallerMemberName();

            lambdaViewModel.PropertyChanged += HandleOnPropertyChanged;
            callerMemberNameViewModel.PropertyChanged += HandleOnPropertyChanged;

            lambdaViewModel.LambdaViewModel = "Lambda ViewModel";
            callerMemberNameViewModel.CallerMemberNameViewModel = "CallerMemberName ViewModel";
            Console.ReadKey();

        }

        static void HandleOnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Console.WriteLine(e.PropertyName);
        }
    }
}
