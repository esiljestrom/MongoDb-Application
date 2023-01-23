﻿namespace Company.Common.DTOs
{
    public record DepartmentDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CorporationId { get; set; }
    }
}
