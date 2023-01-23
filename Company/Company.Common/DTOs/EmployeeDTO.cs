namespace Company.Common.DTOs
{
    public record EmployeeDTO
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public bool? UnionMember { get; set; }
        public double? Salary { get; set; }
        public int DepartmentId { get; set; }
    }
}
