﻿namespace JobSearch.BLL.DTO
{
    public class VacancyResponse
    {
        public int Id { get; set; }

        public string? Fname { get; set; }

        public string? Lname { get; set; }

        public byte[]? Resume { get; set; }

        public string? CoverLetter { get; set; }

        public int? VacancyId { get; set; }
    }
}