using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.Models
{
    public class Sickness
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ScientificNotation { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public ICollection<UserSickness> UserSicknessSickness { get; set; } = new List<UserSickness>();

    }
}
