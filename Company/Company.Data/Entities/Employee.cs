namespace Company.Data.Entities
{
    public class Employee : IEntity
    {
        public int Id { get; set; }
        [MaxLength(50), Required]
        public string? FirstName { get; set; }
        [MaxLength(50), Required]
        public string? LastName { get; set; }
        [Required]
        public bool? UnionMember { get; set; }
        [Required]
        public double? Salary { get; set; }
        public int DepartmentId { get; set; }
        public Department? Department { get; set; }
        public ICollection<Position>? Positions { get; set; }

    }
}
