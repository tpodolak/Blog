namespace RunningAspNetCoreTogetherWithNancy.Contracts
{
    public class Variant
    {
        public Variant(string id, string productId, string name)
        {
            Id = id;
            ProductId = productId;
            Name = name;
        }

        public string Id { get; }

        public string ProductId { get; }

        public string Name { get; }
    }
}