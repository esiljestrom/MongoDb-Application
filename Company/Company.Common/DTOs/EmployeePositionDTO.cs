namespace Company.Common.DTOs
{
    public record EmployeePositionDTO
    {
        public int EmployeeId { get; set; }
        public int PositionId { get; set; }
        public EmployeePositionDTO(int employeeId, int positionId)
        {
            EmployeeId = employeeId;
            PositionId = positionId;
        }
    }
}
