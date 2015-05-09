using System;

namespace CSharp6FeaturesOverview
{
    public class User
    {
        public User Parent { get; set; }
        public DateTime MaxBirthDate { get; } = DateTime.Today;

        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateOfBirth { get; set; }

        public string DisplayName => $"{Surname + " " + Name}";

        public User()
        {
            MaxBirthDate = DateTime.Today.AddDays(1);
        }
    }
}