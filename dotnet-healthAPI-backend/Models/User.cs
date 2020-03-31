using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_healthAPI_backend.Models
{
    public class User
    {
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string AvatarUrl { get; set; }
        public string Password { get; set; }
        public int  Rol { get; set; }

        public ICollection<UserSickness> UserSicknessUser { get; set; } = new List<UserSickness>();

        public ICollection<MedicalHistory> MedicalHistories { get; set; }
    }
}
