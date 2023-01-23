namespace Company.Data.Entities
{
    public class Department : IEntity
    {
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string? Name { get; set; }
        public int CorporationId { get; set; }
        public virtual Corporation? Corporation { get; set; }
    }
}
