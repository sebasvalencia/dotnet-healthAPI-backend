using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.DTO
{
    public class SicknessDTO
    {
        public SicknessDTO(int id, string name, string scientificNotation, string description, string imageUrl)
        {
            Id = id;
            Name = name;
            ScientificNotation = scientificNotation;
            Description = description;
            ImageUrl = imageUrl;
        }

        public SicknessDTO() { }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ScientificNotation { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
