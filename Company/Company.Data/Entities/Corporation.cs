namespace Company.Data.Entities
{
    public class Corporation : IEntity
    {
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string? Name { get; set; }
        [Required]
        public int? OrgNumber { get; set; }
    }
}
