namespace XUnit.Api.Models
{
    public class Games
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int PermitedAge { get; set; }

        public Games(int id, string name, string description, decimal price, int permitedAge)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            PermitedAge = permitedAge;
        }

        public Games()
        {
        }
    }
}
