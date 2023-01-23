namespace Company.Data.Entities
{
    public class EmployeePosition : IReferenceEntity
    {
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public Employee? Employee { get; set; }
        public Position? Position { get; set; }
    }
}
