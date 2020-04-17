namespace RunningAspNetCoreTogetherWithNancy.Contracts
{
    public class Product
    {
        public Product(string id, string name)
        {
            Id = id;
            Name = name;
        }

        public string Id { get; }

        public string Name { get; }
    }
}