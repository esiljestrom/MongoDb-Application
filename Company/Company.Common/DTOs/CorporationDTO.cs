namespace Company.Common.DTOs
{
    public record CorporationDTO
    {
        public int Id { get; set; }
        public string? Name{ get; set; }
        public int? OrgNumber { get; set; }
    }
}
