using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Console;
namespace CSharp6FeaturesOverview
{
    class Program
    {
        static void Main(string[] args)
        {
            InterpolateString();
            IndexerInitializer();
            NullConditionalOperator();
            NameOfExpression();
            ExceptionFilters();
            ExceptionAsync().Wait();
            WriteLine("Using static System.Console");
            Read();
        }

        private static async Task<User> ExceptionAsync()
        {
            var viewModel = new UserListViewModel();
            return await viewModel.SaveUserAsync(new User());
        }

        private static void ExceptionFilters()
        {
            var viewModel = new UserListViewModel();
            viewModel.SaveUser(new User());
        }

        private static void NullConditionalOperator()
        {
            var user = new User
            {
                Parent = CreateDefaultUser()
            };
            WriteLine(user.Parent?.Name[0]);
            WriteLine(user.Parent?.Parent?.Name);
            var viewModel = new UserListViewModel();
            viewModel.AddUser(user);
        }

        private static void NameOfExpression()
        {
            var viewModel = new UserListViewModel();
            viewModel.RemoveUser(null);
        }

        private static void IndexerInitializer()
        {
            // before C#6
            var userDict = new Dictionary<string, User>
            {
                {"1", CreateDefaultUser()},
                {"2", CreateDefaultUser()}
            };
            // now
            userDict = new Dictionary<string, User>
            {
                ["1"] = CreateDefaultUser(),
                ["2"] = CreateDefaultUser(),
            };
        }

        private static void InterpolateString()
        {
            var user = CreateDefaultUser();

            WriteLine($"{user.Name}" + $" {user.Surname}");

            WriteLine($"{user.Name + " " + user.Surname}");

            WriteLine($"{user.Name + user.Surname} " + $"{user.DateOfBirth:yyyy-m-d dddd}");
        }


        private static User CreateDefaultUserOld()
        {
            return new User { Name = "John", Surname = "Kowalski", DateOfBirth = DateTime.Today };
        }

        private static User CreateDefaultUser() => new User { Name = "John", Surname = "Kowalski", DateOfBirth = DateTime.Today };

        private static User CreateCustomUser(string name) => new User { Name = name, Surname = "Kowalski", DateOfBirth = DateTime.Today };
    }
}
