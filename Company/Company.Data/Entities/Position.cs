namespace Company.Data.Entities
{
    public class Position : IEntity
    {
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string? Name { get; set; }
        public ICollection<Employee>? Employees { get; set; }

    }
}
